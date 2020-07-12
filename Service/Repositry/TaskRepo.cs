using DataAccess.Common;
using DataAccess.Context;
using DataAccess.Model.Mapper;
using DataAccess.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Utilities.Helps.clsEnums;

namespace DataAccess.DataAccess
{
    public class TaskRepo : ITask
    {
        //private ApplicationDbContext db = new ApplicationDbContext();
        string sUser_ID = ""; //System.Web.HttpContext.Current.Session["user_ID"] as String;
        string sCompany_ID = ""; // System.Web.HttpContext.Current.Session["company_ID"] as String;
        string sCompanyBranch_ID = ""; // System.Web.HttpContext.Current.Session["companyBranch_ID"] as String;
        private readonly ApplicationContext _context;

        public TaskRepo(ApplicationContext context)
        {
            _context = context;
        }


        #region Search
        public Task<List<TaskBucketVM>> TaskDetailList(bool ShowAll, string AssignedUser)
        {
            return new TaskDAO(_context).GetTaskList(ShowAll, AssignedUser);
        }

        public async Task<List<TaskVM>> SearchTasks(string Search)
        {
            return await new TaskDAO(_context).SearchTasks(Search);
        }

        public async Task<List<TaskVM>> TasksDetails(string task_ID)
        {
            return await new TaskDAO(_context).GetTasksListDetails(task_ID);
        }

        public async Task<List<AttachmentVM>> AttachmentDetails(string transaction_ID)
        {
            return await new TaskDAO(_context).GetAttachmentDetails(transaction_ID);
        }
        #endregion


        #region MyRegion
        //public ActionResult Create()
        //{
        //    cls_HelpMethods.UserDetail();
        //    cls_HelpMethods.CompanyDetail();

        //    tbl_genMasStatus oStatus = db.tbl_genMasStatus.FirstOrDefault(p => p.status.ToLower().Contains("new"));

        //    ViewBag.function_ID = new SelectList(db.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName");
        //    ViewBag.module_ID = new SelectList(db.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName");
        //    ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority");
        //    ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName");
        //    ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", oStatus.status_ID);
        //    ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType");
        //    ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName");
        //    return View();
        //}

        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Create2()
        //{
        //    cls_HelpMethods.UserDetail();
        //    cls_HelpMethods.CompanyDetail();

        //    string sStatus = db.tbl_genMasStatus.FirstOrDefault(p => p.status.ToLower().Contains("new")).status_ID;
        //    ViewBag.function_ID = new SelectList(db.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName");
        //    ViewBag.module_ID = new SelectList(db.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName");
        //    ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority");
        //    ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName");
        //    ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", sStatus);
        //    ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType");
        //    ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName");
        //    return View();
        //}

        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Create3()
        //{
        //    cls_HelpMethods.UserDetail();
        //    cls_HelpMethods.CompanyDetail();

        //    //string sStatus = db.tbl_genMasStatus.FirstOrDefault(p => p.status.ToLower().Contains("new")).status_ID;
        //    //ViewBag.function_ID = new SelectList(db.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName");
        //    //ViewBag.module_ID = new SelectList(db.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName");
        //    //ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority");
        //    //ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName");
        //    //ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", sStatus);
        //    //ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType");
        //    //ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName");
        //    return View();
        //}

        //// GET: Task/Edit/5
        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Edit(string task_ID)
        //{
        //    if (task_ID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTask tbl_pmsTxTask = db.tbl_pmsTxTask.Find(task_ID);
        //    if (tbl_pmsTxTask == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.task_ID = tbl_pmsTxTask.task_ID;
        //    ViewBag.isCancel = tbl_pmsTxTask.isCancelled;

        //    ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster.Where(p => p.isDeleted == false), "customer_ID", "customerName", tbl_pmsTxTask.customer_ID);
        //    ViewBag.function_ID = new SelectList(db.tbl_genMasFunction.Where(p => p.isActive == true), "function_ID", "functionName", tbl_pmsTxTask.function_ID);
        //    ViewBag.module_ID = new SelectList(db.tbl_genMasModule.Where(p => p.isActive == true), "module_ID", "moduleName", tbl_pmsTxTask.module_ID);
        //    ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority.Where(p => p.isActive == true), "priority_ID", "priority", tbl_pmsTxTask.priority_ID);
        //    ViewBag.product_ID = new SelectList(db.tbl_genMasProduct.Where(p => p.isActive == true), "product_ID", "productName", tbl_pmsTxTask.product_ID);
        //    ViewBag.status_ID = new SelectList(db.tbl_genMasStatus.Where(p => p.isActive == true), "status_ID", "status", tbl_pmsTxTask.status_ID);
        //    ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType.Where(p => p.isActive == true), "taskType_ID", "taskType", tbl_pmsTxTask.taskType_ID);
        //    return View(tbl_pmsTxTask);
        //}

