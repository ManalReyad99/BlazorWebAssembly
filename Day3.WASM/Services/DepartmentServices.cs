using Day3.Shared;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Day3.WASM.Services
{
    public class DepartmentServices : IService<Department>
    {
        private readonly HttpClient httpClient;

        public DepartmentServices(HttpClient _httpClient)
        {
            httpClient = _httpClient;
        }
        public async Task Delete(int id)
        {
            await httpClient.DeleteAsync("/api/Departments/" + id);
        }

        public async Task<List<Department>> GetAll()
        {
            return  await httpClient.GetFromJsonAsync<List<Department>>("/api/Departments");
        }

        public async Task<Department> GetById(int id)
        {
            return  await httpClient.GetFromJsonAsync<Department>("/api/Departments/"+id);

        }

        public async Task Insert(Department item)
        {
           await httpClient.PostAsJsonAsync("/api/Departments", item);
        }

        public  async Task Update(int id, Department item)
        {
            await httpClient.PutAsJsonAsync<Department>("/api/Departments/" + id, item);
        }
    }
}
