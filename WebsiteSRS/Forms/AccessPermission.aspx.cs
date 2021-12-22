using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebsiteSRS.Forms
{
    public partial class AccessPermission : System.Web.UI.Page
    {
        readonly string pageID = "RequestPermission";
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
                BindViewData();
            }

        }
        private void SetPageAttribution()
        {
            hfIDs.Value = "0";
               hfCategory.Value = "Home";
            hfPageID.Value = pageID;
            hfAppID.Value = Page.Request.QueryString["appID"].ToString();
            hfModelID.Value = Page.Request.QueryString["modelID"].ToString();
            string userID =  Page.Request.QueryString["userID"].ToString();
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
            AppsPage.BuildingList(ddlAccessScope, "AccessScope", parameters);
            parameters.Para1 = ddlAccessScope.SelectedValue;
            AppsPage.BuildingList(ddlScopeValue, "AccessScopeValue", parameters);

            var yearDate = new SchoolYearDate(hfSchoolYear.Value, hfSchoolCode.Value);
            hfSchoolyearStartDate.Value = yearDate.StartDate();
            hfSchoolyearEndDate.Value = yearDate.EndDate();

            dateStart.Value = yearDate.TodayDate();
            dateEnd.Value = yearDate.EndDate();
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

        }

        protected void ddlAccessScope_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuldDDLScopeValue();

        }
        private void BuldDDLScopeValue()
        {
            var parameters = new CommonListParameter()
            {
                Operate = "",
                UserID = hfUserID.Value,
                Para1 = ddlAccessScope.SelectedValue,
                Para2 = hfSchoolYear.Value,
                Para3 = hfSchoolCode.Value,
                Para4 = ddlApps.SelectedValue,
            };

            AppsPage.BuildingList(ddlScopeValue, "AccessScopeValue", parameters);
        }
        protected void ddlSchool_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppsPage.SetListValue(ddlSchoolCode, ddlSchool.SelectedValue);
        }

        protected void ddlSchoolCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppsPage.SetListValue(ddlSchool, ddlSchoolCode.SelectedValue);
        }

        private void BindViewData()
        {
            CheckPageControlOpenStatus();

            var IDs = hfIDs.Value.ToString();
            if (IDs != "0")
            {
                var formInfo = GetDataSource()[0];
                AppsPage.SetListValue(ddlApps, formInfo.AppID);
                AppsPage.SetListValue(ddlModel, formInfo.ModelID);
                AppsPage.SetListValue(ddlSchoolCode, formInfo.SchoolCode);
                AppsPage.SetListValue(ddlSchool, formInfo.SchoolCode);

                AppsPage.SetListValue(ddlAccessScope, formInfo.AccessScope);
                BuldDDLScopeValue();
                AppsPage.SetListValue(ddlScopeValue, formInfo.RequestValue);
                AppsPage.SetListValue(rblPermission, formInfo.Permission);


                TextUserID.Text = formInfo.StaffUserID;
                TextUserName.Text = formInfo.UserName;
                TextUserRole.Text = formInfo.UserRole;
                dateStart.Value = formInfo.StartDate;
                dateEnd.Value = formInfo.EndDate;
                TextComments.Text = formInfo.Comments;


            }

        }
        private List<RequestPermission> GetDataSource()
        {
            var parameter = new
            {
                Operate = "Get",  
                UserID = hfUserID.Value,
                IDs = hfIDs.Value

            };

            int IDs = int.Parse(hfIDs.Value);
            var myList = ManageFormContent<RequestPermission>.GetListbyID("RequestPermission", IDs);
            return myList;
        }
        private void CheckPageControlOpenStatus()
        {
            if (hfUserRole.Value != "Admin")
            {
                ddlApps.Enabled = false;
                ddlModel.Enabled = false;
                ddlSchool.Enabled = false;
                ddlSchoolCode.Enabled = false;

            }
            if (hfIDs.Value.ToString() != "0")
            {
                checkButton(true);
            }
            else
            {
                checkButton(false);
            }


        }
        private void checkButton(bool visible)
        {
            btnGrant.Visible = visible;
            btnPending.Visible = visible;
            btnRequest.Visible = !visible;
        }
        protected void btnRequest_Click(object sender, EventArgs e)
        {
            var parameter = new RequestPermission()
            {
                Operate = "Add", //"formInformation",
                UserID =hfUserID.Value,
                IDs = hfIDs.Value,
                SchoolYear = hfSchoolYear.Value,
                SchoolCode = ddlSchool.SelectedValue,
                AppID = ddlApps.SelectedValue,
                ModelID = ddlModel.SelectedValue,
                StaffUserID = TextUserID.Text,
                UserRole = TextUserRole.Text,
                Permission = rblPermission.SelectedValue,
                RequestType = "UserRequest",
                RequestValue = ddlScopeValue.SelectedValue,
                AccessScope = ddlAccessScope.SelectedValue,
                StartDate = dateStart.Value,
                EndDate = dateEnd.Value,
                Comments = TextComments.Text
            };
            var result = ManageFormSave<RequestPermission>.SaveFormContent("Add", "RequestPermission", parameter);
        }

        protected void btnGrant_Click(object sender, EventArgs e)
        {

        }

        protected void btnPending_Click(object sender, EventArgs e)
        {

        }
    }
}