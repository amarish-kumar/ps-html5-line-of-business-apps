using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CodedHomes.Data;
using CodedHomes.Models;

namespace CodedHomes.Web.Controllers
{
    [Authorize]
    public class HomesController : ApiController
    {
        private ApplicationUnit _unit = new ApplicationUnit();

        [HttpGet]
        [AllowAnonymous]
        public IEnumerable<Home> Get()
        {
            return this._unit.Homes.GetAll();
        }

        [HttpGet]
        [System.Web.Http.Authorize(Roles = "admin, manager, user")]
        public Home Get(int id)
        {
            Home home = this._unit.Homes.GetById(id);
            if (home == null)
            {
                throw new HttpResponseException(
                    Request.CreateResponse(HttpStatusCode.NotFound)
                    );
            }

            return home;
        }

        /*
        [System.Web.Http.Authorize(Roles = "admin, manager, user")]
        public HttpResponseMessage Put(int id, Home home)
        { 

        }
        */
    }
}
