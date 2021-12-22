using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebsiteSRS
{
    public class SchoolYearDate
    {
        private readonly string _dateStart;
        private readonly string _dateEnd;
        private readonly string _dateToday;
        public SchoolYearDate(string schoolYear, string schoolCode)
        {
            try
            {
                var parameter = new
                {
                    Operate = "SchoolYearDate",
                    UserID = "systemAccount",
                    UserRole = "Admin",
                    SchoolYear = schoolYear,
                    SchoolCode = schoolCode,
                };
                var myDate = AppsPage.GeneralList<SchoolDateStr>("GeneralList", "SchoolDateList", parameter);

                _dateStart = myDate[0].StartDate.ToString();
                _dateEnd = myDate[0].EndDate.ToString();
                _dateToday = myDate[0].TodayDate.ToString();

            }
            catch (Exception)
            {
                var dt = new DateTime(); 
                _dateStart = dt.Date.ToShortDateString();
                _dateEnd = dt.Date.ToShortDateString();
                _dateToday = dt.Date.ToShortDateString();
            }

        }

        public string StartDate()
        {
            return _dateStart;
        }
        public string EndDate()
        {
            return _dateEnd;
        }
        public string TodayDate()
        {
            return _dateToday;
        }
    }
}