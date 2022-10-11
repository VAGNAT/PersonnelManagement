using Model.ViewModel.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IReport
    {
        ReportEmployeesInDepartment GetReportEmployeesInDepartment(ParameterReportEmployeesInDepartment report);        
    }
}
