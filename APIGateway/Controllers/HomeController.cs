using System.Net.Http;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotNet.Docker.Models;
using System.Text.Json;
using Newtonsoft.Json;

namespace DotNet.Docker.Controllers;

[Route("[Controller]/[Action]/")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LoadAdmissions()
    {

        var client = new HttpClient();
        ViewData["admissions"] = new List<StudentAdmissionDetailsModel>();

        try{
             var location = new Uri($"{Request.Scheme}://{Request.Host}");  
             var url = location.AbsoluteUri + "Admission/Index";  
            Console.WriteLine("\nURL Caught!");
            Console.WriteLine(url);

            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
            List<StudentAdmissionDetailsModel> admissions = JsonConvert.DeserializeObject<List<StudentAdmissionDetailsModel>>(responseBody);
            ViewData["admissions"] = admissions;
        }
        catch (HttpRequestException e){
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Approve(int id)
    {
        var client = new HttpClient();

        try{
            var location = new Uri($"{Request.Scheme}://{Request.Host}");  
            var url = location.AbsoluteUri + "Admission/Edit?id=" + id;  
            Console.WriteLine("\nURL Caught!");
            Console.WriteLine(url);

            using HttpResponseMessage response = await client.PostAsync(url, null);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
        }
        catch (HttpRequestException e){
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }

        return RedirectToAction(nameof(LoadAdmissions));
    }

    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
