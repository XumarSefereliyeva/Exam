using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImtahanProyekt.BL.Exceptions
{
    public class TeamException : Exception
    {
        public TeamException():base("Default message")
        {
            
        }
        public TeamException(string errormessage):base(errormessage) 
        {
            
        }
    }
}
