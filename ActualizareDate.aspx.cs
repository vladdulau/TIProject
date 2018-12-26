using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActualizareDate : System.Web.UI.Page
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
                if(conn == null || conn.State.Equals(ConnectionState.Closed)){
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



    protected void gridSalarii_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void buttonCauta_Click(object sender, EventArgs e)
    {
        var searchText = this.textCauta.Text;

        query = "SELECT NR_CRT, NUME, PRENUME, FUNCTIE FROM ANGAJATI WHERE LOWER(NUME) LIKE LOWER(\'%" + searchText + "%\') OR LOWER(PRENUME) LIKE LOWER(\'%" + searchText + "%\') OR LOWER(FUNCTIE) LIKE LOWER(\'%" + searchText + "%\')" ;

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