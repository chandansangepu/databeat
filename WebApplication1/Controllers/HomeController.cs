using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        public async Task<ActionResult> Index()
        {
            DataContext db = new DataContext();
            Response baseclass = new Response();
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("http://api.plos.org/search?q=title:DNA");
                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    baseclass = JsonConvert.DeserializeObject<Response>(Response);
                }
                General go = new General();
                go.numFound = baseclass.response.numFound;
                go.start = baseclass.response.start;
                go.maxScore = baseclass.response.maxScore;
                db.Generals.Add(go);
                db.SaveChanges();
                foreach (var item in baseclass.response.docs)
                {
                    Document docum = new Document();
                    docum.id = item.id;
                    docum.generalId = go.Id;
                    docum.journal = item.journal;
                    docum.eissn = item.eissn;
                    docum.publication_date = item.publication_date;
                    docum.article_type = item.article_type;
                    docum.score = item.score;
                    db.Documents.Add(docum);
                    db.SaveChanges();
                    foreach (var item1 in item.author_display)
                    {
                        author_display ad1 = new author_display();
                        ad1.docid = docum.docid;
                        ad1.author_display_name = item1;
                        db.author_display.Add(ad1);
                        db.SaveChanges();
                    }
                    foreach (var item2 in item.@abstract)
                    {
                        abstract_display add = new abstract_display();
                        add.docid = docum.docid;
                        add.abstract_display_name = item2;
                        db.abstract_display.Add(add);
                        db.SaveChanges();
                    }
                }
                
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}