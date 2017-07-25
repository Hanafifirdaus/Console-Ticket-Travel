using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lat2
{
    class Perhitungan
    {

        public double Tambah(double input1, double input2)
        {
            return input1 + input2;
        }

        public double Kali(double input1, double input2)
        {
            return input1 * input2;
        }

        public string UppercaseFirst(string s)
        {
            // Check for empty string.
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
