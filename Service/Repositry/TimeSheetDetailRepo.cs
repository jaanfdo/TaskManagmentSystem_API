using DataAccess.Context;
using DataAccess.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class TimeSheetDetailRepo
    {
        private readonly ApplicationContext _context;
        public async Task<List<TimeSheet_DetailVM>> TimeSheetsDetail(string timeSheet_ID)
        {
            List<TimeSheet_DetailVM> TimeSheetList = await _context.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == timeSheet_ID)
                .Select(x => new TimeSheet_DetailVM
                {
                    timeSheet_ID = x.timeSheet_ID,
                    task_ID = x.task_ID,
                    status_ID = x.status_ID,
                    status = x.status_ID != null ? _context.tbl_genMasStatus.FirstOrDefault(p => p.status_ID == x.status_ID).status : "",
                    task = x.tbl_pmsTxTask.taskReference,
                    utilizedHours = x.utilizedHours,
                    remarks = x.remarks,
                    line_No = x.line_No
                }).ToListAsync();

            return TimeSheetList;
        }

        #region Transactions
        //public async Task<> SaveTimeSheetDetail(TimeSheet oTimeSheet)
        //{
        //    bool status = false;
        //    string TimeSheetID = "";
        //    string Message = "";
        //    try
        //    {
        //        if (oTimeSheet.timeSheet_ID != null)
        //        {
        //            foreach (var oDetail in oTimeSheet.TimeSheetDetails)
        //            {
        //                var Task = _context.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == oDetail.task_ID);
        //                Task.status_ID = oDetail.status_ID;

        //                tbl_pmsTxTimeSheet_Detail oTimeSheets_Detail = new tbl_pmsTxTimeSheet_Detail();
        //                oTimeSheets_Detail.task_ID = oDetail.task_ID;
        //                oTimeSheets_Detail.line_No = oDetail.line_No;
        //                oTimeSheets_Detail.timeSheet_ID = oTimeSheet.timeSheet_ID;
        //                oTimeSheets_Detail.remarks = oDetail.remarks != null ? oDetail.remarks : "";
        //                oTimeSheets_Detail.utilizedHours = oDetail.utilizedHours;
        //                oTimeSheets_Detail.status_ID = oDetail.status_ID;

        //                _context.tbl_pmsTxTimeSheet_Detail.Add(oTimeSheets_Detail);
        //            }                    
        //            _context.SaveChanges();

        //            Message = "Time Sheet Saved Successfully...!";
        //            status = true;
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

        //    return await new JsonResult { Data = new { status = status, TimeSheetID = TimeSheetID, Message = Message } };
        //}
        //public async JsonResult EditTimeSheetDetail(TimeSheet oTimeSheet)
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
        //public async bool DeleteTimeSheetDetail(string timeSheet_ID)
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
