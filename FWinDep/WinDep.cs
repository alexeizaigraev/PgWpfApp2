using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2.FWindep
{
    internal class WinDep : PgBase
    {
        #region
        /*
        public static string department;
        public static string region;
        public static string district_region;
        public static string district_city;
        public static string city_type;
        public static string city;
        public static string street;
        public static string street_type;
        public static string hous;
        public static string post_index;
        public static string partner;
        public static string status;
        public static string register;
        public static string edrpou;
        public static string address;
        public static string partner_name;
        public static string id_terminal;
        public static string koatu;
        public static string tax_id;
        public static string koatu2;
        */
        #endregion

        public static List<string> GetDep(string dep)
        {

            return DepGetOne(dep);
        }

    }
}
