using IOTKeyAndValues.Models.Requests;
using IOTKeyAndValues.Models.Responses;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace IOTKeyAndValues.Servies
{
    public interface IKeyValuesService
    {
        void Add(KeyValueRequest keyValue);
        void Delete(string key);
        KeyValueResponse Get(string key);
        List<KeyValueResponse> GetAll();
        void PartialUpdate(string key, string value, JsonPatchDocument jsonPatchDocument);
        void Update(string key, KeyValueRequest keyValue);
        bool ValidateKey(string key);
    }
}