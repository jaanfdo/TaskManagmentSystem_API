using DataAccess;
using DataAccess.Model.Mapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ITimeSheet
    {
        Task<List<TimeSheetVM>> TimeSheets(bool ShowAll);
        Task<List<TimeSheetVM>> TimeSheet(string timeSheet_ID);
        Task<List<TimeSheet_DetailVM>> TimeSheetsDetail(string timeSheet_ID);
    }
}
