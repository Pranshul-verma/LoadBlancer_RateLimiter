// See https://aka.ms/new-console-template for more information
using ConsoleApp1.Model;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");
using (HttpClient client = new HttpClient())
{
    client.BaseAddress = new Uri("https://localhost:7178/");
    client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
    SetEmployeeDetail(client).Wait();
    myapiget(client).Wait();
}
static async Task myapiget(HttpClient client)
{
    //using (client)
    {
        HttpResponseMessage res = await client.GetAsync("EmployeeDetail/Get");
        if (res.IsSuccessStatusCode)
        {
            List<EmployeeDetail> employee = await res.Content.ReadAsAsync<List<EmployeeDetail>>();
            foreach (EmployeeDetail emp in employee)
            {
                Console.WriteLine(emp.EmpId.ToString() + " " + emp.EmpName + " " + emp.EmpEmail + " " + emp.Salary);
            }
            Console.Read();
        }

    }
    //throw new NotImplementedException();
}

static async Task SetEmployeeDetail(HttpClient client)
{
    //using (client)
    {
        EmployeeDetail v = new EmployeeDetail { EmpId = 2, EmpName = "Pragya rathi", EmpEmail = "Pragya.com", Salary = 10000000 };
        var json = JsonSerializer.Serialize(v);
        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var responce = client.PostAsync("EmployeeDetail/SetEmployeeDetail", content).Result;
        if (responce.IsSuccessStatusCode)
        {
            var vv = responce.Content.ReadAsStringAsync().Result;
        }
    }
   
}