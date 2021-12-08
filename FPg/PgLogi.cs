using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;

namespace PgWpfApp2
{
    partial class PgBase : Papa
    {

        public static void Loger(string kind)
        {
            #region
            Papa.info += "\nLoged " + kind + "\n";
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            var nau = DateTime.Today.ToString("dd.MM.yyyy");
            var arr = GetLogData();

            foreach (var vec in arr)
            {
                string sql = $"INSERT INTO public.logi(department, termial, serial_number, address, datalog, kind) VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{nau}', '{kind}');";
                NpgsqlCommand com = new NpgsqlCommand(sql, con);
                try
                {
                    com.ExecuteNonQuery();
                    Papa.info += vec[0] + "\n";
                }
                catch (Exception ex) { SayRed(ex.Message); }
            }
            con.Close();

            nau = DateTime.Today.ToString("yyyy.MM.dd");
            string fNameOld = @"R:\DRM\Access\db2_be.accdb";
            string fNameNew = @"R:\DRM\BackupAccess\db2_be_" + nau + "_" + kind + ".accdb";
            CopyOneFile(fNameOld, fNameNew);

            #endregion
        }


    }
}