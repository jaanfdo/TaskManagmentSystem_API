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
using static DataAccess.Models.ViewModels.Main;

namespace TaskManagementSystem.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private IMain _main;

        public MainController(ApplicationContext context)
        {
            _context = context;
            _main = new MainRepo(_context);
        }
        
        [HttpGet("TaskReferences")]
        public async Task<ReferenceMapper> TaskReferences()
        {
            return await _main.TaskReferences();
        }
        [HttpGet("UserList")]
        public async Task<List<UsersVM>> UserList()
        {
            return await _main.UserList();
        }
    }
}
