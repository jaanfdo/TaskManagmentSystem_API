using System;
using System.Collections.Generic;
using System.Text;
using static DataAccess.Models.ViewModels.Main;

namespace DataAccess.Model.Mapper
{
    public class TimeSheetMapper
    {
        public List<TimeSheetVM> TimeSheetVM { get; set; }
        public List<TimeSheet_DetailVM> TimeSheet_DetailVM { get; set; }
    }
}
