using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2
{
    internal class HrDepActual : SomePapa
    {
        static List<string[]> koatuAll;
        //static List<string[]> sprArr;
        static Dictionary<string, List<string[]>> sprDict = new Dictionary<string, List<string[]>>();
        public static void MainHrDepActual()
        {
            info = "";
            //var x = "";
            //string myKey = "partner";
            string outText = "№ п/п;\"№ Відділення ТОВ \"\"ЕПС\"\"\";Область;Район в обл.;Індекс;Тип населеного пункту;Населений пункт;Район в місті;Тип вулиці;Адреса;Номер будинку;Дата признчення керівника;модель РРО;Заводський № РРО;2;koatu1;koatu2\n";
            var data = GetSummuryOtborDataActual();
            var sizeLine = data[0].Count;
            //string partner = MenuColKey(data, sizeLine - 1);
            koatuAll = FileToArr(dataInPath + "koatuall.csv");

            string key = "";
            foreach (var koatuVec in koatuAll)
            {
                try
                {
                    key = koatuVec[1];
                    if (key == "") continue;
                    var place = koatuVec[2];
                    var newInd = koatuVec[0];
                    string[] pair = { place, newInd };
                    //pair[0] = place;
                    //pair[1] = newInd;
                    if (sprDict.ContainsKey(key)) sprDict[key].Add(pair);
                    else
                    {
                        sprDict[key] = new List<string[]>();
                        sprDict[key].Add(pair);
                        //pBlue(key + " " + place + " " + newInd);
                    }
                }
                catch { Say(key); }

            }
            //pGreen("end Spravka\n");

            //Say("\n " + partner + "\n");

            int count = 0;
            foreach (var u in data)
            {
                try
                {

                    count++;
                    string outLine = "";

                    outLine = String.Format("{0}", count) + ";"
                            + u[0] + ";"
                            + u[1] + ";"
                            + u[2] + ";"
                            + u[3] + ";"
                            + u[4] + ";"
                            + u[5] + ";"
                            + u[6] + ";"
                            + u[7] + ";"
                            + u[8] + ";"
                            + u[9] + ";"
                            + "" + ";"
                            + "" + ";"
                            + "" + ";"
                            + u[10] + ";"
                            + u[11] + ";";

                    string sity = u[5];
                    string districtSity = u[6];
                    string koatuOld = u[11];

                    //string koatuNew = MkKoatuNew(outLine, koatuOld, sity, districtSity);
                    string koatuNew = FinderHash(koatuOld, sity, districtSity);
                    outLine += koatuNew;
                    outText += outLine + "\n";

                    info += u[0] + "\n";

                }
                catch { }
            }
            TextToFile(dataOutPath + "hr_new_deps.csv", outText);
        }


        internal static List<List<string>> GetSummuryOtborDataActual()
        {
            #region
            string query = @"SELECT department, region, district_region, post_index, city_type, city, district_city, street_type, street, hous, address, koatu, koatu2
FROM departmentsnew, otbor
WHERE department = dep
ORDER BY department;";
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

        static string FinderHash(string koatuOld, string sity, string districtSity)
        {
            //string res = "";
            var arr = sprDict[koatuOld];
            foreach (var sprLine in arr)
            {
                if (Str1InStr2Both(sprLine[0], sity) || Str1InStr2Both(sprLine[0], districtSity))
                    return sprLine[1];
            }
            return "";
        }

        static bool Str1InStr2(string str1, string str2)
        {
            bool flag = false;
            var s1 = WhiteString(str1);
            var s2 = WhiteString(str2);
            //if ((s2.IndexOf(s1) > -1) || (s2.IndexOf(s1) > -1)) flag = true;
            if ((s2.IndexOf(s1) > -1)) flag = true;
            return flag;
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

        static string MkKoatuNew(string koatuOLd, string sity, string districtSity)
        {
            #region
            foreach (var koatuLine in koatuAll)
            {
                if (
                    Str1InStr2Both(koatuLine[1], koatuOLd) &&
                    (Str1InStr2(koatuLine[2], sity) || Str1InStr2(koatuLine[2], districtSity))
                    ) return koatuLine[0];
            }
            return "";
            #endregion
        }

    }
}
