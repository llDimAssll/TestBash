using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autoriz
{
    public class Service
    {
        public static int Verification(string login, string password)
        {
            if (login == "admin")
            {
                if (password == "admin") return 1;
                else return 2;
            }
            return 0;
        }
    }
}
