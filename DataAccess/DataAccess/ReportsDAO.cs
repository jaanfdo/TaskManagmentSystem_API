using DataAccess.Models.ReportViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess.DataAccess
{
    public class ReportsController
    {
        #region MyRegion
        //    private ApplicationDbContext db = new ApplicationDbContext();
        //    dt_TimeSheets glb_dt_TimeSheets = new dt_TimeSheets();
        //    dt_Tasks glb_dt_Tasks = new dt_Tasks();

        //    string sUser_ID = System.Web.HttpContext.Current.Session["user_ID"] as String;
        //    string sCompany_ID = System.Web.HttpContext.Current.Session["company_ID"] as String;
        //    string sCompanyBranch_ID = System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;

        //    public ActionResult Index()
        //    {
        //        ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName");
        //        ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status");
        //        ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask.Where(p => p.isActive == true), "subTask_ID", "subTaskName");
        //        ViewBag.user_ID = new SelectList(db.tbl_securityUserMaster, "user_ID", "userName");

        //        return View();
        //    }

        //    [Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "," + nameof(clsEnums.enumAuthencationGroups.Employees) + "")]
        //    public ActionResult TimeSheetReports()
        //    {
        //        cls_HelpMethods.UserDetail();
        //        cls_HelpMethods.CompanyDetail();

        //        ViewBag.Users = new SelectList(db.tbl_securityUserMaster, "user_ID", "userName");

        //        return View();
        //    }

        //    public JsonResult TimeSheets(bool ShowAll, string User_ID, DateTime FromDate, DateTime ToDate) //
        //    {
        //        DateTime dtFromDate = FromDate.Date;
        //        DateTime dtToDate = ToDate.Date;

        //        List<TSDetailSubTask> HeaderList = db.tbl_pmsTxTimeSheet.Where(p => p.timeSheetDate >= dtFromDate && p.timeSheetDate <= dtToDate).OrderByDescending(p => p.timeSheetDate).ThenByDescending(p => p.timeSheet_ID)
        //            .Select(x => new TSDetailSubTask
        //            {
        //                //user_ID = x.user_ID,
        //                //user = x.user_ID != null ? db.tbl_securityUserMaster.FirstOrDefault(p => p.user_ID == x.user_ID).userName : "",
        //                //timeSheet_ID = x.timeSheet_ID,
        //                //timeSheetDate = x.timeSheetDate,
        //                //subTask_ID = x.subTask_ID,
        //                //subTask = x.tbl_genMasSubTask.subTaskName,
        //                //isCancelled = x.isCancelled,
        //                //totalUtilizedHours = x.totalUtilizedHours,
        //                //remarks = x.remarks
        //            }).OrderByDescending(p => p.timeSheetDate).ThenByDescending(p => p.timeSheet_ID).ToListAsync();

        //        //if (!ShowAll)
        //        //    HeaderList = HeaderList.Where(p => p.isCancelled == false).ToListAsync();

        //        //if (User_ID != null && User_ID != "")
        //        //    HeaderList = HeaderList.Where(p => p.user_ID == User_ID).ToListAsync();

        //        return Json(new { Headers = HeaderList }, JsonRequestBehavior.AllowGet);
        //    }

        //    public JsonResult TimeSheetsDetail(string timeSheet_ID)
        //    {
        //        //from p in Posts
        //        //join pm in Post_metas on p.Post_id equals pm.Post_id
        //        //select new { Post = p, Meta = pm }

        //        //var TimeSheetsLQ = (from ts in db.tbl_pmsTxTimeSheet 
        //        //                    join tsd in db.tbl_pmsTxTimeSheet_Detail on ts.timeSheet_ID equals tsd.timeSheet_ID into tsdetail
        //        //                    from tsdetails in tsdetail.DefaultIfEmpty()
        //        //                    join t in db.tbl_pmsTxTask on tsdetails.task_ID equals t.task_ID into task
        //        //                    from tasks in task.DefaultIfEmpty()
        //        //                    join c in db.tbl_genCustomerMaster on tasks.customer_ID equals c.customer_ID into customer
        //        //                    from customers in customer.DefaultIfEmpty()
        //        //                    //join s in db.tbl_genMasStatus on tsdetails.status_ID equals s.status_ID into sta
        //        //                    //from status in sta.DefaultIfEmpty()
        //        //                    where ts.timeSheet_ID == timeSheet_ID
        //        //                    select new
        //        //                    {
        //        //                        ts.timeSheet_ID,
        //        //                        ts.user_ID,
        //        //                        //ts.user = x.user_ID != null ? db.tbl_securityUserMaster.FirstOrDefault(p => p.user_ID == x.user_ID).userName : "",

        //        //                        ts.timeSheetDate,
        //        //                        ts.subTask_ID,
        //        //                        //subTask = x.tbl_genMasSubTask.subTaskName,
        //        //                        ts.isCancelled,
        //        //                        ts.totalUtilizedHours,
        //        //                        //ts.remarks,


        //        //                        tsdetails.task_ID,
        //        //                        tsdetails.status_ID,
        //        //                        tsdetails.utilizedHours,
        //        //                        tsdetails.remarks,
        //        //                        tsdetails.line_No,

        //        //                        status.status,

        //        //                        tasks.taskReference,
        //        //                        tasks.customer_ID,

        //        //                        customers.customerName,
        //        //                        customers.customerCode,

        //        //                    }).ToListAsync();


        //        var TimeSheetsLQ = (from ts in db.tbl_pmsTxTimeSheet_Detail
        //                            join t in db.tbl_pmsTxTask on ts.task_ID equals t.task_ID into task
        //                            from tasks in task.DefaultIfEmpty()
        //                            join c in db.tbl_genCustomerMaster on tasks.customer_ID equals c.customer_ID into customer
        //                            from customers in customer.DefaultIfEmpty()
        //                            join s in db.tbl_genMasStatus on ts.status_ID equals s.status_ID into sta
        //                            from status in sta.DefaultIfEmpty()
        //                            where ts.timeSheet_ID == timeSheet_ID
        //                            select new
        //                            {
        //                                ts.timeSheet_ID,
        //                                ts.task_ID,
        //                                ts.status_ID,
        //                                status.status,
        //                                tasks.taskReference,
        //                                tasks.customer_ID,
        //                                customers.customerName,
        //                                customers.customerCode,
        //                                ts.utilizedHours,
        //                                ts.remarks,
        //                                ts.line_No
        //                            }).ToListAsync();

        //        List<TUtilizedHours> DetailList = TimeSheetsLQ
        //        .Select(x => new TUtilizedHours
        //        {
        //            //user_ID = x.user_ID,
        //            //user = x.user_ID != null ? db.tbl_securityUserMaster.FirstOrDefault(p => p.user_ID == x.user_ID).userName : "",
        //            //timeSheet_ID = x.timeSheet_ID,
        //            //timeSheetDate = x.timeSheetDate,
        //            //subTask_ID = x.subTask_ID,
        //            //subTask = x.tbl_genMasSubTask.subTaskName,
        //            //isCancelled = x.isCancelled,
        //            //totalUtilizedHours = x.totalUtilizedHours,
        //            //remarks = x.remarks


        //            //timeSheet_ID = x.timeSheet_ID,
        //            //task_ID = x.task_ID,
        //            //status_ID = x.status_ID,
        //            //status = x.status,
        //            //task = x.taskReference,
        //            //client_ID = x.customer_ID,
        //            //client = x.customerName,
        //            //clientCode = x.customerCode,
        //            //utilizedHours = x.utilizedHours,
        //            //remarks = x.remarks,
        //            //line_No = x.line_No
        //        }).ToListAsync();

        //        return Json(new { Details = DetailList }, JsonRequestBehavior.AllowGet);
        //    }


        //    public JsonResult LoadTSDetailSubTask(string User, string SubTask, string Client, string Status, DateTime FromDate, DateTime ToDate)
        //    {
        //        string sQuery = "EXEC [sp_TimeSheetDetails] '%" + User + "%', '" + FromDate.Date + "', '" + ToDate.Date + "', '%" + SubTask + "%','%" + Client + "%','%" + Status + "%' ";

        //        List<TSDetailSubTask> DetailList = (from DataRow dr in cls_HelpMethods.ExecQuery(sQuery).Tables[0].Rows
        //                                                select new TSDetailSubTask()
        //                                                {
        //                                                    timeSheet_ID = dr["timeSheet_ID"].ToString(),
        //                                                    timeSheetDate = Convert.ToDateTime(dr["timeSheetDate"].ToString()),

        //                                                    task_ID = dr["task_ID"].ToString(),
        //                                                    taskReference = dr["taskReference"].ToString(),
        //                                                    remarks = dr["remarks"].ToString(),

        //                                                    subTask_ID = dr["subTask_ID"].ToString(),
        //                                                    subTaskName = dr["subTaskname"].ToString(),

        //                                                    utilizedHours = Convert.ToDecimal(dr["utilizedHours"].ToString()),


        //                                                    user_ID = dr["user_ID"].ToString(),
        //                                                    userName = dr["userName"].ToString(),

        //                                                    status_ID = dr["status_ID"].ToString(),
        //                                                    status = dr["status"].ToString(),

        //                                                    customer_ID = dr["customer_ID"].ToString(),
        //                                                    customerCode = dr["customerCode"].ToString(),
        //                                                }).ToListAsync();


        //        return Json(new { Details = DetailList }, JsonRequestBehavior.AllowGet);
        //    }

        //    public JsonResult LoadTUtilizedHours(string Task, string Status, DateTime FromDate, DateTime ToDate)
        //    {
        //        string sQuery = "EXEC [sp_TaskUtilizedHours] '%" + Task + "%', '%" + Status + "%', '" + FromDate.Date + "', '" + ToDate.Date + "'";

        //        List<TUtilizedHours> DetailList = (from DataRow dr in cls_HelpMethods.ExecQuery(sQuery).Tables[0].Rows
        //                                                select new TUtilizedHours()
        //                                                {
        //                                                    reported_date = Convert.ToDateTime(dr["reported_date"].ToString()),

        //                                                    task_ID = dr["task_ID"].ToString(),

        //                                                    customer_ID = dr["customer_ID"].ToString(),
        //                                                    customerCode = dr["customerCode"].ToString(),

        //                                                    taskReference = dr["taskReference"].ToString(),

        //                                                    status_ID = dr["status_ID"].ToString(),
        //                                                    status = dr["status"].ToString(),

        //                                                    subTask_ID = dr["subTask_ID"].ToString(),
        //                                                    subTaskName = dr["subTaskname"].ToString(),

        //                                                    timeSheetDate = Convert.ToDateTime(dr["timeSheetDate"].ToString()),

        //                                                    user_ID = dr["user_ID"].ToString(),
        //                                                    userName = dr["userName"].ToString(),

        //                                                    utilizedHours = Convert.ToDecimal(dr["utilizedHours"].ToString()),

        //                                                    isCancelled = Convert.ToBoolean(dr["utilizedHours"])
        //                                                }).ToListAsync();


        //        return Json(new { Details = DetailList }, JsonRequestBehavior.AllowGet);
        //    }

        //    public JsonResult LoadTEstimatedUtilized(string Task, string Product, string Client, DateTime FromDate, DateTime ToDate)
        //    {
        //        string sQuery = "EXEC [sp_TaskDetailsUtlEst] '%" + Task + "%', '%" + Product + "%', '%" + Client + "%', '" + FromDate.Date + "', '" + ToDate.Date + "'";

        //        List<TEstimatedUtilized> DetailList = (from DataRow dr in cls_HelpMethods.ExecQuery(sQuery).Tables[0].Rows
        //                                                select new TEstimatedUtilized()
        //                                                {
        //                                                    TaskStartDate = Convert.ToDateTime(dr["TaskStartDate"].ToString()),
        //                                                    reported_date = Convert.ToDateTime(dr["reported_date"].ToString()),

        //                                                    task_ID = dr["task_ID"].ToString(),
        //                                                    taskReference = dr["taskReference"].ToString(),
        //                                                    remarks = dr["remarks"].ToString(),

        //                                                    customer_ID = dr["customer_ID"].ToString(),
        //                                                    customerCode = dr["customerCode"].ToString(),

        //                                                    product_ID = dr["product_ID"].ToString(),
        //                                                    productName = dr["productName"].ToString(),

        //                                                    totalEstimatedHours = Convert.ToDecimal(dr["totalEstimatedHours"].ToString()),
        //                                                    UtilizedHours = Convert.ToDecimal(dr["UtilizedHours"].ToString()),
        //                                                    TotUtilizedHours = Convert.ToDecimal(dr["TotUtilizedHours"].ToString()),
        //                                                    EstUtlHours = Convert.ToDecimal(dr["EstUtlHours"].ToString()),

        //                                                    status_ID = dr["status_ID"].ToString(),
        //                                                    status = dr["status"].ToString(),

        //                                                    assignedUser_ID = dr["assignedUser_ID"].ToString(),
        //                                                    assignedUser = dr["assignedUser"].ToString(),

        //                                                }).ToListAsync();


        //        return Json(new { Details = DetailList }, JsonRequestBehavior.AllowGet);
        //    }




        //    public ActionResult rptTSDetailSubTask()
        //    {
        //        string User = ""; string SubTask = ""; string Client = ""; string Status = ""; DateTime FromDate = DateTime.Now.AddDays(-90); DateTime ToDate = DateTime.Now;

        //        string sQuery = "EXEC [sp_TimeSheetDetails] '%" + User + "%', '" + FromDate.Date + "', '" + ToDate.Date + "', '%" + SubTask + "%','%" + Client + "%','%" + Status + "%' ";

        //        glb_dt_TimeSheets.Clear();
        //        glb_dt_TimeSheets.tbl_TimeSheets.Merge(cls_HelpMethods.ExecQuery(sQuery).Tables[0]);


        //        ReportViewer reportViewer = new ReportViewer();
        //        reportViewer.LocalReport.Refresh();
        //        reportViewer.ProcessingMode = ProcessingMode.Local;
        //        reportViewer.SizeToReportContent = true;
        //        reportViewer.Width = Unit.Pixel(960);
        //        reportViewer.Height = Unit.Pixel(600);
        //        //reportViewer.ZoomMode = ZoomMode.FullPage;

        //        reportViewer.LocalReport.ReportPath = Server.MapPath("~/SEACCReports/rptTimeSheetDetailsSubTaskWise.rdlc");
        //        reportViewer.LocalReport.DataSources.Clear();
        //        reportViewer.LocalReport.DataSources.Add(new ReportDataSource("DataSet", glb_dt_TimeSheets.tbl_TimeSheets.ToListAsync()));

        //        ReportParameterCollection reportParameters = new ReportParameterCollection();
        //        reportParameters.Add(new ReportParameter("ReportName", "Time Sheet Detail - Sub Task Wise Report"));
        //        reportParameters.Add(new ReportParameter("CompanyName", "Digiteq Solution (Pvt) Ltd"));
        //        reportViewer.LocalReport.SetParameters(reportParameters);
        //        reportViewer.LocalReport.Refresh();

        //        ViewBag.ReportViewer = reportViewer;

        //        return View("ReportViewer");
        //    }




        //    public FileResult TSDetailSubTask(string User, string SubTask, string Client, string Status, DateTime FromDate, DateTime ToDate)
        //    {
        //        string sQuery = "EXEC [sp_TimeSheetDetails] '%" + User + "%', '" + FromDate.Date + "', '" + ToDate.Date + "', '%" + SubTask + "%','%" + Client + "%','%" + Status + "%' ";

        //        glb_dt_TimeSheets.Clear();
        //        glb_dt_TimeSheets.tbl_TimeSheets.Merge(cls_HelpMethods.ExecQuery(sQuery).Tables[0]);

        //        LocalReport lr = new LocalReport();
        //        lr.ReportPath = Server.MapPath("~/SEACCReports/rptTimeSheetDetailsSubTaskWise.rdlc");
        //        lr.DataSources.Clear();
        //        lr.DataSources.Add(new ReportDataSource("DataSet", glb_dt_TimeSheets.tbl_TimeSheets.ToListAsync())); //.Tables[0]

        //        ReportParameterCollection reportParameters = new ReportParameterCollection();
        //        reportParameters.Add(new ReportParameter("ReportName", "Time Sheet Detail - Sub Task Wise Report"));
        //        reportParameters.Add(new ReportParameter("CompanyName", "Digiteq Solution (Pvt) Ltd"));
        //        lr.SetParameters(reportParameters);

        //        lr.Refresh();

        //        byte[] streamBytes = null;
        //        string mimeType = "";
        //        string encoding = "";
        //        string filenameExtension = "";
        //        string[] streamids = null;
        //        Warning[] warnings = null;

        //        streamBytes = lr.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

        //        return File(streamBytes, mimeType); //, "TimeSheetReport" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".pdf"
        //    }

        //    public FileResult TUtilizedHours(string Task, string Status, DateTime FromDate, DateTime ToDate)
        //    {
        //        string sQuery = "EXEC [sp_TaskUtilizedHours] '%" + Task + "%', '%" + Status + "%', '" + FromDate.Date + "', '" + ToDate.Date + "'";

        //        glb_dt_Tasks.Clear();
        //        glb_dt_Tasks.tbl_Tasks.Merge(cls_HelpMethods.ExecQuery(sQuery).Tables[0]);

        //        LocalReport lr = new LocalReport();
        //        lr.ReportPath = Server.MapPath("~/SEACCReports/rptTaskUtilizedHours.rdlc");
        //        lr.DataSources.Clear();
        //        lr.DataSources.Add(new ReportDataSource("DataSet", glb_dt_Tasks.tbl_Tasks.ToListAsync())); //.Tables[0]

        //        ReportParameterCollection reportParameters = new ReportParameterCollection();
        //        reportParameters.Add(new ReportParameter("ReportName", "Task Wise Utilized Hours Detail Report"));
        //        reportParameters.Add(new ReportParameter("CompanyName", "Digiteq Solution (Pvt) Ltd"));
        //        lr.SetParameters(reportParameters);

        //        lr.Refresh();

        //        byte[] streamBytes = null;
        //        string mimeType = "";
        //        string encoding = "";
        //        string filenameExtension = "";
        //        string[] streamids = null;
        //        Warning[] warnings = null;

        //        streamBytes = lr.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

        //        return File(streamBytes, mimeType);
        //    }

        //    public FileResult TEstimatedUtilized(string Task, string Product, string Client, DateTime FromDate, DateTime ToDate)
        //    {
        //        string sQuery = "EXEC [sp_TaskDetailsUtlEst] '%" + Task + "%', '%" + Product + "%', '%" + Client + "%', '" + FromDate.Date + "', '" + ToDate.Date + "'";

        //        glb_dt_Tasks.Clear();
        //        glb_dt_Tasks.tbl_TasksUtlEst.Merge(cls_HelpMethods.ExecQuery(sQuery).Tables[0]);

        //        LocalReport lr = new LocalReport();
        //        lr.ReportPath = Server.MapPath("~/SEACCReports/rptTaskEstimatedUtilizedHours.rdlc");
        //        lr.DataSources.Clear();
        //        lr.DataSources.Add(new ReportDataSource("DataSet", glb_dt_Tasks.tbl_TasksUtlEst.ToListAsync())); //.Tables[0]

        //        ReportParameterCollection reportParameters = new ReportParameterCollection();
        //        reportParameters.Add(new ReportParameter("ReportName", "Task Estimated Vs Utilized Hours Report"));
        //        reportParameters.Add(new ReportParameter("CompanyName", "Digiteq Solution (Pvt) Ltd"));
        //        lr.SetParameters(reportParameters);

        //        lr.Refresh();

        //        byte[] streamBytes = null;
        //        string mimeType = "";
        //        string encoding = "";
        //        string filenameExtension = "";
        //        string[] streamids = null;
        //        Warning[] warnings = null;

        //        streamBytes = lr.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

        //        return File(streamBytes, mimeType); //, "TimeSheetReport" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".pdf"
        //    }

         
        #endregion
    }
}
#region Code Commented
//public ActionResult Print(string ReportID)
//{
//    if(ReportID == "1")
//    {
//        TSDetailSTWise();
//    }
//    else if (ReportID == "2")
//    {
//        TUtilizedHours();
//    }
//    else if (ReportID == "3")
//    {
//        TUtilizedHours();
//    }
//    return Json(true);
//}

