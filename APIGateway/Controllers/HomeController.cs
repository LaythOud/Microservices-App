using System.Net.Http;
using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using APIGateway.Models;
using System.Text.Json;
using Newtonsoft.Json;

namespace APIGateway.Controllers;

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
            List<StudentAdmissionDetailsModel> Admissions = JsonConvert.DeserializeObject<List<StudentAdmissionDetailsModel>>(responseBody);
            ViewData["admissions"] = Admissions;
        }
        catch (HttpRequestException e){
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> LoadSubjects()
    {

        var client = new HttpClient();
        ViewData["subjects"] = new List<Subject>();

        try{
             var location = new Uri($"{Request.Scheme}://{Request.Host}");  
             var url = location.AbsoluteUri + "Subject/Index";  
            Console.WriteLine("\nURL Caught!");
            Console.WriteLine(url);

            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
            List<Subject> Subjects = JsonConvert.DeserializeObject<List<Subject>>(responseBody);
            ViewData["subjects"] = Subjects;
        }
        catch (HttpRequestException e){
            Console.WriteLine("\nException Caught!");
            Console.WriteLine("Message :{0} ", e.Message);
        }
        
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> LoadAttendanceDetails()
    {

        var client = new HttpClient();
        ViewData["attendanceDetails"] = new List<StudentAttendanceDetails>();

        try{
             var location = new Uri($"{Request.Scheme}://{Request.Host}");  
             var url = location.AbsoluteUri + "Attendance/Index";  
            Console.WriteLine("\nURL Caught!");
            Console.WriteLine(url);

            using HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
            List<StudentAttendanceDetails> Details = JsonConvert.DeserializeObject<List<StudentAttendanceDetails>>(responseBody);
            ViewData["attendanceDetails"] = Details;
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

    
    [HttpGet]
    public async Task<IActionResult> Register(int id)
    {
        var client = new HttpClient();

        try{
            var location = new Uri($"{Request.Scheme}://{Request.Host}");  
            var url = location.AbsoluteUri + "Subject/Edit?id=" + id;  
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

        return RedirectToAction(nameof(LoadSubjects));
    }

    [HttpGet]
    public async Task<IActionResult> CalcAttendenceStatus(int id)
    {
        var client = new HttpClient();

        try{
            var location = new Uri($"{Request.Scheme}://{Request.Host}");  
            var url = location.AbsoluteUri + "Attendance/Edit?id=" + id;  
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

        return RedirectToAction(nameof(LoadAttendanceDetails));
    }


    // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    // public IActionResult Error()
    // {
    //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    // }
}
