using DataAccess.Context;
using DataAccess.Model.Mapper;
using DataAccess.Models;
using DataAccess.Models.ViewModels;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static DataAccess.Models.ViewModels.Main;

namespace DataAccess.DataAccess
{
    public class MainRepo : IMain
    {
        // private ApplicationDbContext db = new ApplicationDbContext();
        // string sUser_ID = System.Web.HttpContext.Current.Session["user_ID"] as String;
        // string sCompany_ID = System.Web.HttpContext.Current.Session["company_ID"] as String;
        // string sCompanyBranch_ID = System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;
        private readonly ApplicationContext _context;

        public MainRepo(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ReferenceMapper> TaskReferences()
        {
            //cls_HelpMethods.UserDetail();
            //cls_HelpMethods.CompanyDetail();

            return new ReferenceMapper()
            {
                Product = await new MainDAO(_context).Product(),
                Function = await new MainDAO(_context).Function(),
                Module = await new MainDAO(_context).Module(),
                Priority = await new MainDAO(_context).Priority(),
                Status = await new MainDAO(_context).Status(),
                TaskType = await new MainDAO(_context).TaskType(),
                SubTask = await new MainDAO(_context).SubTask(),
            };
        }

        public async Task<List<UsersVM>> UserList()
        {
            return await new MainDAO(_context).Users();
        }

        // public JsonResult SearchStatus(string Search)
        // {
        //     db.Configuration.ProxyCreationEnabled = false;
        //     List<StatusVM> List = null;

        //     if (Search != null || Search != "")
        //     {
        //         List = db.tbl_genMasStatus
        //         .Where(p => p.status.StartsWith(Search.ToString().Trim()))
        //         .OrderByDescending(p => p.status_ID)
        //         .Select(s => new StatusVM
        //         {
        //             status_ID = s.status_ID,
        //             status = s.status,
        //         }).ToListAsync();
        //     }


        //     //List<tbl_genMasStatus> oStatus = new List<tbl_genMasStatus>();
        //     //oStatus = db.tbl_genMasStatus.OrderBy(a => a.status_ID).ToListAsync();

        //     return new JsonResult { Data = List, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        // }

        // public JsonResult SubTaskDetails(string estimation_ID)
        // {
        //     List<TaskEstimation_DetailVM> List = db.tbl_pmsTxTaskEstimation_Detail.Where(p => p.estimation_ID == estimation_ID)
        //         .Select(x => new TaskEstimation_DetailVM
        //         {
        //             estimation_ID = x.estimation_ID,
        //             subTask_ID = x.subTask_ID,
        //             subTask = x.tbl_genMasSubTask.subTaskName,
        //             estimatedHours = x.estimatedHours,
        //             line_No = x.line_No
        //         }).ToListAsync();

        //     return Json(List, JsonRequestBehavior.AllowGet);
        // }

        // public JsonResult SearchClients(string Search)
        //{
        //     List<ClientVM> List = db.tbl_genCustomerMaster
        //         .Where(p => p.customerName.Contains(Search))
        //         .OrderByDescending(p => p.customer_ID)
        //         .Select(s => new ClientVM
        //         {
        //             Customer_ID = s.customer_ID,
        //             CustomerName = s.customerName
        //         }).ToListAsync();

        //     return Json(List, JsonRequestBehavior.AllowGet);
        // }

        // public JsonResult SearchFunctions(string Search)
        // {
        //     List<FunctionVM> List = null;
        //     List = db.tbl_genMasFunction
        //     .Where(p => p.functionName.Contains(Search))
        //     .OrderByDescending(p => p.function_ID)
        //     .Select(s => new FunctionVM
        //     {
        //         Function_ID = s.function_ID,
        //         FunctionName = s.functionName,
        //         Module_ID = s.module_ID,
        //         ModuleName = s.tbl_genMasModule.moduleName
        //     }).ToListAsync();

        //     return Json(List, JsonRequestBehavior.AllowGet);
        // }


        // public JsonResult Users()
        // {
        //     var users = from s in db.tbl_securityUserMaster
        //                 orderby s.user_ID
        //                 select new
        //                 {
        //                     user_ID = s.user_ID.ToString(),
        //                     user = s.userName
        //                 };
        //     return Json(users, JsonRequestBehavior.AllowGet);
        // }

        // public JsonResult Module()
        // {
        //     var list = from s in db.tbl_genMasModule
        //                orderby s.module_ID
        //                where s.isActive == true
        //                select new
        //                {
        //                    module_ID = s.module_ID.ToString(),
        //                    moduleName = s.moduleName
        //                };
        //     return Json(list, JsonRequestBehavior.AllowGet);
        // }

        // public JsonResult Priority()
        // {
        //     var list = from s in db.tbl_genMasPriority
        //                orderby s.priority_ID
        //                where s.isActive == true
        //                select new
        //                {
        //                    priority_ID = s.priority_ID.ToString(),
        //                    priority = s.priority
        //                };
        //     return Json(list, JsonRequestBehavior.AllowGet);
        // }

        // public JsonResult Product()
        // {
        //     var list = from s in db.tbl_genMasProduct
        //                orderby s.product_ID
        //                where s.isActive == true
        //                select new
        //                {
        //                    product_ID = s.product_ID.ToString(),
        //                    productName = s.productName
        //                };
        //     return Json(list, JsonRequestBehavior.AllowGet);
        // }

        // public JsonResult SubTask()
        // {
        //     var list = from s in db.tbl_genMasSubTask
        //                orderby s.subTask_ID
        //                where s.isActive == true
        //                select new
        //                {
        //                    subTask_ID = s.subTask_ID.ToString(),
        //                    subTaskName = s.subTaskName
        //                };
        //     return Json(list, JsonRequestBehavior.AllowGet);
        // }

        // public JsonResult TaskType()
        // {
        //     var list = from s in db.tbl_genMasTaskType
        //                orderby s.taskType_ID
        //                where s.isActive == true
        //                select new
        //                {
        //                    taskType_ID = s.taskType_ID.ToString(),
        //                    taskType = s.taskType
        //                };
        //     return Json(list, JsonRequestBehavior.AllowGet);
        // }

        // public JsonResult Status()
        // {
        //     var list = from s in db.tbl_genMasStatus
        //                orderby s.status_ID
        //                where s.isActive == true
        //                select new
        //                {
        //                    status_ID = s.status_ID.ToString(),
        //                    status = s.status
        //                };
        //     return Json(list, JsonRequestBehavior.AllowGet);
        // }
    }
}