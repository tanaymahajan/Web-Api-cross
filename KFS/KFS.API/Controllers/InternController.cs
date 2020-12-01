using KFS.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using KFS.API.Models;
using KFS.BAL.Repo;
using KFS.BAL.interfaces;

namespace KFS.API.Controllers
{
    public class InternController : ApiController
    {
        IInterns internrepo = null;
        
        public InternController()
        {
            internrepo = new InternRepo();
            
        }
        [HttpGet]
        [Route("api/InterList")]
        public IHttpActionResult InterList()
        {
            var intern = internrepo.GetAllIntern();
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
            var intern = internrepo.GetPerticulartInter(id);
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

           
            int i = internrepo.AddInter(info);
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
            int i = internrepo.UpdateInter(model);
            
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
            int i = internrepo.DeleteInter(id);
            
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
