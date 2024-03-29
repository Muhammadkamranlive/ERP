﻿using ERP.Core.DataAccess;
using System.Linq.Expressions;
using ERP.Core.BusinessAccess;
using Microsoft.EntityFrameworkCore;

namespace ERP.Core.ServiceAccess
{
    public class Base_Service<T> : IBase_Service<T> where T : class
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRepo<T> _genericRepository;
        public Base_Service(IUnitOfWork unitOfWork, IRepo<T> genericRepository)
        {
            _unitOfWork        = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<int> CompleteAync()
        {
            return await _unitOfWork.Save();
        }

        public async Task<bool> Delete(Guid id)
        {
            var tempRecord = await _genericRepository.Get(id);
            if (tempRecord != null)
            {
                return await _genericRepository.Remove(id);
            }
            throw new Exception($"{typeof(T).Name} with the {id} is  not Found sorry...!");

        }

        public async Task<IList<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return (IList<T>)await _genericRepository.Find(predicate);
            
            
        }
        public async Task AddRange(IEnumerable<T> entities)
        {
            await _genericRepository.AddRange(entities);
        }
        public async Task<T?> Get(Guid id)
        {
            var tempRecord = await _genericRepository.Get(id);
            if (tempRecord == null)
            {
                throw new Exception($"{typeof(T).Name} with the {id} is  not Found sorry...!");
            }
            return tempRecord;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var AllData = await _genericRepository.GetAll();
            if (AllData != null)
            {
                return AllData;
            }
            throw new Exception($"{typeof(T).Name} is not having any record Sorry...!");
        }

        public async Task InsertAsync(T entity)
        {
            await _genericRepository.Add(entity);
        }

        public void UpdateRecord(T entity)
        {
            _genericRepository.Update(entity);
        }
    }

}
