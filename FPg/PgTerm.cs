using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;

namespace PgWpfApp2
{
    partial class PgBase : Papa
    {


        internal static void TermClearCascadShablon(string dep, string table)
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            string sql = $"delete from {table}  where department = '{dep}'";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            con.Open();
            try
            {
                com.ExecuteNonQuery();
                Say(sql);
            }
            catch (Exception ex) { SayRed(ex.Message); }
            con.Close();
            #endregion
        }

        internal static void TermClearCascad(string dep)
        {
            #region
            TermClearCascadShablon(dep, "terminals");
            #endregion
        }

        internal static void TermNewClearCascad(string dep)
        {
            #region
            TermClearCascadShablon(dep, "terminalsnew");
            #endregion
        }

        internal static void TermNewAddCascad()
        {
            #region
            var otbor = OtborGet();
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            foreach (var line in otbor)
            {
                string dep = line[1];
                string term = line[0];
                var vec = TermGetOne(term);
                string sql = $"INSERT INTO public.terminalsnew(" + @"
	" + "department, termial, model, serial_number, date_manufacture, soft, producer, rne_rro, sealing, fiscal_number, oro_serial, oro_number, ticket_serial, ticket_1sheet, ticket_number, sending, books_arhiv, tickets_arhiv, to_rro, owner_rro, register, finish) " +
    $"VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}', '{vec[19]}', '{vec[20]}', '{vec[21]}');";

                string sql0 = $"INSERT INTO public.terminalsnew(" + @"
	" + "department, termial, model, serial_number, date_manufacture, soft, producer, rne_rro, sealing, fiscal_number, oro_serial, oro_number, ticket_serial, ticket_1sheet, ticket_number, sending, books_arhiv, tickets_arhiv, to_rro, owner_rro, register, finish) " +
    $"VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}', '{vec[19]}', '{vec[20]}');";



