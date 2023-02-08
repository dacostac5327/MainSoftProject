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
    /// <summary>
    /// Services authores
    /// </summary>
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        readonly AuthorsBussinesRules authorsBussinesRules;
        public AuthorsController(IAuthorsRepositories authors)
        {
            authorsBussinesRules = new AuthorsBussinesRules(authors);
        }

        /// <summary>
        /// Consult all authors
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet]
        public async Task<ActionResult> GetAuthors()
        {
            var response = new ResponseBase<List<Authors>>();
            try
            {
                var authors = await authorsBussinesRules.GetAuthorsAsync();
                response.Code = (int)HttpStatusCode.OK;
                response.Data = authors.ToList();
                response.Count = authors.Count;
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }

        /// <summary>
        /// Query author by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("GetAuthorById")]
        public async Task<ActionResult> GetAuthorByIdAsync(int id)
        {
            var response = new ResponseBase<Authors>();
            try
            {
                var authors = await authorsBussinesRules.GetAuthorByIdAsync(id);
                response.Code = (int)HttpStatusCode.OK;
                response.Data = authors;
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }

        /// <summary>
        /// Register new author
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> PostAuthorsAsync(Authors model)
        {
            var response = new ResponseBase<Authors>();
            try
            {
                var author = await authorsBussinesRules.PostAuthorsAsync(model);
                if (author != null)
                {
                    if (author.id > 0)
                    {
                        response.Code = (int)HttpStatusCode.OK;
                        response.Message = "Autor registrado!";
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

        /// <summary>
        /// Update author
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> PutAuthorsAsync(Authors model)
        {
            var response = new ResponseBase<Authors>();
            try
            {
                var author = await authorsBussinesRules.PutAuthorsAsync(model);
                if (author != null)
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
