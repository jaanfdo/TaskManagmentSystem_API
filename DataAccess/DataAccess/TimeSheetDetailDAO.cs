using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Models.ViewModels;
using System.Threading.Tasks;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.DataAccess
{
    public class TimeSheetDetailDAO
    {
        private readonly ApplicationContext _context;
        string sUser_ID = "";// System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = ""; //System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = "";// System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;

        public TimeSheetDetailDAO(ApplicationContext context)
        {
            _context = context;
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

        #region Transactions
        public async Task<bool> SaveTimeSheetDetail(TimeSheet oTimeSheet)
        {
            string Message = "";
            try
            {
                foreach (var oDetail in oTimeSheet.TimeSheetDetails)
                {
                    tbl_pmsTxTimeSheet_Detail oTimeSheets_Detail = new tbl_pmsTxTimeSheet_Detail();
                    oTimeSheets_Detail.task_ID = oDetail.task_ID;
                    oTimeSheets_Detail.line_No = oDetail.line_No;
                    oTimeSheets_Detail.timeSheet_ID = oTimeSheet.timeSheet_ID;
                    oTimeSheets_Detail.remarks = oDetail.remarks != null ? oDetail.remarks : "";
                    oTimeSheets_Detail.utilizedHours = oDetail.utilizedHours;
                    oTimeSheets_Detail.status_ID = oDetail.status_ID;

                    _context.tbl_pmsTxTimeSheet_Detail.Add(oTimeSheets_Detail);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
            }

            return false;
        }
        public async Task<bool> DeleteTimeSheetDetail(string timeSheet_ID)
        {
            string Message = "";
            try
            {
                foreach (var oldRecordDetail in _context.tbl_pmsTxTimeSheet_Detail.Where(p => p.timeSheet_ID == timeSheet_ID))
                {
                    _context.Entry(oldRecordDetail).State = EntityState.Deleted;
                }
                await _context.SaveChangesAsync();

                return true;
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
