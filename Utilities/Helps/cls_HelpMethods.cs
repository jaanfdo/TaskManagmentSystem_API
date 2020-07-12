using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Utilities.Helps
{
    public static class clsEnums
    {
        public enum enumAuthencationGroups
        {
            Administrators = 1,
            Managers = 2,
            Executives = 3,
            Employees = 4,
        }

        public enum enumFormNames
        {
            Home = 1,
            Task = 2,
            TaskEstimation = 3,
            TimeSheet = 4,
            TaskBucket = 5,
            UserMaster = 6,
        }

        public enum enumStatus
        {
            New = 1,
            Assigned = 2,
            WIP = 3,
            Dev_Release = 4,
            QA_Pass = 5,
            QA_Fail = 6,
            Completed = 7,
            Inactive = 8,
            OnHold = 9,
            Rejected = 10,
            DEVWIP = 11,
            QAWIP = 12,
        }
    }

    public static class clsConfig
    {
        public static string DefaultUser = "-1";
    }
}