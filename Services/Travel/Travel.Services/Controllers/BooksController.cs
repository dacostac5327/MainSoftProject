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
    public class BooksController : ControllerBase
    {
        readonly BooksBussinesRules booksBussinesRules;
        public BooksController(IBooksRepositories books)
        {
            booksBussinesRules = new BooksBussinesRules(books);
        }

        [HttpGet]
        public async Task<ActionResult> GetBooksAsync()
        {
            var response = new ResponseBase<List<Books>>();
            try
            {
                var books = await booksBussinesRules.GetBooksAsync();
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

        [HttpGet("BookById")]
        public async Task<ActionResult> GetBookByIdAsync(long id)
        {
            var response = new ResponseBase<Books>();
            try
            {
                var book = await booksBussinesRules.GetBookByIdAsync(id);
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
        public async Task<ActionResult> PostBooksAsync(Books model)
        {
            var response = new ResponseBase<Books>();
            try
            {
                var book = await booksBussinesRules.PostBooksAsync(model);
                if (book != null)
                {
                    if (book.ISBN > 0)
                    {
                        response.Code = (int)HttpStatusCode.OK;
                        response.Message = "Libro registrado!";
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
        public async Task<ActionResult> PutBooksAsync(Books model)
        {
            var response = new ResponseBase<Books>();
            try
            {
                var book = await booksBussinesRules.PutBooksAsync(model);
                if (book != null)
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
