using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2
{
    class GetRp : Papa
    {
        internal static void MainGetRp()
        {
            var knigiPath = "R:/DRM/Ключи/КНИГИ";
            Papa.ClearFolderPdf(knigiPath);
            var folderHash = MkComonHash(3);
            var otbor = PgBase.GetDepOtbor();
            foreach (var unit in otbor)
            {

                var dep = unit[0];
                var agSign = dep.Substring(0, 3);
                var folderAgent = folderHash[agSign];
                var folder = Path.Combine(gDrivePath, folderAgent);
                var folderFull = Path.Combine(folder, dep);
                CoperRp(folderFull, knigiPath);

                //SayBlue(agSign);
            }
        }
    }
}
