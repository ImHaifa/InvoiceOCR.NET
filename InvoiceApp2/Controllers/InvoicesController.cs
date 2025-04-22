using InvoiceApp2.Data;
using InvoiceApp2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tesseract;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace InvoiceApp2.Controllers
{
    public class InvoicesController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
      
        public IActionResult Index()
        {
            return View();
        }

       

        public InvoicesController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
            
        }

        [HttpGet]
        public IActionResult Upload() => View();

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, string email)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var folderPath = Path.Combine(_environment.WebRootPath, "uploads");
                Directory.CreateDirectory(folderPath);
                var filePath = Path.Combine(folderPath, fileName);
          
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
       


                var reader = ExtractValue(filePath);
                var invoice = new Invoice
                {
                    FileName = file.FileName,
                    FilePath = "/uploads/" + file.FileName,
                    InvoiceNumber = "",
                    Vendor = "",
                    Amount  = 0.0m,
                    Status = "Pending",
                    Date = DateTime.Now,
                    ExtractedText=reader,
                    Email=email
                };

                _context.Invoices.Add(invoice);
                await _context.SaveChangesAsync();
                TempData["Email"] = email;
                TempData["ExtractedText"] = reader;

                //await SendToPowerAutomate(email, reader);

                // Redirect to the results view
                return RedirectToAction("ShowOCRResult");
            }

            return View();
        }
        public async Task<IActionResult> List()
        {
            var invoices = await _context.Invoices.ToListAsync();
            return View(invoices);
        }

        [HttpPost]
        public async Task<IActionResult> ClearAll()
        {
            var allInvoices = await _context.Invoices.ToListAsync();
            _context.Invoices.RemoveRange(allInvoices);
            await _context.SaveChangesAsync();         
            return RedirectToAction("List");
        }


        public static string ExtractValue(string imagePath)
        {
       
            using (var engine = new TesseractEngine(@"./tessdata", "eng+ara", EngineMode.Default))
            {
                using (var img = Pix.LoadFromFile(imagePath))
                {
                    using (var page = engine.Process(img))
                    {
                        return page.GetText();
                    }
                }
            }
        
        }

        public IActionResult ShowOCRResult()
        {
            return View();
        }



        /*
        private async Task SendToPowerAutomate(string email, string extractedText)
        {
            using (var client = new HttpClient())
            {
                var apiUrl = "";

                var jsonContent = new
                {
                    email = email,
                    extractedText = extractedText
                };

                var json = JsonConvert.SerializeObject(jsonContent);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                //var response = await client.PostAsync(apiUrl, content);

              
                HttpResponseMessage response = await client.PostAsync(apiUrl, content);
                
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Data sent successfully to Power Automate.");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    Console.WriteLine($"Failed to send data. Status: {response.StatusCode}, Error: {error}");
                
        }}*/
    }


}


