using IOTKeyAndValues.Data;
using IOTKeyAndValues.Models.DB;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTKeyAndValues.Repositories
{
    public class KeyValuesRepository : IKeyValuesRepository
    {
        private readonly KeyValuesStoreContext _context;

        public KeyValuesRepository(KeyValuesStoreContext context)
        {
            _context = context;
        }

        public async Task<List<KeyValue>> GetAllAsync()
        {
            var keyValues = await _context.KeyValues.ToListAsync();
            return keyValues;
        }

        public async Task<KeyValue> GetAsync(string key)
        {
            var keyValue = await _context.KeyValues.FirstOrDefaultAsync(u=>u.Key==key);
            return keyValue;
        }

        public async Task AddAsync(KeyValue keyValue)
        {
            await _context.KeyValues.AddAsync(keyValue);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(string key, KeyValue keyValue)
        {
            var nonUpdatedkeyValue = _context.KeyValues.Find(key);
            nonUpdatedkeyValue.Key = keyValue.Key;
            nonUpdatedkeyValue.Value = keyValue.Value;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(string key)
        {
            var keyValue = _context.KeyValues.Find(key);
            _context.KeyValues.Remove(keyValue);
            await _context.SaveChangesAsync();
        }

        public async Task PartialUpdateAsync(string key, string value, JsonPatchDocument jsonPatchDocument)
        {
            var keyValue = _context.KeyValues.Find(key);
            keyValue.Value = value;
            jsonPatchDocument.ApplyTo(keyValue);
            await _context.SaveChangesAsync();
        }
    }
}
