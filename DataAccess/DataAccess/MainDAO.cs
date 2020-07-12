using DataAccess.Context;
using DataAccess.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static DataAccess.Models.ViewModels.Main;

namespace DataAccess.DataAccess
{
    public class MainDAO
    {
        #region MyRegion
        private readonly ApplicationContext _context;
        string sUser_ID = "";//System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = "";//System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = "";//System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;

        public MainDAO(ApplicationContext context)
        {
            _context = context;
        }

        #region MyRegion
        //public JsonResult getStatus()
        //{
        //    _context.Configuration.ProxyCreationEnabled = false;
        //    List<tbl_genMasStatus> oStatus = new List<tbl_genMasStatus>();
        //    oStatus = _context.tbl_genMasStatus.OrderBy(a => a.status_ID).ToListAsync();

        //    return new JsonResult { Data = oStatus, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //public JsonResult SearchStatus(string Search)
        //{
        //    _context.Configuration.ProxyCreationEnabled = false;
        //    List<StatusVM> List = null;

        //    if (Search != null || Search != "")
        //    {
        //        List = _context.tbl_genMasStatus
        //        .Where(p => p.status.StartsWith(Search.ToString().Trim()))
        //        .OrderByDescending(p => p.status_ID)
        //        .Select(s => new StatusVM
        //        {
        //            status_ID = s.status_ID,
        //            status = s.status,
        //        }).ToListAsync();
        //    }


        //    //List<tbl_genMasStatus> oStatus = new List<tbl_genMasStatus>();
        //    //oStatus = _context.tbl_genMasStatus.OrderBy(a => a.status_ID).ToListAsync();

        //    return new JsonResult { Data = List, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        //}

        //public JsonResult SubTaskDetails(string estimation_ID)
        //{
        //    List<TaskEstimation_DetailVM> List = _context.tbl_pmsTxTaskEstimation_Detail.Where(p => p.estimation_ID == estimation_ID)
        //        .Select(x => new TaskEstimation_DetailVM
        //        {
        //            estimation_ID = x.estimation_ID,
        //            subTask_ID = x.subTask_ID,
        //            subTask = x.tbl_genMasSubTask.subTaskName,
        //            estimatedHours = x.estimatedHours,
        //            line_No = x.line_No
        //        }).ToListAsync();

        //    return list;
        //}
        #endregion

        #region Search Function
        public async Task<List<ClientVM>> SearchClients(string Search)
        {
            List<ClientVM> List = _context.tbl_genCustomerMaster
                .Where(p => p.customerName.Contains(Search))
                .OrderByDescending(p => p.customer_ID)
                .Select(s => new ClientVM
                {
                    Customer_ID = s.customer_ID,
                    CustomerName = s.customerName
                }).ToList();

            return List;
        }

        public async Task<List<FunctionVM>> SearchFunctions(string Search)
        {
            List<FunctionVM> List = _context.tbl_genMasFunction
            .Where(p => p.functionName.Contains(Search))
            .OrderByDescending(p => p.function_ID)
            .Select(s => new FunctionVM
            {
                function_ID = s.function_ID,
                functionName = s.functionName
            }).ToList();

            return List;
        }

        public async Task<List<UsersVM>> SearchUsers(string Search)
        {
            List<UsersVM> List = _context.tbl_securityUserMaster
            .Where(p => p.userName.Contains(Search))
            .OrderByDescending(p => p.user_ID)
            .Select(s => new UsersVM
            {
                user_ID = s.user_ID,
                user = s.userName
            }).ToList();

            return List;
        }
        #endregion


        public async Task<List<UsersVM>> Users()
        {
            var list = from s in _context.tbl_securityUserMaster
                       orderby s.user_ID
                       select new UsersVM
                       {
                           user_ID = s.user_ID.ToString(),
                           user = s.userName
                       };
            return list.ToList();
        }

        public async Task<List<FunctionVM>> Function()
        {
            var list = from s in _context.tbl_genMasFunction
                       orderby s.function_ID
                       select new FunctionVM
                       {
                           function_ID = s.function_ID.ToString(),
                           functionName = s.functionName
                       };
            return list.ToList();
        }

        public async Task<List<ModuleVM>> Module()
        {
            var list = from s in _context.tbl_genMasModule
                       orderby s.module_ID
                       where s.isActive == true
                       select new ModuleVM
                       {
                           module_ID = s.module_ID.ToString(),
                           moduleName = s.moduleName
                       };
            return list.ToList();
        }

        public async Task<List<PriorityVM>> Priority()
        {
            var list = from s in _context.tbl_genMasPriority
                       orderby s.priority_ID
                       where s.isActive == true
                       select new PriorityVM
                       {
                           priority_ID = s.priority_ID.ToString(),
                           priority = s.priority
                       };
            return list.ToList();
        }

        public async Task<List<ProductVM>> Product()
        {
            var list = from s in _context.tbl_genMasProduct
                       orderby s.product_ID
                       where s.isActive == true
                       select new ProductVM
                       {
                           product_ID = s.product_ID.ToString(),
                           productName = s.productName
                       };
            return list.ToList();
        }

        public async Task<List<SubTaskVM>> SubTask()
        {
            var list = from s in _context.tbl_genMasSubTask
                       orderby s.subTask_ID
                       where s.isActive == true
                       select new SubTaskVM
                       {
                           subTask_ID = s.subTask_ID.ToString(),
                           subTaskName = s.subTaskName
                       };
            return list.ToList();
        }

        public async Task<List<TaskTypeVM>> TaskType()
        {
            var list = from s in _context.tbl_genMasTaskType
                       orderby s.taskType_ID
                       where s.isActive == true
                       select new TaskTypeVM
                       {
                           taskType_ID = s.taskType_ID.ToString(),
                           taskType = s.taskType
                       };
            return list.ToList();
        }

        public async Task<List<StatusVM>> Status()
        {
            var list = from s in _context.tbl_genMasStatus
                       orderby s.status_ID
                       where s.isActive == true
                       select new StatusVM
                       {
                           status_ID = s.status_ID.ToString(),
                           status = s.status
                       };
            return list.ToList();
        }
        #endregion


        private void TotalTask_Status()
        {
            //ViewBag.Users = _context.tbl_securityUserMaster.Count(p => p.employeeID != "-1");

            if (sUser_ID != "")
            {
                decimal dCount = _context.tbl_pmsTxTask.Where(p => p.status_ID == "1" && p.assignedUser_ID == sUser_ID).Count();
                //ViewBag.NewStatus_Count = dCount;

                DateTime dtNow = DateTime.Now.Date;
                //decimal dDeadlineCount = _context.tbl_pmsTxTask.Where(p => p.DeadlineDate >= dtNow && p.DeadlineDate <= EntityFunctions.AddDays(dtNow, 7) && p.assignedUser_ID == sUser_ID).Count();
                //ViewBag.Deadline_Count = dDeadlineCount;

                decimal dDueCount = _context.tbl_pmsTxTask.Where(p => DateTime.Now > p.DeadlineDate && p.assignedUser_ID == sUser_ID).Count();
                //ViewBag.Due_Count = dDueCount;
            }
        }

        public async Task<bool> CheckFormAutogenerated(int id)
        {
            string Message = "";
            try
            {
                return _context.tbl_securityFunctionMaster.Find(id.ToString()).isAutoGenerate ? true : false;
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
            }
            return false;
        }
    }
}