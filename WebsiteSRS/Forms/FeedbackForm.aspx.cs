using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteSRS.Forms
{
    public partial class FeedbackForm : System.Web.UI.Page
    {
        readonly string pageID = "Feedback";
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (Session["myTheme"] != null) this.Theme = Session["myTheme"].ToString();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Response.Expires = 0;
                SetPageAttribution();
                AssiblingPage();
            }

        }
        private void SetPageAttribution()
        {
            hfIDs.Value = "0";
            hfCategory.Value = "Home";
            hfPageID.Value = pageID;
            hfAppID.Value = Page.Request.QueryString["appID"].ToString();
            hfModelID.Value = Page.Request.QueryString["modelID"].ToString();
            string userID = Page.Request.QueryString["userID"].ToString();
            hfUserID.Value = userID;
            hfUserRole.Value = Page.Request.QueryString["userRole"].ToString();
            hfSchoolYear.Value = Page.Request.QueryString["schoolYear"].ToString();
            hfSchoolCode.Value = Page.Request.QueryString["schoolCode"].ToString();


            TextUserID.Text = userID;
            TextUserName.Text = userID;
            TextUserRole.Text = Page.Request.QueryString["userRole"].ToString();


        }
        private void AssiblingPage()
        {

            var parameters = new CommonListParameter()
            {
                Operate = "",
                UserID = TextUserID.Text,
                Para1 = hfUserRole.Value,
                Para2 = hfSchoolYear.Value,
                Para3 = hfSchoolCode.Value,
                Para4 = hfAppID.Value,
            };

            AppsPage.BuildingList(ddlSchoolCode, ddlSchool, "DDLListSchool", parameters, hfSchoolCode.Value);
            AppsPage.BuildingList(ddlApps, "AppsName", parameters, hfAppID.Value);
            parameters.Para1 = hfAppID.Value;
            AppsPage.BuildingList(ddlModel, "AppsModel", parameters, hfModelID.Value);
            AppsPage.BuildingList(ddlAppSection, "AppsSection", parameters);
        }

        protected void ddlApps_SelectedIndexChanged(object sender, EventArgs e)
        {
            var parameters = new CommonListParameter()
            {
                Operate = "",
                UserID = hfUserID.Value,
                Para1 = ddlApps.SelectedValue,
                Para2 = hfSchoolYear.Value,
                Para3 = hfSchoolCode.Value,
                Para4 = ddlApps.SelectedValue,
            };

            AppsPage.BuildingList(ddlModel, "AppsModel", parameters, "Pages");
            AppsPage.BuildingList(ddlAppSection, "AppSection", parameters);

        }

        protected void btnRequest_Click(object sender, EventArgs e)
        {
            var parameter = new Feedback()
            {
                Operate = "Add",
                UserID = hfUserID.Value,
                IDs = hfIDs.Value,
                UserRole = TextUserRole.Text,
                SchoolYear = hfSchoolYear.Value,
                SchoolCode = ddlSchool.SelectedValue,
                AppID = ddlApps.SelectedValue,
                ModelID = ddlModel.SelectedValue,
                AppSection = ddlAppSection.SelectedValue,
                FeedbackType = ddlFeedbackType.SelectedValue,

                Comments = TextComments.Text
            };
            var result = ManageFormSave<Feedback>.SaveFormContent("Add", "Feedback", parameter);
        }

    }
}