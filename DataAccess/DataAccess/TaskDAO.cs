using DataAccess.Models.ViewModels;
using DataAccess.Context;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataAccess.Model.Mapper;
using Newtonsoft.Json;
using Utilities.Helps;

namespace DataAccess.DataAccess
{
    public class TaskDAO
    {
        private readonly ApplicationContext _context;
        string sUser_ID = "";//System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = "";//System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = "";//System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;

        public TaskDAO(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<List<TaskVM>> SearchTasks(string Search)
        {
            if (Search != null || Search != "")
            {
                List<TaskVM> List = await _context.tbl_pmsTxTask
                .Where(p => p.taskReference.Contains(Search.ToString().Trim()))
                .Select(s => new TaskVM
                {
                    task_ID = s.task_ID,
                    taskDate = s.taskDate.ToString(),
                    taskReference = s.taskReference,
                    customer = s.tbl_genCustomerMaster.customerName,
                    product = s.tbl_genMasProduct.productName,
                })
                .OrderByDescending(p => p.taskDate).ToListAsync();

                return List;
            }

            return null;
        }

        public async Task<List<TaskVM>> GetTasksListDetails(string task_ID)
        {
            List<TaskVM> List = await _context.tbl_pmsTxTask
                .Where(p => p.task_ID == task_ID)
                .Select(s => new TaskVM
                {
                    task_ID = s.task_ID,
                    taskDate = s.taskDate.ToString(),
                    taskReference = s.taskReference,
                    remarks = s.remarks,
                    customer = s.tbl_genCustomerMaster.customerName,
                    customer_ID = s.customer_ID,
                    product = s.tbl_genMasProduct.productName,
                    product_ID = s.product_ID,
                    taskType = s.tbl_genMasTaskType.taskType,
                    taskType_ID = s.taskType_ID,
                    module = s.tbl_genMasModule.moduleName,
                    module_ID = s.module_ID,
                    function = s.tbl_genMasFunction.functionName,
                    function_ID = s.function_ID,
                    priority = s.tbl_genMasPriority.priority,
                    priority_ID = s.priority_ID,
                    status = s.tbl_genMasStatus.status,
                    status_ID = s.status_ID,
                    reported_Date = s.reported_Date.ToString(),
                    reportedUser_ID = s.reportedUser_ID,

                }).ToListAsync();

            return List;
        }

        public tbl_pmsTxTask GetTasksDetails(string task_ID)
        {
            tbl_pmsTxTask List = _context.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == task_ID);
            return List;
        }

        public async Task<List<AttachmentVM>> GetAttachmentDetails(string transaction_ID)
        {
            List<AttachmentVM> Attachment = await _context.tbl_sasAttachments
                .Where(p => p.transaction_ID == transaction_ID)
                .Select(s => new AttachmentVM
                {
                    transaction_ID = s.transaction_ID,
                    attachment_Index = s.attachment_Index,
                    form_ID = s.form_ID,
                    attachment = s.attachment,
                    displayName = s.dipsplayName

                }).ToListAsync();

            return Attachment;
        }

