using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ModificareTaxe : System.Web.UI.Page
{
    OracleConnection conn;
    OracleCommand command;
    OracleDataAdapter dataAdapter;
    DataSet dataSet;

    string query = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            try
            {
                if (Session["parola"] != null)
                {
                    string parolaAdaugata = Session["parola"].ToString();
                    string parolaActuala = null;

                    query = "SELECT PAROLA FROM VALORI_TAXE";

                    if (conn == null || conn.State.Equals(ConnectionState.Closed))
                    {
                        conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                        conn.Open();
                    }
                    command = new OracleCommand(query, conn);

                    OracleDataReader queryResult = command.ExecuteReader();

                    try
                    {
                        while (queryResult.Read())
                        {
                            parolaActuala = queryResult.GetValue(0).ToString();
                        }
                    }

                    finally
                    {
                        queryResult.Close();
                    }
                    if (parolaAdaugata.Equals(parolaActuala))
                    {
                        try
                        {
                            query = "SELECT CAS, CASS, IMPOZIT FROM VALORI_TAXE";
                            command = new OracleCommand(query, conn);
                            dataAdapter = new OracleDataAdapter(command);
                            dataSet = new DataSet();

                            dataAdapter.Fill(dataSet, "VALORI_TAXE");
                            //this.gridSalarii.DataSource = dataSet.Tables["VALORI_TAXE"].DefaultView;
                            //gridSalarii.DataBind();

                            query = "SELECT CAS, CASS, IMPOZIT FROM VALORI_TAXE";
                            conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                            conn.Open();
                            command = new OracleCommand(query, conn);

                            queryResult = command.ExecuteReader();

                            try
                            {
                                while (queryResult.Read())
                                {
                                    this.CAS.Text = queryResult.GetValue(0).ToString();
                                    this.CASS.Text = queryResult.GetValue(1).ToString();
                                    this.IMPOZIT.Text = queryResult.GetValue(2).ToString();
                                }
                            }
                            finally
                            {
                                conn.Close();
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
                    else
                    {
                        Server.Transfer("~/ActualizareTaxe.aspx");
                    }
                }
                else
                {
                    Server.Transfer("~/ActualizareTaxe.aspx");
                }
            }
            catch (Exception ex)
            {
            }
        }
    }

    protected void btnRenunta_Click(object sender, EventArgs e)
    {
        try
        {
            if (conn == null || conn.State.Equals(ConnectionState.Closed))
            {
                query = "SELECT CAS, CASS, IMPOZIT FROM VALORI_TAXE";
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();
                command = new OracleCommand(query, conn);

                OracleDataReader result = command.ExecuteReader();
                try
                {
                    while (result.Read())
                    {
                        CAS.Text = result.GetValue(0).ToString();
                        CASS.Text = result.GetValue(1).ToString();
                        IMPOZIT.Text = result.GetValue(2).ToString();
                    }
                }
                finally
                {
                    result.Close();
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

    protected void btnSalveaza_Click(object sender, EventArgs e)
    {
        if (this.CAS.Text == null || this.CAS.Text == "" || this.CASS.Text == null || this.CASS.Text == "" || this.IMPOZIT.Text == null || this.IMPOZIT.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nu modificat valorile');", true);
        }
        else
        {
            float cas = float.Parse(this.CAS.Text);
            float cass = float.Parse(this.CASS.Text);
            float impozit = float.Parse(this.IMPOZIT.Text);

            try
            {
                if (conn == null || conn.State.Equals(ConnectionState.Closed))
                {
                    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    conn.Open();

                    query = "UPDATE VALORI_TAXE SET CAS=" + cas + ",CASS=" + cass + ", IMPOZIT=" + impozit + "WHERE NR_CRT=1";

                    command = new OracleCommand(query, conn);
                    command.ExecuteNonQuery();


                    query = "SELECT CAS, CASS, IMPOZIT FROM VALORI_TAXE";
                    conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                    conn.Open();

                    command = new OracleCommand(query, conn);

                    OracleDataReader result = command.ExecuteReader();
                    try
                    {
                        while (result.Read())
                        {
                            this.CAS.Text = result.GetValue(0).ToString();
                            this.CASS.Text = result.GetValue(1).ToString();
                            this.IMPOZIT.Text = result.GetValue(2).ToString();
                        }
                    }
                    finally
                    {
                        result.Close();
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
    }

    protected void savePassword_Click(object sender, EventArgs e)
    {
        try
        {
            if (conn == null || conn.State.Equals(ConnectionState.Closed))
            {
                conn = new OracleConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();

            }
            string parola = null;

            query = "SELECT PAROLA FROM VALORI_TAXE WHERE NR_CRT=1";
            command = new OracleCommand(query, conn);
            OracleDataReader result = command.ExecuteReader();
            try
            {
                while (result.Read())
                {
                    parola = result.GetValue(0).ToString();

                }

            }
            finally
            {
                result.Close();
            }

            if (parola != null && oldPassword.Text != null && oldPassword.Text != "" && newPassword.Text != null && newPassword.Text != "" && oldPassword.Text.Equals(parola))
            {
                query = "UPDATE VALORI_TAXE SET PAROLA=\'" + this.newPassword.Text + "\' WHERE NR_CRT=1";
                command = new OracleCommand(query, conn);
                command.ExecuteNonQuery();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Actualizarea parolei nu a fost efectuata cu succes');", true);
                oldPassword.Text = "";
                newPassword.Text = "";
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

    protected void endPassword_Click(object sender, EventArgs e)
    {
        oldPassword.Text = "";
        newPassword.Text = "";
    }
}