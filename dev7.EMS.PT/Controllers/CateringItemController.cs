//using dev7.EMS.Model.CateringItem;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Mvc;

//namespace dev7.EMS.MVC.Controllers
//{
//    public class CateringItemController : Controller
//    {
//        public CateringItemController()
//        { }
//        public ActionResult GetAllCateringItems()
//        {
//            CateringItemsMD CateringItems = null;

//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/CateringItem/GetAllCateringItems");
//                //HTTP GET
//                var responseTask = client.GetAsync("CateringItem");
//                responseTask.Wait();

//                var result = responseTask.Result;
//                if (result.IsSuccessStatusCode)
//                {
//                    var readTask = result.Content.ReadAsAsync<IList<CateringItemsMD>>();
//                    readTask.Wait();

//                    CateringItems = readTask.Result;
//                }
//                else //web api sent error response 
//                {
//                    //log response status here..

//                    CateringItems = Enumerable.Empty<CateringItemsMD>();

//                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
//                }
//            }
//            return View(CateringItems);
//        }

//        [HttpPost]
//        public ActionResult AddNewCateringItem(CateringItemMD CateringItem)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/CateringItem/AddNewCateringItem");

//                //HTTP POST
//                var postTask = client.PostAsJsonAsync<CateringItemMD>("CateringItem", CateringItem);
//                postTask.Wait();

//                var result = postTask.Result;
//                if (result.IsSuccessStatusCode)
//                {
//                    return RedirectToAction("Index");
//                }
//            }

//            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

//            return View(CateringItem);
//        }

//        public ActionResult UpdateCateringItem(int id)
//        {
//            CateringItemMD CateringItem = null;

//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/CateringItem/UpdateCateringItem");
//                //HTTP GET
//                var responseTask = client.GetAsync("CateringItem?id=" + id.ToString());
//                responseTask.Wait();

//                var result = responseTask.Result;
//                if (result.IsSuccessStatusCode)
//                {
//                    var readTask = result.Content.ReadAsAsync<CateringItemMD>();
//                    readTask.Wait();

//                    CateringItem = readTask.Result;
//                }
//            }
//            return View(CateringItem);
//        }
//        [HttpPost]
//        public ActionResult UpdateCateringItem(CateringItemMD CateringItem)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/CateringItem/UpdateCateringItem");

//                //HTTP POST
//                var putTask = client.PutAsJsonAsync<CateringItemMD>("CateringItem", CateringItem);
//                putTask.Wait();

//                var result = putTask.Result;
//                if (result.IsSuccessStatusCode)
//                {

//                    return RedirectToAction("Index");
//                }
//            }
//            return View(CateringItem);
//        }

//        public ActionResult DeleteCateringItem(int id)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/CateringItem/DeleteCateringItem");

//                //HTTP DELETE
//                var deleteTask = client.DeleteAsync("CateringItem/" + id.ToString());
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