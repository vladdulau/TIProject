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

public partial class TiparireFluturas : System.Web.UI.Page
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

                DBQuery.Text = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, TOTAL_BRUT, BRUT_IMPOZITABIL, CAS, CASS, IMPOZIT, RETINERI, VIRAT_CARD FROM ANGAJATI ORDER BY NR_CRT";
                command = new OracleCommand(DBQuery.Text, conn);
                dataAdapter = new OracleDataAdapter(command);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "ANGAJATI");
                gridSalarii.DataSource = dataSet.Tables["ANGAJATI"].DefaultView;
                gridSalarii.DataBind();

                var raport = new ReportDocument();

                var path = Server.MapPath("CrystalReport2.rpt");
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

    protected void gridSalarii_PageIndexChanging1(object sender, GridViewPageEventArgs e)
    {

        try
        {
            if (conn == null || conn.State.Equals(ConnectionState.Closed))
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();
                command = new OracleCommand(query, conn);
                dataAdapter = new OracleDataAdapter(command);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Angajati");
                this.gridSalarii.DataSource = dataSet.Tables["Angajati"].DefaultView;
                this.gridSalarii.PageIndex = e.NewPageIndex;
                gridSalarii.DataBind();
            }
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

    protected void BTN_EXPORTA_Click(object sender, EventArgs e)
    {

        try
        {
            if (conn == null || conn.State.Equals(ConnectionState.Closed))
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();
            }

            command = new OracleCommand(DBQuery.Text, conn);
            dataAdapter = new OracleDataAdapter(command);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "ANGAJATI");
            gridSalarii.DataSource = dataSet.Tables["ANGAJATI"].DefaultView;
            gridSalarii.DataBind();

            var raport = new ReportDocument();

            var path = Server.MapPath("CrystalReport2.rpt");
            raport.Load(path);
            raport.SetDataSource(dataSet.Tables["ANGAJATI"]);
            CrystalReportViewer1.ReportSource = raport;

            string numeRaport = NUME_RAPORT.Text == null ? "fluturas-" : NUME_RAPORT.Text;
            raport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, numeRaport);

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

    protected void buttonRenunta_Click(object sender, EventArgs e)
    {
        NUME_RAPORT.Text = "";
        textCauta.Text = "";

        DBQuery.Text = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, TOTAL_BRUT, BRUT_IMPOZITABIL, CAS, CASS, IMPOZIT, RETINERI, VIRAT_CARD FROM ANGAJATI ORDER BY NR_CRT";

        try
        {
            if (conn == null || conn.State.Equals(ConnectionState.Closed))
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();

                command = new OracleCommand(DBQuery.Text, conn);
                dataAdapter = new OracleDataAdapter(command);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "ANGAJATI");
                gridSalarii.DataSource = dataSet.Tables["ANGAJATI"].DefaultView;
                gridSalarii.DataBind();

                var raport = new ReportDocument();

                var path = Server.MapPath("CrystalReport2.rpt");
                raport.Load(path);
                raport.SetDataSource(dataSet.Tables["ANGAJATI"]);
                CrystalReportViewer1.ReportSource = raport;

                string numeRaport = NUME_RAPORT.Text == null ? "fluturas-" : NUME_RAPORT.Text;
                raport.ExportToHttpResponse(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, Response, true, numeRaport);

            }
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

    protected void buttonCauta_Click(object sender, EventArgs e)
    {
        var searchText = textCauta.Text;

        DBQuery.Text = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, TOTAL_BRUT, BRUT_IMPOZITABIL, CAS, CASS, IMPOZIT, RETINERI, VIRAT_CARD FROM ANGAJATI WHERE LOWER(NUME) LIKE LOWER(\'%" + searchText + "%\') OR LOWER(PRENUME) LIKE LOWER(\'%" + searchText + "%\') OR LOWER(FUNCTIE) LIKE LOWER(\'%" + searchText + "%\')";
        try
        {
            if (conn == null || conn.State.Equals(ConnectionState.Closed))
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();

                command = new OracleCommand(DBQuery.Text, conn);
                dataAdapter = new OracleDataAdapter(command);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "ANGAJATI");
                gridSalarii.DataSource = dataSet.Tables["ANGAJATI"].DefaultView;
                gridSalarii.DataBind();

                var raport = new ReportDocument();

                var path = Server.MapPath("CrystalReport2.rpt");
                raport.Load(path);
                raport.SetDataSource(dataSet.Tables["ANGAJATI"]);
                CrystalReportViewer1.ReportSource = raport;

            }
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

    protected void gridSalarii_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int nr_crt = Int32.Parse(gridSalarii.Rows[e.NewSelectedIndex].Cells[1].Text);

        DBQuery.Text = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, TOTAL_BRUT, BRUT_IMPOZITABIL, CAS, CASS, IMPOZIT, RETINERI, VIRAT_CARD FROM ANGAJATI WHERE  NR_CRT="+nr_crt+ "ORDER BY NR_CRT";

        try
        {
            if (conn == null || conn.State.Equals(ConnectionState.Closed))
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();

                command = new OracleCommand(DBQuery.Text, conn);
                dataAdapter = new OracleDataAdapter(command);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "ANGAJATI");
                gridSalarii.DataSource = dataSet.Tables["ANGAJATI"].DefaultView;
                gridSalarii.DataBind();

                var raport = new ReportDocument();

                var path = Server.MapPath("CrystalReport2.rpt");
                raport.Load(path);
                raport.SetDataSource(dataSet.Tables["ANGAJATI"]);
                CrystalReportViewer1.ReportSource = raport;

            }
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