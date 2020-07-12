namespace DataAccess.DataAccess
{
    ////[Authorize]
    ////[Authorize(Roles = "Administrators")]
    //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
    //public class TaskBucketController : Controller
    //{
    //    private ApplicationDbContext db = new ApplicationDbContext();
    //    string sUser_ID = System.Web.HttpContext.Current.Session["user_ID"] as String;
    //    // GET: TaskBucket
    //    public ActionResult Index()
    //    {
    //        cls_HelpMethods.UserDetail();
    //        cls_HelpMethods.CompanyDetail();

    //        TotalTask_Status();

    //        return View();
    //    }

    //    public ActionResult ModalTest()
    //    {
    //        return View();
    //    }

    //    public ActionResult Pagination()
    //    {
    //        return View();
    //    }

    //    public ActionResult Test()
    //    {
    //        cls_HelpMethods.UserDetail();
    //        cls_HelpMethods.CompanyDetail();

    //        TotalTask_Status();

    //        return View();
    //    }

    //    public JsonResult List(bool ShowAll, string AssignedUser) //
    //    {
    //        List<TaskBucketVM> List = db.tbl_pmsTxTask//.Where(p => p.assignedUser_ID == "%%")
    //            .Select(x => new TaskBucketVM
    //            {
    //                task_ID = x.task_ID,
    //                taskDate = x.taskDate,
    //                taskReference = x.taskReference,
    //                taskType_ID = x.tbl_genMasTaskType.taskType,

    //                estimation_ID = x.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == x.task_ID).estimation_ID != null ? x.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == x.task_ID).estimation_ID : "0",

    //                priority_ID = x.tbl_genMasPriority.priority,
    //                status_ID = x.status_ID,
    //                status = x.tbl_genMasStatus.status,
    //                DeadlineDate = x.DeadlineDate,
    //                AssignedTo = x.assignedUser_ID,

    //                client_ID = x.tbl_genCustomerMaster.customerCode,
    //                product_ID = x.tbl_genMasProduct.productName,
    //                module_ID = x.tbl_genMasModule.moduleName,
    //                function_ID = x.tbl_genMasFunction.functionName,

    //                reported_Date = x.reported_Date,
    //                reportedUser_ID = x.reportedUser_ID,

    //                isCancelled = x.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == x.task_ID).isCancelled == true ? true : false,
    //                isApproved = x.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == x.task_ID).isApproved == true ? true : false,

    //            }).OrderByDescending(p => p.taskDate).ThenByDescending(p => p.task_ID).ToListAsync();//.Where(p => p.AssignedTo == sUser_ID)


    //        if (AssignedUser != "")
    //            List = List.Where(p => p.AssignedTo == AssignedUser).ToListAsync();

    //        if (!ShowAll)
    //            List = List.Where(p => p.status_ID.Equals(((int)clsEnums.enumStatus.Assigned).ToString()) || p.status_ID.Equals(((int)clsEnums.enumStatus.New).ToString()) ||
    //                            p.status_ID.Equals(((int)clsEnums.enumStatus.QAWIP).ToString()) || p.status_ID.Equals(((int)clsEnums.enumStatus.DEVWIP).ToString()) || 
    //                            p.status_ID.Equals(((int)clsEnums.enumStatus.WIP).ToString()) || p.status_ID.Equals(((int)clsEnums.enumStatus.QA_Fail).ToString())).ToListAsync();

    //        return Json(new { data = List }, JsonRequestBehavior.AllowGet);
    //    }

    //    [HttpPost]
    //    [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
    //    public JsonResult UpdateDeadline(string sTaskID, DateTime dtDeadline)
    //    {
    //        bool status = false;
    //        if (!string.IsNullOrEmpty(sTaskID))
    //        {
    //            var oTask = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == sTaskID);
    //            if (oTask != null)
    //            {
    //                oTask.DeadlineDate = dtDeadline.Date;

    //                db.SaveChanges();
    //                status = true;
    //            }
    //        }
    //        else
    //        {
    //            status = false;
    //        }

    //        return new JsonResult { Data = new { status = status } };
    //    }

    //    [HttpPost]
    //    [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
    //    public JsonResult UpdateAssignedTo(string sTaskID, string sAssignedTo)
    //    {
    //        bool status = false;
    //        if (!string.IsNullOrEmpty(sTaskID) && !string.IsNullOrEmpty(sAssignedTo))
    //        {
    //            var oTask = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == sTaskID);
    //            if (oTask != null)
    //            {
    //                oTask.assignedUser_ID = sAssignedTo;

    //                db.SaveChanges();
    //                status = true;
    //            }
    //        }
    //        else
    //        {
    //            status = false;
    //        }
    //        return new JsonResult { Data = new { status = status } };
    //    }

    //    private void TotalTask_Status()
    //    {
    //        //decimal dCount = db.tbl_pmsTxTask.Where(p => p.assignedUser_ID == sUser_ID && p.status_ID == "1").Count();
    //        decimal dCount = db.tbl_pmsTxTask.Where(p => p.status_ID == "1").Count();
    //        ViewBag.NewStatus_Count = dCount;

    //        DateTime dtNow = DateTime.Now.Date;
    //        //decimal dDeadlineCount = db.tbl_pmsTxTask.Where(p => p.assignedUser_ID == sUser_ID && p.DeadlineDate >= dtNow && p.DeadlineDate <= EntityFunctions.AddDays(dtNow, 7)).Count();
    //        decimal dDeadlineCount = db.tbl_pmsTxTask.Where(p => p.DeadlineDate >= dtNow && p.DeadlineDate <= EntityFunctions.AddDays(dtNow, 7)).Count();
    //        ViewBag.Deadline_Count = dDeadlineCount;

    //        //decimal dDueCount = db.tbl_pmsTxTask.Where(p => p.assignedUser_ID == sUser_ID && DateTime.Now > p.DeadlineDate).Count();
    //        decimal dDueCount = db.tbl_pmsTxTask.Where(p => DateTime.Now > p.DeadlineDate).Count();
    //        ViewBag.Due_Count = dDueCount;
    //    }
    //}
}
