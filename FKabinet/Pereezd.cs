﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PgWpfApp2
{
    class Pereezd : PapaKabinet
    {

        private const string QKabinetPereezd = @"SELECT terminals.department,
departments.post_index, departments.region,
departments.city, departments.street, departments.hous,
departments.koatu, departments.tax_id,
terminals.model, terminals.serial_number, terminals.soft,
terminals.producer, terminals.date_manufacture,
terminals.rne_rro, terminals.fiscal_number, terminals.oro_serial, terminals.ticket_serial,
terminals.to_rro,
otbor.term
FROM otbor, terminals, departments
WHERE otbor.term = terminals.termial
AND departments.department = terminals.department
ORDER BY terminals.termial;";


        internal static List<List<string>> GetKabinetPereezd() { return PgGetData(QKabinetPereezd); }




        public static void MainPereezd()
        {
            //List<List<string>> data = new List<List<string>>();
            //data = PgBase.GetKabinetPereezd();
            var data = GetKabinetPereezd();

            foreach (var dataLine in data)
            {
                if (dataLine[2] == "") dataLine[2] = "Київська";
                string shablon = "<?xml version=\"1.0\" encoding=\"windows-1251\" standalone=\"no\"?>" + @"
" + "<DECLAR xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xsi:noNamespaceSchemaLocation=\"J1311402.xsd\">" + @"
    <DECLARHEAD>
        <TIN>40243180</TIN>
        <C_DOC>J13</C_DOC>
        <C_DOC_SUB>114</C_DOC_SUB>
        <C_DOC_VER>2</C_DOC_VER>
        <C_DOC_TYPE>0</C_DOC_TYPE>
        <C_DOC_CNT>660</C_DOC_CNT>
        <C_REG>26</C_REG>
        <C_RAJ>50</C_RAJ>
        <PERIOD_MONTH>2</PERIOD_MONTH>
        <PERIOD_TYPE>1</PERIOD_TYPE>
        <PERIOD_YEAR>2020</PERIOD_YEAR>
        <C_STI_ORIG>2650</C_STI_ORIG>
        <C_DOC_STAN>1</C_DOC_STAN>" + @"
        " + "<LINKED_DOCS xsi:nil=\"true\"/>" + @"
        <D_FILL>17062020</D_FILL>
        <SOFTWARE>CABINET 0.4.1</SOFTWARE>
    </DECLARHEAD>
  <DECLARBODY>
<HMN>1</HMN>
<HPR>1</HPR>
<H01G1S>переїзд</H01G1S>
<HKSTI>2650</HKSTI>
<HSTI>ГОЛОВНЕ УПРАВЛІННЯ ДФС У М.КИЄВІ, ДПІ У ГОЛОСІЇВСЬКОМУ РАЙОНІ (ГОЛОСІЇВСЬКИЙ РАЙОН М.КИЄВА)</HSTI>" + @"
" + "<HNAME>ТОВАРИСТВО З ОБМЕЖЕНОЮ ВIДПОВIДАЛЬНIСТЮ \"ЕЛЕКТРУМ ПЕЙМЕНТ СІСТЕМ\"</HNAME>" + @"
<HTIN>40243180</HTIN>" + @"
" + "<T3RXXXXG1S ROWNUM=\"1\">Відділення № " + dataLine[0] + @"</T3RXXXXG1S>
" + "<T3RXXXXG2 ROWNUM=\"1\">" + dataLine[1] + @"</T3RXXXXG2>
" + "<T3RXXXXG3S ROWNUM=\"1\">" + dataLine[2] + @"</T3RXXXXG3S>
" + "<T3RXXXXG4S ROWNUM=\"1\" xsi:nil=\"true\"/>" + @"
" + "<T3RXXXXG5S ROWNUM=\"1\">" + dataLine[3] + @"</T3RXXXXG5S>
" + "<T3RXXXXG6S ROWNUM=\"1\">" + dataLine[4] + @"</T3RXXXXG6S>
" + "<T3RXXXXG7S ROWNUM=\"1\">" + dataLine[5] + @"</T3RXXXXG7S>
" + "<T3RXXXXG8S ROWNUM=\"1\" xsi:nil=\"true\"/>" + @"
" + "<T3RXXXXG9S ROWNUM=\"1\" xsi:nil = \"true\"/>" + @"
" + "<T3RXXXXG10S ROWNUM=\"1\" xsi:nil = \"true\"/>" + @"
" + "<T3RXXXXG11 ROWNUM=\"1\">" + dataLine[6] + @"</T3RXXXXG11>
" + "<T3RXXXXG12S ROWNUM=\"1\">" + dataLine[7] + @"</T3RXXXXG12S>
" + "<T3RXXXXG13 ROWNUM=\"1\">1406</T3RXXXXG13>" + @"
" + "<T3RXXXXG13S ROWNUM=\"1\">ГУ ДПС У МИКОЛАЇВСЬКІЙ ОБЛАСТІ (М. ВОЗНЕСЕНСЬК)</T3RXXXXG13S>" + @"
<R0401G1>420</R0401G1>
<R0401G1S>" + dataLine[8] + @"</R0401G1S>
<R0402G1S>" + dataLine[9] + @"</R0402G1S>
<R0403G1>1085</R0403G1>
<R0403G1S>" + dataLine[10] + @"</R0403G1S>
<R0404G1S>" + dataLine[11] + @"</R0404G1S>
<R0405G1D>" + dataLine[12].ToString().Replace(".", "").Substring(0, 8) + @"</R0405G1D>
<R0408G1S>" + dataLine[13] + @"</R0408G1S>
<R0409G1S>" + dataLine[14] + @"</R0409G1S>
<R0501G1S>Торгівля. Громадське харчування. Сфера послуг.</R0501G1S>
<R0601G1S>" + dataLine[15] + @"</R0601G1S>
<R0602G1>40</R0602G1>
<R0603G1S>" + dataLine[16] + @"</R0603G1S>
<R0604G1>100</R0604G1>
<R0701G1S>" + dataLine[17] + @"</R0701G1S>
<R0702G1S>39205324</R0702G1S>
<R0703G1S>97</R0703G1S>
<R0703G2D>01092016</R0703G2D>
<R0703G3D>31122024</R0703G3D>
<M04>1</M04>
<R0901G1S></R0901G1S>
<M05>1</M05>
<HKBOS>2903722436</HKBOS>
<HBOS>ПОЖАРСЬКИЙ ВЯЧЕСЛАВ ЮХИМОВИЧ</HBOS>
<HFILL>" + DateNow() + @"</HFILL>
</DECLARBODY>
</DECLAR>";
                string ofname = kabinetPath + dataLine[0] + "_pereezd_" + dataLine[9] + ".xml";
                TextToFileCP1251(ofname, shablon);
            }
            Loger("pereezd");
        }

    }
}
