using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;

namespace PgWpfApp2
{
    partial class PgBase : Papa
    {

        internal static void OtborClear()
        {

            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            string sql = "delete from otbor";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            con.Open();
            try
            {
                com.ExecuteNonQuery();
                //Console.WriteLine(sql);
            }
            catch { }
            con.Close();
        }

        internal static void OtborAdd(List<string[]> arr)
        {

            OtborClear();
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            int countRows = -1;
            foreach (var vec in arr)
            {
                countRows += 1;
                if (vec[0] == "" || countRows < 1) continue;
                string sql = $"INSERT INTO public.otbor VALUES ('{vec[0]}', '{vec[1]}');";
                NpgsqlCommand com = new NpgsqlCommand(sql, con);
                try
                {
                    com.ExecuteNonQuery();
                    //Console.WriteLine(sql);
                }
                catch (Exception ex) { SayRed(ex.Message); }
            }
            con.Close();
        }


        internal static void OtborAddChoise(List<string[]> arr)
        {
            info = "";
            OtborClear();
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            foreach (var vec in arr)
            {
                if (vec[0] == "") continue;
                string sql = $"INSERT INTO public.otbor VALUES ('{vec[0]}', '{vec[1]}');";
                NpgsqlCommand com = new NpgsqlCommand(sql, con);
                try
                {
                    com.ExecuteNonQuery();
                    //Console.WriteLine(sql);
                    info += vec[0] + "\n";
                }
                catch (Exception ex) { SayRed(ex.Message); }
            }
            con.Close();
        }



        internal static void OtborAddInputDeps(string[] arr)
        {
            info = "\n\n";
            OtborClear();
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            foreach (var dep in arr)
            {
                var term = dep + "1";
                if (dep == "") continue;
                string sql = $"INSERT INTO public.otbor VALUES ('{term}', '{dep}');";
                NpgsqlCommand com = new NpgsqlCommand(sql, con);
                try
                {
                    com.ExecuteNonQuery();
                    //Console.WriteLine(sql);
                    info += term + " " + dep + "\n";
                }
                catch (Exception ex) { SayRed(ex.Message); }
            }
            con.Close();
        }


        internal static void OtborFromFile()
        {
            var arr = FileToArr(Path.Combine(dataInPath, "Otbor.csv"));
            OtborAdd(arr);
        }

        internal static List<List<string>> OtborGet()
        {
            string query = "select * from otbor";
            var arr = PgGetData(query);
            foreach (var vec in arr)
            {
                System.Console.WriteLine(vec[0] + " " + vec[1]);
            }
            return arr;
        }

        internal static string OtborToText()
        {
            string query = "select * from otbor";
            var arr = PgGetData(query);
            var text = "";
            foreach (var vec in arr)
            {
                text += $"{vec[0]};{vec[1]}\n";
            }
            return text;
        }

    }
}