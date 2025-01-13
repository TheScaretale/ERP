using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MySql.Data.MySqlClient;

namespace scanFiles
{
    internal class GerarSQL
    {
        public void GetFileData(string filePath)
        {
            XDocument doc = XDocument.Load(filePath);
            XNamespace ns = "http://www.portalfiscal.inf.br/nfe"; // Define the namespace

            string? nfc_mod = doc.Descendants(ns + "ide").FirstOrDefault()?.Element(ns + "mod")?.Value ?? "N/A";
            string? nfc_serie = doc.Descendants(ns + "ide").FirstOrDefault()?.Element(ns + "serie")?.Value ?? "N/A";
            string? nfc_numero = doc.Descendants(ns + "ide").FirstOrDefault()?.Element(ns + "nNF")?.Value ?? "N/A";
            string? nfc_tipo = doc.Descendants(ns + "ide").FirstOrDefault()?.Element(ns + "tpNF")?.Value ?? "N/A";
            string? nfc_sit = "E";
            string? nfc_natOp = doc.Descendants(ns + "ide").FirstOrDefault()?.Element(ns + "natOp")?.Value ?? "N/A";
            string? nfc_cfo = "N/A";
            string? nfc_ies = "N/A";
            string? nfc_emi = doc.Descendants(ns + "ide").FirstOrDefault()?.Element(ns + "dhEmi")?.Value ?? "N/A";
            string? nfc_sai = doc.Descendants(ns + "ide").FirstOrDefault()?.Element(ns + "dhSaiEnt")?.Value ?? "N/A";
            string? nfc_hor = "N/A";
            string? nfc_nom = doc.Descendants(ns + "emit").FirstOrDefault()?.Element(ns + "xNome")?.Value ?? "N/A";
            string? nfc_cnpj = doc.Descendants(ns + "emit").FirstOrDefault()?.Element(ns + "CNPJ")?.Value ?? "N/A";
            string? nfc_end = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "xLgr")?.Value ?? "N/A";
            string? nfc_bai = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "xBairro")?.Value ?? "N/A";
            string? nfc_cep = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "CEP")?.Value ?? "N/A";
            string? nfc_mun = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "xMun")?.Value ?? "N/A";
            string? nfc_tel = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "fone")?.Value ?? "N/A";
            string? nfc_uf = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "UF")?.Value ?? "N/A";
            string? nfc_ie = doc.Descendants(ns + "emit").FirstOrDefault()?.Element(ns + "IE")?.Value ?? "N/A";
            string nfc_fat = "E";
            string? nfc_bas_icm = doc.Descendants(ns + "total").Descendants(ns + "ICMSTot").FirstOrDefault()?.Element(ns + "vBC")?.Value ?? "N/A";
            string? nfc_val_icm = doc.Descendants(ns + "total").Descendants(ns + "ICMSTot").FirstOrDefault()?.Element(ns + "vICMS")?.Value ?? "N/A";
            string? nfc_bas_sub = doc.Descendants(ns + "total").Descendants(ns + "ICMSTot").FirstOrDefault()?.Element(ns + "vBCST")?.Value ?? "N/A";
            string? nfc_val_sub = doc.Descendants(ns + "total").Descendants(ns + "ICMSTot").FirstOrDefault()?.Element(ns + "vST")?.Value ?? "N/A";
            string? nfc_val_pro = doc.Descendants(ns + "total").Descendants(ns + "ICMSTot").FirstOrDefault()?.Element(ns + "vProd")?.Value ?? "N/A";
            string? nfc_val_fre = doc.Descendants(ns + "total").Descendants(ns + "ICMSTot").FirstOrDefault()?.Element(ns + "vFrete")?.Value ?? "N/A";
            string? nfc_val_seg = doc.Descendants(ns + "total").Descendants(ns + "ICMSTot").FirstOrDefault()?.Element(ns + "vSeg")?.Value ?? "N/A";
            string? nfc_val_out = doc.Descendants(ns + "total").Descendants(ns + "ICMSTot").FirstOrDefault()?.Element(ns + "vOutro")?.Value ?? "N/A";
            string? nfc_val_tot = doc.Descendants(ns + "total").Descendants(ns + "ICMSTot").FirstOrDefault()?.Element(ns + "vTotTrib")?.Value ?? "N/A";
            string? nfc_tra_nom = doc.Descendants(ns + "transp").Descendants(ns + "transporta").FirstOrDefault()?.Element(ns + "xNome")?.Value ?? "N/A";
            string? nfc_tra_fre = doc.Descendants(ns + "transp").FirstOrDefault()?.Element(ns + "modFrete")?.Value ?? "N/A";
            string? nfc_tra_plc = "N/A";
            string? nfc_tra_plc_uf = "N/A";
            string? nfc_tra_cnpj = doc.Descendants(ns + "transp").Descendants(ns + "transporta").FirstOrDefault()?.Element(ns + "CNPJ")?.Value ?? "N/A";
            string? nfc_tra_end = doc.Descendants(ns + "transp").Descendants(ns + "transporta").FirstOrDefault()?.Element(ns + "xEnder")?.Value ?? "N/A";
            string? nfc_tra_mun = doc.Descendants(ns + "transp").Descendants(ns + "transporta").FirstOrDefault()?.Element(ns + "xMun")?.Value ?? "N/A";
            string? nfc_tra_uf = doc.Descendants(ns + "transp").Descendants(ns + "transporta").FirstOrDefault()?.Element(ns + "UF")?.Value ?? "N/A";
            string? nfc_tra_ie = doc.Descendants(ns + "transp").Descendants(ns + "transporta").FirstOrDefault()?.Element(ns + "IE")?.Value ?? "N/A";
            string? nfc_vol_qtd = doc.Descendants(ns + "transp").Descendants(ns + "vol").FirstOrDefault()?.Element(ns + "qVol")?.Value ?? "N/A";
            string? nfc_vol_esp = "N/A";
            string? nfc_vol_mar = "N/A";
            string? nfc_vol_num = "N/A";
            string? nfc_vol_pbr = doc.Descendants(ns + "transp").Descendants(ns + "vol").FirstOrDefault()?.Element(ns + "pesoB")?.Value ?? "N/A";
            string? nfc_vol_plq = doc.Descendants(ns + "transp").Descendants(ns + "vol").FirstOrDefault()?.Element(ns + "pesoL")?.Value ?? "N/A";
            string? nfc_obs = doc.Descendants(ns + "infAdic").FirstOrDefault()?.Element(ns + "infCpl")?.Value ?? "N/A";
            string? nfc_emp_cod = "0";
            string? nfc_ped_cod = "0";
            string? nfc_end_nro = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "nro")?.Value ?? "N/A";
            string? nfc_end_cpl = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "xCpl")?.Value ?? "N/A";
            string? nfc_suf = "N/A";
            string? nfc_cod_mun = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "cMun")?.Value ?? "N/A";
            string? nfc_cod_pais = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "cPais")?.Value ?? "N/A";
            string? nfc_pais = doc.Descendants(ns + "emit").Descendants(ns + "enderEmit").FirstOrDefault()?.Element(ns + "xPais")?.Value ?? "N/A";
            string? nfc_eml = "N/A";
            string? nfc_val_trb = "N/A";
            string? nfc_dif_vld = "N/A";
            string? nfc_fcp_val = "N/A";

            string txtPath = "C:\\Users\\mikae\\desktop\\teste.txt";
            if (!File.Exists(txtPath))
            {
                using (TextWriter tW = new StreamWriter(txtPath))
                {
                    tW.WriteLine(nfc_mod);
                    tW.WriteLine(nfc_serie);
                    tW.WriteLine(nfc_numero);
                    tW.WriteLine(nfc_tipo);
                    tW.WriteLine(nfc_sit);
                    tW.WriteLine(nfc_natOp);
                    tW.WriteLine(nfc_cfo);
                    tW.WriteLine(nfc_ies);
                    tW.WriteLine(nfc_emi);
                    tW.WriteLine(nfc_sai);
                    tW.WriteLine(nfc_hor);
                    tW.WriteLine(nfc_nom);
                    tW.WriteLine(nfc_cnpj);
                    tW.WriteLine(nfc_end);
                    tW.WriteLine(nfc_bai);
                    tW.WriteLine(nfc_cep);
                    tW.WriteLine(nfc_mun);
                    tW.WriteLine(nfc_tel);
                    tW.WriteLine(nfc_uf);
                    tW.WriteLine(nfc_ie);
                    tW.WriteLine(nfc_fat);
                    tW.WriteLine(nfc_bas_icm);
                    tW.WriteLine(nfc_val_icm);
                    tW.WriteLine(nfc_bas_sub);
                    tW.WriteLine(nfc_val_sub);
                    tW.WriteLine(nfc_val_pro);
                    tW.WriteLine(nfc_val_fre);
                    tW.WriteLine(nfc_val_seg);
                    tW.WriteLine(nfc_val_out);
                    tW.WriteLine(nfc_val_tot);
                    tW.WriteLine(nfc_tra_nom);
                    tW.WriteLine(nfc_tra_fre);
                    tW.WriteLine(nfc_tra_plc);
                    tW.WriteLine(nfc_tra_plc_uf);
                    tW.WriteLine(nfc_tra_cnpj);
                    tW.WriteLine(nfc_tra_end);
                    tW.WriteLine(nfc_tra_mun);
                    tW.WriteLine(nfc_tra_uf);
                    tW.WriteLine(nfc_tra_ie);
                    tW.WriteLine(nfc_vol_qtd);
                    tW.WriteLine(nfc_vol_esp);
                    tW.WriteLine(nfc_vol_mar);
                    tW.WriteLine(nfc_vol_num);
                    tW.WriteLine(nfc_vol_pbr);
                    tW.WriteLine(nfc_vol_plq);
                    tW.WriteLine(nfc_obs);
                    tW.WriteLine(nfc_emp_cod);
                    tW.WriteLine(nfc_ped_cod);
                    tW.WriteLine(nfc_end_nro);
                    tW.WriteLine(nfc_end_cpl);
                    tW.WriteLine(nfc_suf);
                    tW.WriteLine(nfc_cod_mun);
                    tW.WriteLine(nfc_cod_pais);
                    tW.WriteLine(nfc_pais);
                    tW.WriteLine(nfc_eml);
                    tW.WriteLine(nfc_val_trb);
                    tW.WriteLine(nfc_dif_vld);
                    tW.WriteLine(nfc_fcp_val);
                }
                MessageBox.Show("Arquivo criado com sucesso!");
            }
            else
            {
                using (TextWriter tW = new StreamWriter(txtPath))
                {
                    tW.WriteLine(nfc_mod);
                    tW.WriteLine(nfc_serie);
                    tW.WriteLine(nfc_numero);
                    tW.WriteLine(nfc_tipo);
                    tW.WriteLine(nfc_sit);
                    tW.WriteLine(nfc_natOp);
                    tW.WriteLine(nfc_cfo);
                    tW.WriteLine(nfc_ies);
                    tW.WriteLine(nfc_emi);
                    tW.WriteLine(nfc_sai);
                    tW.WriteLine(nfc_hor);
                    tW.WriteLine(nfc_nom);
                    tW.WriteLine(nfc_cnpj);
                    tW.WriteLine(nfc_end);
                    tW.WriteLine(nfc_bai);
                    tW.WriteLine(nfc_cep);
                    tW.WriteLine(nfc_mun);
                    tW.WriteLine(nfc_tel);
                    tW.WriteLine(nfc_uf);
                    tW.WriteLine(nfc_ie);
                    tW.WriteLine(nfc_fat);
                    tW.WriteLine(nfc_bas_icm);
                    tW.WriteLine(nfc_val_icm);
                    tW.WriteLine(nfc_bas_sub);
                    tW.WriteLine(nfc_val_sub);
                    tW.WriteLine(nfc_val_pro);
                    tW.WriteLine(nfc_val_fre);
                    tW.WriteLine(nfc_val_seg);
                    tW.WriteLine(nfc_val_out);
                    tW.WriteLine(nfc_val_tot);
                    tW.WriteLine(nfc_tra_nom);
                    tW.WriteLine(nfc_tra_fre);
                    tW.WriteLine(nfc_tra_plc);
                    tW.WriteLine(nfc_tra_plc_uf);
                    tW.WriteLine(nfc_tra_cnpj);
                    tW.WriteLine(nfc_tra_end);
                    tW.WriteLine(nfc_tra_mun);
                    tW.WriteLine(nfc_tra_uf);
                    tW.WriteLine(nfc_tra_ie);
                    tW.WriteLine(nfc_vol_qtd);
                    tW.WriteLine(nfc_vol_esp);
                    tW.WriteLine(nfc_vol_mar);
                    tW.WriteLine(nfc_vol_num);
                    tW.WriteLine(nfc_vol_pbr);
                    tW.WriteLine(nfc_vol_plq);
                    tW.WriteLine(nfc_obs);
                    tW.WriteLine(nfc_emp_cod);
                    tW.WriteLine(nfc_ped_cod);
                    tW.WriteLine(nfc_end_nro);
                    tW.WriteLine(nfc_end_cpl);
                    tW.WriteLine(nfc_suf);
                    tW.WriteLine(nfc_cod_mun);
                    tW.WriteLine(nfc_cod_pais);
                    tW.WriteLine(nfc_pais);
                    tW.WriteLine(nfc_eml);
                    tW.WriteLine(nfc_val_trb);
                    tW.WriteLine(nfc_dif_vld);
                    tW.WriteLine(nfc_fcp_val);
                }
                MessageBox.Show("Arquivo atualizado com sucesso!");
            }
        }
        public void CreateSQL()
        {
            string query = "INSERT INTO NOTAS_COMRPAS" +
                "(NFC_COD, " +
                "NFC_MOD, " +
                "NFC_SER, " +
                "NFC_NRO, " +
                "NFC_TIP, " +
                "NFC_SIT, " +
                "NFC_NAT, " +
                "NFC_CFO, " +
                "NFC_IES, " +
                "NFC_EMI, " +
                "NFC_SAI, " +
                "NFC_HOR, " +
                "NFC_NOM, " +
                "NFC_CNPJ, " +
                "NFC_END, " +
                "NFC_BAI, " +
                "NFC_CEP, " +
                "NFC_MUN, " +
                "NFC_TEL, " +
                "NFC_UF, " +
                "NFC_IE, " +
                "NFC_FAT, " +
                "NFC_BAS_ICM, " +
                "NFC_VLR_ICM, " +
                "NFC_BAS_SUB, " +
                "NFC_VLR_SUB, " +
                "NFC_VLR_PRO, " +
                "NFC_VLR_FRE, " +
                "NFC_VLR_SEG, " +
                "NFC_VLR_OUT, " +
                "NFC_VLR_IPI, " +
                "NFC_VLR_TOT, " +
                "NFC_TRA_NOM, " +
                "NFC_TRA_FRE, " +
                "NFC_TRA_PLC, " +
                "NFC_TRA_PLC_UF, " +
                "NFC_TRA_CNPJ, " +
                "NFC_TRA_END, " +
                "NFC_TRA_MUN, " +
                "NFC_TRA_UF, " +
                "NFC_TRA_IE, " +
                "NFC_VOL_QTD, " +
                "NFC_VOL_ESP, " +
                "NFC_VOL_MAR, " +
                "NFC_VOL_NRO, " +
                "NFC_VOL_PBR, " +
                "NFC_VOL_PLQ, " +
                "NFC_OBS, " +
                "NFC_EMP_COD, " +
                "NFC_PED_COD, " +
                "NFC_END_NRO, " +
                "NFC_END_CPL, " +
                "NFC_SUF, " +
                "NFC_COD_MUN, " +
                "NFC_COD_PAIS, " +
                "NFC_PAIS, " +
                "NFC_EML, " +
                "NFC_VLR_TRB, " +
                "NFC_DIF_VLD, " +
                "NFC_FCP_VLR)" +
                "VALUES" +
                "(@valor_nfc_cod," +
                "@valor_nfc_mod," +
                "@valor_nfc_ser," +
                "@valor_nfc_nro," +
                "@valor_nfc_tip," +
                "@valor_nfc_sit," +
                "@valor_nfc_nat," +
                "@valor_nfc_cfo," +
                "@valor_nfc_ies," +
                "@valor_nfc_emi," +
                "@valor_nfc_sai," +
                "@valor_nfc_hor," +
                "@valor_nfc_nom," +
                "@valor_nfc_cnpj," +
                "@valor_nfc_end," +
                "@valor_nfc_bai," +
                "@valor_nfc_cep," +
                "@valor_nfc_mun," +
                "@valor_nfc_tel," +
                "@valor_nfc_uf," +
                "@valor_nfc_ie," +
                "@valor_nfc_fat," +
                "@valor_nfc_bas_icm," +
                "@valor_nfc_vlr_icm," +
                "@valor_nfc_bas_sub," +
                "@valor_nfc_vlr_sub," +
                "@valor_nfc_vlr_pro," +
                "@valor_nfc_vlr_fre," +
                "@valor_nfc_vlr_seg," +
                "@valor_nfc_vlr_out," +
                "@valor_nfc_vlr_ipi," +
                "@valor_nfc_vlr_tot," +
                "@valor_nfc_tra_nom," +
                "@valor_nfc_tra_fre," +
                "@valor_nfc_tra_plc," +
                "@valor_nfc_tra_plc_uf," +
                "@valor_nfc_tra_cnpj," +
                "@valor_nfc_tra_end," +
                "@valor_nfc_tra_mun," +
                "@valor_nfc_tra_uf," +
                "@valor_nfc_tra_ie," +
                "@valor_nfc_vol_qtd," +
                "@valor_nfc_vol_esp," +
                "@valor_nfc_vol_mar," +
                "@valor_nfc_vol_nro," +
                "@valor_nfc_vol_pbr," +
                "@valor_nfc_vol_plq," +
                "@valor_nfc_obs," +
                "@valor_nfc_emp_cod," +
                "@valor_nfc_ped_cod," +
                "@valor_nfc_end_nro," +
                "@valor_nfc_end_cpl," +
                "@valor_nfc_suf," +
                "@valor_nfc_cod_mun," +
                "@valor_nfc_cod_pais," +
                "@valor_nfc_pais," +
                "@valor_nfc_eml," +
                "@valor_nfc_vlr_trb," +
                "@valor_nfc_dif_vld," +
                "@valor_nfc_fcp_vlr);";

            SearchFiles sf = new();

            string[] files = sf.GetFiles();

            using (MySqlCommand cmd = new MySqlCommand())
            {
                cmd.Parameters.AddWithValue("@valor_nfc_cod", "SQ_NOTAS_FISCAIS.NEXTVAL");
                //cmd.Parameters.AddWithValue("@valor_nfc_mod", sf.GetFileData.nfc_mod);

            }
        }
    }
}