        //[Authorize(Roles = "" + nameof(clsEnums.enumAuthencationGroups.Administrators) + "," + nameof(clsEnums.enumAuthencationGroups.Executives) + "")]
        //public ActionResult Edit2(string task_ID)
        //{
        //    if (task_ID == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    tbl_pmsTxTask tbl_pmsTxTask = db.tbl_pmsTxTask.Find(task_ID);
        //    if (tbl_pmsTxTask == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    ViewBag.task_ID = tbl_pmsTxTask.task_ID;
        //    ViewBag.isCancel = tbl_pmsTxTask.isCancelled;

        //    ViewBag.customer_ID = new SelectList(db.tbl_genCustomerMaster, "customer_ID", "customerName", tbl_pmsTxTask.customer_ID);
        //    ViewBag.function_ID = new SelectList(db.tbl_genMasFunction, "function_ID", "functionName", tbl_pmsTxTask.function_ID);
        //    ViewBag.module_ID = new SelectList(db.tbl_genMasModule, "module_ID", "moduleName", tbl_pmsTxTask.module_ID);
        //    ViewBag.priority_ID = new SelectList(db.tbl_genMasPriority, "priority_ID", "priority", tbl_pmsTxTask.priority_ID);
        //    ViewBag.product_ID = new SelectList(db.tbl_genMasProduct, "product_ID", "productName", tbl_pmsTxTask.product_ID);
        //    ViewBag.status_ID = new SelectList(db.tbl_genMasStatus, "status_ID", "status", tbl_pmsTxTask.status_ID);
        //    ViewBag.taskType_ID = new SelectList(db.tbl_genMasTaskType, "taskType_ID", "taskType", tbl_pmsTxTask.taskType_ID);
        //    return View(tbl_pmsTxTask);
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
        public async Task<Tuple<bool, string, Tasks>> SaveTask(Tasks oTask)
        {
            bool status = false;
            string Message = "";
            Tasks oReturnTask = null;
            try
            {
                #region Save
                if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
                {
                    if (oTask != null)
                    {
                        var ExsistsRecords = new TaskDAO(_context).TaskExists(oTask.task_ID);
                        if (ExsistsRecords == null)
                        {
                            oTask.task_ID = cls_AutoCode.AutoCode((int)enumFormNames.Task);
                            if (oTask.task_ID != null)
                            {
                                oReturnTask = await new TaskDAO(_context).SaveTask(oTask);
                                status = true;
                                Message = "Task Saved Successfully";
                            }
                            else
                            {
                                Message = "Task ID is Empty...!";
                                status = false;
                            }
                        }
                        else
                        {
                            Message = "Already Create This Task";
                            status = false;
                        }
                    }
                    else
                    {
                        Message = "Null Task";
                        status = false;
                    }
                }
                else
                {
                    string sHeader = "Your Session is Expired";
                    Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
                    status = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                status = false;
            }

            return new Tuple<bool, string, Tasks>(status, Message, oReturnTask);
        }

        public async Task<Tuple<bool, string, Tasks>> UpdateTask(Tasks oTask)
        {
            bool status = false;
            string Message = "";
            Tasks oReturnTask = null;
            try
            {
                #region Update
                if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
                {
                    if (oTask != null)
                    {
                        var oldRecord = new TaskDAO(_context).GetTasksDetails(oTask.task_ID);
                        if (oldRecord != null)
                        {
                            oReturnTask = await new TaskDAO(_context).UpdateTask(oTask);
                            status = true;
                            Message = "Task Updated Successfully...!";
                        }
                        else
                        {
                            Message = "Task Details are Empty...!";
                            status = false;
                        }
                    }
                    else
                    {
                        Message = "Task Details are Empty...!";
                        status = false;
                    }
                }
                else
                {
                    string sHeader = "Your Session is Expired";
                    Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
                    status = false;
                }
                #endregion
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                status = false;
            }

            return new Tuple<bool, string, Tasks>(status, Message, oReturnTask);
        }

        public async Task<Tuple<bool, string, bool>> DeleteTask(string task_ID)
        {
            bool status = false;
            bool bIscancelled = false;
            string Message = "";
            try
            {
                if (task_ID != null)
                {
                    if (sUser_ID != null && sCompany_ID != null && sCompanyBranch_ID != null)
                    {
                        var oldRecord = new TaskDAO(_context).GetTasksDetails(task_ID);
                        if (oldRecord != null)
                        {
                            bIscancelled = await new TaskDAO(_context).DeleteTask(task_ID);
                            Message = "Task Cancelled Succefully...!";
                            status = true;
                        }
                        else
                        {
                            Message = "Task Details Are Empty...!";
                            status = false;
                        }
                    }
                    else
                    {
                        string sHeader = "Your Session is Expired";
                        Message = sHeader.ToUpper() + ", \nPlease Reload This Page...!";
                        status = false;
                    }
                }
                else
                {
                    Message = "Task ID Empty...!";
                    status = false;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message + "\n\n" + ex.Data;
                status = false;
            }

            return new Tuple<bool, string, bool>(status, Message, bIscancelled);
        }
        #endregion

        #region Files Handle
        //[HttpPost]
        //public JsonResult UploadFiles(string TxID)
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
        //                    db.tbl_sasAttachments.Add(oAttachment);
        //                }

        //                var Task = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == TxID);
        //                if (Task != null)
        //                {
        //                    Task.isAttachment = true;
        //                    db.SaveChanges();
        //                }

        //                db.SaveChanges();

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

        //    return new JsonResult { Data = new { status = status, Message = sMessage } };
        //}

        //[HttpPost]
        //public JsonResult UpdateFiles(string TxID)
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

        //                var oldRecord = db.tbl_sasAttachments.FirstOrDefault(p => p.transaction_ID == TxID);
        //                if (oldRecord != null)
        //                {
        //                    MaxNumber = db.tbl_sasAttachments.Where(p => p.transaction_ID == TxID).Max(p => p.attachment_Index);
        //                    sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
        //                    File.SaveAs(sDestinationPath);

        //                    tbl_sasAttachments oAttachment = new tbl_sasAttachments(TxID, ++MaxNumber, (int)enumFormNames.Task, Filename, Filename);
        //                    db.tbl_sasAttachments.Add(oAttachment);
        //                }
        //                else
        //                {
        //                    sDestinationPath = Path.Combine(Server.MapPath("~/Images/"), sDestinationPath);
        //                    File.SaveAs(sDestinationPath);

        //                    tbl_sasAttachments oAttachment = new tbl_sasAttachments(TxID, ++MaxNumber, (int)enumFormNames.Task, Filename, Filename);
        //                    db.tbl_sasAttachments.Add(oAttachment);

        //                }
        //            }

        //            var Task = db.tbl_pmsTxTask.FirstOrDefault(p => p.task_ID == TxID);
        //            if (Task != null)
        //            {
        //                Task.isAttachment = true;
        //                db.SaveChanges();
        //            }

        //            db.SaveChanges();

        //            status = true;
        //            sMessage = "File Uploaded Successfully!";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        status = false;
        //        sMessage = "Error occurred. Error details: " + ex.Message;
        //    }

        //    return new JsonResult { Data = new { status = status, Message = sMessage } };
        //}

        //[HttpPost]
        //public JsonResult DeleteFiles(string TxID, int AttachmentIndex)
        //{
        //    string sMessage = "";
        //    bool status = false;
        //    try
        //    {
        //        if (TxID != null && AttachmentIndex > 0)
        //        {
        //            var oTask = db.tbl_sasAttachments.FirstOrDefault(p => p.transaction_ID == TxID && p.attachment_Index == AttachmentIndex);
        //            if (oTask != null)
        //            {
        //                string fullPath = Path.Combine(Server.MapPath("~/Images/"), oTask.attachment);
        //                if (System.IO.File.Exists(fullPath))
        //                {
        //                    System.IO.File.Delete(fullPath);

        //                    db.tbl_sasAttachments.Remove(oTask);
        //                    db.SaveChanges();

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

        //    return new JsonResult { Data = new { status = status, Message = sMessage } };
        //}

        //public JsonResult ViewFile(string sPath)
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

        //    return new JsonResult { Data = new { status = status, Message = sMessage } };
        //}

        //public JsonResult ViewDestinationFile()
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

        //    return new JsonResult { Data = new { status = status, Message = sMessage } };
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

    }
}
