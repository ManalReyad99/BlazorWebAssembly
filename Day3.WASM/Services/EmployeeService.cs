using Day3.Shared;
using System.Collections.Generic;
using System.Net.Http;//HttpClient
using System.Net.Http.Json;//extension method http client Json
using System.Threading.Tasks;

namespace Day3.WASM.Services
{
    public class EmployeeService : IService<Employee>
    {
        HttpClient httpClient;
        public EmployeeService(HttpClient httpClient)//register
        {
            this.httpClient= httpClient;
        }

        public async Task Delete(int id)
        {
            await httpClient.DeleteAsync("/api/Employees/"+id);
        }

        public async Task<List<Employee>> GetAll()
        {
            List<Employee> EmpList = 
                await httpClient.GetFromJsonAsync<List<Employee>>("/api/Employees");
            return EmpList;
        }

        public async Task<Employee> GetById(int id)
        {
            Employee Emp= await  httpClient.GetFromJsonAsync<Employee>("/api/Employees/" + id);
            return Emp;
        }

        public async Task Insert(Employee item)
        {
             await httpClient.PostAsJsonAsync<Employee>("/api/Employees", item);
        }

        public async Task Update(int id, Employee item)
        {
           await httpClient.PutAsJsonAsync<Employee>("/api/Employees/" + id, item);
        }
    }
}