                NpgsqlCommand com = new NpgsqlCommand(sql, con);
                try
                {
                    com.ExecuteNonQuery();
                    Say($"+ terminalsnew {vec[1]}");
                }
                catch (Exception ex) { SayRed(ex.Message); }
            }
            con.Close();
            //info = $"�������� {vec[1]}";
            #endregion
        }

        internal static void TermClearShablon(string table)
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            string sql = "delete from terminals";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            con.Open();
            try
            {
                com.ExecuteNonQuery();
                //Console.WriteLine(sql);
            }
            catch { }
            con.Close();
            #endregion
        }

        internal static void TermClear()
        {
            #region
            TermClearShablon("terminals");
            #endregion
        }

        internal static void TermNewClear()
        {

            #region
            TermClearShablon("terminalsnew");
            #endregion
        }


        internal static void TermAdd(List<string[]> arr)
        {
            #region
            TermClear();
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            int countRows = -1;
            foreach (var vec in arr)
            {
                countRows += 1;
                if (vec[0] == "" || countRows < 1) continue;
                //string insertData = "nodata";
                string sql = $"INSERT INTO public.terminals VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}', '{vec[19]}', '{vec[20]}', '{vec[21]}');";

                //string sql = $"INSERT INTO public.departments VALUES (\"{vec[0]}\", \"{vec[1]}\", \"{vec[2]}\", \"{vec[3]}\", \"{vec[4]}\", \"{vec[5]}\", \"{vec[6]}\", \"{vec[7]}\", \"{vec[8]}\", \"{vec[9]}\", \"{vec[10]}\", \"{vec[11]}\", \"{vec[12]}\", \"{vec[13]}\", \"{vec[14]}\", \"{vec[15]}\", \"{vec[16]}\", \"{vec[17]}\", \"{vec[18]}\", '{insertData}');";
                NpgsqlCommand com = new NpgsqlCommand(sql, con);
                try
                {
                    com.ExecuteNonQuery();
                    //pCyan(vec[1]);
                    //Console.WriteLine(sql);
                }
                catch (Exception ex) { SayRed(ex.Message); }
            }
            con.Close();
            #endregion
        }


        internal static void TermAddOneShablon(List<string> vec, string table)
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            string sql = $"INSERT INTO public.{table}(" + @"
	" + "department, termial, model, serial_number, date_manufacture, soft, producer, rne_rro, sealing, fiscal_number, oro_serial, oro_number, ticket_serial, ticket_1sheet, ticket_number, sending, books_arhiv, tickets_arhiv, to_rro, owner_rro, register, finish) " +
    $"VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}', '{vec[19]}', '{vec[20]}', '{vec[21]}');";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            try { com.ExecuteNonQuery(); }
            catch (Exception ex) { info = ex.Message; }
            con.Close();
            info = $"добавлен {vec[1]}";
            #endregion
        }

        internal static void TermAddOne(List<string> vec)
        {
            #region
            TermAddOneShablon(vec, "terminals");
            #endregion
        }

        internal static void TermAddOneNew(List<string> vec)
        {
            #region
            TermAddOneShablon(vec, "terminalsnew");
            #endregion
        }


        internal static void TermUpdateOne(List<string> vec)
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            string sql = @"UPDATE public.terminals " +
    $"SET department='{vec[0]}', model='{vec[2]}', serial_number='{vec[3]}', date_manufacture='{vec[4]}', soft='{vec[5]}', producer='{vec[6]}', rne_rro='{vec[7]}', sealing='{vec[8]}', fiscal_number='{vec[9]}', oro_serial='{vec[10]}', oro_number='{vec[11]}', ticket_serial='{vec[12]}', ticket_1sheet='{vec[13]}', ticket_number='{vec[14]}', sending='{vec[15]}', books_arhiv='{vec[16]}', tickets_arhiv='{vec[17]}', to_rro='{vec[18]}', owner_rro='{vec[19]}', register='{vec[20]}', finish='{vec[21]}' " +
    $"WHERE termial='{vec[1]}';";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            try
            {
                com.ExecuteNonQuery();
                info = $"обновлен {vec[1]}";
            }
            catch (Exception ex) { info = ex.Message; }
            con.Close();
            #endregion
        }


        internal static void TermFromFile()
        {
            #region
            var arr = FileToArr(Path.Combine(dataInPath, "terminals.csv"));
            TermAdd(arr);
            #endregion
        }

        internal static List<List<string>> TermGet()
        {
            #region
            string query = "select * from terminals";
            var arr = PgGetData(query);
            foreach (var vec in arr)
            {
                System.Console.WriteLine(vec[0] + " " + vec[1]);
            }
            return arr;
            #endregion
        }

        internal static List<string> TermGetOne(string term)
        {
            #region
            string query = $"select * from terminals WHERE termial='{term}'";
            var arr = PgGetData(query);
            return arr[0];
            #endregion
        }

        internal static List<string> TermGetOneNew(string term)
        {
            #region
            string query = $"select * from terminalsnew WHERE termial='{term}'";
            var arr = PgGetData(query);
            return arr[0];
            #endregion
        }


        internal static void TermDelOneShablon(string term, string table)
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            string sql = $"DELETE FROM public.{table} WHERE termial = '{term}';";
            info = "";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            try
            {
                com.ExecuteNonQuery();
                info = $"удалён {term}";
            }
            catch (Exception ex) { info = ex.Message; }
            con.Close();
            #endregion
        }

        internal static void TermDelOne(string term)
        {
            #region
            TermDelOneShablon(term, "terminals");
            #endregion
        }

        internal static void TermDelOneNew(string term)
        {
            #region
            TermDelOneShablon(term, "terminalsnew");
            #endregion
        }

        public static string NextTerm(string term)
        {
            #region
            string outTerm = "";
            var terms = GetListTerm();
            int ind = terms.IndexOf(term);
            if (ind < terms.Count - 1) { outTerm = terms[ind + 1]; }
            else { outTerm = terms[0]; }
            info = outTerm;
            return outTerm;
            #endregion
        }

        public static string PredTerm(string term)
        {
            #region
            string rez = "";
            var vec = GetListTerm();
            int ind = vec.IndexOf(term);
            if (ind > 0) { rez = vec[ind - 1]; }
            else { rez = vec[vec.Count - 1]; }
            return rez;
            #endregion
        }

        // actual_____________________









    }
}