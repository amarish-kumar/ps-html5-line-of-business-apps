using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using CodedHomes.Data;
using CodedHomes.Models;
using System.Data.Entity.Infrastructure;

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

        [System.Web.Http.Authorize(Roles = "admin, manager, user")]
        public HttpResponseMessage Put(int id, Home home)
        {
            // some validation error
            if (!ModelState.IsValid)
            {
                return Request.
                    CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != home.Id)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            Home existingHome = this._unit.Homes.GetById(id);
            _unit.Homes.Detach(existingHome);

            // keep original CreatedOn value
            home.CreatedOn = existingHome.CreatedOn;

            this._unit.Homes.Update(home);

            try
            {
                this._unit.SaveChanges();

                // return an expicit value to avoid the fail callback
                //beign incorrectly invoiked
                return Request.CreateResponse(HttpStatusCode.OK, "{success:'true', verb:'PUT'}");
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            catch(Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
