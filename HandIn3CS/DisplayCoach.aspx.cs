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
    public partial class DisplayCoach : System.Web.UI.Page
    {
        ArrayList coachlist;
        int index;
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

            if (Application["mycoachlist"] == null)
            {
                coachlist = new ArrayList();
                Application["mycoachlist"] = coachlist;
                ButtonUpdate.Enabled = false;
                ButtonDelete.Enabled = false;
                ButtonSave.Enabled = false;
            }
            else
            {
                coachlist = (ArrayList)Application["mycoachlist"];  // type casting
                ButtonUpdate.Enabled = true;
                ButtonDelete.Enabled = true;
                ButtonSave.Enabled = true;
            }

            if (!Page.IsPostBack)
            {
                if (coachlist.Count == 0)
                {
                    LabelMessage.Text = "No coaches";
                }
                else
                {
                    PrintCoach(coachlist);
                    if (role == "Administrator")
                    {
                        // administrators can only update at administrator page
                        ButtonUpdate.Visible = false;
                    }
                }
            }
        }

        protected void ButtonRead_Click(object sender, EventArgs e)
        {            
            try
            {
                coachlist = FileUtility.ReadFile(Server.MapPath("~/App_Data/Coachfile.ser"));
                Application["mycoachlist"] = coachlist;

                LabelMessage.Text = "File read from App_Data";

                if (coachlist.Count == 0)
                {
                    LabelMessage.Text = "No Coaches in file";
                }
                else
                {
                    PrintCoach(coachlist);
                }
            }
            catch (Exception ex)
            {
                LabelMessage.Text = "Coachfile could not be read" + ex.Message;
            }
        }

        protected void ListBoxDisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Application.Set("mycoachlist", coachlist);
                index = ListBoxDisplay.SelectedIndex;
                Session["Index"] = index;
            }
            catch
            {
                //TextBoxInfo.Text = "Choose an employee";
            }
        }

        protected void ButtonCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateCoach.aspx");
        }

        protected void ButtonSave_Click(object sender, EventArgs e)
        {
            coachlist = (ArrayList)Application["mycoachlist"];

            if (coachlist != null)
            {
                FileUtility.WriteFile(coachlist, Server.MapPath("~/App_Data/Coachfile.ser"));
                LabelMessage.Text = "File written in App_Data folder";
            }
            else
            {
                LabelMessage.Text = "No coaches to save";
            }           
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ListBoxDisplay.SelectedIndex == -1)
            {
                LabelMessage.Text = "Please select a coach from the list";
            }
            else
            {
                for (int i = 0; i < coachlist.Count; i++)
                {
                    if (ListBoxDisplay.SelectedIndex == i)
                    {
                        coachlist.RemoveAt(i);
                        LabelMessage.Text = "Selected coach has been deleted";
                    }
                }
            }

            PrintCoach(coachlist);
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateCoach.aspx");
        }

        private void PrintCoach(ArrayList coachlist)
        {
            ListBoxDisplay.Items.Clear();

            foreach (Coach c in coachlist)
            {
                ListBoxDisplay.Items.Add(c.ToString());
            }
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
