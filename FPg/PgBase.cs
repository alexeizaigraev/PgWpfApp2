using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;

namespace PgWpfApp2
{
    partial class PgBase : Papa
    {
        static string conn_param = "Server=127.0.0.1;Port=5432;User Id=postgres;Password=postgres;Database=postgres;";
        internal static List<List<string>> PgGetData(string query, int minSize = 1)
        {
            #region
            List<List<string>> arr = new List<List<string>>();
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            NpgsqlCommand com = new NpgsqlCommand(query, con);
            con.Open();
            NpgsqlDataReader reader;
            try
            {
                reader = com.ExecuteReader();
                while (reader.Read())
                {
                    List<string> vec = new List<string>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        try
                        { vec.Add(reader[i].ToString()); }
                        catch { }
                    }
                    if (vec.Count < minSize)
                    {
                        Say(String.Format(" BedSize {0}", vec[0]));
                        continue;
                    }

                    arr.Add(vec);
                }
                //File.WriteAllText(ofName, outText);
                //TextToFile(ofName, outText);
                con.Close();
                //textBox1.Text = "~ " + ofName;

            }
            catch (Exception ex)
            {
                // if (connection.State == ConnectionState.Open) { connection.Close(); }
                Sos("db error", ex.Message);
            }
            //finally { if (connection.State == ConnectionState.Open) { connection.Close(); } }
            return arr;
            #endregion
        }


        internal static void RefreshPg()
        {
            #region
            PgBase.OtborFromFile();
            //SayGray("Refresh Otbor");
            PgBase.DepFromFile();
            //SayGray("Refresh Departments");
            PgBase.TermFromFile();
            //SayGray("Refresh Terminals");
            //SayCyan("\n\tAll Refreshed\n");
            #endregion
        }

    }
}