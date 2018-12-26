using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ActualizareTaxe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void buttonCauta_Click(object sender, EventArgs e)
    {
        if(this.textCauta.Text == null || this.textCauta.Text == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Nu ati introdus parola');", true);
        }
        else
        {
            Session["parola"] = this.textCauta.Text;
            if (Page.IsValid)
            {
                Server.Transfer("ModificareTaxe.aspx");
            }
        }
    }
}