//public JsonResult TimeSheets(bool ShowAll, string User_ID, DateTime FromDate, DateTime ToDate) //
//{
//    db.Configuration.ProxyCreationEnabled = false;
//    DateTime dtFromDate = FromDate.Date;
//    DateTime dtToDate = ToDate.Date;

//    List<TimeSheetRVM> HeaderList = new List<TimeSheetRVM>();
//    foreach (var item in db.tbl_pmsTxTimeSheet.Where(p => p.timeSheetDate >= dtFromDate && p.timeSheetDate <= dtToDate).OrderByDescending(p => p.timeSheetDate).ThenByDescending(p => p.timeSheet_ID))
//    {
//        //foreach (var detail in db.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == item.timeSheet_ID).OrderBy(p => p.line_No))
//        //{
//        TimeSheetRVM ts = new TimeSheetRVM();

//        ts.user_ID = item.user_ID;
//        ts.user = item.user_ID != null ? db.tbl_securityUserMaster.FirstOrDefault(p => p.user_ID == item.user_ID).userName : "";
//        ts.timeSheet_ID = item.timeSheet_ID;
//        ts.timeSheetDate = item.timeSheetDate;
//        ts.subTask_ID = item.subTask_ID;
//        ts.subTask = item.tbl_genMasSubTask.subTaskName;
//        ts.isCancelled = item.isCancelled;
//        ts.totalUtilizedHours = item.totalUtilizedHours;
//        ts.remarks = item.remarks;
//        //ts.task_ID = detail.task_ID;
//        //ts.status_ID = detail.status_ID;
//        //ts.status = detail.status_ID != null ? db.tbl_genMasStatus.FirstOrDefault(p => p.status_ID == detail.status_ID).status : "";
//        //ts.task = detail.tbl_pmsTxTask.taskReference;
//        //ts.utilizedHours = detail.utilizedHours;

