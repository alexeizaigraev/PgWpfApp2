using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PgWpfApp2
{
    internal class NatashaActual : PgBase
    {
        static List<List<string>> accessData;
        static List<string> natasha;
        private const string QNatashaDataActual = @"SELECT department, edrpou, partner FROM departmentsnew
ORDER BY partner;";

        static int CountPnfp(string partner)
        {
            #region
            int count = 0;
            foreach (var line in accessData)
            {
                if ((line[2].IndexOf(partner) > -1)
                    && (natasha.IndexOf(line[0]) > -1)
                    && (line[1] == ""))
                    count += 1;
            }
            return count;
            #endregion
        }

        static int CountEdrpou(string partner)
        {
            #region
            int count = 0;
            foreach (var line in accessData)
            {
                if ((line[2].IndexOf(partner) > -1)
                    && (natasha.IndexOf(line[0]) > -1)
                    && (line[1] != ""))
                    count += 1;
            }
            return count;
            #endregion
        }

        static int CountComon(string partner)
        {
            #region
            int count = 0;
            foreach (var line in accessData)
            {
                if ((line[2].IndexOf(partner) > -1)
                    && (natasha.IndexOf(line[0]) > -1))
                    count += 1;
            }
            return count;
            #endregion
        }


        internal static List<List<string>> GetNataDataActual() { return PgGetData(QNatashaDataActual); }


        public static void MainNatashaActual()
        {
            outLine = "";
            var header = "Партнёр;Отделения с ЕДРПОУ;ПНФП;Всего\n";
            outText = header;
            natasha = MkNatasha();
            accessData = GetNataDataActual();
            var partners = PgBase.GetPartners();
            int sumComon = 0;
            int sumEdrpou = 0;
            int sumPnfp = 0;
            foreach (var partnerItem in partners)
            {
                string partner = partnerItem[0];
                if ("intime" == partner.ToString()) continue;
                if ("" == partner.ToString()) continue;
                if (0 == CountComon(partner)) continue;
                var outLine = String.Format("{0};{1};{2};{3}\n", partner, CountEdrpou(partner), CountPnfp(partner), CountComon(partner));
                outText += outLine;
                sumComon += CountComon(partner);
                sumEdrpou += CountEdrpou(partner);
                sumPnfp += CountPnfp(partner);
            }

            outText += String.Format("\nВсего с ЕДРПОУ {0}", sumEdrpou);
            outText += String.Format("\nВсего ПНФП {0}", sumPnfp);
            outText += String.Format("\nВсего {0}", sumComon);
            //infoBig = outText;
            Say(outText);

            string oFname = dataPath + "Количество отделений/Отделения-" + DateNowLine() + ".csv";
            TextToFile(oFname, outText);
            //infoSmall = oFname;
        }

    }
}