/*          BEGINTRANS
                                                                                                                                                                                           
            INSERT INTO NOTAS_COMPRAS ( NFC_COD, NFC_MOD, NFC_SER, NFC_NRO, NFC_TIP, NFC_SIT, NFC_NAT, NFC_CFO, NFC_IES, NFC_EMI, NFC_SAI, NFC_HOR, NFC_NOM, NFC_CNPJ, NFC_END, NFC_BAI, NFC_CEP, NFC_MUN, NFC_TEL, NFC_UF, NFC_IE, NFC_FAT, NFC_BAS_ICM, NFC_VLR_ICM, NFC_BAS_SUB, NFC_VLR_SUB, NFC_VLR_PRO, NFC_VLR_FRE, NFC_VLR_SEG, NFC_VLR_OUT, NFC_VLR_IPI, NFC_VLR_TOT, NFC_TRA_NOM, NFC_TRA_FRE, NFC_TRA_PLC, NFC_TRA_PLC_UF, NFC_TRA_CNPJ, NFC_TRA_END, NFC_TRA_MUN, NFC_TRA_UF, NFC_TRA_IE, NFC_VOL_QTD, NFC_VOL_ESP, NFC_VOL_MAR, NFC_VOL_NRO, NFC_VOL_PBR, NFC_VOL_PLQ, NFC_OBS, NFC_EMP_COD, NFC_PED_COD, NFC_END_NRO, NFC_END_CPL, NFC_SUF, NFC_COD_MUN, NFC_COD_PAIS, NFC_PAIS, NFC_EML, NFC_VLR_TRB, NFC_DIF_VLD, NFC_FCP_VLR) VALUES 
            (SQ_NOTAS_FISCAIS.NEXTVAL, '55', '2', 83439, '1', 'E', 'Venda de mercadorias', '', '', '13/12/2024', '13/12/2024', '', 'LUCAS MACACARI TURATTI', '47146743000138', 'Avenida Deputado Joao Lazaro de Almeida Prado', 'Jardim Novo Horizonte', '17209851', 'Jau', '0014996875104', 'SP', '401348078110', '', 0, 0, 0, 0, 149.99, 0, 0, 0, 0, 149.99, 'EBAZAR.COM.BR LTDA', 2, '', '', '', 'AVENIDA DAS NACOES UNIDAS 3000 3003', 'OSASCO', 'SP', '120519234116', '1', '', '', '', '1110', '1110', 'Mercadoria depositada na empresa EBAZAR.COM.BR LTDA, estabelecida na Via Parafuso, 51, Bairro Barro Duro, Lauro de Freitas, BA, CEP 42735100, inscrita no CNPJ/MF sob o n 03007331009793, Inscricao Estadual n 195222822, Autorizado conforme Regime Especial concedido nos termos do Parecer DITRI/GETRI n 3828/2022 Valor aproximado dos tributos (IBPT) R$93,83. Agradecemos pela preferencia, qualquer duvida entre em contato conosco estaremos felizes em atende-lo Lucas (14) 3626 2295',17066, '', '776', 'Nao consta', '', '3525300', '1058', 'Brasil', '', 0, 0, 0)

            INSERT INTO NOTAS_COMPRAS_ITENS ( NCI_NF_COD, NCI_ITEM, NCI_PRD_COD, NCI_DSC, NCI_CF, NCI_CST, NCI_UND, NCI_QTD, NCI_VLR_UNI, NCI_VLR_TOT, NCI_ICMS, NCI_VLR_ICM, NCI_IPI, NCI_VLR_IPI, NCI_VLR_CUS, NCI_ST_IVA, NCI_ST_BASE, NCI_ST_VLR, NCI_ST_ICMS, NCI_CFO, NCI_CRD_SN, NCI_VLR_SN, NCI_BAS_ICM, NCI_VLR_TRB, NCI_PRT_NUM, NCI_EAN, NCI_INF_ADC, NCI_CST_PIS, NCI_BAS_PIS, NCI_PER_PIS, NCI_VLR_PIS, NCI_BCP_PIS, NCI_ALQ_PIS, NCI_CST_COF, NCI_BAS_COF, NCI_PER_COF, NCI_VLR_COF, NCI_BCP_COF, NCI_ALQ_COF, NCI_DIF_BC, NCI_DIF_ALD, NCI_DIF_ALO, NCI_DIF_PAR, NCI_DIF_VLD, NCI_DIF_VLO, NCI_FCP_ALQ, NCI_FCP_VLR ) VALUES 
            (SQ_NOTAS_FISCAIS.CURRVAL, 1, 0, 'Vara Telescopica Molinete p/ 10 Lbs', '95071000', '2500', 'UN', 2, 29.6, 59.2, 0, 0, 0, 0, 0, 0, 0, 0, 0, '5106', 0, 0, 0, 0, 'JPTEL', '7892510500704', 'xPed:2000010159379834 Total aproximado de tributos federais, estaduais e municipais: R$39,54', '07', 0, 0, 0, 0, 0, '07', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 )
            INSERT INTO NOTAS_COMPRAS_ITENS ( NCI_NF_COD, NCI_ITEM, NCI_PRD_COD, NCI_DSC, NCI_CF, NCI_CST, NCI_UND, NCI_QTD, NCI_VLR_UNI, NCI_VLR_TOT, NCI_ICMS, NCI_VLR_ICM, NCI_IPI, NCI_VLR_IPI, NCI_VLR_CUS, NCI_ST_IVA, NCI_ST_BASE, NCI_ST_VLR, NCI_ST_ICMS, NCI_CFO, NCI_CRD_SN, NCI_VLR_SN, NCI_BAS_ICM, NCI_VLR_TRB, NCI_PRT_NUM, NCI_EAN, NCI_INF_ADC, NCI_CST_PIS, NCI_BAS_PIS, NCI_PER_PIS, NCI_VLR_PIS, NCI_BCP_PIS, NCI_ALQ_PIS, NCI_CST_COF, NCI_BAS_COF, NCI_PER_COF, NCI_VLR_COF, NCI_BCP_COF, NCI_ALQ_COF, NCI_DIF_BC, NCI_DIF_ALD, NCI_DIF_ALO, NCI_DIF_PAR, NCI_DIF_VLD, NCI_DIF_VLO, NCI_FCP_ALQ, NCI_FCP_VLR ) VALUES (SQ_NOTAS_FISCAIS.CURRVAL, 2, 0, 'Molinete De Pesca 1 Rolamento Central', '95073000', '2500', 'UN', 2, 24.67, 49.34, 0, 0, 0, 0, 0, 0, 0, 0, 0, '5106', 0, 0, 0, 0, 'JPMOL', 'SEM GTIN', 'xPed:2000010159379834 Total aproximado de tributos federais, estaduais e municipais: R$32,95', '07', 0, 0, 0, 0, 0, '07', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 )
            INSERT INTO NOTAS_COMPRAS_ITENS ( NCI_NF_COD, NCI_ITEM, NCI_PRD_COD, NCI_DSC, NCI_CF, NCI_CST, NCI_UND, NCI_QTD, NCI_VLR_UNI, NCI_VLR_TOT, NCI_ICMS, NCI_VLR_ICM, NCI_IPI, NCI_VLR_IPI, NCI_VLR_CUS, NCI_ST_IVA, NCI_ST_BASE, NCI_ST_VLR, NCI_ST_ICMS, NCI_CFO, NCI_CRD_SN, NCI_VLR_SN, NCI_BAS_ICM, NCI_VLR_TRB, NCI_PRT_NUM, NCI_EAN, NCI_INF_ADC, NCI_CST_PIS, NCI_BAS_PIS, NCI_PER_PIS, NCI_VLR_PIS, NCI_BCP_PIS, NCI_ALQ_PIS, NCI_CST_COF, NCI_BAS_COF, NCI_PER_COF, NCI_VLR_COF, NCI_BCP_COF, NCI_ALQ_COF, NCI_DIF_BC, NCI_DIF_ALD, NCI_DIF_ALO, NCI_DIF_PAR, NCI_DIF_VLD, NCI_DIF_VLO, NCI_FCP_ALQ, NCI_FCP_VLR ) VALUES (SQ_NOTAS_FISCAIS.CURRVAL, 3, 0, 'Isca Artificial Camarao para Pesca', '95071000', '2500', 'UN', 2, 1.235, 2.47, 0, 0, 0, 0, 0, 0, 0, 0, 0, '5106', 0, 0, 0, 0, 'CAMARAO-IA', '7899088205550', 'xPed:2000010159379834 Total aproximado de tributos federais, estaduais e municipais: R$1,65', '07', 0, 0, 0, 0, 0, '07', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 )
            INSERT INTO NOTAS_COMPRAS_ITENS ( NCI_NF_COD, NCI_ITEM, NCI_PRD_COD, NCI_DSC, NCI_CF, NCI_CST, NCI_UND, NCI_QTD, NCI_VLR_UNI, NCI_VLR_TOT, NCI_ICMS, NCI_VLR_ICM, NCI_IPI, NCI_VLR_IPI, NCI_VLR_CUS, NCI_ST_IVA, NCI_ST_BASE, NCI_ST_VLR, NCI_ST_ICMS, NCI_CFO, NCI_CRD_SN, NCI_VLR_SN, NCI_BAS_ICM, NCI_VLR_TRB, NCI_PRT_NUM, NCI_EAN, NCI_INF_ADC, NCI_CST_PIS, NCI_BAS_PIS, NCI_PER_PIS, NCI_VLR_PIS, NCI_BCP_PIS, NCI_ALQ_PIS, NCI_CST_COF, NCI_BAS_COF, NCI_PER_COF, NCI_VLR_COF, NCI_BCP_COF, NCI_ALQ_COF, NCI_DIF_BC, NCI_DIF_ALD, NCI_DIF_ALO, NCI_DIF_PAR, NCI_DIF_VLD, NCI_DIF_VLO, NCI_FCP_ALQ, NCI_FCP_VLR ) VALUES (SQ_NOTAS_FISCAIS.CURRVAL, 4, 0, 'Canivete com Lamina de Aco', '82119320', '2500', 'UN', 2, 3.945, 7.89, 0, 0, 0, 0, 0, 0, 0, 0, 0, '5106', 0, 0, 0, 0, 'CANIVETE', '7899088212374', 'xPed:2000010159379834 Total aproximado de tributos federais, estaduais e municipais: R$3,64', '07', 0, 0, 0, 0, 0, '07', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 )
            INSERT INTO NOTAS_COMPRAS_ITENS ( NCI_NF_COD, NCI_ITEM, NCI_PRD_COD, NCI_DSC, NCI_CF, NCI_CST, NCI_UND, NCI_QTD, NCI_VLR_UNI, NCI_VLR_TOT, NCI_ICMS, NCI_VLR_ICM, NCI_IPI, NCI_VLR_IPI, NCI_VLR_CUS, NCI_ST_IVA, NCI_ST_BASE, NCI_ST_VLR, NCI_ST_ICMS, NCI_CFO, NCI_CRD_SN, NCI_VLR_SN, NCI_BAS_ICM, NCI_VLR_TRB, NCI_PRT_NUM, NCI_EAN, NCI_INF_ADC, NCI_CST_PIS, NCI_BAS_PIS, NCI_PER_PIS, NCI_VLR_PIS, NCI_BCP_PIS, NCI_ALQ_PIS, NCI_CST_COF, NCI_BAS_COF, NCI_PER_COF, NCI_VLR_COF, NCI_BCP_COF, NCI_ALQ_COF, NCI_DIF_BC, NCI_DIF_ALD, NCI_DIF_ALO, NCI_DIF_PAR, NCI_DIF_VLD, NCI_DIF_VLO, NCI_FCP_ALQ, NCI_FCP_VLR ) VALUES (SQ_NOTAS_FISCAIS.CURRVAL, 5, 0, 'Saquinho com Acessorios De Pesca DUPLO', '95071000', '2500', 'UN', 1, 7.4, 7.4, 0, 0, 0, 0, 0, 0, 0, 0, 0, '5106', 0, 0, 0, 0, 'JP7137', '7899088233997', 'xPed:2000010159379834 Total aproximado de tributos federais, estaduais e municipais: R$4,94', '07', 0, 0, 0, 0, 0, '07', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 )
            INSERT INTO NOTAS_COMPRAS_ITENS ( NCI_NF_COD, NCI_ITEM, NCI_PRD_COD, NCI_DSC, NCI_CF, NCI_CST, NCI_UND, NCI_QTD, NCI_VLR_UNI, NCI_VLR_TOT, NCI_ICMS, NCI_VLR_ICM, NCI_IPI, NCI_VLR_IPI, NCI_VLR_CUS, NCI_ST_IVA, NCI_ST_BASE, NCI_ST_VLR, NCI_ST_ICMS, NCI_CFO, NCI_CRD_SN, NCI_VLR_SN, NCI_BAS_ICM, NCI_VLR_TRB, NCI_PRT_NUM, NCI_EAN, NCI_INF_ADC, NCI_CST_PIS, NCI_BAS_PIS, NCI_PER_PIS, NCI_VLR_PIS, NCI_BCP_PIS, NCI_ALQ_PIS, NCI_CST_COF, NCI_BAS_COF, NCI_PER_COF, NCI_VLR_COF, NCI_BCP_COF, NCI_ALQ_COF, NCI_DIF_BC, NCI_DIF_ALD, NCI_DIF_ALO, NCI_DIF_PAR, NCI_DIF_VLD, NCI_DIF_VLO, NCI_FCP_ALQ, NCI_FCP_VLR ) VALUES (SQ_NOTAS_FISCAIS.CURRVAL, 6, 0, 'Racao 50G', '23099010', '2500', 'UN', 1, 2.47, 2.47, 0, 0, 0, 0, 0, 0, 0, 0, 0, '5106', 0, 0, 0, 0, 'RACAO-50G', 'SEM GTIN', 'xPed:2000010159379834 Total aproximado de tributos federais, estaduais e municipais: R$0,90', '07', 0, 0, 0, 0, 0, '07', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 )
            INSERT INTO NOTAS_COMPRAS_ITENS ( NCI_NF_COD, NCI_ITEM, NCI_PRD_COD, NCI_DSC, NCI_CF, NCI_CST, NCI_UND, NCI_QTD, NCI_VLR_UNI, NCI_VLR_TOT, NCI_ICMS, NCI_VLR_ICM, NCI_IPI, NCI_VLR_IPI, NCI_VLR_CUS, NCI_ST_IVA, NCI_ST_BASE, NCI_ST_VLR, NCI_ST_ICMS, NCI_CFO, NCI_CRD_SN, NCI_VLR_SN, NCI_BAS_ICM, NCI_VLR_TRB, NCI_PRT_NUM, NCI_EAN, NCI_INF_ADC, NCI_CST_PIS, NCI_BAS_PIS, NCI_PER_PIS, NCI_VLR_PIS, NCI_BCP_PIS, NCI_ALQ_PIS, NCI_CST_COF, NCI_BAS_COF, NCI_PER_COF, NCI_VLR_COF, NCI_BCP_COF, NCI_ALQ_COF, NCI_DIF_BC, NCI_DIF_ALD, NCI_DIF_ALO, NCI_DIF_PAR, NCI_DIF_VLD, NCI_DIF_VLO, NCI_FCP_ALQ, NCI_FCP_VLR ) VALUES (SQ_NOTAS_FISCAIS.CURRVAL, 7, 0, 'Suporte Mini para Barranco', '95072000', '0102', 'UN', 2, 7.525, 15.05, 0, 0, 0, 0, 0, 0, 0, 0, 0, '5106', 0, 0, 0, 0, 'JP6571', '7899088212060', 'xPed:2000010159379834 Total aproximado de tributos federais, estaduais e municipais: R$7,24', '07', 0, 0, 0, 0, 0, '07', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 )
            INSERT INTO NOTAS_COMPRAS_ITENS ( NCI_NF_COD, NCI_ITEM, NCI_PRD_COD, NCI_DSC, NCI_CF, NCI_CST, NCI_UND, NCI_QTD, NCI_VLR_UNI, NCI_VLR_TOT, NCI_ICMS, NCI_VLR_ICM, NCI_IPI, NCI_VLR_IPI, NCI_VLR_CUS, NCI_ST_IVA, NCI_ST_BASE, NCI_ST_VLR, NCI_ST_ICMS, NCI_CFO, NCI_CRD_SN, NCI_VLR_SN, NCI_BAS_ICM, NCI_VLR_TRB, NCI_PRT_NUM, NCI_EAN, NCI_INF_ADC, NCI_CST_PIS, NCI_BAS_PIS, NCI_PER_PIS, NCI_VLR_PIS, NCI_BCP_PIS, NCI_ALQ_PIS, NCI_CST_COF, NCI_BAS_COF, NCI_PER_COF, NCI_VLR_COF, NCI_BCP_COF, NCI_ALQ_COF, NCI_DIF_BC, NCI_DIF_ALD, NCI_DIF_ALO, NCI_DIF_PAR, NCI_DIF_VLD, NCI_DIF_VLO, NCI_FCP_ALQ, NCI_FCP_VLR ) VALUES (SQ_NOTAS_FISCAIS.CURRVAL, 8, 0, 'Maleta Combat 5060 Preto', '95071000', '0102', 'UN', 1, 6.17, 6.17, 0, 0, 0, 0, 0, 0, 0, 0, 0, '5106', 0, 0, 0, 0, 'JP7778', '7899088234826', 'xPed:2000010159379834 Total aproximado de tributos federais, estaduais e municipais: R$2,97', '07', 0, 0, 0, 0, 0, '07', 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 )

            INSERT INTO NOTAS_COMPRAS_VENCIMENTOS ( NCV_COD, NCV_NF_COD, NCV_DTA_VCT, NCV_VLR) VALUES ( SQ_NOTAS_FISCALS_VENCIMENTOS.NEXTVAL, SQ_NOTAS_FISCAIS.CURRVAL,'13/12/2024', 149.99)

            INSERT INTO LANCAMENTOS (LAN_COD, LAN_DTA,LAN_DSC, LAN_VLR,LAN_PLC_CTA, LAN_STA,LAN_TIP_LAN, LAN_TIP_COD,LAN_CTB_COD, LAN_EMP_COD, LAN_VLR_SLD) VALUES (SQ_LANCAMENTOS.NEXTVAL, '13/12/2024','Compra NF: 83439', 149.99,'50101', 'PRV','CMP', SQ_NOTAS_FISCAIS.CURRVAL,0, 17066, 149.99)

            INSERT INTO FINANCEIRO (CODIGO, VENCIMENTO, DESCRICAO, DOCUMENTO,VALOR, LOJA, PAGO,CODPESSOA, EMISSAO, PAGREC) VALUES (SQ_FINANCEIRO.NEXTVAL, '13/12/2024', 'NET', '83439',149.99, '1', 'N',17066, '13/12/2024', 'P')

            INSERT INTO NOTAS_COMPRAS_NFE ( NCE_NF_IDE, NCE_RECIBO, NCE_RESULTADO, NCE_QUANDO, NCE_CHAVE, NCE_PROTOCOLO) VALUES ( SQ_NOTAS_FISCAIS.CURRVAL, '', '2024-12-13T09:19:52-03:00', SYSDATE, '35241247146743000138550020000834391773615140', '135242921781363')

            COMMIT*/