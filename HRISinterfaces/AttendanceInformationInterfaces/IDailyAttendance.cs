using HRISdatabaseModels.DatabaseModels.AttendenceInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRISgenericInterfaces.AttendanceInformationInterfaces
{
    public interface IDailyAttendance: IGetInterfaces<DailyAttendence>,IInsertInterfaces<DailyAttendence>,IUpdateInterfaces<DailyAttendence>,IDeleteInterfaces<DailyAttendence>
    {
        Task<bool> AttendaceReport(int id,DateTime fromDate, DateTime toDate);

        Task<bool> InsertAttnWithSP(DailyAttendence dailyAttendence);
        Task<bool> UpdateAttnWithSP(DailyAttendence dailyAttendence);
        Task<bool> DeleteAttnWithSP(int id);
    }
}
