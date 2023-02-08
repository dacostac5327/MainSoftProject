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
    public class AuthorsBooksController : ControllerBase
    {
        readonly Authors_has_BooksBussinesRules authors_Has_BooksBussinesRules;
        public AuthorsBooksController(IAuthors_has_BooksRepositories authors)
        {
            authors_Has_BooksBussinesRules = new Authors_has_BooksBussinesRules(authors);
        }

        [HttpGet("Authors_has_Books")]
        public async Task<ActionResult> GetAuthors_has_BooksAsync()
        {
            var response = new ResponseBase<List<Authors_has_Books>>();
            try
            {
                var authors_Has_Books = await authors_Has_BooksBussinesRules.GetAuthors_has_BooksAsync();
                response.Code = (int)HttpStatusCode.OK;
                response.Data = authors_Has_Books.ToList();
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }

        [HttpGet("Authors_has_BooksByAuthorId")]
        public async Task<ActionResult> GetAuthors_has_BooksByAuthorIdAsync(int id)
        {
            var response = new ResponseBase<List<Authors_has_Books>>();
            try
            {
                var authors_Has_Books = await authors_Has_BooksBussinesRules.GetAuthors_has_BooksByAuthorIdAsync(id);
                response.Code = (int)HttpStatusCode.OK;
                response.Data = authors_Has_Books.ToList();
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }

        [HttpGet("Authors_has_BooksByEditorialId")]
        public async Task<ActionResult> GetAuthors_has_BooksByEditorialIdAsync(int id)
        {
            var response = new ResponseBase<List<Authors_has_Books>>();
            try
            {
                var authors_Has_Books = await authors_Has_BooksBussinesRules.GetAuthors_has_BooksByEditorialIdAsync(id);
                response.Code = (int)HttpStatusCode.OK;
                response.Data = authors_Has_Books.ToList();
            }
            catch (Exception ex)
            {
                response.Code = (int)HttpStatusCode.InternalServerError;
                response.Message = ex.Message;
            }
            return StatusCode(response.Code, response);
        }
        
        [HttpPost]
        public async Task<ActionResult> PostAuthors_has_BooksAsync(Authors_has_Books model)
        {
            var response = new ResponseBase<Authors_has_Books>();
            try
            {
                var authorBooks = await authors_Has_BooksBussinesRules.PostAuthors_has_BooksAsync(model);
                if (authorBooks != null)
                {
                    if (authorBooks.authors_id > 0)
                    {
                        response.Code = (int)HttpStatusCode.OK;
                        response.Message = "Autor asociado!";
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
    }
}
