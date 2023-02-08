using Entities;
using Entities.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repository;
using Repository.BussinesRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Travel.Services.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class EditorialsController : ControllerBase
    {
        readonly EditorialsBussinesRules booksBussinesRules;
        public EditorialsController(IEditorialsRepositories books)
        {
            booksBussinesRules = new EditorialsBussinesRules(books);
        }

        [HttpGet]
        public async Task<ActionResult> GetEditorialsAsync()
        {
            var response = new ResponseBase<List<Editorials>>();
            try
            {
                var books = await booksBussinesRules.GetEditorialsAsync();
                response.Code = (int)HttpStatusCode.OK;
                response.Data = books.ToList();
                response.Count = books.Count;
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }

        [HttpGet("GetEditorialByIdAsync")]
        public async Task<ActionResult> GetEditorialByIdAsync(int id)
        {
            var response = new ResponseBase<Editorials>();
            try
            {
                var book = await booksBussinesRules.GetEditorialByIdAsync(id);
                response.Code = (int)HttpStatusCode.OK;
                response.Data = book;
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }

        [HttpPost]
        public async Task<ActionResult> PostEditorialsAsync(Editorials model)
        {
            var response = new ResponseBase<Editorials>();
            try
            {
                var editorial = await booksBussinesRules.PostEditorialsAsync(model);
                if (editorial != null)
                {
                    if (editorial.id > 0)
                    {
                        response.Code = (int)HttpStatusCode.OK;
                        response.Message = "Editorial registrada!";
                    }
                    else
                    {
                        response.Code = (int)HttpStatusCode.BadRequest;
                        response.Message = "Ocurrio un error al registrar";
                    }
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                    response.Message = "Ocurrio un error al registrar";
                }
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }

        [HttpPut]
        public async Task<ActionResult> PutEditorialsAsync(Editorials model)
        {
            var response = new ResponseBase<Editorials>();
            try
            {
                var editorial = await booksBussinesRules.PutEditorialsAsync(model);
                if (editorial != null)
                {
                    response.Code = (int)HttpStatusCode.OK;
                }
                else
                {
                    response.Code = (int)HttpStatusCode.BadRequest;
                }
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }
    }
}
