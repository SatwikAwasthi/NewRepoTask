using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BankingAPI.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankingAPI.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        Account _objAcc = new Account();
        // GET: api/values
        [HttpGet]
        [Route("account/all")]
        public IActionResult GetAllAcccounts()
        {
            try
            {
                return Ok(_objAcc.DisplayAllAccounts());
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet]
        [Route("account/byType/{type}")]
        public IActionResult GetAllByAccType(string type)
        {
            try
            {
                return Ok(_objAcc.DisplayAllAccountsByType(type));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet]
        [Route("account/byStatus/{status}")]
        public IActionResult GetAllByAccStatus(bool status)
        {
            try
            {
                return Ok(_objAcc.DisplayAllAccountsByStatus(status));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        [HttpGet]
        [Route("account/byNumber/{num}")]
        public IActionResult GetByAccNumber(int num)
        {
            try
            {
                return Ok(_objAcc.DisplayAcountByID(num));
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }

        // POST api/values
        [HttpPost]
        [Route("account/add/{AccNum}/{AccName}/{AccType}/{AccBalance}/{AccIsActive}")]
        public IActionResult AddNewAccount(Account acc)
        {
            try
            {
                return Created("", _objAcc.AddNewAccount(acc));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/values/5
        [HttpPut]
        [Route("account/edit/{AccNum}/{AccName}/{AccType}/{AccBalance}/{AccIsActive}")]
        public IActionResult EditAccount(Account acc)
        {
            try
            {
                return Ok(_objAcc.EditAccountDetail(acc));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("account/delete/{id}")]
        public IActionResult DeleteAccount(int id)
        {
            try
            {
                return Ok(_objAcc.DeleteAccount(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

