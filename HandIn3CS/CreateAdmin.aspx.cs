using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

namespace HandIn3CS
{
    public partial class CreateAdmin : System.Web.UI.Page
    {
        ArrayList adminlist;
        int userlevel;
        int staffnumber;
        string role;

        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Cache.SetNoStore();

            try
            {
                userlevel = (int)Session["Level"];
                staffnumber = (int)Session["StaffNumber"];
                role = (string)Session["Role"];
            }
            catch (NullReferenceException nre)
            {
                userlevel = 0;
                Session["Level"] = userlevel;
                LabelMessage.Text = nre.Message;
            }
            finally
            {
                SetLevelOrError();
            }

            adminlist = (ArrayList)Application["myadminlist"];

            int maxstaffnumber = 0;

            if (adminlist == null)
            {
                adminlist = new ArrayList();
                maxstaffnumber = maxstaffnumber + 1;
                TextBoxStaffNumber.Text = maxstaffnumber.ToString();
            }
            else
            {
                foreach (Administrator a in adminlist)
                {
                    if (a.StaffNumber > maxstaffnumber)
                    {
                        maxstaffnumber = a.StaffNumber;
                    }
                }
                maxstaffnumber = maxstaffnumber + 1;
                TextBoxStaffNumber.Text = maxstaffnumber.ToString();
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            //create admin
            Administrator a = new Administrator((Convert.ToInt32(TextBoxStaffNumber.Text)), TextBoxName.Text, TextBoxGender.Text, TextBoxPassword.Text, TextBoxEmail.Text, "Administrator", (Convert.ToInt32(TextBoxLevel.Text)));

            string email = a.Email;

            if (a.ChangeEmail(email) == "ok")
            {
                //add to coachlist
                adminlist.Add(a);
                Application.Set("myadminlist", adminlist);


                LabelMessage.Text = "New administrator added";

                TextBoxStaffNumber.Text = "";
                TextBoxName.Text = "";
                TextBoxGender.Text = "";
                TextBoxPassword.Text = "";
                TextBoxEmail.Text = "";
                TextBoxLevel.Text = "";

                Response.Redirect("DisplayAdmin.aspx");
            }
            else
            {
                LabelMessage.Text = "Error in email format";
            }                                                
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayAdmin.aspx");
        }

        private void SetLevelOrError()
        {
            if (userlevel == 1)
            {
                LabelUserLevel.Text = "You are logged in as an administrator ";
            }
            else
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}