using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2
{
    internal class Actual : PgBase
    {
        internal static void OtborToActua()
        {
            #region

            var otbor = OtborGet();

            foreach (var line in otbor)
            {
                var dep = line[1];
                var data = DepGetOne(dep);
                try
                {
                    DepDelOneNew(dep);
                }
                catch { }
                try
                {
                    DepAddOneNew(data);
                    info += $"+ dep new {dep}\n";
                }
                catch (Exception ex) { SayRed(ex.Message); }

            }

            TermNewAddCascad();
            #endregion
        }

        internal static void RefreshActual()
        {
            #region
            DepNewClear();
            var data = DepGet();
            foreach (var line in data)
            {
                try { DepAddOneNew(line); }
                catch (Exception ex) { SayRed(ex.Message); }
            }

            TermNewClear();
            data = TermGet();
            foreach (var line in data)
            {
                try { TermAddOneNew(line); }
                catch (Exception ex) { SayRed(ex.Message); }
            }
            #endregion
        }




        internal static void ClearActual()
        {
            DepNewClear();
            Say("DepNewClear");
        }

        internal static void ClearActualOtbor()
        {
            #region
            var otbor = OtborGet();
            foreach (var line in otbor)
            {
                var dep = line[1];
                try
                {
                    DepDelOneNew(dep);
                    Say($"DepDelOneNew {dep}");
                }
                catch { }
            }

            #endregion
        }



        internal static void OtborToActual()
        {
            #region
            var otbor = OtborGet();
            foreach (var line in otbor)
            {
                var dep = line[1];
                var data = DepGetOne(dep);
                try { DepDelOneNew(dep); }
                catch { }

                try
                {
                    DepAddOneNew(data);
                    Say($"DepAddOneNew {dep}");
                }
                catch (Exception ex) { SayRed(ex.Message); }
            }

            #endregion
        }


    }
}
