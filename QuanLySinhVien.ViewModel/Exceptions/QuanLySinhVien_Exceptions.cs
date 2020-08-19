using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Exceptions
{
    public class QuanLySinhVien_Exceptions : Exception
    {
        public QuanLySinhVien_Exceptions()
        {
        }

        public QuanLySinhVien_Exceptions(string message)
            : base(message)
        {
        }

        public QuanLySinhVien_Exceptions(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
