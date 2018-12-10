using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Label1.Text = DateTime.Now.ToString();
            Image1.ImageUrl = "~/Images/payment.jpg";
        }
       
        
    }

    protected void Timer2_Tick(object sender, EventArgs e)
    {
        Label1.Text = DateTime.Now.ToString();

        if (Image1.ImageUrl == "~/Images/payment.jpg")
        {
            Image1.ImageUrl = "~/Images/salary.jpg";
        }
        else
        {
            Image1.ImageUrl = "~/Images/payment.jpg";
        }
    }
}