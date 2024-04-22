using PeopleApp.ClassLib.Models;
using PeopleApp.Mvc.Helpers;

namespace PeopleApp.Mvc.Services.Interfaces
{
    public interface IDepartmentRepository
    {
        Task<ApiResult<Department>> get();
        Task<ApiResult<Department>> getById(long id);
        Task<ApiResult<Department>> add(Department department);
    }
}
