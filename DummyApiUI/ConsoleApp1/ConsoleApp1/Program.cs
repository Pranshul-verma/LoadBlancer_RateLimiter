// See https://aka.ms/new-console-template for more information
using ConsoleApp1;
using ConsoleApp1.Model;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Text.Json;

#region Dummy Api

    SetLBStrategy().Wait();
    SetEmployeeDetail().Wait();
    myapiget().Wait();


static async Task SetLBStrategy()
{
    var v = StrategyEnum.RoundRobin;
    var json = JsonSerializer.Serialize(v);
    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "LoadBalancer/SetLBStrategy")
    {
        Content = new StringContent(json, Encoding.UTF8, "application/json")
    };
    var responce = SendDataToApi(requestMessage);
    if (responce.IsSuccessStatusCode)
    {
        var vv = responce.Content.ReadAsStringAsync().Result;
    }
}

static HttpResponseMessage SendDataToApi(HttpRequestMessage requestMessage)
{
    using (HttpClient client = new HttpClient())
    {
        //setting base address of Loadbalancer Api....
        client.BaseAddress = new Uri("https://localhost:7186/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        return client.SendAsync(requestMessage).Result;
    }
}

static async Task myapiget()
{
    var requestMessage = new HttpRequestMessage(HttpMethod.Get, "LoadBalancer/GetEmployeeDetail");

    HttpResponseMessage res = SendDataToApi(requestMessage);
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

static async Task SetEmployeeDetail()
{
    EmployeeDetail v = new EmployeeDetail { EmpId = 2, EmpName = "Pragya rathi", EmpEmail = "Pragya.com", Salary = 10000000 };
    var json = JsonSerializer.Serialize(v);
    var requestMessage = new HttpRequestMessage(HttpMethod.Post, "LoadBalancer/SetEmployeeDetail")
    {
        Content = new StringContent(json, Encoding.UTF8, "application/json")
    };
    var responce = SendDataToApi(requestMessage);
    if (responce.IsSuccessStatusCode)
    {
        var vv = responce.Content.ReadAsStringAsync().Result;
    }
}

#endregion

//#region RoundRobin
//RoundRobin rr = new RoundRobin(new List<string> {"1", "2", "3" });
//for (int i = 0; i < 4; i++)
//{
//    Console.WriteLine(rr.Next());
//}
//Console.ReadLine();
//#endregion

#region Weight Round Robin
//WeightedRoundRobin rr = new WeightedRoundRobin(new List<string> { "1", "2", "3" },new List<int> {5,1,2 });
//for (int i = 0; i < 16; i++)
//{
//    Console.WriteLine(rr.GetNextServer());





//}
#endregion

Console.ReadLine();


