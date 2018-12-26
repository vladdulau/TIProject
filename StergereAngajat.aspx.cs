using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class StergereAngajat : System.Web.UI.Page
{
    OracleConnection conn;
    OracleCommand command;
    OracleDataAdapter dataAdapter;
    DataSet dataSet;

    string query = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE FROM ANGAJATI ORDER BY NR_CRT";

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
                    command = new OracleCommand(query, conn);
                    dataAdapter = new OracleDataAdapter(command);
                    dataSet = new DataSet();

                    dataAdapter.Fill(dataSet, "Angajati");
                    this.gridSalarii.DataSource = dataSet.Tables["Angajati"].DefaultView;
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
    }

    protected void buttonCauta_Click(object sender, EventArgs e)
    {

        var searchText = this.textCauta.Text;

        query = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE FROM ANGAJATI WHERE LOWER(NUME) LIKE LOWER(\'%" + searchText + "%\') OR LOWER(PRENUME) LIKE LOWER(\'%" + searchText + "%\') OR LOWER(FUNCTIE) LIKE LOWER(\'%" + searchText + "%\')";

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

    public void cleanAllFields()
    {
        this.textCauta.Text = "";
        this.NUME.Text = "";
        this.PRENUME.Text = "";
        this.FUNCTIE.Text = "";
        this.SALAR_BAZA.Text = "";
        this.SPOR.Text = "";
        this.PREMII_BRUTE.Text = "";
        this.RETINERI.Text = "";
    }

    protected void gridSalarii_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        int nr_crt = Int32.Parse(this.gridSalarii.Rows[e.NewSelectedIndex].Cells[1].Text);

        string queryCautare = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, TOTAL_BRUT, BRUT_IMPOZITABIL, IMPOZIT, CAS, CASS, RETINERI, VIRAT_CARD FROM ANGAJATI WHERE NR_CRT=" + nr_crt + "ORDER BY NR_CRT";

        try
        {
            if (conn == null || conn.State.Equals(ConnectionState.Closed))
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();
                command = new OracleCommand(queryCautare, conn);

                OracleDataReader queryResult = command.ExecuteReader();

                try
                {
                    while (queryResult.Read())
                    {
                        this.NR_CRT.Text = queryResult.GetValue(0).ToString();
                        this.NUME.Text = queryResult.GetValue(1).ToString();
                        this.PRENUME.Text = queryResult.GetValue(2).ToString();
                        this.FUNCTIE.Text = queryResult.GetValue(3).ToString();
                        this.SALAR_BAZA.Text = queryResult.GetValue(4).ToString();
                        this.SPOR.Text = queryResult.GetValue(5).ToString();
                        this.PREMII_BRUTE.Text = queryResult.GetValue(6).ToString();
                        this.TOTAL_BRUT.Text = queryResult.GetValue(7).ToString();
                        this.BRUT_IMPOZITABIL.Text = queryResult.GetValue(8).ToString();
                        this.IMPOZIT.Text = queryResult.GetValue(9).ToString();
                        this.CAS.Text = queryResult.GetValue(10).ToString();
                        this.CASS.Text = queryResult.GetValue(11).ToString();
                        this.RETINERI.Text = queryResult.GetValue(12).ToString();
                        this.VIRAT_CARD.Text = queryResult.GetValue(13).ToString();


                    }
                }
                finally
                {
                    queryResult.Close();
                }

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

    protected void buttonRenunta_Click(object sender, EventArgs e)
    {
        cleanAllFields();

        query = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE FROM ANGAJATI ORDER BY NR_CRT";

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

    protected void gridSalarii_PageIndexChanging(object sender, GridViewPageEventArgs e)
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


    protected void buttonStergere_Click(object sender, EventArgs e)
    {
        if(this.NR_CRT.Text == null || this.NR_CRT.Text== "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nu ati ales un angajat');", true);
        }
        else
        {
            int nr_crt = Int32.Parse(this.NR_CRT.Text);
            query = "DELETE FROM ANGAJATI WHERE NR_CRT=" + nr_crt;
            try
            {
                if (conn == null || conn.State.Equals(ConnectionState.Closed))
                {
                    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    conn.Open();
                    command = new OracleCommand(query, conn);
                }

                command.ExecuteNonQuery();

                query = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE FROM ANGAJATI ORDER BY NR_CRT";
                command = new OracleCommand(query, conn);
                dataAdapter = new OracleDataAdapter(command);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "Angajati");
                this.gridSalarii.DataSource = dataSet.Tables["Angajati"].DefaultView;
                gridSalarii.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            cleanAllFields();
        }
    }
}