using System;
using System.Collections.Generic;
using System.Text;
using static DataAccess.Models.ViewModels.Main;

namespace DataAccess.Model.Mapper
{
    public class ReferenceMapper
    {
        public List<ProductVM> Product { get; set; }
        public List<FunctionVM> Function { get; set; }
        public List<ModuleVM> Module { get; set; }
        public List<PriorityVM> Priority { get; set; }
        public List<StatusVM> Status { get; set; }
        public List<TaskTypeVM> TaskType { get; set; }
        public List<SubTaskVM> SubTask { get; set; }

        //public IEnumerable<tbl_genMasProduct> Product { get; set; }
        //public List<tbl_genMasFunction> Function { get; set; }
        //public List<tbl_genMasModule> Module { get; set; }
        //public List<tbl_genMasPriority> Priority { get; set; }
        //public List<tbl_genMasStatus> Status { get; set; }
        //public List<tbl_genMasTaskType> TaskType { get; set; }

    }
}
