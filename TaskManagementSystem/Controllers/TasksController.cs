using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DataAccess;
using DataAccess.Context;
using DataAccess.DataAccess;
using Service.Interface;
using Service.Repositry;
using DataAccess.Model.Mapper;
using DataAccess.Models.ViewModels;
using Microsoft.AspNetCore.Cors;

namespace TaskManagementSystem.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private ITask _task;

        public TasksController(ApplicationContext context)
        {
            _context = context;
            _task = new TaskRepo(_context);
        }

        #region Return Details
        //
        [HttpGet("TaskDetailList")]
        public async Task<List<TaskBucketVM>> TaskDetailList(bool ShowAll, string AssignedUser)
        {
            return await _task.TaskDetailList(ShowAll, AssignedUser);
        }
        //
        [HttpGet("SearchTasks")]
        public async Task<List<TaskVM>> SearchTasks(string Search)
        {
            return await _task.SearchTasks(Search);
        }
        //
        [HttpGet("TasksDetails")]
        public async Task<List<TaskVM>> TasksDetails(string TaskID)
        {
            return await _task.TasksDetails(TaskID);
        }

        [HttpGet("TasksAttachmentsList")]
        public async Task<List<AttachmentVM>> TasksAttachmentsList(string TransactionID)
        {
            return await _task.AttachmentDetails(TransactionID);
        }
        #endregion


        #region Transactions
        [HttpPost]
        //[Route("CreateTask")]
        public async Task<Tuple<bool, string, Tasks>> PostTask(Tasks oTask)
        {
            return await _task.SaveTask(oTask);
        }
        [HttpPut]
        public async Task<Tuple<bool, string, Tasks>> PutTask(Tasks oTask)
        {
            return await _task.UpdateTask(oTask);
        }

        [HttpDelete("{id}")]
        public async Task<Tuple<bool, string, bool>> DeleteTask(string id)
        {
            return await _task.DeleteTask(id);
        } 
        #endregion

        [HttpPost]
        [Route("SaveTask")]
        //[Route("[action]")]
        public async Task<string> SaveTask()
        {
            //_context.tbl_genMasProduct.Add(tbl_genMasProduct);
            return "jjj";
        }

        #region MyRegion
        //// GET: api/Products/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<tbl_genMasProduct>> GetProduct(string id)
        //{
        //    var tbl_genMasProduct = await _context.tbl_genMasProduct.FindAsync(id);

        //    if (tbl_genMasProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    return tbl_genMasProduct;
        //}

        //// PUT: api/Products/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Puttbl_genMasProduct(string id, tbl_genMasProduct tbl_genMasProduct)
        //{
        //    if (id != tbl_genMasProduct.product_ID)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tbl_genMasProduct).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!tbl_genMasProductExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        //// DELETE: api/Products/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<tbl_genMasProduct>> Deletetbl_genMasProduct(string id)
        //{
        //    var tbl_genMasProduct = await _context.tbl_genMasProduct.FindAsync(id);
        //    if (tbl_genMasProduct == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.tbl_genMasProduct.Remove(tbl_genMasProduct);
        //    await _context.SaveChangesAsync();

        //    return tbl_genMasProduct;
        //}

        //private bool tbl_genMasProductExists(string id)
        //{
        //    return _context.tbl_genMasProduct.Any(e => e.product_ID == id);
        //} 
        #endregion
    }
}
