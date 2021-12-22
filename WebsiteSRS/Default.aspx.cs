using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteSRS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                var requestID = Page.Request.QueryString["rID"];
                if (requestID != null)
                {  
                    string queryStr = AppsPage.GetQueryString(Page);
                    string goPage = "Forms/Loading.aspx?pID=" + GetForm(requestID) + "&" + queryStr;
                    Page.Response.Redirect(goPage);
                }
            }
        }
        private string GetForm(string rID)
        {
            switch (rID)
            {
                case "Feedback":
                    return "FeedbackForm.aspx";
                case "ClassMatch":
                    return "ClassMatchForm.aspx";
                case "Permission":
                    return "AccessPermission.aspx";
                default:
                    return "NewComesoom.aspx";
            }
        }
    }
}