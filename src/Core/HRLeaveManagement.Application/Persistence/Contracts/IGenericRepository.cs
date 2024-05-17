﻿namespace HRLeaveManagement.Application.Persistence.Contracts;

public interface IGenericRepository<T> where T : class
{
    Task<T> Get(int id);

    Task<T> GetAll();

    Task<bool> Exists(int id);

    Task<T> Add(T entity);

    Task<T> Update(T entity);

    Task<T> Delete(T entity);
}
