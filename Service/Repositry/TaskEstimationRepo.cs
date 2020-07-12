using DataAccess.Context;
using DataAccess.Models.ViewModels;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class TaskEstimationRepo : ITaskEstimation
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        //string sUser_ID = System.Web.HttpContext.Current.Session["user_ID"] as String;
        //string sCompany_ID = System.Web.HttpContext.Current.Session["company_ID"] as String;
        //string sCompanyBranch_ID = System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;

        private readonly ApplicationContext _context;

        public TaskEstimationRepo(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<TaskEstimation_VM>> TaskEstimations(string estimation_ID)
        {
            return await new TaskEstimationDAO(_context).GetEstimations(estimation_ID);
        }
        public async Task<List<TaskEstimation_DetailVM>> TaskEstimationsDetails(string estimation_ID)
        {
            return await new TaskEstimationDetailDAO(_context).GetEstimationDetails(estimation_ID);
        }


        #region MyRegion

        //// GET: tbl_pmsTxTaskEstimation/Details/5
        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTaskEstimation tbl_pmsTxTaskEstimation = db.tbl_pmsTxTaskEstimation.Find(id);
        //    if (tbl_pmsTxTaskEstimation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_pmsTxTaskEstimation);
        //}

        //// GET: tbl_pmsTxTaskEstimation/Create
        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Create(string task_ID)
        //{
        //    cls_HelpMethods.UserDetail();
        //    cls_HelpMethods.CompanyDetail();

        //    ViewBag.task_ID = task_ID;
        //    ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask.Where(p => p.isActive == true), "subTask_ID", "subTaskName");

        //    return View();
        //}

        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Create2(string task_ID)
        //{
        //    cls_HelpMethods.UserDetail();
        //    cls_HelpMethods.CompanyDetail();

        //    ViewBag.task_ID = task_ID;
        //    ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask.Where(p => p.isActive == true), "subTask_ID", "subTaskName");

        //    return View();
        //}

        //// GET: tbl_pmsTxTaskEstimation/Edit/5
        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Edit(string estimation_ID)
        //{
        //    if (estimation_ID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTaskEstimation tbl_pmsTxTaskEstimation = db.tbl_pmsTxTaskEstimation.Where(p => p.estimation_ID == estimation_ID).FirstOrDefault();
        //    if (tbl_pmsTxTaskEstimation == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.isApprove = tbl_pmsTxTaskEstimation.isApproved;
        //    ViewBag.isCancel = tbl_pmsTxTaskEstimation.isCancelled;

        //    //var List = db.tbl_pmsTxTask.Where(p => p.assignedUser_ID == sUser_ID);

        //    ViewBag.estimation_ID = tbl_pmsTxTaskEstimation.estimation_ID;
        //    ViewBag.task_ID = new SelectList(db.tbl_pmsTxTask.Where(p => p.isCancelled == false), "task_ID", "taskReference", tbl_pmsTxTaskEstimation.task_ID);
        //    ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask.Where(p => p.isActive == true), "subTask_ID", "subTaskName");
        //    return View();
        //}

        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Edit2(string estimation_ID)
        //{
        //    if (estimation_ID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTaskEstimation tbl_pmsTxTaskEstimation = db.tbl_pmsTxTaskEstimation.Where(p => p.estimation_ID == estimation_ID).FirstOrDefault();
        //    if (tbl_pmsTxTaskEstimation == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.isApprove = tbl_pmsTxTaskEstimation.isApproved;
        //    ViewBag.isCancel = tbl_pmsTxTaskEstimation.isCancelled;

        //    //var List = db.tbl_pmsTxTask.Where(p => p.assignedUser_ID == sUser_ID);

        //    ViewBag.estimation_ID = tbl_pmsTxTaskEstimation.estimation_ID;
        //    ViewBag.task_ID = new SelectList(db.tbl_pmsTxTask.Where(p => p.isCancelled == false), "task_ID", "taskReference", tbl_pmsTxTaskEstimation.task_ID);
        //    ViewBag.subTask_ID = new SelectList(db.tbl_genMasSubTask.Where(p => p.isActive == true), "subTask_ID", "subTaskName");
        //    return View();
        //}

        //// GET: tbl_pmsTxTaskEstimation/Delete/5
        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Delete(string estimation_ID)
        //{
        //    if (estimation_ID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTaskEstimation tbl_pmsTxTaskEstimation = db.tbl_pmsTxTaskEstimation.Find(estimation_ID);
        //    if (tbl_pmsTxTaskEstimation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_pmsTxTaskEstimation);
        //} 
        #endregion



        #region Transaction
        //// POST: tbl_pmsTxTaskEstimation/Create
        //[HttpPost]
        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public JsonResult SaveTaskEstimation(TaskEstimation oTaskEstimation)
        //{
        //    bool status = false;
        //    string EstimationID = "", Message = "";
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
        //            {
        //                var Task = db.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == oTaskEstimation.task_ID);
        //                if (Task == null)
        //                {
        //                    oTaskEstimation.estimation_ID = tbl_AutoCode.AutoCode((int)enumFormNames.TaskEstimation);
        //                    if (oTaskEstimation.estimation_ID != null)
        //                    {
        //                        tbl_pmsTxTaskEstimation oEstimation = new tbl_pmsTxTaskEstimation(oTaskEstimation.estimation_ID, oTaskEstimation.estimationDate, oTaskEstimation.task_ID, oTaskEstimation.totalEstimatedHours, oTaskEstimation.remarks,
        //                            false, false, sUser_ID, sUser_ID, sUser_ID, sUser_ID, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, sCompany_ID, sCompanyBranch_ID);

        //                        db.tbl_pmsTxTaskEstimation.Add(oEstimation);
        //                        db.SaveChanges();

        //                        foreach (var oDetail in oTaskEstimation.TaskEstimationDetails)
        //                        {
        //                            //tbl_pmsTxTaskEstimation_Detail oEstimationDetail = new tbl_pmsTxTaskEstimation_Detail(oDetail.line_No, oDetail.estimation_ID, oDetail.subTask_ID, oDetail.estimatedHours);
        //                            oDetail.estimation_ID = oTaskEstimation.estimation_ID;
        //                        }

        //                        db.tbl_pmsTxTaskEstimation_Detail.AddRange(oTaskEstimation.TaskEstimationDetails);
        //                        db.SaveChanges();

        //                        EstimationID = oTaskEstimation.estimation_ID;

        //                        status = true;
        //                        Message = "Task Estimation Saved Successfully";
        //                    }
        //                    else
        //                    {
        //                        Message = "Task Estimation ID is Empty...!";
        //                        status = false;
        //                    }
        //                }
        //                else
        //                {
        //                    Message = "Already Create Estimation for This Task";
        //                    status = false;
        //                }
        //            }
        //            else
        //            {
        //                string sHeader = "Your Session is Expired";
        //                Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
        //                status = false;
        //            }
        //        }
        //        else
        //        {
        //            Message = "Model State Invalid...!";
        //            status = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message + "\n\n" + ex.Data;
        //        status = false;
        //    }

        //    return new JsonResult { Data = new { status = status, EstimationID = EstimationID, Message = Message } };
        //}

        //// POST: tbl_pmsTxTaskEstimation/Edit/5
        //[HttpPost]
        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public JsonResult EditTaskEstimation(TaskEstimation oTaskEstimation)
        //{
        //    bool status = false;
        //    string Message = "";
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
        //            {
        //                var oldRecord = db.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.estimation_ID == oTaskEstimation.estimation_ID);
        //                if (oldRecord != null)
        //                {
        //                    foreach (var oldRecordDetail in db.tbl_pmsTxTaskEstimation_Detail.Where(p => p.estimation_ID == oTaskEstimation.estimation_ID))
        //                    {
        //                        db.Entry(oldRecordDetail).State = EntityState.Deleted;
        //                    }
        //                    db.SaveChanges();

        //                    oldRecord.estimation_ID = oTaskEstimation.estimation_ID;
        //                    oldRecord.estimationDate = oTaskEstimation.estimationDate;
        //                    oldRecord.task_ID = oTaskEstimation.task_ID;
        //                    oldRecord.totalEstimatedHours = oTaskEstimation.totalEstimatedHours;
        //                    oldRecord.remarks = oTaskEstimation.remarks;
        //                    oldRecord.modifiedUser_ID = sUser_ID;
        //                    oldRecord.dateModified = DateTime.Now;

        //                    //db.Entry(oldRecord).State = EntityState.Modified;
        //                    db.tbl_pmsTxTaskEstimation_Detail.AddRange(oTaskEstimation.TaskEstimationDetails);
        //                    db.SaveChanges();

        //                    status = true;
        //                    Message = "Estimation Updated Successfully";
        //                }
        //                else
        //                {
        //                    Message = "Time Sheet Details are Empty...!";
        //                    status = false;
        //                }
        //            }
        //            else
        //            {
        //                string sHeader = "Your Session is Expired";
        //                Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
        //                status = false;
        //            }
        //        }
        //        else
        //        {
        //            Message = "Model State Invalid...!";
        //            status = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message + "\n\n" + ex.Data;
        //        status = false;
        //    }
        //    return new JsonResult { Data = new { status = status, Message = Message } };
        //}

        //// POST: tbl_pmsTxTaskEstimation/Edit/5
        //[HttpPost]
        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public JsonResult ApproveTaskEstimation(string estimation_ID)
        //{
        //    bool status = false;
        //    bool bIsApproved = false;
        //    string Message = "";
        //    try
        //    {
        //        if (estimation_ID != null)
        //        {
        //            if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
        //            {
        //                var oTaskEstimation = db.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.estimation_ID == estimation_ID);
        //                if (oTaskEstimation != null)
        //                {
        //                    oTaskEstimation.isApproved = true;
        //                    oTaskEstimation.dateApproved = DateTime.Now;
        //                    oTaskEstimation.approvedUser_ID = sUser_ID;

        //                    var oTask = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == oTaskEstimation.task_ID);
        //                    if (oTask != null)
        //                    {
        //                        oTask.status_ID = "2";
        //                    }

        //                    //db.Entry(oTaskEstimation).State = EntityState.Modified;
        //                    //db.Entry(oTask).State = EntityState.Modified;
        //                    db.SaveChanges();

        //                    //ViewBag.isApprove = oTaskEstimation.isApproved;
        //                    bIsApproved = oTaskEstimation.isApproved;

        //                    Message = "Task Estimation Approved Successfully...!";
        //                    status = true;
        //                }
        //                else
        //                {
        //                    Message = "Task Estimation Details are Empty...!";
        //                    status = false;
        //                }
        //            }
        //            else
        //            {
        //                string sHeader = "Your Session is Expired";
        //                Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
        //                status = false;
        //            }
        //        }
        //        else
        //        {
        //            Message = "Task Estimation ID is Empty...!";
        //            status = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message + "\n\n" + ex.Data;
        //        status = false;
        //    }
        //    return new JsonResult { Data = new { status = status, isApproved = bIsApproved, Message = Message } };
        //}

        //// POST: tbl_pmsTxTaskEstimation/Delete/5
        //[HttpPost]
        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public JsonResult DeleteTaskEstimation(string estimation_ID)
        //{
        //    bool status = false;
        //    bool bIscancelled = false;
        //    string Message = "";
        //    try
        //    {
        //        if (estimation_ID != null)
        //        {
        //            if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
        //            {
        //                var oTaskEstimation = db.tbl_pmsTxTaskEstimation.Find(estimation_ID);
        //                if (oTaskEstimation != null)
        //                {
        //                    oTaskEstimation.isCancelled = true;
        //                    oTaskEstimation.deletedUser_ID = sUser_ID;
        //                    oTaskEstimation.dateDeleted = DateTime.Now;

        //                    //db.Entry(oTaskEstimation).State = EntityState.Modified;
        //                    db.SaveChanges();

        //                    //ViewBag.isApprove = oTaskEstimation.isCancelled;
        //                    bIscancelled = oTaskEstimation.isCancelled;

        //                    Message = "Task Estimation Cancelled Successfully...!";
        //                    status = true;
        //                }
        //            }
        //            else
        //            {
        //                string sHeader = "Your Session is Expired";
        //                Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
        //                status = false;
        //            }
        //        }
        //        else
        //        {
        //            Message = "Task Estimation ID is Empty...!";
        //            status = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message + "\n\n" + ex.Data;
        //        status = false;
        //    }

        //    return new JsonResult { Data = new { status = status, isCancelled = bIscancelled, Message = Message } };
        //} 
        #endregion

    }
}
