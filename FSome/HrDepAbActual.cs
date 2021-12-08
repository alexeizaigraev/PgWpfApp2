using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2
{
    class HrDepAbActual : PgBase
    {
        static SortedDictionary<string, int> dictSum = new SortedDictionary<string, int>();
        static List<string[]> koatuAll;
        static Dictionary<string, List<string[]>> sprDict = new Dictionary<string, List<string[]>>();
        public static void MainHrDepAbActual()
        {
            #region
            var natasha = MkNatasha();
            //string myKey = "partner";
            //string outText = "№ п/п;\"№ Відділення ТОВ \"\"ЕПС\"\"\";Адреса;koatu1;koatu2;Партнер\n";
            string outText = "№ п/п;\"№ Відділення ТОВ \"\"ЕПС\"\"\";Адреса;Партнер\n";
            var data = GetSummuryDataActual();
            var sizeLine = data[0].Count;


            int count = 0;
            foreach (var u in data)
            {
                try
                {
                    if (u[0] == "" || natasha.IndexOf(u[0]) < 0) continue;

                    count++;
                    string outLine = String.Format("{0}", count) + ";"
                            + u[0] + ";" + u[1] + ";" + u[2];

                    outText += outLine + "\n";
                }
                //catch (Exception ex) { pMagenta(ex.Message); }
                catch (Exception ex) { info += ex.Message + "\n"; }
                //catch { }
            }

            string oFname = dataOutPath + "summury_ab.csv";
            SayGreen($"\n\n\tsumm {count}\n\n");
            TextToFile(oFname, outText);
            //OpenNote(oFname);
            #endregion
        }

        internal static List<List<string>> GetSummuryDataActual()
        {
            #region
            string query = "SELECT department, address, partner FROM departmentsnew WHERE department != '1700999' ORDER BY department ;";
            return PgGetData(query);
            #endregion
        }


        static string WhiteString(string inString)
        {
            #region #MkFioWhite
            string white = "";
            foreach (char cha in inString)
            {
                if (char.IsLetter(cha))
                {
                    char[] c = { cha };
                    string ss = new string(c);
                    white += ss;
                }
            }
            return white.ToLower();
            #endregion
        }

        static string FinderHash(string koatuOld, string sity, string districtSity, string bigLine)
        {
            #region
            var arr = sprDict[koatuOld];
            foreach (var sprLine in arr)
            {
                if (Str1InStr2Both(sprLine[0], sity) || Str1InStr2Both(sprLine[0], districtSity))
                    return sprLine[1];
            }

            foreach (var sprLine in arr)
            {
                if (Str1InStr2(sprLine[0], bigLine)) return sprLine[1];
            }

            return "";
            #endregion
        }

        static bool Str1InStr2(string str1, string str2)
        {
            #region
            bool flag = false;
            var s1 = WhiteString(str1);
            var s2 = WhiteString(str2);
            //if ((s2.IndexOf(s1) > -1) || (s2.IndexOf(s1) > -1)) flag = true;
            if ((s2.IndexOf(s1) > -1)) flag = true;
            return flag;
            #endregion
        }

        static bool Str1InStr2Both(string str1, string str2)
        {
            #region
            bool flag = false;
            var s1 = WhiteString(str1);
            var s2 = WhiteString(str2);
            if ((s2.IndexOf(s1) > -1) || (s1.IndexOf(s2) > -1)) flag = true;
            return flag;
            #endregion
        }

        static string MkKoatuNew(string bigString, string koatuOLd, string sity, string districtSity)
        {
            #region
            foreach (var koatuLine in koatuAll)
            {
                if (
                    Str1InStr2Both(koatuLine[1], koatuOLd) &&
                    (Str1InStr2(koatuLine[2], sity) || Str1InStr2(koatuLine[2], districtSity))
                    ) return koatuLine[0];
            }

            foreach (var koatuLine in koatuAll)
            {
                if (koatuLine[1] != koatuOLd) continue;
                if (Str1InStr2(koatuLine[1], bigString) && Str1InStr2(koatuLine[2], bigString)) return koatuLine[0];
            }
            return "";
            #endregion
        }

    }
}
