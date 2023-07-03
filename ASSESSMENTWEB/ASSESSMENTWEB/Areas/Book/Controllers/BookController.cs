using ASSESSMENTWEB.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using static ASSESSMENTWEB.Models.Books;
using static ASSESSMENTWEB.Models.CommonFunctions;

namespace ASSESSMENTWEB.Areas.Book.Controllers
{
    [Area("Book")]
    public class BookController : Controller
    {
        // GET: BookController
        APIConfiguration objAPIConfigure = new APIConfiguration();

        public async Task<IActionResult> Index(Pagination B)
        {
            try
            {
                List l = new List();
                objAPIConfigure.apiConfig();
                HttpResponseMessage response = await objAPIConfigure.client.PostAsJsonAsync("api/BookAPI/BookAPI/BookList", B);
                List sRes = JsonConvert.DeserializeObject<List>(await response.Content.ReadAsStringAsync());
                l.BookList = sRes.BookList;
                return View(l);
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Create/5
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        public async Task<IActionResult> Create(BookCRUD B)
        {
            try
            {
                JsonResponse res = new JsonResponse();
                var responseMrg = new { result = true, strmsg = "" };
                objAPIConfigure.apiConfig();
                HttpResponseMessage response = await objAPIConfigure.client.PostAsJsonAsync("api/BookAPI/BookAPI/SaveBook", B);
                res = JsonConvert.DeserializeObject<JsonResponse>(await response.Content.ReadAsStringAsync());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                BookCRUD B = new BookCRUD();
                B.BookID = id;
                objAPIConfigure.apiConfig();
                HttpResponseMessage response = await objAPIConfigure.client.PostAsJsonAsync("api/BookAPI/BookAPI/BookDetail", B);
                B = JsonConvert.DeserializeObject<BookCRUD>(await response.Content.ReadAsStringAsync());
                return View(B);
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Edit/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                BookCRUD B = new BookCRUD();
                B.BookID = id;
                objAPIConfigure.apiConfig();
                HttpResponseMessage response = await objAPIConfigure.client.PostAsJsonAsync("api/BookAPI/BookAPI/BookDetail", B);
                B = JsonConvert.DeserializeObject<BookCRUD>(await response.Content.ReadAsStringAsync());
                return View(B);
            }
            catch
            {
                return View();
            }
        }

        // POST: BookController/Edit/5
        [HttpPost]
        public async Task<IActionResult> Update(BookCRUD B)
        {
            try
            {
                JsonResponse res = new JsonResponse();
                var responseMrg = new { result = true, strmsg = "" };
                objAPIConfigure.apiConfig();
                HttpResponseMessage response = await objAPIConfigure.client.PostAsJsonAsync("api/BookAPI/BookAPI/UpdateBook", B);
                res = JsonConvert.DeserializeObject<JsonResponse>(await response.Content.ReadAsStringAsync());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: BookController/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Pagination P = new Pagination();
                BookCRUD B = new BookCRUD();
                B.BookID = id;
                JsonResponse res = new JsonResponse();
                var responseMrg = new { result = true, strmsg = "" };
                objAPIConfigure.apiConfig();
                HttpResponseMessage response = await objAPIConfigure.client.PostAsJsonAsync("api/BookAPI/BookAPI/BookDelete", B);
                res = JsonConvert.DeserializeObject<JsonResponse>(await response.Content.ReadAsStringAsync());
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
