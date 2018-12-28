using CrystalDecisions.CrystalReports.Engine;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class TiparireStatPlata : System.Web.UI.Page
{

    OracleConnection conn;
    OracleCommand command;
    OracleDataAdapter dataAdapter;
    DataSet dataSet;

    string query = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, TOTAL_BRUT, BRUT_IMPOZITABIL, CAS, CASS, IMPOZIT, RETINERI, VIRAT_CARD FROM ANGAJATI ORDER BY NR_CRT";


    protected void Page_Load(object sender, EventArgs e)
    {
        Session["parola"] = null;

        if (!Page.IsPostBack)
        {
            try
            {
                if (conn == null || conn.State.Equals(ConnectionState.Closed))
                {
                    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    conn.Open();
                }

                command = new OracleCommand(query, conn);
                dataAdapter = new OracleDataAdapter(command);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "ANGAJATI");

                var raport = new ReportDocument();

                var path = Server.MapPath("CrystalReport.rpt");
                raport.Load(path);
                raport.SetDataSource(dataSet.Tables["ANGAJATI"]);
                CrystalReportViewer1.ReportSource = raport;
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }

    protected void buttonExporta_Click(object sender, EventArgs e)
    {
        try
        {
            if (conn == null || conn.State.Equals(ConnectionState.Closed))
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();
            }

            command = new OracleCommand(query, conn);
            dataAdapter = new OracleDataAdapter(command);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "ANGAJATI");

            var raport = new ReportDocument();

            var path = Server.MapPath("CrystalReport.rpt");
            raport.Load(path);
            raport.SetDataSource(dataSet.Tables["ANGAJATI"]);
            CrystalReportViewer1.ReportSource = raport;

            string raportName = textRaport.Text == null ? "stat-plata-" : textRaport.Text + "-";
            raport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, raportName);


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
        finally
        {
            conn.Close();
        }
    }
}