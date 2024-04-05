using EmployeeCrud.Models;
using Microsoft.Extensions.DependencyInjection;

namespace EmployeeCrud
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IEmployeeService, EmployeeService>();
        }
    }
}