//        //ts.client_ID = ts.task_ID != null ? db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == detail.task_ID).customer_ID : "";
//        //ts.client = ts.client_ID != null ? db.tbl_genCustomerMaster.FirstOrDefault(p => p.customer_ID == ts.client_ID).customerName : "";
//        //ts.clientCode = ts.client_ID != null ? db.tbl_genCustomerMaster.FirstOrDefault(p => p.customer_ID == ts.client_ID).customerCode : "";

//        //ts.detailremarks = detail.remarks;
//        //ts.line_No = detail.line_No;

//        HeaderList.Add(ts);
//        //}
//    }

//    if (User_ID != null && User_ID != "")
//        HeaderList = HeaderList.Where(p => p.user_ID == User_ID).ToListAsync();

//    if (!ShowAll)
//        HeaderList = HeaderList.Where(p => p.isCancelled == false).ToListAsync();


//    return Json(new { Headers = HeaderList }, JsonRequestBehavior.AllowGet);
//}

//public JsonResult TimeSheetsDetail(string timeSheet_ID)
//{
//    List<TimeSheet_DetailRVM> DetailList = new List<TimeSheet_DetailRVM>();

//    if (timeSheet_ID != null)
//    {
//        foreach (var item in db.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == timeSheet_ID))
//        {
//            TimeSheet_DetailRVM detail = new TimeSheet_DetailRVM();
//            detail.timeSheet_ID = item.timeSheet_ID;
//            detail.task_ID = item.task_ID;
//            detail.status_ID = item.status_ID;
//            detail.status = item.status_ID != null ? db.tbl_genMasStatus.FirstOrDefault(p => p.status_ID == item.status_ID).status : "";
//            detail.task = item.tbl_pmsTxTask.taskReference;
//            detail.utilizedHours = item.utilizedHours;

