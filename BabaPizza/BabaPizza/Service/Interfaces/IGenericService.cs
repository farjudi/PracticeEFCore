﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabaPizza.Service.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);


        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();

    }
}
