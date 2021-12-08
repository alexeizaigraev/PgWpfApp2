using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;

namespace PgWpfApp2
{
    partial class PgBase : Papa
    {

        internal static void DepClear()
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            string sql = "delete from departments;";
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

        /*
        internal static void DepNewClear()
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            string sql = "delete from departmentsnew;";
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

        */

        internal static void DepAddShablon(List<string[]> arr, string table)
        {
            #region
            if (table == "departments") DepClear();
            else DepNewClear();
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            int countRows = -1;
            foreach (var vec in arr)
            {
                countRows += 1;
                if (vec[0] == "" || countRows < 1) continue;
                string insertData = "";
                string sql = $"INSERT INTO public.{table}(" + @"
    department, region, district_region, district_city, city_type, city, street, street_type, hous, post_index, partner, status, register, edrpou, address, partner_name, id_terminal, koatu, tax_id, koatu2)
	VALUES(" + $"'{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}', ''); ";

                NpgsqlCommand com = new NpgsqlCommand(sql, con);
                try
                {
                    com.ExecuteNonQuery();
                    // pCyan(vec[0]);
                    //Console.WriteLine(sql);
                }
                catch (Exception ex) { SayRed(ex.Message); }
            }
            con.Close();
            #endregion
        }

        internal static void DepAdd(List<string[]> arr)
        {
            #region
            DepClear();
            DepAddShablon(arr, "departments");
            #endregion
        }

        internal static void DepAddNew(List<string[]> arr)
        {
            #region
            DepNewClear();
            DepAddShablon(arr, "departmentsnew");
            #endregion
        }


        internal static void DepAddOneShablon(List<string> vec, string table)
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            string sql = $"INSERT INTO public.{table}(" + @"
	department, region, district_region, district_city, city_type, city, street, street_type, hous, post_index, partner, status, register, edrpou, address, partner_name, id_terminal, koatu, tax_id)" + @"
" + $"VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}');";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            try
            {
                com.ExecuteNonQuery();
                //Say($"+ {table} {vec[0]}\n");
                //info += $"добавлен {vec[0]}";
            }
            catch (Exception ex) { info = ex.Message; }
            con.Close();

            #endregion
        }


        internal static void DepAddOne(List<string> vec)
        {
            #region
            DepAddOneShablon(vec, "departments");
            #endregion
        }

        internal static void DepAddOneNew(List<string> vec)
        {
            #region
            try
            {
                DepDelOneNew(vec[0]);
            }
            catch { }

            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            string sql = $"INSERT INTO public.departmentsnew(" + @"
	department, region, district_region, district_city, city_type, city, street, street_type, hous, post_index, partner, status, register, edrpou, address, partner_name, id_terminal, koatu, tax_id)" + @"
" + $"VALUES ('{vec[0]}', '{vec[1]}', '{vec[2]}', '{vec[3]}', '{vec[4]}', '{vec[5]}', '{vec[6]}', '{vec[7]}', '{vec[8]}', '{vec[9]}', '{vec[10]}', '{vec[11]}', '{vec[12]}', '{vec[13]}', '{vec[14]}', '{vec[15]}', '{vec[16]}', '{vec[17]}', '{vec[18]}');";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            try
            {
                com.ExecuteNonQuery();
                //Say($"+ {table} {vec[0]}\n");
                //info += $"добавлен {vec[0]}";
            }
            catch (Exception ex) { info = ex.Message; }
            con.Close();

            //DepAddOneShablon(vec, "departmentsnew");
            #endregion
        }

        internal static void DepUpdateOne(List<string> vec)
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            string sql = @"UPDATE public.departments " +
     $"SET region='{vec[1]}', district_region='{vec[2]}', district_city='{vec[3]}', city_type='{vec[4]}', city='{vec[5]}', street='{vec[6]}', street_type='{vec[7]}', hous='{vec[8]}', post_index='{vec[9]}', partner='{vec[10]}', status='{vec[11]}', register='{vec[12]}', edrpou='{vec[13]}', address='{vec[14]}', partner_name='{vec[15]}', id_terminal='{vec[16]}', koatu='{vec[17]}', tax_id='{vec[18]}' " +
     $"WHERE department='{vec[0]}';";


            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            try
            {
                com.ExecuteNonQuery();
                info = $"обновлен {vec[0]}";
            }
            catch (Exception ex) { info = ex.Message; }
            con.Close();
            #endregion
        }

        internal static void DepFromFile()
        {
            var arr = FileToArr(Path.Combine(dataInPath, "departments.csv"));
            DepAdd(arr);
        }

        internal static List<List<string>> DepGetShablon(string table)
        {
            #region
            string query = $"select * from {table}";
            return PgGetData(query);
            #endregion
        }

        internal static List<List<string>> DepGet()
        {
            #region
            return DepGetShablon("departments");
            #endregion
        }

        internal static List<List<string>> DepGetNew()
        {
            #region
            return DepGetShablon("departmentsnew");
            #endregion
        }



        internal static List<string> DepGetOne(string dep)
        {
            #region
            string query = $"select * from departments WHERE department = '{dep}'";
            var arr = PgGetData(query);
            return arr[0];
            #endregion
        }

        internal static List<string> DepGetOneNew(string dep)
        {
            #region
            string query = $"select * from departmentsnew WHERE department = '{dep}'";
            var arr = PgGetData(query);
            return arr[0];
            #endregion
        }

        internal static string DepGetAddress(string dep)
        {
            #region
            string query = $"select * from departments WHERE department = '{dep}'";
            var arr = PgGetData(query);
            //info = arr[0][1]
            return arr[0][14];
            #endregion
        }


        internal static void DepDelOneShablon(string dep, string table)
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            con.Open();
            string sql = $"DELETE FROM public.{table} WHERE department = '{dep}';";
            //info = "";
            NpgsqlCommand com = new NpgsqlCommand(sql, con);
            try
            {
                com.ExecuteNonQuery();
                //info += $"удалён {dep}";
            }
            catch (Exception ex) { info = ex.Message; }
            con.Close();
            #endregion
        }





        internal static void DepDelOne(string dep)
        {
            #region
            DepDelOneShablon(dep, "departments");
            #endregion
        }

        internal static void DepDelOneNew(string dep)
        {
            #region
            DepDelOneShablon(dep, "departmentsnew");
            #endregion
        }

        public static string NextDep(string dep)
        {
            string outDep = "";
            var deps = GetListDep();
            int ind = deps.IndexOf(dep);
            if (ind < deps.Count - 1) { outDep = deps[ind + 1]; }
            else { outDep = deps[0]; }
            return outDep;
        }

        public static string PredDep(string dep)
        {
            string outDep = "";
            var deps = GetListDep();
            int ind = deps.IndexOf(dep);
            if (ind > 0) { outDep = deps[ind - 1]; }
            else { outDep = deps[deps.Count - 1]; }
            return outDep;
        }



        // actual_____________________



        internal static void DepNewClear()
        {
            #region
            NpgsqlConnection con = new NpgsqlConnection(conn_param);
            string sql = "delete from departmentsnew";
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

        internal static string DepNewToText(string dep)
        {
            #region
            string query = $"select * from departmentsnew WHERE department = '{dep}'";
            var arr = PgGetData(query);
            return "\n" + String.Join("\n", arr[0]);
            #endregion
        }


    }
}