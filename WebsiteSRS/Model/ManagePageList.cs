using ASMBLL;
using BLL;
using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebsiteSRS
{
    public class ManagePageList<T, T2>
    {
       
        public static List<T> GetList(string dataSource,string obj, object parameter)
        {
            return RunGetListFromDB(dataSource,obj, parameter);
        }

        public static List<T> GetList(string dataSource, string obj, object parameter, WebControl actionControl)
        {
            if (WebConfig.RunningModel() == "Design") {
               var _sp = MapClass<T2>.SPName("Read");
                actionControl.ToolTip = CheckStoreProcedureParameters.GetParamerters(_sp, parameter);
            }
            return RunGetListFromDB(dataSource,obj, parameter);
        }
   
        private static List<T> RunGetListFromDB(string dataSource,string obj, object parameter)
        {
  
          var action = new ActionAppList<T,T2>(dataSource);
            return action.GetObjList(obj, parameter);
 
     }
 
    }

}