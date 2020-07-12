using DataAccess;
using DataAccess.Model.Mapper;
using DataAccess.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITask
    {
        Task<List<TaskBucketVM>> TaskDetailList(bool ShowAll, string AssignedUser);
        Task<Tuple<bool, string, Tasks>> SaveTask(Tasks oTask);
        Task<Tuple<bool, string, Tasks>> UpdateTask(Tasks oTask);
        Task<Tuple<bool, string, bool>> DeleteTask(string task_ID);
        Task<List<TaskVM>> SearchTasks(string Search);
        Task<List<TaskVM>> TasksDetails(string task_ID);
        Task<List<AttachmentVM>> AttachmentDetails(string transaction_ID);
    }
}
