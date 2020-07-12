using DataAccess;
using DataAccess.Model.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITaskEstimation
    {
        Task<List<TaskEstimation_VM>> TaskEstimations(string estimation_ID);
        Task<List<TaskEstimation_DetailVM>> TaskEstimationsDetails(string estimation_ID);
    }
}
