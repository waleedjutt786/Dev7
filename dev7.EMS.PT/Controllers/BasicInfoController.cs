//using dev7.EMS.Model.BasicInfo;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Web;
//using System.Web.Mvc;

//namespace dev7.EMS.MVC.Controllers
//{
//    public class BasicInfoController : Controller
//    {
//        public BasicInfoController()
//        { }
//        public ActionResult GetAllBasicInfos()
//        {
//            BasicInfoListMD BasicInfos = null;

//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/BasicInfo/GetAllBasicInfos");
//                //HTTP GET
//                var responseTask = client.GetAsync("BasicInfo");
//                responseTask.Wait();

//                var result = responseTask.Result;
//                if (result.IsSuccessStatusCode)
//                {
//                    var readTask = result.Content.ReadAsAsync<IList<BasicInfoListMD>>();
//                    readTask.Wait();

//                    BasicInfos = readTask.Result;
//                }
//                else //web api sent error response 
//                {
//                    //log response status here..

//                    BasicInfos = Enumerable.Empty<BasicInfoListMD>();

//                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
//                }
//            }
//            return View(BasicInfos);
//        }

//        [HttpPost]
//        public ActionResult AddNewBasicInfo(BasicInfoMD BasicInfo)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/BasicInfo/AddNewBasicInfo");

//                //HTTP POST
//                var postTask = client.PostAsJsonAsync<BasicInfoMD>("BasicInfo", BasicInfo);
//                postTask.Wait();

//                var result = postTask.Result;
//                if (result.IsSuccessStatusCode)
//                {
//                    return RedirectToAction("Index");
//                }
//            }

//            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

//            return View(BasicInfo);
//        }

//        public ActionResult UpdateBasicInfo(int id)
//        {
//            BasicInfoMD BasicInfo = null;

//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/BasicInfo/UpdateBasicInfo");
//                //HTTP GET
//                var responseTask = client.GetAsync("BasicInfo?id=" + id.ToString());
//                responseTask.Wait();

//                var result = responseTask.Result;
//                if (result.IsSuccessStatusCode)
//                {
//                    var readTask = result.Content.ReadAsAsync<BasicInfoMD>();
//                    readTask.Wait();

//                    BasicInfo = readTask.Result;
//                }
//            }
//            return View(BasicInfo);
//        }
//        [HttpPost]
//        public ActionResult UpdateBasicInfo(BasicInfoMD BasicInfo)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/BasicInfo/UpdateBasicInfo");

//                //HTTP POST
//                var putTask = client.PutAsJsonAsync<BasicInfoMD>("BasicInfo", BasicInfo);
//                putTask.Wait();

//                var result = putTask.Result;
//                if (result.IsSuccessStatusCode)
//                {

//                    return RedirectToAction("Index");
//                }
//            }
//            return View(BasicInfo);
//        }

//        public ActionResult DeleteBasicInfo(int id)
//        {
//            using (var client = new HttpClient())
//            {
//                client.BaseAddress = new Uri("http://localhost:64189/api/BasicInfo/DeleteBasicInfo");

//                //HTTP DELETE
//                var deleteTask = client.DeleteAsync("BasicInfo/" + id.ToString());
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