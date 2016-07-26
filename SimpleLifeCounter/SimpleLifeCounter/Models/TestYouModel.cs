using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLifeCounter.Models
{
    class TestYouModel
    {
        public string SomeMethod(string s1, string s2)
        {
            if (s1.Length < s2.Length)
                return $"{s1} < {s2}";
            else if (s1.Length == s2.Length)
                return $"{s1} = {s2}";
            else
                return $"{s1} > {s2}";
        }
    }
}
