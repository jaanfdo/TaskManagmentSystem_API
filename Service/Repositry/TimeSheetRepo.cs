using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models.ViewModels;
using System.Threading.Tasks;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace DataAccess.DataAccess
{
    public class TimeSheetRepo : ITimeSheet
    {
        private readonly ApplicationContext _context;
        //private ApplicationDbContext _context = new ApplicationDbContext();
        string sUser_ID = "";// System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = ""; //System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = "";// System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;

        public TimeSheetRepo(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<TimeSheetVM>> TimeSheets(bool ShowAll)
        {
            return await new TimeSheetDAO(_context).GetTimeSheetsList(ShowAll);
        }

        public async Task<List<TimeSheet_DetailVM>> TimeSheetsDetail(string timeSheet_ID)
        {
            return await new TimeSheetDetailDAO(_context).GetTimeSheetsDetail(timeSheet_ID);
        }

        public async Task<List<TimeSheetVM>> TimeSheet(string timeSheet_ID)
        {
            return await new TimeSheetDAO(_context).GetTimeSheet(timeSheet_ID);
        }

        #region MyRegion
        //public async Task<tbl_pmsTxTimeSheet> Edit(string timeSheet_ID)
        //{
        //    if (timeSheet_ID == null)
        //    {
        //        return null;//new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet = await _context.tbl_pmsTxTimeSheet.Where(p => p.timeSheet_ID == timeSheet_ID).FirstOrDefaultAsync();
        //    if (tbl_pmsTxTimeSheet == null)
        //    {
        //        return null; //HttpNotFound();
        //    }

        //    //ViewBag.isCancel = tbl_pmsTxTimeSheet.isCancelled;
        //    //ViewBag.timeSheet_ID = tbl_pmsTxTimeSheet.timeSheet_ID;

        //    //ViewBag.subTask_ID = new SelectList(_context.tbl_genMasSubTask, "subTask_ID", "subTaskName", tbl_pmsTxTimeSheet.subTask_ID);

        //    //var vResult = _context.tbl_pmsTxTask.Where(p => p.status_ID != "2" && p.assignedUser_ID == sUser_ID);
        //    //ViewBag.task_ID = new SelectList(vResult, "task_ID", "taskReference");

        //    return tbl_pmsTxTimeSheet;
        //}
        //public async Task<tbl_pmsTxTimeSheet> Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return null;// await new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet = await _context.tbl_pmsTxTimeSheet.FindAsync(id);
        //    if (tbl_pmsTxTimeSheet == null)
        //    {
        //        return null; // await HttpNotFound();
        //    }
        //    return tbl_pmsTxTimeSheet;
        //}
        //public async Task<tbl_pmsTxTimeSheet> Delete(string id)
        //{
        //    if (id == null)
        //    {
        //        return null; // await new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet = await _context.tbl_pmsTxTimeSheet.FindAsync(id);
        //    if (tbl_pmsTxTimeSheet == null)
        //    {
        //        return null; //await HttpNotFound();
        //    }
        //    return tbl_pmsTxTimeSheet;
        //}
        //public async Task<tbl_pmsTxTimeSheet> Create()
        //{
        //    //ViewBag.subTask_ID = new SelectList(_context.tbl_genMasSubTask, "subTask_ID", "subTaskName");
        //    //ViewBag.status_ID = new SelectList(_context.tbl_genMasStatus, "status_ID", "status");

        //    //var vResult = _context.tbl_pmsTxTask.Where(p => p.status_ID != "2" && p.assignedUser_ID == sUser_ID);
        //    //ViewBag.task_ID = new SelectList(vResult, "task_ID", "taskReference");
        //    return null;
        //} 
        #endregion


        #region Transactions
        //public async JsonResult SaveTimeSheet(TimeSheet oTimeSheet)
        //{
        //    bool status = false;
        //    string TimeSheetID = "";
        //    string Message = "";
        //    try
        //    {
        //        if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
        //        {
        //            oTimeSheet.timeSheet_ID = "";// cls_AutoCode.AutoCode((int)enumFormNames.TimeSheet);
        //            if (oTimeSheet.timeSheet_ID != null)
        //            {
        //                tbl_pmsTxTimeSheet oTimeSheets = new tbl_pmsTxTimeSheet(oTimeSheet.timeSheet_ID, oTimeSheet.timeSheetDate, oTimeSheet.subTask_ID, oTimeSheet.totalUtilizedHours, oTimeSheet.remarks != null ? oTimeSheet.remarks : "",
        //                   false, sUser_ID, sUser_ID, sUser_ID, sUser_ID, DateTime.Now, DateTime.Now, DateTime.Now, sCompany_ID, sCompanyBranch_ID);

        //                _context.tbl_pmsTxTimeSheet.Add(oTimeSheets);
        //                TimeSheetID = oTimeSheet.timeSheet_ID;
        //                _context.SaveChanges();


        //                foreach (var oDetail in oTimeSheet.TimeSheetDetails)
        //                {
        //                    var Task = _context.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == oDetail.task_ID);
        //                    Task.status_ID = oDetail.status_ID;

        //                    tbl_pmsTxTimeSheet_Detail oTimeSheets_Detail = new tbl_pmsTxTimeSheet_Detail();
        //                    oTimeSheets_Detail.task_ID = oDetail.task_ID;
        //                    oTimeSheets_Detail.line_No = oDetail.line_No;
        //                    oTimeSheets_Detail.timeSheet_ID = oTimeSheet.timeSheet_ID;
        //                    oTimeSheets_Detail.remarks = oDetail.remarks != null ? oDetail.remarks : "";
        //                    oTimeSheets_Detail.utilizedHours = oDetail.utilizedHours;
        //                    oTimeSheets_Detail.status_ID = oDetail.status_ID;

        //                    _context.tbl_pmsTxTimeSheet_Detail.Add(oTimeSheets_Detail);
        //                }

        //                //_context.tbl_pmsTxTimeSheet_Detail.AddRange(oTimeSheet.TimeSheetDetails);
        //                _context.SaveChanges();

        //                Message = "Time Sheet Saved Successfully...!";
        //                status = true;
        //            }
        //            else
        //            {
        //                Message = "Time Sheet ID is Empty...!";
        //                status = false;
        //            }

        //        }
        //        else
        //        {
        //            string sHeader = "Your Session is Expired";
        //            Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
        //            status = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message + "\n\n" + ex.Data;
        //        status = false;
        //    }

        //    return await new JsonResult { Data = new { status = status, TimeSheetID = TimeSheetID, Message = Message } };
        //}
        //public async JsonResult EditTimeSheet(TimeSheet oTimeSheet)
        //{
        //    bool status = false;
        //    string Message = "";
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
        //            {
        //                var oldRecord = _context.tbl_pmsTxTimeSheet.FirstOrDefault(p => p.timeSheet_ID == oTimeSheet.timeSheet_ID);
        //                if (oldRecord != null)
        //                {
        //                    foreach (var oldRecordDetail in _context.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == oTimeSheet.timeSheet_ID))
        //                    {
        //                        _context.Entry(oldRecordDetail).State = EntityState.Deleted;
        //                    }
        //                    _context.SaveChanges();

        //                    oldRecord.timeSheet_ID = oTimeSheet.timeSheet_ID;
        //                    oldRecord.timeSheetDate = oTimeSheet.timeSheetDate;
        //                    oldRecord.subTask_ID = oTimeSheet.subTask_ID;
        //                    oldRecord.totalUtilizedHours = oTimeSheet.totalUtilizedHours;
        //                    oldRecord.remarks = oTimeSheet.remarks != null ? oTimeSheet.remarks : "";
        //                    oldRecord.modifiedUser_ID = sUser_ID;
        //                    oldRecord.dateModified = DateTime.Now;

        //                    foreach (var oDetail in oTimeSheet.TimeSheetDetails)
        //                    {
        //                        var Task = _context.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == oDetail.task_ID);
        //                        Task.status_ID = oDetail.status_ID;

        //                        tbl_pmsTxTimeSheet_Detail oTimeSheets_Detail = new tbl_pmsTxTimeSheet_Detail();
        //                        oTimeSheets_Detail.task_ID = oDetail.task_ID;
        //                        oTimeSheets_Detail.line_No = oDetail.line_No;
        //                        oTimeSheets_Detail.timeSheet_ID = oTimeSheet.timeSheet_ID;
        //                        oTimeSheets_Detail.remarks = oDetail.remarks != null ? oDetail.remarks : "";
        //                        oTimeSheets_Detail.utilizedHours = oDetail.utilizedHours;
        //                        oTimeSheets_Detail.status_ID = oDetail.status_ID;

        //                        _context.tbl_pmsTxTimeSheet_Detail.Add(oTimeSheets_Detail);
        //                    }

        //                    _context.SaveChanges();

        //                    Message = "Time Sheet Updated Successfully...!";
        //                    status = true;
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
        //    return await new JsonResult { Data = new { status = status, Message = Message } };
        //}
        //public async JsonResult DeleteConfirmed(string timeSheet_ID)
        //{
        //    bool status = false;
        //    string Message = "";
        //    try
        //    {
        //        if (timeSheet_ID != null)
        //        {
        //            if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
        //            {
        //                var oTimeSheet = _context.tbl_pmsTxTimeSheet.Find(timeSheet_ID);
        //                if (oTimeSheet != null)
        //                {
        //                    oTimeSheet.isCancelled = true;
        //                    oTimeSheet.deletedUser_ID = sUser_ID;
        //                    oTimeSheet.dateDeleted = DateTime.Now;

        //                    //_context.Entry(oTimeSheet).State = EntityState.Modified;
        //                    _context.SaveChanges();

        //                    ViewBag.isCancel = oTimeSheet.isCancelled;

        //                    Message = "Time Sheet Cancelled Successfully...!";
        //                    status = true;
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
        //            Message = "Time Sheet ID is Empty...!";
        //            status = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Message = ex.Message + "\n\n" + ex.Data;
        //        status = false;
        //    }
        //    return await new JsonResult { Data = new { status = status, Message = Message } };
        //}
        #endregion

    }
}
