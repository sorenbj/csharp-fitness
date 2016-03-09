using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Collections;
using System.Data;

namespace HandIn3CS
{
    public partial class UpdateAdmin : System.Web.UI.Page
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

            if (Application["myadminlist"] == null)
            {
                adminlist = new ArrayList();
                Application["myadminlist"] = adminlist;
            }
            else
            {
                adminlist = (ArrayList)Application["myadminlist"];  // type casting
            }

            if (!Page.IsPostBack)
            {
                if (adminlist.Count == 0)
                {
                    LabelMessage.Text = "No Administrators";
                    ButtonUpdate.Enabled = false;
                }
                else
                {
                    ButtonUpdate.Enabled = false;
                    FillTextBoxes(adminlist);
                }
            }
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            LabelMessage.Text = "";

            foreach (Administrator a in adminlist)
            {
                if (a.StaffNumber == staffnumber)
                {
                    string email = TextBoxEmail.Text;

                    if (a.ChangeEmail(email) == "ok")
                    {
                        a.StaffNumber = Convert.ToInt32(TextBoxStaffNumber.Text);
                        a.Name = TextBoxName.Text;
                        a.Gender = TextBoxGender.Text;
                        a.Password = TextBoxPassword.Text;
                        a.Email = TextBoxEmail.Text;
                        a.Level = Convert.ToInt32(TextBoxLevel.Text);
                        a.Role = "Administrator";
                        LabelMessage.Text = "Administrator updated";
                        Response.Redirect("DisplayAdmin.aspx");
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

        private void FillTextBoxes(ArrayList adminlist)
        {
            foreach (Administrator a in adminlist)
            {
                if (a.StaffNumber == staffnumber)
                {
                    TextBoxStaffNumber.Text = a.StaffNumber.ToString();
                    TextBoxName.Text = a.Name;
                    TextBoxGender.Text = a.Gender;
                    TextBoxPassword.Text = a.Password;
                    TextBoxEmail.Text = a.Email;
                    TextBoxLevel.Text = a.Level.ToString();
                    LabelMessage.Text = "";
                    ButtonUpdate.Enabled = true;
                }
            }
        }
    }
}