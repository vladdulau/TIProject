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
        Session["parola"] = null;

        if (!IsPostBack)
        {
            Label1.Text = DateTime.Now.ToString();
            Image1.ImageUrl = "~/Images/1.jpg";
        }
       
        
    }

    protected void Timer2_Tick(object sender, EventArgs e)
    {
        var imageUrl= Image1.ImageUrl.ToString();
        Label1.Text = DateTime.Now.ToString();

        if (imageUrl == "~/Images/1.jpg")
            imageUrl = "~/Images/2.jpg";

        if (imageUrl == "~/Images/2.jpg")
            imageUrl = "~/Images/3.jpg";

        if (imageUrl == "~/Images/3.jpg")
            imageUrl = "~/Images/4.jpg";

        if (imageUrl == "~/Images/4.jpg")
            imageUrl = "~Images/1.jpg";

        
        Random random = new Random();
        int i = random.Next(1, 4);
        Image1.ImageUrl = "~/Images/" + i.ToString() + ".jpg";
    }
}