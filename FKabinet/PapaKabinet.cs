﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2
{
    internal class PapaKabinet : PgBase
    {
        protected static string KabinetPath()
        {
            #region
            string path = File.ReadAllLines(dataConfigPath + "ConfigKabinetPath.txt")[0];
            return path;
            #endregion
        }

        protected static string DateNow()
        {
            #region
            var nau = DateTime.Today;
            return nau.ToString("dd.MM.yyyy").Replace(".", "");
            #endregion
        }

        protected static void TextToFileCP1251(string fName, string text)
        {
            #region
            try
            {
                Encoding win1251 = Encoding.GetEncoding(1251);
                File.WriteAllText(fName, text, win1251);
                Say(fName);
            }
            catch (Exception ex) { Alarm(ex.Message, fName); }
            #endregion
        }

    }
}
