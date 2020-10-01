using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace collection
{
    class CName
    {
        public string Name;
        public string Family;
        public CName()
        {
        }
        public CName(string name, string family)
        {
            Name = name;
            Family = family;
        }
        public CName(CName ToCopy)
        {
            Name = ToCopy.Name;
            Family = ToCopy.Family;
        }
    }
}