//            detail.client_ID = item.task_ID != null ? db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == item.task_ID).customer_ID : "";
//            detail.client = detail.client_ID != null ? db.tbl_genCustomerMaster.FirstOrDefault(p => p.customer_ID == detail.client_ID).customerName : "";
//            detail.clientCode = detail.client_ID != null ? db.tbl_genCustomerMaster.FirstOrDefault(p => p.customer_ID == detail.client_ID).customerCode : "";

//            detail.remarks = item.remarks;
//            detail.line_No = item.line_No;

//            DetailList.Add(detail);
//        }
//    }

//    return Json(new { Details = DetailList }, JsonRequestBehavior.AllowGet);
//}

//public JsonResult TimeSheets(bool ShowAll, string User_ID)
//{
//    List<TimeSheetVM> HeaderList = db.tbl_pmsTxTimeSheet
//        .Select(x => new TimeSheetVM
//        {
//            user_ID = x.user_ID,
//            user = db.tbl_securityUserMaster.FirstOrDefault(p => p.user_ID == x.user_ID).userName,
//            timeSheet_ID = x.timeSheet_ID,
//            timeSheetDate = x.timeSheetDate,
//            subTask_ID = x.subTask_ID,
//            subTask = x.tbl_genMasSubTask.subTaskName,
//            isCancelled = x.isCancelled,
//            totalUtilizedHours = x.totalUtilizedHours,
//            remarks = x.remarks
//        }).OrderByDescending(p => p.timeSheetDate).ThenByDescending(p => p.timeSheet_ID).ToListAsync();

