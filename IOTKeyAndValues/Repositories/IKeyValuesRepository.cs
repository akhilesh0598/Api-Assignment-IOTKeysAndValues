using IOTKeyAndValues.Models.DB;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IOTKeyAndValues.Repositories
{
    public interface IKeyValuesRepository
    {
        Task AddAsync(KeyValue keyValue);
        Task DeleteAsync(string key);
        Task<List<KeyValue>> GetAllAsync();
        Task<KeyValue> GetAsync(string key);
        Task PartialUpdateAsync(string key, string value, JsonPatchDocument jsonPatchDocument);
        Task UpdateAsync(string key, KeyValue keyValue);
    }
}