using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Text
{
    public static class TextEdit
    {
        public static string FomatEmail(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
