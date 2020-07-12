using DataAccess.Context;
using DataAccess.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.DataAccess
{
    public class TaskEstimationDetailDAO
    {
        private readonly ApplicationContext _context;
        string sUser_ID = "";//System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = "";//System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = "";//System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;
        public TaskEstimationDetailDAO(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<List<TaskEstimation_DetailVM>> GetEstimationDetails(string estimation_ID)
        {
            List<TaskEstimation_DetailVM> List = _context.tbl_pmsTxTaskEstimation_Detail.Where(p => p.estimation_ID == estimation_ID)
                .Select(x => new TaskEstimation_DetailVM
                {
                    estimation_ID = x.estimation_ID,
                    subTask_ID = x.subTask_ID,
                    subTask = x.tbl_genMasSubTask.subTaskName,
                    estimatedHours = x.estimatedHours,
                    line_No = x.line_No
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
        public async Task<bool> SaveTaskEstimationDetails(TaskEstimation oTaskEstimation)
        {
            bool status = false;
            string Message = "";
            try
            {
                foreach (var oDetail in oTaskEstimation.TaskEstimationDetails)
                {
                    //tbl_pmsTxTaskEstimation_Detail oEstimationDetail = new tbl_pmsTxTaskEstimation_Detail(oDetail.line_No, oDetail.estimation_ID, oDetail.subTask_ID, oDetail.estimatedHours);
                    oDetail.estimation_ID = oTaskEstimation.estimation_ID;
                }

                _context.tbl_pmsTxTaskEstimation_Detail.AddRange(oTaskEstimation.TaskEstimationDetails);
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                status = false;
            }

            return false;
        }

        public async Task<bool> DeleteTaskEstimationDetails(string estimation_ID)
        {
            bool status = false;
            bool bIscancelled = false;
            string Message = "";
            try
            {
                foreach (var oldRecordDetail in _context.tbl_pmsTxTaskEstimation_Detail.Where(p => p.estimation_ID == estimation_ID))
                {
                    _context.Entry(oldRecordDetail).State = EntityState.Deleted;
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                status = false;
            }

            return false;
        }
        #endregion


    }
}
