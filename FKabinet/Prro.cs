﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2
{
    internal class Prro : PapaKabinet
    {

        private const string QKabinetPrro = @"SELECT departments.tax_id, departments.koatu, departments.department,
departments.address
FROM otbor, departments
WHERE otbor.dep = departments.department
ORDER BY departments.department;";


        internal static List<List<string>> GetKabinetPrro() { return PgGetData(QKabinetPrro); }




        public static void MainPrro()
        {
            //List<List<string>> data = new List<List<string>>();
            //data = PgBase.GetKabinetPrro();
            var data = GetKabinetPrro();

            foreach (var dataLine in data)
            {
                string shablon = "<?xml version=\"1.0\" encoding=\"windows-1251\" standalone=\"no\"?>" + @"
" + "<DECLAR xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"J1316602.xsd\">" + @"
    " + @"<DECLARHEAD>
        <TIN>40243180</TIN>
        <C_DOC>J13</C_DOC>
        <C_DOC_SUB>166</C_DOC_SUB>
        <C_DOC_VER>2</C_DOC_VER>
        <C_DOC_TYPE>0</C_DOC_TYPE>
        <C_DOC_CNT>212</C_DOC_CNT>
        <C_REG>26</C_REG>
        <C_RAJ>50</C_RAJ>
        <PERIOD_MONTH>7</PERIOD_MONTH>
        <PERIOD_TYPE>1</PERIOD_TYPE>
        <PERIOD_YEAR>2021</PERIOD_YEAR>
        <C_STI_ORIG>2650</C_STI_ORIG>
        <C_DOC_STAN>1</C_DOC_STAN>" + @"
        " + "<LINKED_DOCS xsi:nil=\"true\"/>" + @"
        <D_FILL>09072021</D_FILL>
        <SOFTWARE>CABINET</SOFTWARE>
    </DECLARHEAD>
  <DECLARBODY>
<M011>1</M011>
" + "<HNAME>ТОВАРИСТВО З ОБМЕЖЕНОЮ ВIДПОВIДАЛЬНIСТЮ \"ЕЛЕКТРУМ ПЕЙМЕНТ СІСТЕМ\"</HNAME>" + @"
<HTIN>40243180</HTIN>
<R03G1S>" + dataLine[0] + @"</R03G1S>
<HKOATUU>" + dataLine[1] + @"</HKOATUU>
<R03G3S>Відділення №" + dataLine[2] + @"</R03G3S>
<R03G4S>" + dataLine[3] + @"</R03G4S>
<R03G5S>ВПС ЕЛЕКТРУМ</R03G5S>
<M041>1</M041>
<R04G11S>ПРРО</R04G11S>
<R04G12S>1</R04G12S>
<M051>1</M051>
<M11>1</M11>
<HKBOS>2903722436</HKBOS>
<HBOS>ПОЖАРСЬКИЙ ВЯЧЕСЛАВ ЮХИМОВИЧ</HBOS>
<HFILL>29032021</HFILL>
<HZ>1</HZ>
    <HZM>4</HZM>
    <HMONTH>4</HMONTH>
    <HZY>2021</HZY>
  </DECLARBODY>
</DECLAR>
";
                string ofname = kabinetPath + dataLine[2] + "_prro_" + ".xml";
                TextToFileCP1251(ofname, shablon);
            }
            Loger("prro");
        }

    }
}
