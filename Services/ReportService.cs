using Infrastructure.Interfaces;
using Model.ViewModel.Reports;
using Services.Interfaces;

namespace Services
{
    public class ReportService : IReport
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReportService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public ReportEmployeesInDepartment GetReportEmployeesInDepartment(ParameterReportEmployeesInDepartment parameterReport)
        {
            var employeesId = _unitOfWork.PersonnelMovements.ReadAll()
                .Where(p => p.DepartmentId == parameterReport.DepartmentId
                & p.DateStart < parameterReport.DateEnd
                & (p.DateEnd > parameterReport.DateStart | p.DateEnd == DateTime.MinValue))
                .Select(p => p.EmployeeId).ToList();
            return new ReportEmployeesInDepartment() { Employees = _unitOfWork.Employee.ReadAll().Where(res => employeesId.Contains(res.Id)).ToList() , ParameterReport = parameterReport};
        }
    }
}
