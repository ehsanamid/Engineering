using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CName> namelist = new List<CName>();
            namelist.Add(new CName("N1", "F1"));
            namelist.Add(new CName("N2", "F2"));
            namelist.Add(new CName("N3", "F3"));
            CName c0 = new CName(namelist[0]);
            //c0 = namelist[0];
            c0.Name = "N11";
            c0.Family = "F11";

            CName c1 ;
            c1 = namelist[1];
            c1.Name = "N21";
            c1.Family = "F21";

        }
    }
}
