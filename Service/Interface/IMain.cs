using DataAccess.Model.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using static DataAccess.Models.ViewModels.Main;

namespace Service.Interface
{
    public interface IMain
    {
        Task<ReferenceMapper> TaskReferences();
        Task<List<UsersVM>> UserList();
    }
}
