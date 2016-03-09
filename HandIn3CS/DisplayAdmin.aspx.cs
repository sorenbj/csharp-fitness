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
    public partial class DisplayAdmin : System.Web.UI.Page
    {
        ArrayList adminlist;
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

            if (Application["myadminlist"] == null)
            {
                adminlist = new ArrayList();
                Application["myadminlist"] = adminlist;
                ButtonUpdate.Enabled = false;
                ButtonDelete.Enabled = false;
                ButtonSave.Enabled = false;
            }
            else
            {
                adminlist = (ArrayList)Application["myadminlist"];  // type casting
                ButtonUpdate.Enabled = true;
                ButtonDelete.Enabled = true;
                ButtonSave.Enabled = true;
            }

            if (!Page.IsPostBack)
            {
                if (adminlist.Count == 0)
                {
                    LabelMessage.Text = "No Administrators";
                }
                else
                {
                    PrintAdmin(adminlist);
                    ButtonHide.Visible = false;
                }
            }
        }

        protected void ButtonRead_Click(object sender, EventArgs e)
        {
            try
            {
                adminlist = FileUtility.ReadFile(Server.MapPath("~/App_Data/Admfile.ser"));
                Application["myadminlist"] = adminlist;

                LabelMessage.Text = "File read from App_Data";

                if (adminlist.Count == 0)
                {
                    LabelMessage.Text = "No Administrators in file";
                }
                else
                {
                    PrintAdmin(adminlist);
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "Admfile could not be read" + ex.Message;
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAdmin.aspx");
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            adminlist = (ArrayList)Application["myadminlist"];

            if (adminlist != null)
            {
                FileUtility.WriteFile(adminlist, Server.MapPath("~/App_Data/Admfile.ser"));
                LabelMessage.Text = "File written in App_Data folder";
            }
            else
            {
                LabelMessage.Text = "No Administrators to save";
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ListBoxDisplay.SelectedIndex == -1)
            {
                LabelMessage.Text = "Please select an administrator from the list";
            }
            else
            {
                for (int i = 0; i < adminlist.Count; i++)
                {
                    if (ListBoxDisplay.SelectedIndex == i)
                    {
                        adminlist.RemoveAt(i);
                        LabelMessage.Text = "Selected Administrator has been deleted";
                    }
                }
            }

            PrintAdmin(adminlist);
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateAdmin.aspx");
        }

        private void PrintAdmin(ArrayList adminlist)
        {
            ListBoxDisplay.Items.Clear();

            foreach (Administrator a in adminlist)
            {
                ListBoxDisplay.Items.Add(a.ToString());
            }
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

        protected void ButtonShowAll_Click(object sender, EventArgs e)
        {
            coachlist = (ArrayList)Application["mycoachlist"];

            ButtonShowAll.Visible = false;
            ButtonHide.Visible = true;

            ButtonCreate.Enabled = false;
            ButtonRead.Enabled = false;
            ButtonUpdate.Enabled = false;
            ButtonDelete.Enabled = false;
            ButtonSave.Enabled = false;
            

            ListBoxDisplay.Visible = false;
            ListBoxAll.Visible = true;
            ListBoxAll.Items.Clear();
            ListBoxAll.Items.Add("Administrators");

            foreach (Administrator a in adminlist)
            {
                ListBoxAll.Items.Add(a.ToString());
            }

            ListBoxAll.Items.Add("");
            ListBoxAll.Items.Add("Coaches");

            foreach (Coach c in coachlist)
            {
                ListBoxAll.Items.Add(c.ToString());
            }
        }

        protected void ButtonHide_Click(object sender, EventArgs e)
        {
            ListBoxDisplay.Visible = true;
            ListBoxAll.Visible = false;
            ButtonHide.Visible = false;
            ButtonShowAll.Visible = true;
            ButtonCreate.Enabled = true;
            ButtonRead.Enabled = true;
            ButtonDelete.Enabled = true;
            ButtonSave.Enabled = true;

        }
    }
}
