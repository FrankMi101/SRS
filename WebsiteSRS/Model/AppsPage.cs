/// <summary>
/// Summary description for WorkingProfile
/// </summary>
/// 
using ASMBLL;
using BLL;
using ClassLibrary;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace WebsiteSRS
{
    public class AppsPage : AppsBase
    {
        public AppsPage()
        {

        }
        public static string GetQueryString(Page page)
        {
            try
            {
                string appID = page.Request.QueryString["appID"].ToString();
                string modelID = page.Request.QueryString["modelID"].ToString();
                string userID = page.Request.QueryString["userID"].ToString();
                string userRole = page.Request.QueryString["userRole"].ToString();
                string schoolYear = page.Request.QueryString["schoolYear"].ToString();
                string schoolCode = page.Request.QueryString["schoolCode"].ToString();

                return "appID=" + appID + "&modelID=" + modelID + "&userID=" + userID + "&userRole=" + userRole + "&schoolYear=" + schoolYear + "&schoolCode=" + schoolCode;

            }
            catch
            {
                return "";
            }
        }
    

        public static void SetListValue(ListControl myListControl, object value)
        {
            AssemblingList.SetValue(myListControl, value);
        }

        public static void BuildingList(ListControl myListControl, string action, CommonListParameter parameter)
        {
            AssemblingList.SetLists("", myListControl, action, parameter);
        }

        public static void BuildingList(ListControl myListControl, string action, CommonListParameter parameter, object initialValue)
        {
            AssemblingList.SetLists("", myListControl, action, parameter, initialValue);
        }

        public static void BuildingList(ListControl myListControl, string operate, string userId, string para1, string para2, string para3)
        {
            var parameter = CommonParameters.GetListParameters(operate, userId, para1, para2, para3);
            BuildingList(myListControl, operate, parameter);
        }
        public static void BuildingList(ListControl myListControl, string operate, string userId, string para1, string para2, string para3, object initialvalue)
        {
            var parameter = CommonParameters.GetListParameters(operate, userId, para1, para2, para3);
            BuildingList(myListControl, operate, parameter, initialvalue);
        }

        public static void BuildingList(ListControl myCodeListControl, ListControl myListNameControl, string action, CommonListParameter parameter)
        {
            AssemblingList.SetListSchool(myCodeListControl, myListNameControl, action, parameter);
        }
        public static void BuildingList(ListControl myCodeListControl, ListControl myListNameControl, string action, CommonListParameter parameter, object initialValue)
        {
            AssemblingList.SetListSchool(myCodeListControl, myListNameControl, action, parameter, initialValue);
        }
      
        private static HtmlAnchor getALink(string code, string name, string cTab)
        {
            var a = new HtmlAnchor();
            a.InnerText = name;
            a.ID = code;
            a.HRef = "#";
            string classAdd = code == cTab ? "aLinkTabHS" : "aLinkTabH";
            a.Attributes.Add("class", classAdd);
            return a;
        }
        private static HtmlGenericControl getLi(string code, string name, string cTab)
        {
            var li = new HtmlGenericControl("li");
            li.ID = "GT_" + code;
            string classAdd = code == cTab ? "liTabHS" : "liTabH";
            li.Attributes.Add("class", classAdd);

            if (name.Length > 9)
                li.Style.Add("width", "100");
            else if (name.Length > 8)
                li.Style.Add("width", "80");
            else
                li.Style.Add("width", "80");
            return li;
        }
    }

}