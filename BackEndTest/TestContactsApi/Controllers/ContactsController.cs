using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using TestContactsApi.Models;
using TestContactsApi.Services.Contracts;

namespace TestContactsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactsServices _contactsService;

        public ContactsController(IContactsServices contactsServices)
        {
            this._contactsService = contactsServices;
        }

        [HttpGet("{id}", Name = "GetContact")]
        public async Task<IActionResult> GetContact(int id)
        {
            try
            {
                var response = await this._contactsService.GetContactById(id);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
            
        }

        [HttpGet]
        [Route("Contact/{pattern}/contactByPattern")]
        public async Task<IActionResult> GetContactByPattern(string pattern)
        {
            try
            {
                var response = await this._contactsService.GetContactByPattern(pattern);
                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return StatusCode(ex.HResult);
            }           
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteContact(int id)
        {
            try
            {
                this._contactsService.DeleteContactById(id);
                return Ok(true);
            }
            catch (Exception ex)
            {
                if (ex.Message.Equals("204"))
                {
                    return StatusCode(204, "No Content.");
                }
                return StatusCode(ex.HResult);
            }           
        }
    }
}
