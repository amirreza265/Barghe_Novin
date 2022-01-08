using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BargheNovin.Core.Attributes
{
    public class FileMaxSizeAttribute : ValidationAttribute
    {
        public long Size { get; set; }

        public override bool IsValid(object value)
        {
            IFormFile file = (IFormFile)value;

            if (file == null)
                return true;

            if (file.Length > Size)
                return false;

            return true;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture,
                       ErrorMessageString, name, String.Format("{0:0.00}", ((float)this.Size / 1024f / 1024f)) + " MB");
        }
    }
}