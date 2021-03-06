﻿using System;
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
    public class TimeSheetController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private ITimeSheet _timeSheet;

        public TimeSheetController(ApplicationContext context)
        {
            _context = context;
            _timeSheet = new TimeSheetRepo(_context);
        }

        // GET: api/Task
        [HttpGet("TimeSheets")]
        public async Task<List<TimeSheetVM>> TimeSheets(bool ShowAll)
        {
            return await _timeSheet.TimeSheets(ShowAll);
        }

        [HttpGet("TimeSheet")]
        public async Task<List<TimeSheetVM>> TimeSheet(string TimeSheetID)
        {
            return await _timeSheet.TimeSheet(TimeSheetID);
        }

        [HttpGet("TimeSheetsDetail")]
        public async Task<List<TimeSheet_DetailVM>> TimeSheetsDetail(string TimeSheetID)
        {
            return await _timeSheet.TimeSheetsDetail(TimeSheetID);
        }

        //[HttpPost("PostTasks")]
        //public async Task<Tasks> PostTasks(Tasks oTask)
        //{
        //    //_context.tbl_genMasProduct.Add(tbl_genMasProduct);
        //    return await _taskEstimation.SaveTask(oTask);
        //}

        [HttpPost("SaveTask")]
        public async Task<string> SaveTask(string name)
        {
            //_context.tbl_genMasProduct.Add(tbl_genMasProduct);
            return name;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tbl_genMasProduct>> GetProduct(string id)
        {
            var tbl_genMasProduct = await _context.tbl_genMasProduct.FindAsync(id);

            if (tbl_genMasProduct == null)
            {
                return NotFound();
            }

            return tbl_genMasProduct;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Puttbl_genMasProduct(string id, tbl_genMasProduct tbl_genMasProduct)
        {
            if (id != tbl_genMasProduct.product_ID)
            {
                return BadRequest();
            }

            _context.Entry(tbl_genMasProduct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tbl_genMasProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<tbl_genMasProduct>> Deletetbl_genMasProduct(string id)
        {
            var tbl_genMasProduct = await _context.tbl_genMasProduct.FindAsync(id);
            if (tbl_genMasProduct == null)
            {
                return NotFound();
            }

            _context.tbl_genMasProduct.Remove(tbl_genMasProduct);
            await _context.SaveChangesAsync();

            return tbl_genMasProduct;
        }

        private bool tbl_genMasProductExists(string id)
        {
            return _context.tbl_genMasProduct.Any(e => e.product_ID == id);
        }
    }
}
