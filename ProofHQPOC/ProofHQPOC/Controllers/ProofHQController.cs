using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//using com.proofhq.soap;

namespace ProofHQPOC.Controllers
{
    public class ProofHQController : Controller
    {
        // GET: ProofHQ
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult Validate(string user,string pass)
        {
          com.proofhq.soap.soapService  client = new com.proofhq.soap.soapService();
          com.proofhq.soap.SOAPLoginObject login = client.doLogin(user,pass);
           return Json("success");
        }

    }
}