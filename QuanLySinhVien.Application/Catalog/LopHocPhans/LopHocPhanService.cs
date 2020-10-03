using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.Data.EF;
using QuanLySinhVien.Data.Entities;
using QuanLySinhVien.Data.Enums;
using QuanLySinhVien.ViewModel.Catalog.LopHocPhans;
using QuanLySinhVien.ViewModel.Common;
using QuanLySinhVien.ViewModel.Exceptions;

namespace QuanLySinhVien.Service.Catalog.LopHocPhans
{
    public class LopHocPhanService : ILopHocPhanService, IScheduleService
    {
        private readonly QLSV_DBContext _context;

        public LopHocPhanService(QLSV_DBContext context)
        {
            _context = context;
        }

        public async Task<string> Create(LopHocPhanCreateRequest request)
        {
            //STT mặc định là 1
            //STT = số thứ tự cuối cùng học kì năm đó + 1
            int soThuTu = 1;
            var sttCuoiCung = _context.LopHocPhans
                                    .Where(x => x.HK_NamHoc == request.HK_NamHoc)
                                    .Where(x => x.HK_HocKy == request.HK_HocKy)
                                    .Where(x => x.ID_MonHoc == request.ID_MonHoc)
                                    .Select(x => x.SoThuTu)
                                    .ToArray()
                                    .LastOrDefault();
            soThuTu += sttCuoiCung;

            //Lấy năm hiện tại
            string namHoc = request.HK_NamHoc.ToString();
            //Lấy 2 số cuối của năm
            string namHoc_2SoCuoi = namHoc.Substring(namHoc.Length - 2);

            //Lấy học kỳ hiện tại
            string hocKy = request.HK_HocKy.ToString();

            //Lấy số thứ tự 
            string stt = soThuTu.ToString().PadLeft(2, '0');

            //Lấy ID môn học
            string Id_MonHoc = request.ID_MonHoc;

            //Ghép chuỗi tạo ID => 201INT00101
            string ID_LopHocPhan = namHoc_2SoCuoi + hocKy + Id_MonHoc + stt;

            var lopHocPhan = new LopHocPhan()
            {
                ID = ID_LopHocPhan,
                SoThuTu = soThuTu,
                ID_MonHoc = Id_MonHoc,
                ID_GiangVien = request.ID_GiangVien,
                IsActive = Status.Active,
                HK_HocKy = request.HK_HocKy,
                HK_NamHoc = request.HK_NamHoc,
                ID_Phong = request.ID_Phong,
                BuoiHoc = request.BuoiHoc,
                NgayHoc = request.NgayHoc
            };

            _context.LopHocPhans.Add(lopHocPhan);
            await _context.SaveChangesAsync();

            return lopHocPhan.ID;
        }

        public async Task<int> Delete(string id)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);

            if (lopHocPhan == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            _context.LopHocPhans.Remove(lopHocPhan);
            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<LopHocPhanViewModel>> GetAllPaging(LopHocPhanManagePagingRequest request)
        {
            var query = from lhp
                        in _context.LopHocPhans
                        select new { lhp };

            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(
                    x => x.lhp.ID_GiangVien.Contains(request.Keyword)
                    || x.lhp.ID.Contains(request.Keyword)
                    || x.lhp.ID_MonHoc.Contains(request.Keyword));
            }

            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new LopHocPhanViewModel()
                {
                    ID = x.lhp.ID,
                    BuoiHoc = x.lhp.BuoiHoc,
                    NgayHoc = x.lhp.NgayHoc,
                    ID_GiangVien = x.lhp.ID_GiangVien,
                    ID_MonHoc = x.lhp.ID_MonHoc,
                    ID_Phong = x.lhp.ID_Phong,
                    HK_HocKy = x.lhp.HK_HocKy,
                    HK_NamHoc = x.lhp.HK_NamHoc,

                }).ToListAsync();

