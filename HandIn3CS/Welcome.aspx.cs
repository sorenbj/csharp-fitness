using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HandIn3CS
{
    public partial class Welcome : System.Web.UI.Page
    {
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
                LabelUserLevel.Text = nre.Message;
            }
            finally
            {
                SetLevelOrError();
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
                LabelUserLevel.Text = "You are not logged in";
            }
        }
    }
}