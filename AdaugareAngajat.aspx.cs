using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdaugareAngajat : System.Web.UI.Page
{
    OracleConnection conn;
    OracleCommand command;
    OracleDataAdapter dataAdapter;
    DataSet dataSet;

    string query = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE FROM ANGAJATI ORDER BY NR_CRT";

    protected void Page_Load(object sender, EventArgs e)
    {
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



    

    protected void buttonAdauga_Click(object sender, EventArgs e)
    {
        if (this.NUME.Text == null || this.NUME.Text == "" || this.PRENUME.Text == null || this.PRENUME.Text == "" || this.FUNCTIE.Text == null || this.FUNCTIE.Text == ""
            || this.SALAR_BAZA.Text == null || this.SALAR_BAZA.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Completati toate campurile pentru a adauga un angajat');", true);
        }
        else
        {
            string nume = this.NUME.Text;
            string prenume = this.PRENUME.Text;
            string functie = this.FUNCTIE.Text;
            decimal salar_baza = Decimal.Parse(this.SALAR_BAZA.Text);
            decimal spor = this.SPOR.Text == null || this.SPOR.Text == "" ? 0 : Decimal.Parse(this.SPOR.Text);
            decimal premii_brute = this.PREMII_BRUTE.Text == null || this.PREMII_BRUTE.Text == "" ? 0 : Decimal.Parse(this.PREMII_BRUTE.Text);
            decimal retineri = this.RETINERI.Text == null || this.RETINERI.Text == "" ? 0 : Decimal.Parse(this.RETINERI.Text);

            try
            {
                if (conn == null || conn.State.Equals(ConnectionState.Closed))
                {
                    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    conn.Open();
                    query = "INSERT INTO ANGAJATI (NUME, PRENUME, FUNCTIE, SALAR_BAZA, SPOR, PREMII_BRUTE, RETINERI) VALUES( \'" + nume + "\',\'" + prenume + "\',\'" + functie + "\'," + salar_baza + ", " + spor + ", " + premii_brute + ", " + retineri + ")";

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