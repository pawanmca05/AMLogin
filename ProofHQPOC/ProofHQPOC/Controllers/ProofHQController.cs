using ProofHQPOC.com.proofhq.soap;
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
       com.proofhq.soap.SOAPFileObject[] allProofs;
       com.proofhq.soap.soapService client= new com.proofhq.soap.soapService();
       com.proofhq.soap.SOAPLoginObject loginObject;
        // GET: ProofHQ
        public ActionResult Index(string Id)
        {
            ViewBag.Id = Id;
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CreateProoff(string id)
        {
            ViewBag.id = id;
            return View();
        }

        public JsonResult GeenerateProof(string Id,string filename,string hash,string proofname)
        {
           var result=client.createProof(Id,0,hash,proofname,filename,"","","","",0,0,true,true,"","",true, true, true, true, true, true, true, true, true, true, true, true, true, true, true, true,"","",true,"",true);
            return Json("success");
        }

        public JsonResult GetComments(string Id,int fileId)
        {
            var comments = client.getProofComments(Id, fileId);
           // comments[0].replies[0].
            return Json(comments,JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProofDoc(string Id,int fileId)
        {
            string result = client.getProofDownloadURL(Id,fileId);
            return Json(result,JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddComments(string Id, int fileId,int RevId,int commentId,string comment)
        {

            SOAPCommentReplyObject repl= client.addCommentReply(Id, fileId, RevId, commentId, comment);
            return Json("success",JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllProofs(string Id)
        {
            allProofs = client.getAllProofs(Id, 0, "", 10);
            return Json(allProofs,JsonRequestBehavior.AllowGet);
        }

        //Getting the List of Reviewers
        public JsonResult GetUsers(string Id,string fileId)
        {
            var users = client.getProofReviewers(Id, fileId);
            return Json(users, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Validate(string user,string pass)
        {
            
            loginObject = client.doLogin(user, pass);
            //ViewBag.Id = loginObject.session;
            return Json(loginObject.session);
        }

    }
}