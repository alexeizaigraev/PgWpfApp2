using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2
{
    internal class WinTerm : PgBase
    {
        public static List<string> GetDep(string dep)
        {

            return TermGetOne(dep);

        }


    }
}
