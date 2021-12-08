using System;
using System.Collections.Generic;
using System.IO;
using Npgsql;

namespace PgWpfApp2
{
    partial class PgBase : Papa
    {
        private const string QPartnersData = "SELECT DISTINCT partner FROM departments ORDER BY partner;";

        private const string QDepOtborData = "SELECT DISTINCT dep FROM otbor ORDER BY dep;";

        private const string QLogi = @"SELECT terminals.department, terminals.termial, terminals.serial_number, departments.address
FROM terminals, departments, otbor
WHERE terminals.termial = otbor.term
AND departments.department = otbor.dep;";

        internal static List<List<string>> GetPartners() { return PgGetData(QPartnersData); }

        internal static List<List<string>> GetDepOtbor() { return PgGetData(QDepOtborData); }

        internal static List<List<string>> GetSummuryPartnerData(string partner)
        {
            string query = String.Format("SELECT department, region, district_region, post_index, city_type, city, district_city, street_type, street, hous, address, koatu, partner FROM departments WHERE partner = '{0}' AND department != '1700999' ORDER BY department;", partner);
            return PgGetData(query);

        }













        internal static List<List<string>> GetLogData() { return PgGetData(QLogi); }

        internal static List<string> GetListTermPartner()
        {
            var query = String.Format("SELECT terminals.termial FROM terminals, departments WHERE terminals.department = departments.department AND departments.partner = '{0}' ORDER BY terminals.termial;", partnerChoised);
            var rez = new List<string>();
            var data = PgGetData(query);
            foreach (var line in data)
            {
                try { rez.Add(line[0]); }
                catch { }
            }
            return rez;
        }

        internal static List<string> GetListTerm()
        {
            var query = "SELECT termial FROM terminals ORDER BY termial;";
            var rez = new List<string>();
            var data = PgGetData(query);
            foreach (var line in data)
            {
                try { rez.Add(line[0]); }
                catch { }
            }
            return rez;
        }

        internal static List<string> GetListTermNew()
        {
            var query = "SELECT termial FROM terminalsnew ORDER BY termial;";
            var rez = new List<string>();
            var data = PgGetData(query);
            foreach (var line in data)
            {
                try { rez.Add(line[0]); }
                catch { }
            }
            return rez;
        }


        internal static List<string> GetListDep()
        {
            var query = "SELECT department FROM departments ORDER BY department;";
            var rez = new List<string>();
            var data = PgGetData(query);
            foreach (var line in data)
            {
                try { rez.Add(line[0]); }
                catch { }
            }
            return rez;
        }

        internal static List<string> GetListDepNew()
        {
            var query = "SELECT department FROM departmentsnew ORDER BY department;";
            var rez = new List<string>();
            var data = PgGetData(query);
            foreach (var line in data)
            {
                try { rez.Add(line[0]); }
                catch { }
            }
            return rez;
        }

        internal static List<string> GetListPartners()
        {
            var query = "SELECT DISTINCT partner FROM departments ORDER BY partner;";
            var rez = new List<string>();
            var data = PgGetData(query);
            foreach (var line in data)
            {
                if (line[0] == "") continue;
                try { rez.Add(line[0]); }
                catch { }
            }
            return rez;
        }


    }
}