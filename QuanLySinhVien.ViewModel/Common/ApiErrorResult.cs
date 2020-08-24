using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien.ViewModel.Common
{
    public class ApiErrorResult<T> : ApiResult<T>
    {
        private IEnumerable<IdentityError> errors;

        public T ValidationErrors { get; set; }

        public ApiErrorResult()
        {
        }

        public ApiErrorResult(string message)
        {
            IsSuccessed = false;
            Message = message;
        }

        public ApiErrorResult(T validationErrors)
        {
            IsSuccessed = false;
            ValidationErrors = validationErrors;
        }

    }
}