//    if (!ShowAll)
//        List = List.Where(p => p.isCancelled == false).ToListAsync();

//    if (User_ID != null)
//        List = List.Where(p => p.user_ID == User_ID).ToListAsync();

//    List<TimeSheet_DetailVM> DetailList = db.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == timeSheet_ID)
//        .Select(x => new TimeSheet_DetailVM
//        {
//            timeSheet_ID = x.timeSheet_ID,
//            task_ID = x.task_ID,
//            status_ID = x.status_ID,
//            status = x.status_ID != null ? db.tbl_genMasStatus.FirstOrDefault(p => p.status_ID == x.status_ID).status : "",
//            task = x.tbl_pmsTxTask.taskReference,
//            utilizedHours = x.utilizedHours,
//            remarks = x.remarks,
//            line_No = x.line_No
//        }).ToListAsync();

//List<TimeSheet_DetailRVM> DetailList = new List<TimeSheet_DetailRVM>();

//if (timeSheet_ID != null)
//{
//    foreach (var item in db.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == timeSheet_ID))
//    {
//        TimeSheet_DetailRVM detail = new TimeSheet_DetailRVM();
//        detail.timeSheet_ID = item.timeSheet_ID;
//        detail.task_ID = item.task_ID;
//        detail.status_ID = item.status_ID;
//        detail.status = item.status_ID != null ? db.tbl_genMasStatus.FirstOrDefault(p => p.status_ID == item.status_ID).status : "";
//        detail.task = item.tbl_pmsTxTask.taskReference;
//        detail.utilizedHours = item.utilizedHours;

//        detail.client_ID = item.task_ID != null ? db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == item.task_ID).customer_ID : "";
//        detail.client = detail.client_ID != null ? db.tbl_genCustomerMaster.FirstOrDefault(p => p.customer_ID == detail.client_ID).customerName : "";
//        detail.clientCode = detail.client_ID != null ? db.tbl_genCustomerMaster.FirstOrDefault(p => p.customer_ID == detail.client_ID).customerCode : "";

//        detail.remarks = item.remarks;
//        detail.line_No = item.line_No;

//        DetailList.Add(detail);
//    }
//}

//    return Json(new { HeaderData = HeaderList, DetailDate = DetailList }, JsonRequestBehavior.AllowGet);
//} 
#endregion