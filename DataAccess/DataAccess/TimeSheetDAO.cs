using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models.ViewModels;
using System.Threading.Tasks;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccess
{
    public class TimeSheetDAO
    {
        private readonly ApplicationContext _context;
        //private ApplicationDbContext _context = new ApplicationDbContext();
        string sUser_ID = "";// System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = ""; //System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = "";// System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;

        public TimeSheetDAO(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<TimeSheetVM>> GetTimeSheetsList(bool ShowAll)
        {
            List<TimeSheetVM> TimeSheetList = await _context.tbl_pmsTxTimeSheet //.Where(p => p.user_ID == sUser_ID)
                .Select(x => new TimeSheetVM
                {
                    user_ID = x.user_ID,
                    user = _context.tbl_securityUserMaster.FirstOrDefault(p => p.user_ID == x.user_ID).userName,
                    timeSheet_ID = x.timeSheet_ID,
                    timeSheetDate = x.timeSheetDate,
                    subTask_ID = x.subTask_ID,
                    subTask = x.tbl_genMasSubTask.subTaskName,
                    isCancelled = x.isCancelled,
                    totalUtilizedHours = x.totalUtilizedHours,
                    remarks = x.remarks
                }).OrderByDescending(p => p.timeSheetDate).ThenByDescending(p => p.timeSheet_ID).ToListAsync();

            if (!ShowAll)
                TimeSheetList = TimeSheetList.Where(p => p.isCancelled == false).ToList();

            return TimeSheetList;
        }

        public async Task<List<TimeSheetVM>> GetTimeSheet(string timeSheet_ID)
        {
            List<TimeSheetVM> TimeSheetList = await _context.tbl_pmsTxTimeSheet.Where(p => p.timeSheet_ID == timeSheet_ID)
                .Select(x => new TimeSheetVM
                {
                    timeSheet_ID = x.timeSheet_ID,
                    timeSheetDate = x.timeSheetDate,
                    subTask_ID = x.tbl_genMasSubTask.subTaskName,
                    remarks = x.remarks,
                    totalUtilizedHours = x.totalUtilizedHours,
                    isCancelled = x.isCancelled
                }).ToListAsync();

            return TimeSheetList;
        }

        public async Task<List<TimeSheet_DetailVM>> GetTimeSheetsDetail(string timeSheet_ID)
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


        #region MyRegion
        public async Task<tbl_pmsTxTimeSheet> Edit(string timeSheet_ID)
        {
            if (timeSheet_ID == null)
            {
                return null;//new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet = await _context.tbl_pmsTxTimeSheet.Where(p => p.timeSheet_ID == timeSheet_ID).FirstOrDefaultAsync();
            if (tbl_pmsTxTimeSheet == null)
            {
                return null; //HttpNotFound();
            }

            //ViewBag.isCancel = tbl_pmsTxTimeSheet.isCancelled;
            //ViewBag.timeSheet_ID = tbl_pmsTxTimeSheet.timeSheet_ID;

            //ViewBag.subTask_ID = new SelectList(_context.tbl_genMasSubTask, "subTask_ID", "subTaskName", tbl_pmsTxTimeSheet.subTask_ID);

            //var vResult = _context.tbl_pmsTxTask.Where(p => p.status_ID != "2" && p.assignedUser_ID == sUser_ID);
            //ViewBag.task_ID = new SelectList(vResult, "task_ID", "taskReference");

            return tbl_pmsTxTimeSheet;
        }
        public async Task<tbl_pmsTxTimeSheet> Details(string id)
        {
            if (id == null)
            {
                return null;// await new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet = await _context.tbl_pmsTxTimeSheet.FindAsync(id);
            if (tbl_pmsTxTimeSheet == null)
            {
                return null; // await HttpNotFound();
            }
            return tbl_pmsTxTimeSheet;
        }
        public async Task<tbl_pmsTxTimeSheet> Delete(string id)
        {
            if (id == null)
            {
                return null; // await new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_pmsTxTimeSheet tbl_pmsTxTimeSheet = await _context.tbl_pmsTxTimeSheet.FindAsync(id);
            if (tbl_pmsTxTimeSheet == null)
            {
                return null; //await HttpNotFound();
            }
            return tbl_pmsTxTimeSheet;
        }
        public async Task<tbl_pmsTxTimeSheet> Create()
        {
            //ViewBag.subTask_ID = new SelectList(_context.tbl_genMasSubTask, "subTask_ID", "subTaskName");
            //ViewBag.status_ID = new SelectList(_context.tbl_genMasStatus, "status_ID", "status");

            //var vResult = _context.tbl_pmsTxTask.Where(p => p.status_ID != "2" && p.assignedUser_ID == sUser_ID);
            //ViewBag.task_ID = new SelectList(vResult, "task_ID", "taskReference");
            return null;
        } 
        #endregion

        #region Transactions
        public async Task<tbl_pmsTxTimeSheet> SaveTimeSheet(TimeSheet oTimeSheet)
        {
            string Message = "";
            try
            {
                tbl_pmsTxTimeSheet oTimeSheets = new tbl_pmsTxTimeSheet(oTimeSheet.timeSheet_ID,
                    oTimeSheet.timeSheetDate, oTimeSheet.subTask_ID, oTimeSheet.totalUtilizedHours,
                    oTimeSheet.remarks != null ? oTimeSheet.remarks : "",
                   false, sUser_ID, sUser_ID, sUser_ID, sUser_ID,
                   DateTime.Now, DateTime.Now, DateTime.Now,
                   sCompany_ID, sCompanyBranch_ID);

                _context.tbl_pmsTxTimeSheet.Add(oTimeSheets);
                await _context.SaveChangesAsync();

                return oTimeSheets;
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
            }
            return null;
        }
        public async Task<tbl_pmsTxTimeSheet> EditTimeSheet(TimeSheet oTimeSheet)
        {
            string Message = "";
            try
            {
                var oldRecord = await _context.tbl_pmsTxTimeSheet.FirstOrDefaultAsync(p => p.timeSheet_ID == oTimeSheet.timeSheet_ID);
                if (oldRecord != null)
                {
                    oldRecord.timeSheet_ID = oTimeSheet.timeSheet_ID;
                    oldRecord.timeSheetDate = oTimeSheet.timeSheetDate;
                    oldRecord.subTask_ID = oTimeSheet.subTask_ID;
                    oldRecord.totalUtilizedHours = oTimeSheet.totalUtilizedHours;
                    oldRecord.remarks = oTimeSheet.remarks != null ? oTimeSheet.remarks : "";
                    oldRecord.modifiedUser_ID = sUser_ID;
                    oldRecord.dateModified = DateTime.Now;

                    _context.Entry(oldRecord).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return oldRecord;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
            }
            return null;
        }
        public async Task<bool> DeleteConfirmed(string timeSheet_ID)
        {
            string Message = "";
            try
            {
                var oTimeSheet = await _context.tbl_pmsTxTimeSheet.FindAsync(timeSheet_ID);
                if (oTimeSheet != null)
                {
                    oTimeSheet.isCancelled = true;
                    oTimeSheet.deletedUser_ID = sUser_ID;
                    oTimeSheet.dateDeleted = DateTime.Now;

                    _context.Entry(oTimeSheet).State = EntityState.Deleted;
                    await _context.SaveChangesAsync();

                    return true;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
            }
            return false;
        }
        #endregion

    }
}
