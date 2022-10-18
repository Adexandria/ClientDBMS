using ClientDBMS.Model;
using ClientDBMS.Models;
using ClientDBMS.Services.Repository;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientDBMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private IClient _clientDb;
        public ClientController(IClient clientDb)
        {
            _clientDb = clientDb;
        }

        [HttpGet]
        public IActionResult GetAllClients()
        {
            var clients = _clientDb.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<Client>> GetClientByClientId(Guid clientId)
        {
            try
            {
                var client = await _clientDb.GetExistingClientById(clientId);
                if(client == null)
                {
                    return NotFound("Client doesn't exist");
                }
                return Ok(client);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewClient(ClientCreateDTO newClient)
        {
            try
            {
                var client = newClient.Adapt<Client>();
                await _clientDb.CreateNewClient(client);
                return Ok("Created");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
          
        }

        [HttpPut("{clientId}/firstname")]
        public async Task<IActionResult> UpdateClientFirstName(Guid clientId, string firstname)
        {
            try
            {
                await _clientDb.UpdateClientName(clientId, firstname);
                return Ok("Successful");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut("{clientId}/middlename")]
        public async Task<IActionResult> UpdateClientMiddleName(Guid clientId, string middlename)
        {
            try
            {
                await _clientDb.UpdateClientMiddlename(clientId, middlename);
                return Ok("Successful");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut("{clientId}/lastname")]
        public async Task<IActionResult> UpdateClientLastName(Guid clientId, string lastname)
        {
            try
            {
                await _clientDb.UpdateClientLastname(clientId, lastname);
                return Ok("Successful");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPut("{clientId}/address")]
        public async Task<IActionResult> UpdateClientAddress(Guid clientId, string address)
        {
            try
            {
                await _clientDb.UpdateClientAddress(clientId, address);
                return Ok("Successful");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
        [HttpPut("{clientId}/phonenumber")]
        public async Task<IActionResult> UpdateClientPhonenumber(Guid clientId, string phonenumber)
        {
            try
            {
                await _clientDb.UpdateClientPhonenumber(clientId, phonenumber);
                return Ok("Successful");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClientById(Guid clientId)
        {
            try
            {
                await _clientDb.DeleteClient(clientId);
                return Ok("Successful");
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }
    }
}
