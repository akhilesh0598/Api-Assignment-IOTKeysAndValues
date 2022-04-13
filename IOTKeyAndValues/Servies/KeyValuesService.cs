using AutoMapper;
using IOTKeyAndValues.Models.DB;
using IOTKeyAndValues.Models.Requests;
using IOTKeyAndValues.Models.Responses;
using IOTKeyAndValues.Repositories;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IOTKeyAndValues.Servies
{
    public class KeyValuesService : IKeyValuesService
    {
        private readonly IKeyValuesRepository _keyValuesRepository;
        private readonly IMapper _mapper;

        public KeyValuesService(IKeyValuesRepository keyValuesRepository, IMapper mapper)
        {
            _keyValuesRepository = keyValuesRepository;
            _mapper = mapper;
        }

        public List<KeyValueResponse> GetAll()
        {
            var keyValues = _keyValuesRepository.GetAllAsync().Result;
            return _mapper.Map<List<KeyValueResponse>>(keyValues);
        }

        public KeyValueResponse Get(string key)
        {
            var keyValue = _keyValuesRepository.GetAsync(key).Result;
            return _mapper.Map<KeyValueResponse>(keyValue);
        }

        public void Add(KeyValueRequest keyValue)
        {
            _keyValuesRepository.AddAsync(_mapper.Map<KeyValue>(keyValue));
        }

        public void Update(string key, KeyValueRequest keyValue)
        {
            _keyValuesRepository.UpdateAsync(key, _mapper.Map<KeyValue>(keyValue));
        }

        public void Delete(string key)
        {
            _keyValuesRepository.DeleteAsync(key);
        }

        public void PartialUpdate(string key,string value, JsonPatchDocument jsonPatchDocument)
        {
            _keyValuesRepository.PartialUpdateAsync(key,value,jsonPatchDocument);
        }

        public bool ValidateKey(string key)
        {
            var keyVal = _keyValuesRepository.GetAsync(key).Result;
            if (keyVal == null)
                return false;
            else
                return true;
        }
    }
}
