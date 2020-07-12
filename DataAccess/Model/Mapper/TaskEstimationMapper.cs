using System;
using System.Collections.Generic;
using System.Text;
using static DataAccess.Models.ViewModels.Main;

namespace DataAccess.Model.Mapper
{
    public class TaskEstimationMapper
    {
        public List<TaskEstimation_VM> TaskEstimation_VM { get; set; }
        public List<TaskEstimation_DetailVM> TaskEstimation_DetailVM { get; set; }

    }
}
