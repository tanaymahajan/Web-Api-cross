using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using KFS.BAL;

namespace KFS.API.Controllers
{
    public class CountryController : ApiController
    {
        praticedbEntities db;
        public CountryController()
        {
            db = new praticedbEntities();
        }

        [HttpGet]
        [Route("api/AllCountry")]
        public IHttpActionResult AllCountry()
        {
            var country = db.countries.ToList();
            if (country != null)
            {
                
                return Ok(country);
            }
            else
            {
                return NotFound();
            }
            
        }
    }
}