        public async Task<List<TaskBucketVM>> GetTaskList(bool ShowAll, string AssignedUser)
        {
            List<TaskBucketVM> List = await _context.tbl_pmsTxTask//.Where(p => p.assignedUser_ID == "%%")
                .Select(x => new TaskBucketVM
                {
                    task_ID = x.task_ID,
                    taskDate = x.taskDate,
                    taskReference = x.taskReference,
                    remarks = x.remarks,
                    taskType_ID = x.tbl_genMasTaskType.taskType,

                    estimation_ID = x.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == x.task_ID).estimation_ID != null ? x.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == x.task_ID).estimation_ID : "0",

                    priority_ID = x.tbl_genMasPriority.priority,
                    status_ID = x.status_ID,
                    status = x.tbl_genMasStatus.status,
                    DeadlineDate = x.DeadlineDate,
                    AssignedTo = x.assignedUser_ID,

                    client_ID = x.tbl_genCustomerMaster.customerCode,
                    product_ID = x.tbl_genMasProduct.productName,
                    module_ID = x.tbl_genMasModule.moduleName,
                    function_ID = x.tbl_genMasFunction.functionName,

                    reported_Date = x.reported_Date,
                    reportedUser_ID = x.reportedUser_ID,

                    isCancelled = x.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == x.task_ID).isCancelled == true ? true : false,
                    isApproved = x.tbl_pmsTxTaskEstimation.FirstOrDefault(p => p.task_ID == x.task_ID).isApproved == true ? true : false,

                }).OrderByDescending(p => p.taskDate).ThenByDescending(p => p.task_ID).ToListAsync();//.Where(p => p.AssignedTo == sUser_ID)


            if (!String.IsNullOrEmpty(AssignedUser))
                List = List.Where(p => p.AssignedTo == AssignedUser).ToList();

            if (!ShowAll)
                List = List.Where(p => p.status_ID.Equals(((int)clsEnums.enumStatus.Assigned).ToString()) || p.status_ID.Equals(((int)clsEnums.enumStatus.New).ToString()) ||
                                p.status_ID.Equals(((int)clsEnums.enumStatus.QAWIP).ToString()) || p.status_ID.Equals(((int)clsEnums.enumStatus.DEVWIP).ToString()) ||
                                p.status_ID.Equals(((int)clsEnums.enumStatus.WIP).ToString()) || p.status_ID.Equals(((int)clsEnums.enumStatus.QA_Fail).ToString())).ToList();

            return List;
        }


        #region Reffrence Details
        //public async Task<TaskMapper> TaskReferences()
        //{
        //    //cls_HelpMethods.UserDetail();
        //    //cls_HelpMethods.CompanyDetail();

        //    return new TaskMapper()
        //    {
        //        Product = await _context.tbl_genMasProduct.Where(p => p.isActive == true).ToListAsync(),
        //        Function = await _context.tbl_genMasFunction.Where(p => p.isActive == true).ToListAsync(),
        //        Module = await _context.tbl_genMasModule.Where(p => p.isActive == true).ToListAsync(),
        //        Priority = await _context.tbl_genMasPriority.Where(p => p.isActive == true).ToListAsync(),
        //        Status = await _context.tbl_genMasStatus.Where(p => p.isActive == true).ToListAsync(),
        //        TaskType = await _context.tbl_genMasTaskType.Where(p => p.isActive == true).ToListAsync()
        //    };
        //}

        // GET: Task/Edit/5
        //public ActionResult Edit(string task_ID)
        //{
        //    //if (task_ID == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //tbl_pmsTxTask tbl_pmsTxTask = _context.tbl_pmsTxTask.Find(task_ID);
        //    //if (tbl_pmsTxTask == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}

        //    //ViewBag.task_ID = tbl_pmsTxTask.task_ID;
        //    //ViewBag.isCancel = tbl_pmsTxTask.isCancelled;

        //    //ViewBag.customer_ID = new SelectList(_context.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName", tbl_pmsTxTask.customer_ID);
        //    //ViewBag.function_ID = new SelectList(_context.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName", tbl_pmsTxTask.function_ID);
        //    //ViewBag.module_ID = new SelectList(_context.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName", tbl_pmsTxTask.module_ID);
        //    //ViewBag.priority_ID = new SelectList(_context.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority", tbl_pmsTxTask.priority_ID);
        //    //ViewBag.product_ID = new SelectList(_context.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName", tbl_pmsTxTask.product_ID);
        //    //ViewBag.status_ID = new SelectList(_context.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", tbl_pmsTxTask.status_ID);
        //    //ViewBag.taskType_ID = new SelectList(_context.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType", tbl_pmsTxTask.taskType_ID);
        //    //return View(tbl_pmsTxTask);
        //}

        //public ActionResult Edit2(string task_ID)
        //{
        //    //if (task_ID == null)
        //    //{
        //    //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //}
        //    //tbl_pmsTxTask tbl_pmsTxTask = _context.tbl_pmsTxTask.Find(task_ID);
        //    //if (tbl_pmsTxTask == null)
        //    //{
        //    //    return HttpNotFound();
        //    //}

        //    //ViewBag.task_ID = tbl_pmsTxTask.task_ID;
        //    //ViewBag.isCancel = tbl_pmsTxTask.isCancelled;

        //    //ViewBag.customer_ID = new SelectList(_context.tbl_genCustomerMaster, "customer_ID", "customerName", tbl_pmsTxTask.customer_ID);
        //    //ViewBag.function_ID = new SelectList(_context.tbl_genMasFunction, "function_ID", "functionName", tbl_pmsTxTask.function_ID);
        //    //ViewBag.module_ID = new SelectList(_context.tbl_genMasModule, "module_ID", "moduleName", tbl_pmsTxTask.module_ID);
        //    //ViewBag.priority_ID = new SelectList(_context.tbl_genMasPriority, "priority_ID", "priority", tbl_pmsTxTask.priority_ID);
        //    //ViewBag.product_ID = new SelectList(_context.tbl_genMasProduct, "product_ID", "productName", tbl_pmsTxTask.product_ID);
        //    //ViewBag.status_ID = new SelectList(_context.tbl_genMasStatus, "status_ID", "status", tbl_pmsTxTask.status_ID);
        //    //ViewBag.taskType_ID = new SelectList(_context.tbl_genMasTaskType, "taskType_ID", "taskType", tbl_pmsTxTask.taskType_ID);
        //    //return View(tbl_pmsTxTask);
        //}

        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Details(string task_ID)
        //{
        //    if (task_ID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    ViewBag.task_ID = task_ID;

        //    return View();
        //}
        #endregion

        #region Transaction
        public async Task<Tasks> SaveTask(Tasks oTask)
        {
            string Message = "";
            try
            {
                //DateTime dtTaskDate = DateTime.Parse(oTask.taskDate.ToString() + " " + DateTime.Now.TimeOfDay.ToString());
                DateTime dtTaskDate = new DateTime(oTask.taskDate.Year, oTask.taskDate.Month, oTask.taskDate.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                tbl_pmsTxTask tblTask = new tbl_pmsTxTask(oTask.task_ID, dtTaskDate, oTask.taskReference, oTask.remarks,
                    oTask.reportedDate, oTask.reportedUser_ID,
                    oTask.customer_ID, oTask.product_ID, oTask.module_ID, oTask.function_ID, oTask.taskType_ID, oTask.priority_ID, oTask.status_ID,
                    DateTime.Now, "-1",
                    false, sUser_ID, sUser_ID, sUser_ID, DateTime.Now, DateTime.Now, DateTime.Now, sCompany_ID, sCompanyBranch_ID);

                await _context.tbl_pmsTxTask.AddAsync(tblTask);
                await _context.SaveChangesAsync();
                return oTask;
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
            }
            return null;
        }

        public async Task<Tasks> UpdateTask(Tasks oTask)
        {
            string Message = "";
            try
            {
                var oldRecord = await _context.tbl_pmsTxTask.FirstOrDefaultAsync(p => p.task_ID == oTask.task_ID);
                if (oldRecord != null)
                {
                    //oldRecord.taskDate = oTask.taskDate;
                    oldRecord.taskReference = oTask.taskReference;
                    oldRecord.remarks = oTask.remarks;

                    oldRecord.customer_ID = oTask.customer_ID;
                    oldRecord.function_ID = oTask.function_ID;
                    oldRecord.module_ID = oTask.module_ID;
                    oldRecord.priority_ID = oTask.priority_ID;
                    oldRecord.product_ID = oTask.product_ID;
                    oldRecord.reportedUser_ID = oTask.reportedUser_ID;
                    oldRecord.reported_Date = oTask.reportedDate;
                    oldRecord.status_ID = oTask.status_ID;
                    oldRecord.taskType_ID = oTask.taskType_ID;

                    oldRecord.modifiedUser_ID = sUser_ID;
                    oldRecord.dateModified = DateTime.Now;

                    await _context.SaveChangesAsync();

                    return oTask;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
            }

            return null;
        }

        public async Task<bool> DeleteTask(string task_ID)
        {
            string Message = "";
            try
            {
                var oTask = await _context.tbl_pmsTxTask.FirstOrDefaultAsync(p => p.task_ID == task_ID);
                if (oTask != null)
                {
                    oTask.isCancelled = true;
                    oTask.deletedUser_ID = sUser_ID;
                    oTask.dateDeleted = DateTime.Now;

                    _context.Entry(oTask).State = EntityState.Deleted;
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

        public async Task<bool> UpdateTaskStatus(string task_ID)
        {
            string Message = "";
            try
            {

                var oTask = _context.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == task_ID);
                if (oTask != null)
                {
                    oTask.status_ID = "2";
                    _context.Entry(oTask).State = EntityState.Modified;

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

        #region Files Handle
        //[HttpPost]
        //public Task<> UploadFiles(string TxID)
        //{
        //    string sMessage = "";
        //    bool status = false;
        //    try
        //    {
        //        if (Request.Files.Count > 0)
        //        {
        //            string path1 = Server.MapPath("~/Images/");
        //            if (!System.IO.Directory.Exists(path1))
        //            {
        //                status = false;
        //                sMessage = "File Upload Folder Not Found";
        //            }
        //            else
        //            {
        //                HttpFileCollectionBase FileList = Request.Files;
        //                for (int i = 0; i < FileList.Count; i++)
        //                {
        //                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
        //                    string Filename = Path.GetFileName(Request.Files[i].FileName);

        //                    HttpPostedFileBase File = FileList[i];
        //                    string sDestinationPath = File.FileName;

        //                    // Checking for Internet Explorer  
        //                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
        //                    {
        //                        string[] testfiles = File.FileName.Split(new char[] { '\\' });
        //                        sDestinationPath = testfiles[testfiles.Length - 1];
        //                    }


        //                    // Get the complete folder path and store the file inside it.  
        //                    sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
        //                    File.SaveAs(sDestinationPath);

        //                    tbl_sasAttachments oAttachment = new tbl_sasAttachments(TxID, ++i, (int)enumFormNames.Task, Filename, Filename);
        //                    _context.tbl_sasAttachments.Add(oAttachment);
        //                }

        //                var Task = _context.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == TxID);
        //                if (Task != null)
        //                {
        //                    Task.isAttachment = true;
        //                    _context.SaveChanges();
        //                }

        //                _context.SaveChanges();

        //                status = true;
        //                sMessage = "File Uploaded Successfully!";
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status = false;
        //        sMessage = "Error occurred. Error details: " + ex.Message;
        //    }

        //    return new Task<> { Data = new { status = status, Message = sMessage } };
        //}

        //[HttpPost]
        //public Task<> UpdateFiles(string TxID)
        //{
        //    string sMessage = "";
        //    bool status = false;
        //    try
        //    {
        //        if (Request.Files.Count > 0)
        //        {
        //            int MaxNumber = 0;
        //            HttpFileCollectionBase files = Request.Files;
        //            for (int i = 0; i < files.Count; i++)
        //            {
        //                string Filename = Path.GetFileName(Request.Files[i].FileName);

        //                HttpPostedFileBase File = files[i];
        //                string sDestinationPath = File.FileName;

        //                // Checking for Internet Explorer
        //                if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
        //                {
        //                    string[] testfiles = File.FileName.Split(new char[] { '\\' });
        //                    sDestinationPath = testfiles[testfiles.Length - 1];
        //                }

        //                var oldRecord = _context.tbl_sasAttachments.FirstOrDefault(p => p.transaction_ID == TxID);
        //                if (oldRecord != null)
        //                {
        //                    MaxNumber = _context.tbl_sasAttachments.Where(p => p.transaction_ID == TxID).Max(p => p.attachment_Index);
        //                    sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
        //                    File.SaveAs(sDestinationPath);

        //                    tbl_sasAttachments oAttachment = new tbl_sasAttachments(TxID, ++MaxNumber, (int)enumFormNames.Task, Filename, Filename);
        //                    _context.tbl_sasAttachments.Add(oAttachment);
        //                }
        //                else
        //                {
        //                    sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
        //                    File.SaveAs(sDestinationPath);

        //                    tbl_sasAttachments oAttachment = new tbl_sasAttachments(TxID, ++MaxNumber, (int)enumFormNames.Task, Filename, Filename);
        //                    _context.tbl_sasAttachments.Add(oAttachment);

        //                }
        //            }

        //            var Task = _context.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == TxID);
        //            if (Task != null)
        //            {
        //                Task.isAttachment = true;
        //                _context.SaveChanges();
        //            }

        //            _context.SaveChanges();

        //            status = true;
        //            sMessage = "File Uploaded Successfully!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status = false;
        //        sMessage = "Error occurred. Error details: " + ex.Message;
        //    }

        //    return new Task<> { Data = new { status = status, Message = sMessage } };
        //}

        //[HttpPost]
        //public Task<> DeleteFiles(string TxID, int AttachmentIndex)
        //{
        //    string sMessage = "";
        //    bool status = false;
        //    try
        //    {
        //        if (TxID != null && AttachmentIndex > 0)
        //        {
        //            var oTask = _context.tbl_sasAttachments.FirstOrDefault(p => p.transaction_ID == TxID && p.attachment_Index == AttachmentIndex);
        //            if (oTask != null)
        //            {
        //                string fullPath = Path.Combine(Server.MapPath("~/Images/"), oTask.attachment);
        //                if (System.IO.File.Exists(fullPath))
        //                {
        //                    System.IO.File.Delete(fullPath);

        //                    _context.tbl_sasAttachments.Remove(oTask);
        //                    _context.SaveChanges();

        //                    sMessage = "File Uploaded Successfully!";
        //                    status = true;
        //                }
        //                else
        //                {
        //                    sMessage = "This file is not exists in the current folder";
        //                    status = false;
        //                }
        //            }
        //            else
        //            {
        //                sMessage = "Record Not Found...!";
        //                status = false;
        //            }
        //        }
        //        else
        //        {
        //            sMessage = "Files Not Found...!";
        //            status = false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status = false;
        //        sMessage = "Error occurred. Error details: " + ex.Message;
        //    }

        //    return new Task<> { Data = new { status = status, Message = sMessage } };
        //}

        //public Task<> ViewFile(string sPath)
        //{
        //    string sMessage = "";
        //    bool status = true;
        //    try
        //    {
        //        string fullPath = Path.Combine(Server.MapPath("~/Images/"), sPath);

        //        if (FolderPermission(fullPath))
        //        {
        //            if (System.IO.File.Exists(fullPath))
        //            {
        //                System.Diagnostics.Process.Start(fullPath);
        //                sMessage = "File Processing";
        //            }
        //            else
        //            {
        //                status = false;
        //                sMessage = "File Not Found...";
        //            }
        //        }
        //        else
        //        {
        //            sMessage = "You don't have write permissions";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status = false;
        //        sMessage = "Error occurred. Error details: " + ex.Message;
        //    }

        //    return new Task<> { Data = new { status = status, Message = sMessage } };
        //}

        //public Task<> ViewDestinationFile()
        //{
        //    string sMessage = "";
        //    bool status = true;
        //    if (Request.Files.Count > 0)
        //    {
        //        HttpFileCollectionBase FileList = Request.Files;

        //        for (int i = 1; i < FileList.Count; i++)
        //        {
        //            HttpPostedFileBase sFile = FileList[i];
        //            FilePathResult sPath = File(FileList[i].FileName, FileList[i].ContentType);

        //            string file = sPath.FileName;
        //            string downloadname = sPath.FileDownloadName;

        //            //if (System.IO.File.Exists(sFile.FileName))
        //            //    System.Diagnostics.Process.Start(sFile.FileName);

        //            // Get the complete folder path and store the file inside it.  
        //            //sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
        //            //File.SaveAs(sDestinationPath);
        //        }

        //        status = true;
        //        sMessage = "File Uploaded Successfully!";
        //    }

        //    return new Task<> { Data = new { status = status, Message = sMessage } };
        //}

        #region Check Folder Permission
        //private bool FolderPermission(string path)
        //{
        //    bool bPermission = false;

        //    PermissionSet permissionSet = new PermissionSet(PermissionState.None);
        //    FileIOPermission AllPermission = new FileIOPermission(FileIOPermissionAccess.AllAccess, path);

        //    permissionSet.AddPermission(AllPermission);
        //    if (permissionSet.IsSubsetOf(AppDomain.CurrentDomain.PermissionSet))
        //    {
        //        bPermission = true;
        //    }
        //    else
        //    {
        //        bPermission = false;
        //    }

        //    return bPermission;
        //}
        #endregion
        #endregion

        #region Help Methods
        public async Task<bool> CheckEstimationMandatoryTasks(string task_ID)
        {
            bool isValid = true;
            var taskType = await _context.tbl_pmsTxTask.FirstOrDefaultAsync(p => p.task_ID == task_ID);
            if (taskType != null)
            {
                var isMandatoryEstimation = await _context.tbl_genMasTaskType.FirstOrDefaultAsync(p => p.taskType_ID == taskType.taskType_ID);
                if (isMandatoryEstimation != null && isMandatoryEstimation.isMandatoryEstimation)
                {
                    var task = await _context.tbl_pmsTxTaskEstimation.FirstOrDefaultAsync(p => p.task_ID == task_ID);
                    if (task != null)
                        isValid = true;
                    else
                        isValid = false;
                }
                else
                    isValid = true;
            }

            return isValid;
        }

        public async Task<bool> TaskExists(string task_ID)
        {
            string Message = "";
            try
            {
                var ExsistsRecords = await _context.tbl_pmsTxTask.FirstOrDefaultAsync(p => p.task_ID == task_ID);
                if (ExsistsRecords != null)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                return false;
            }

            return true;
        }

        public async Task<bool> TaskExistsByName(string taskReference)
        {
            string Message = "";
            try
            {
                var ExsistsRecords = await _context.tbl_pmsTxTask.FirstOrDefaultAsync(p => p.taskReference == taskReference);
                if (ExsistsRecords != null)
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                return false;
            }
            return true;
        }
        #endregion
    }
}
