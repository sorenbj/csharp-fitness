using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

namespace HandIn3CS
{
    public partial class CreateCoach : System.Web.UI.Page
    {
        ArrayList coachlist;
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

            coachlist = (ArrayList)Application["mycoachlist"];

            int maxstaffnumber = 100;

            if (coachlist == null)
            {
                coachlist = new ArrayList();
                maxstaffnumber = maxstaffnumber + 1;
                TextBoxStaffNumber.Text = maxstaffnumber.ToString();
            }
            else
            {
                foreach (Coach c in coachlist)
                {
                    if (c.StaffNumber > maxstaffnumber)
                    {
                        maxstaffnumber = c.StaffNumber;
                    }
                }
                maxstaffnumber = maxstaffnumber + 1;
                TextBoxStaffNumber.Text = maxstaffnumber.ToString();
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {            
            

            //create coach
            Coach c = new Coach((Convert.ToInt32(TextBoxStaffNumber.Text)), TextBoxName.Text, TextBoxGender.Text, TextBoxPassword.Text, TextBoxEmail.Text, "Coach", TextBoxEvent.Text);
            string email = c.Email;

            if (email.Trim().EndsWith("@fitness.dk"))
            {
                //add to coachlist
                coachlist.Add(c);
                Application.Set("mycoachlist", coachlist);

                TextBoxStaffNumber.Text = "";
                TextBoxName.Text = "";
                TextBoxGender.Text = "";
                TextBoxPassword.Text = "";
                TextBoxEmail.Text = "";
                TextBoxEvent.Text = "";

                Response.Redirect("DisplayCoach.aspx");
            }
            else
            {
                LabelMessage.Text = "Error in email format";
            }           
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayCoach.aspx");
        }

        private void SetLevelOrError()
        {
            if (userlevel == 1)
            {
                LabelUserLevel.Text = "You are logged in as an administrator ";
            }
            else if (userlevel == 2)
            {
                LabelUserLevel.Text = "You are logged in as a coach ";
            }
            else
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }
    }
}