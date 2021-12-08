using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2
{
    internal class ExternProcess : Papa
    {
        internal static void RefresFromAccessAll()
        {

            string appPath = FileToVec("Config/SharpForPyPath.txt")[0];
            StartProcess(appPath);
            //StartProcess(@"C:\Users\a.zaigraev\source\repos\EXTERN\SharpForPy\bin\Release\SharpForPy.exe");
            PgBase.RefreshPg();
            //StartProcess(@"C:\Users\Alex\source\repos\alexeizaigraev\WpfApp3\bin\Release\WpfApp3.exe");
        }


        internal static void RefresFromAccessOtbor()
        {
            StartProcess(@"C:\Users\a.zaigraev\source\repos\EXTERN\SharpForPyLite\bin\Release\SharpForPyLite.exe");
            PgBase.RefreshPg();
        }

        internal static void OtborToAccess()
        {
            /*
            OtborDb.MainOtborDb();
            StartProcess(@"C:\Users\a.zaigraev\source\repos\EXTERN\SharpForPyOtbor\bin\Release\SharpForPyOtbor.exe");
            RefresFromAccessOtbor();
            PgBase.RefreshPg();
            */
        }


        internal static void OtborToAccessHard()
        {
            OtborHard.MainOtborHard();
            StartProcess(@"C:\Users\a.zaigraev\source\repos\alexeizaigraev\SharpForPyOtbor\bin\Release\SharpForPyOtbor.exe");
            RefresFromAccessOtbor();
            PgBase.RefreshPg();
        }

    }
}
