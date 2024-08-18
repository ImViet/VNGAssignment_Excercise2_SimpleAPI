using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VNGAssignment.Contracts.Validators
{
    public static class CommonValidator
    {
        public static bool ContainLetters(string title)
        {
            return !string.IsNullOrEmpty(title) && title.Any(char.IsLetter);
        }
    }
}