            var pagedResult = new PagedResult<LopHocPhanViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = request.PageIndex,
                PageSize = request.PageSize,
                Items = data
            };
            return pagedResult;
        }

        public async Task<LopHocPhanViewModel> GetById(string id)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);

            if (lopHocPhan == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            var giangVien =  _context.GiangViens.Where(x => x.ID == lopHocPhan.ID_GiangVien).FirstOrDefault();

            var lopHocPhanViewModel = new LopHocPhanViewModel()
            {
                ID = lopHocPhan.ID,
                BuoiHoc = lopHocPhan.BuoiHoc,
                NgayHoc = lopHocPhan.NgayHoc,
                ID_GiangVien = lopHocPhan.ID_GiangVien,
                ID_MonHoc = lopHocPhan.ID_MonHoc,
                ID_Phong = lopHocPhan.ID_Phong,
                HK_HocKy = lopHocPhan.HK_HocKy,
                HK_NamHoc = lopHocPhan.HK_NamHoc,
                GiangVien = giangVien
            };
            return lopHocPhanViewModel;
        }

        public async Task<int> Update(string id, LopHocPhanUpdateRequest request)
        {
            var lopHocPhan = await _context.LopHocPhans.FindAsync(id);

            if (lopHocPhan == null)
            {
                throw new QuanLySinhVien_Exceptions($"Không thể tìm thấy: {id}");
            }

            lopHocPhan.BuoiHoc = request.BuoiHoc;
            lopHocPhan.NgayHoc = request.NgayHoc;
            lopHocPhan.ID_Phong = request.ID_Phong;
            lopHocPhan.ID_GiangVien = request.ID_GiangVien;


            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResult<LopHocPhanViewModel>> GetSchedule(LopHocPhanManagePagingRequest request)
        {
            var query = from lhp in _context.LopHocPhans
                        join mh in _context.MonHocs on lhp.ID_MonHoc equals mh.ID
                        join gv in _context.GiangViens on lhp.ID_GiangVien equals gv.ID
                        orderby lhp.ID
                        select new { lhp, mh, gv };


            query = query.Where(
                x => x.lhp.HK_HocKy.Equals(request.HocKy)
                && x.lhp.HK_NamHoc.Equals(request.NamHoc));


            int totalRow = await query.CountAsync();

            var lopHocPhans = await query
                .Select(x => new LopHocPhanViewModel()
                {
                    ID = x.lhp.ID,
                    BuoiHoc = x.lhp.BuoiHoc,
                    NgayHoc = x.lhp.NgayHoc,
                    ID_GiangVien = x.lhp.ID_GiangVien,
                    ID_MonHoc = x.lhp.ID_MonHoc,
                    ID_Phong = x.lhp.ID_Phong,
                    HK_HocKy = x.lhp.HK_HocKy,
                    HK_NamHoc = x.lhp.HK_NamHoc,
                    MonHoc = x.mh,
                    GiangVien = x.gv
                }).ToListAsync();

            var pagedResult = new PagedResult<LopHocPhanViewModel>()
            {
                TotalRecords = totalRow,
                PageIndex = 1,
                PageSize = 1000,
                Items = lopHocPhans
            };
            return pagedResult;
        }

        public async Task<int> Schedule(ScheduleRequest request)
        {
            //Lấy toàn bộ những lớp học phần theo học kỳ & năm học
            var lopHocPhans = _context.LopHocPhans.Where(
                x => x.HK_HocKy.Equals(request.HocKy)
                && x.HK_NamHoc.Equals(request.NamHoc))
                .ToList();

            //Tạo biến random để random buổi & ngày học
            Random random = new Random();

            //Random ngày học và buổi học của lớp đầu tiên
            int randomBuoiHoc = random.Next(1, 3);
            lopHocPhans[0].BuoiHoc = RandomBuoiHoc(randomBuoiHoc);
            int randomNgayHoc = random.Next(2, 8);
            lopHocPhans[0].NgayHoc = RandomNgayHoc(randomNgayHoc);

            //Tạo danh sách lớp học phần đã tạo lịch thành công
            var scheduledLopHocPhan = new List<LopHocPhan>();
            scheduledLopHocPhan.Add(lopHocPhans[0]);

            for (int current = 1; current < lopHocPhans.Count(); current++)
            {
                //Kiểm tra giảng viên tại row hiện tại có tồn tại trong list đã sắp xếp chưa, và kiểm tra gv có bận buổi dạy đó chưa
                //true là đã bận
                bool checkGiangVien = true;

                //Kiểm tra phòng học tại row hiện tại có tồn tại trong list đã sắp xếp chưa, và kiểm tra phòng đã có lớp khác sự dụng không
                //true là đã bận
                bool checkPhong = true;

                //Điều kiện ngừng lặp
                int loopCount = 1;

                //Nếu giảng viên hoặc phòng học tại row hiện tại đã bận, random 1 buổi khác
                //loopCount = lặp qua số lượng phòng được request * 21 buổi để tìm buổi trống
                while ((checkGiangVien || checkPhong) && loopCount <= request.RoomCount*21)
                {
                    //Random ngày học và buổi học cho row hiện tại
                    int randomBuoi = random.Next(1, 4);
                    lopHocPhans[current].BuoiHoc = RandomBuoiHoc(randomBuoi);
                    int randomNgay = random.Next(2, 9);
                    lopHocPhans[current].NgayHoc = RandomNgayHoc(randomNgay);

                    //Kiểm tra giảng viên tại row hiện tại có tồn tại trong list đã sắp xếp chưa, và kiểm tra gv có bận buổi dạy đó chưa
                    checkGiangVien = scheduledLopHocPhan.Any(
                            x => x.ID_GiangVien == lopHocPhans[current].ID_GiangVien
                            && x.BuoiHoc == lopHocPhans[current].BuoiHoc
                            && x.NgayHoc == lopHocPhans[current].NgayHoc);

                    //Random phòng mới cho ngày học của row hiện tại
                    var listPhong = _context.Phongs.ToList();
                    var randomPhong = random.Next(request.RoomCount);
                    lopHocPhans[current].ID_Phong = listPhong[randomPhong].ID;

                    //Kiểm tra phòng học tại row hiện tại có tồn tại trong list đã sắp xếp chưa, và kiểm tra phòng đã có lớp khác sự dụng không
                    checkPhong = scheduledLopHocPhan.Any(
                            x => x.ID_Phong == lopHocPhans[current].ID_Phong
                            && x.BuoiHoc == lopHocPhans[current].BuoiHoc
                            && x.NgayHoc == lopHocPhans[current].NgayHoc);

                    loopCount++;
                }


                //Thêm lớp học phần vào list cần check
                scheduledLopHocPhan.Add(lopHocPhans[current]);
            }

            return await _context.SaveChangesAsync();
        }

        public BuoiHoc RandomBuoiHoc(int randomBuoiHoc)
        {
            BuoiHoc buoiHoc = BuoiHoc.Sang;
            switch (randomBuoiHoc)
            {
                case 1:
                    buoiHoc = BuoiHoc.Sang;
                    break;
                case 2:
                    buoiHoc = BuoiHoc.Chieu;
                    break;
                case 3:
                    buoiHoc = BuoiHoc.Toi;
                    break;
            }
            return buoiHoc;
        }

        public NgayHoc RandomNgayHoc(int randomNgayHoc)
        {
            NgayHoc ngayHoc = NgayHoc.Thu2;
            switch (randomNgayHoc)
            {
                case 2:
                    ngayHoc = NgayHoc.Thu2;
                    break;
                case 3:
                    ngayHoc = NgayHoc.Thu3;
                    break;
                case 4:
                    ngayHoc = NgayHoc.Thu4;
                    break;
                case 5:
                    ngayHoc = NgayHoc.Thu5;
                    break;
                case 6:
                    ngayHoc = NgayHoc.Thu6;
                    break;
                case 7:
                    ngayHoc = NgayHoc.Thu7;
                    break;
                case 8:
                    ngayHoc = NgayHoc.ChuNhat;
                    break;
            }
            return ngayHoc;
        }
    }
}
