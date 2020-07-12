using DataAccess.Context;
using DataAccess.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class TaskEstimationDAO
    {
        private readonly ApplicationContext _context;
        string sUser_ID = "";//System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = "";//System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = "";//System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;
        public TaskEstimationDAO(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<TaskEstimation_VM>> GetEstimations(string estimation_ID)
        {
            List<TaskEstimation_VM> List = _context.tbl_pmsTxTaskEstimation
                .Where(p => p.estimation_ID == estimation_ID)
                .Select(x => new TaskEstimation_VM
                {
                    estimation_ID = x.estimation_ID,
                    estimationDate = x.estimationDate,
                    task_ID = x.task_ID,
                    task = x.tbl_pmsTxTask.taskReference,
                    totalEstimatedHours = x.totalEstimatedHours,
                    remarks = x.remarks,
                    isApproved = x.isApproved,
                    isCancelled = x.isCancelled
                }).ToList();

            return List;
        }

        #region Reference
        //public ActionResult Details(string id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTaskEstimation tbl_pmsTxTaskEstimation = _context.tbl_pmsTxTaskEstimation.Find(id);
        //    if (tbl_pmsTxTaskEstimation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_pmsTxTaskEstimation);
        //}

        //public ActionResult Create(string task_ID)
        //{
        //    cls_HelpMethods.UserDetail();
        //    cls_HelpMethods.CompanyDetail();

        //    ViewBag.task_ID = task_ID;
        //    ViewBag.subTask_ID = new SelectList(_context.tbl_genMasSubTask.Where(p => p.isActive == true), "subTask_ID", "subTaskName");

        //    return View();
        //}

        //public ActionResult Edit(string estimation_ID)
        //{
        //    if (estimation_ID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTaskEstimation tbl_pmsTxTaskEstimation = _context.tbl_pmsTxTaskEstimation.Where(p => p.estimation_ID == estimation_ID).FirstOrDefault();
        //    if (tbl_pmsTxTaskEstimation == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.isApprove = tbl_pmsTxTaskEstimation.isApproved;
        //    ViewBag.isCancel = tbl_pmsTxTaskEstimation.isCancelled;

        //    //var List = _context.tbl_pmsTxTask.Where(p => p.assignedUser_ID == sUser_ID);

        //    ViewBag.estimation_ID = tbl_pmsTxTaskEstimation.estimation_ID;
        //    ViewBag.task_ID = new SelectList(_context.tbl_pmsTxTask.Where(p => p.isCancelled == false), "task_ID", "taskReference", tbl_pmsTxTaskEstimation.task_ID);
        //    ViewBag.subTask_ID = new SelectList(_context.tbl_genMasSubTask.Where(p => p.isActive == true), "subTask_ID", "subTaskName");
        //    return View();
        //}

        //public ActionResult Delete(string estimation_ID)
        //{
        //    if (estimation_ID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTaskEstimation tbl_pmsTxTaskEstimation = _context.tbl_pmsTxTaskEstimation.Find(estimation_ID);
        //    if (tbl_pmsTxTaskEstimation == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tbl_pmsTxTaskEstimation);
        //} 
        #endregion



        #region Transaction
        public async Task<tbl_pmsTxTaskEstimation> SaveTaskEstimation(TaskEstimation oTaskEstimation)
        {
            string Message = "";
            try
            {
                tbl_pmsTxTaskEstimation oEstimation = new tbl_pmsTxTaskEstimation(oTaskEstimation.estimation_ID, oTaskEstimation.estimationDate, oTaskEstimation.task_ID, oTaskEstimation.totalEstimatedHours, oTaskEstimation.remarks,
                    false, false, sUser_ID, sUser_ID, sUser_ID, sUser_ID, DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now, sCompany_ID, sCompanyBranch_ID);

                await _context.tbl_pmsTxTaskEstimation.AddAsync(oEstimation);
                await _context.SaveChangesAsync();

                return oEstimation;
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
            }
            return null;
        }

        public async Task<tbl_pmsTxTaskEstimation> EditTaskEstimation(TaskEstimation oTaskEstimation)
        {
            string Message = "";
            try
            {
                var oldRecord = await _context.tbl_pmsTxTaskEstimation.FirstOrDefaultAsync(p => p.estimation_ID == oTaskEstimation.estimation_ID);
                if (oldRecord != null)
                {
                    oldRecord.estimation_ID = oTaskEstimation.estimation_ID;
                    oldRecord.estimationDate = oTaskEstimation.estimationDate;
                    oldRecord.task_ID = oTaskEstimation.task_ID;
                    oldRecord.totalEstimatedHours = oTaskEstimation.totalEstimatedHours;
                    oldRecord.remarks = oTaskEstimation.remarks;
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

        public async Task<tbl_pmsTxTaskEstimation> ApproveTaskEstimation(string estimation_ID)
        {
            string Message = "";
            try
            {
                var oTaskEstimation = await _context.tbl_pmsTxTaskEstimation.FirstOrDefaultAsync(p => p.estimation_ID == estimation_ID);
                if (oTaskEstimation != null)
                {
                    oTaskEstimation.isApproved = true;
                    oTaskEstimation.dateApproved = DateTime.Now;
                    oTaskEstimation.approvedUser_ID = sUser_ID;

                    _context.Entry(oTaskEstimation).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    return oTaskEstimation;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
            }
            return null;
        }

        public async Task<bool> DeleteTaskEstimation(string estimation_ID)
        {
            string Message = "";
            try
            {
                var oTaskEstimation = await _context.tbl_pmsTxTaskEstimation.FindAsync(estimation_ID);
                if (oTaskEstimation != null)
                {
                    oTaskEstimation.isCancelled = true;
                    oTaskEstimation.deletedUser_ID = sUser_ID;
                    oTaskEstimation.dateDeleted = DateTime.Now;

                    _context.Entry(oTaskEstimation).State = EntityState.Modified;
                    await _context.SaveChangesAsync();

                    Message = "Task Estimation Cancelled Successfully...!";
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
