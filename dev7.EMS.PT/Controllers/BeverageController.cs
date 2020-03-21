//using dev7.EMS.Model.Beverage;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Mvc;

//namespace dev7.EMS.MVC.Controllers
//{
//    public class BeverageController : Controller
//    {
//        public BeverageController()
//        { }
//        public ActionResult GetAllBeverages()
//        {
//            BeveragesMD Beverages = null;

//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/Beverage/GetAllBeverages");
//                //HTTP GET
//                var responseTask = client.GetAsync("Beverage");
//                responseTask.Wait();

//                var result = responseTask.Result;
//                if (result.IsSuccessStatusCode)
//                {
//                    var readTask = result.Content.ReadAsAsync<IList<BeveragesMD>>();
//                    readTask.Wait();

//                    Beverages = readTask.Result;
//                }
//                else //web api sent error response 
//                {
//                    //log response status here..

//                    Beverages = Enumerable.Empty<BeveragesMD>();

//                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
//                }
//            }
//            return View(Beverages);
//        }

//        [HttpPost]
//        public ActionResult AddNewBeverage(BeverageMD Beverage)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/Beverage/AddNewBeverage");

//                //HTTP POST
//                var postTask = client.PostAsJsonAsync<BeverageMD>("Beverage", Beverage);
//                postTask.Wait();

//                var result = postTask.Result;
//                if (result.IsSuccessStatusCode)
//                {
//                    return RedirectToAction("Index");
//                }
//            }

//            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

//            return View(Beverage);
//        }

//        public ActionResult UpdateBeverage(int id)
//        {
//            BeverageMD Beverage = null;

//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/Beverage/UpdateBeverage");
//                //HTTP GET
//                var responseTask = client.GetAsync("Beverage?id=" + id.ToString());
//                responseTask.Wait();

//                var result = responseTask.Result;
//                if (result.IsSuccessStatusCode)
//                {
//                    var readTask = result.Content.ReadAsAsync<BeverageMD>();
//                    readTask.Wait();

//                    Beverage = readTask.Result;
//                }
//            }
//            return View(Beverage);
//        }
//        [HttpPost]
//        public ActionResult UpdateBeverage(BeverageMD Beverage)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/Beverage/UpdateBeverage");

//                //HTTP POST
//                var putTask = client.PutAsJsonAsync<BeverageMD>("Beverage", Beverage);
//                putTask.Wait();

//                var result = putTask.Result;
//                if (result.IsSuccessStatusCode)
//                {

//                    return RedirectToAction("Index");
//                }
//            }
//            return View(Beverage);
//        }

//        public ActionResult DeleteBeverage(int id)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/Beverage/DeleteBeverage");

//                //HTTP DELETE
//                var deleteTask = client.DeleteAsync("Beverage/" + id.ToString());
//                deleteTask.Wait();

//                var result = deleteTask.Result;
//                if (result.IsSuccessStatusCode)
//                {

//                    return RedirectToAction("Index");
//                }
//            }

//            return RedirectToAction("Index");
//        }
//    }
//}