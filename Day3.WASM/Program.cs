using Day3.Shared;
using Day3.WASM.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Day3.WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            //register custom service
            //builder.Services.AddScoped<IService<Employee>, EmployeeService>();
            //builder.Services.AddScoped<IService<Department>, DepartmentServices>();
            ////register HttpClient
            //builder.Services.AddScoped(
            //    sp => new HttpClient { 
            //        BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>()["Ip"]) }
            //    );
            
            //HttpClientFactory
            builder.Services.AddHttpClient<IService<Employee>, EmployeeService>((sp, client) =>
            {
                client.BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>()["Ip"]);
            });
            builder.Services.AddHttpClient<IService<Department>, DepartmentServices>((sp, client) =>
            {
                client.BaseAddress = new Uri(sp.GetRequiredService<IConfiguration>()["Ip2"]);
            });
            await builder.Build().RunAsync();
        }
    }
}
