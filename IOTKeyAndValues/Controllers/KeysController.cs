using IMDB_API_Project.Exceptions;
using IOTKeyAndValues.Models.Requests;
using IOTKeyAndValues.Servies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTKeyAndValues.Controllers
{
    [Route("api/[controller]")]
    public class KeysController : BaseController
    {
        private readonly IKeyValuesService _keyValuesService;

        public KeysController(IKeyValuesService keyValuesService)
        {
            _keyValuesService = keyValuesService;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            var keyValues = _keyValuesService.GetAll();
            return Ok(keyValues);
        }

        [HttpGet("{key}")]
        public IActionResult Get(string key)
        {
            try
            {
                if (!_keyValuesService.ValidateKey(key))
                    throw new KeyNotFoundExceptionInKeyValues($"In KeyValue Entity key '{key}' not found");
                var keyValue = _keyValuesService.Get(key);
                return Ok(keyValue);
            }
            catch (KeyNotFoundExceptionInKeyValues ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] KeyValueRequest keyValueRequest)
        {
            try
            {
                if (_keyValuesService.ValidateKey(keyValueRequest.Key))
                    throw new KeyFoundExceptionInKeyValues($"In KeyValue Entity key '{keyValueRequest.Key}' already exist");
                _keyValuesService.Add(keyValueRequest);
                return Created("~api/keys/", new { key = keyValueRequest.Key });
            }
            catch (KeyFoundExceptionInKeyValues ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPut("{key}")]
        public IActionResult Put(string key, [FromBody] KeyValueRequest keyValueRequest)
        {
            try
            {
                if (key != keyValueRequest.Key)
                    throw new KeyMatchExceptionInKeyValues(
                        $"Route key '{key}' and body key '{keyValueRequest.Key}' are not equal");
                if (!_keyValuesService.ValidateKey(key))
                    throw new KeyNotFoundExceptionInKeyValues($"In KeyValue Entity key '{key}' not found");
                _keyValuesService.Update(key, keyValueRequest);
                return Ok(new { message = "Updated Successfully" });
            }
            catch (KeyNotFoundExceptionInKeyValues ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (KeyMatchExceptionInKeyValues ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{key}/{value}")]
        public IActionResult Patch([FromRoute] string key, [FromRoute] string value, JsonPatchDocument jsonPatchDocument)
        {
            try
            {
                if (!_keyValuesService.ValidateKey(key))
                    throw new KeyNotFoundExceptionInKeyValues($"In KeyValue Entity key '{key}' not found");
                _keyValuesService.PartialUpdate(key, value, jsonPatchDocument);
                return Ok(new { message = "Updated Successfully" });
            }
            catch (KeyNotFoundExceptionInKeyValues ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{key}")]
        public IActionResult Delete(string key)
        {
            try
            {
                if (!_keyValuesService.ValidateKey(key))
                    throw new KeyNotFoundExceptionInKeyValues($"In KeyValue Entity key '{key}' not found");
                _keyValuesService.Delete(key);
                return Ok(new { message = "Deleted Successfully" });
            }
            catch (KeyNotFoundExceptionInKeyValues ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }
    }
}
