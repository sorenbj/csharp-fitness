using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

namespace HandIn3CS
{
    public partial class Login : System.Web.UI.Page
    {
        ArrayList adminlist;
        ArrayList coachlist;
        int userlevel;
        int staffnumber;
        string role;

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelMessage.Text = "";

            try
            {
                adminlist = FileUtility.ReadFile(Server.MapPath("~/App_Data/Admfile.ser"));
                Application["myadminlist"] = adminlist;

                coachlist = FileUtility.ReadFile(Server.MapPath("~/App_Data/Coachfile.ser"));
                Application["mycoachlist"] = coachlist;
            }
            catch (Exception ex)
            {
                LabelMessage.Text = ex.Message;
            }
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            userlevel = 0;
            Session["Level"] = userlevel;
            LabelMessage.Text = "You are logged out";
            Response.Redirect("Welcome.aspx");
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

            foreach (Coach c in coachlist)
            {
                if ((c.Email == TextBoxEmail.Text) && (c.Password == TextBoxPassword.Text))
                {
                    userlevel = 2;
                    Session["Level"] = userlevel;
                    staffnumber = c.StaffNumber;
                    Session["StaffNumber"] = staffnumber;
                    role = c.Role;
                    Session["Role"] = role;
                    Response.Redirect("Welcome.aspx");
                }
                else
                {
                    foreach (Administrator a in adminlist)
                    {
                        if ((a.Email == TextBoxEmail.Text) && (a.Password == TextBoxPassword.Text))
                        {
                            userlevel = 1;
                            Session["Level"] = userlevel;
                            staffnumber = a.StaffNumber;
                            Session["StaffNumber"] = staffnumber;
                            role = a.Role;
                            Session["Role"] = role;
                            Response.Redirect("Welcome.aspx");
                        }
                        else
                        {
                            LabelMessage.Text = "You are not a registred user";
                        }
                    }
                }
            }
        }
    }
}