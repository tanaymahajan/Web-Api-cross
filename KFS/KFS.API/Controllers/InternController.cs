using KFS.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KFS.API.Models;

namespace KFS.API.Controllers
{
    public class InternController : ApiController
    {
        praticedbEntities db;
        public InternController()
        {
            db = new praticedbEntities();
        }
        [HttpGet]
        [Route("api/InterList")]
        public IHttpActionResult InterList()
        {
            var intern = db.InternInfoes.ToList();
            if (intern != null)
            {
                return Ok(intern);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("api/InterDetails")]
        public IHttpActionResult InterDetails(int id)
        {
            var intern = db.InternInfoes.Where(x => x.Id == id).First();
            if (intern != null)
            {
                return Ok(intern);
            }
            else
            {
                return BadRequest("Not found");
            }
        }
        [HttpPost]
        [Route("api/RegisterInter")]
        //[ResponseType(typeof(InternInfo))]
        public IHttpActionResult RegisterInter([FromBody] InternModel model)
        {

            InternInfo info = new InternInfo();
            info.First_Name = model.First_Name;
            info.Last_Name = model.Last_Name;
            info.College = model.College;

           db.InternInfoes.Add(info);
           int i=db.SaveChanges();
            if (i >= 1)
            {
                return Ok("Successfully Register");
            }
            else
            {
                return BadRequest("Not a valid model");
            }
        }
        [HttpPut]
        [Route("api/UpdateInterInfo")]
        public IHttpActionResult UpdateInterInfo(InternInfo model)
        {
            int i = 0;
            var data = db.InternInfoes.Where(x => x.Id == model.Id).FirstOrDefault();
            if (data != null)
            {
                data.First_Name = model.First_Name;
                data.Last_Name = model.Last_Name;
                data.College = model.College;
                i=db.SaveChanges();
            }
            if (i >= 1)
            {
                return Ok("Successfully updated");
            }
            else
            {
                return BadRequest("Not a valid model");
            }
        }
        [HttpDelete]
        [Route("api/RemoveIntern")]
        public IHttpActionResult RemoveIntern(int id)
        {
            int i = 0;
            var data = db.InternInfoes.Where(x => x.Id == id).FirstOrDefault();
            if (data != null)
            {
                db.InternInfoes.Remove(data);
                i = db.SaveChanges();
            }
            if (i >= 1)
            {
                return Ok("Deleted Successfully");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
