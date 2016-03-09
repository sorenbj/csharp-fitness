using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;

namespace HandIn3CS
{
    public partial class UpdateCoach : System.Web.UI.Page
    {
        ArrayList coachlist;
        int userlevel;
        int staffnumber;
        string role;

        protected void Page_Load(object sender, EventArgs e)
        {
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

            if (Application["mycoachlist"] == null)
            {
                coachlist = new ArrayList();
                Application["mycoachlist"] = coachlist;
            }
            else
            {
                coachlist = (ArrayList)Application["mycoachlist"];  // type casting
            }

            if (!Page.IsPostBack)
            {
                if (coachlist.Count == 0)
                {
                    LabelMessage.Text = "No Coaches";
                    ButtonUpdate.Enabled = false;
                }
                else
                {
                    ButtonUpdate.Enabled = false;
                    FillTextBoxes(coachlist);
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LabelMessage.Text = "";

            foreach (Coach c in coachlist)
            {
                if (c.StaffNumber == staffnumber)
                {
                    string email = TextBoxEmail.Text;

                    if (email.Trim().EndsWith("@fitness.dk"))
                    {
                        c.StaffNumber = Convert.ToInt32(TextBoxStaffNumber.Text);
                        c.Name = TextBoxName.Text;
                        c.Gender = TextBoxGender.Text;
                        c.Password = TextBoxPassword.Text;
                        c.Email = TextBoxEmail.Text;
                        c.EventType = TextBoxEvent.Text;
                        c.Role = "Coach";
                        LabelMessage.Text = "Coach updated";
                        Response.Redirect("DisplayCoach.aspx");
                    }
                    else
                    {
                        LabelMessage.Text = "Error in email format";
                    }
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("DisplayCoach.aspx");
        }

        private void SetLevelOrError()
        {
            if (userlevel == 2)
            {
                LabelUserLevel.Text = "You are logged in as an coach ";
            }
            else
            {
                Response.Redirect("ErrorPage.aspx");
            }
        }

        private void FillTextBoxes(ArrayList coachlist)
        {
            foreach (Coach c in coachlist)
            {
                if (c.StaffNumber == staffnumber)
                {
                    TextBoxStaffNumber.Text = c.StaffNumber.ToString();
                    TextBoxName.Text = c.Name;
                    TextBoxGender.Text = c.Gender;
                    TextBoxPassword.Text = c.Password;
                    TextBoxEmail.Text = c.Email;
                    TextBoxEvent.Text = c.EventType.ToString();
                    LabelMessage.Text = "";
                    ButtonUpdate.Enabled = true;
                }
            }
        }
    }
}