﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RealDeal.AppLogic.Abstractions
{
    public interface IRepository<T>
    {
        T Get( int id );
        IEnumerable<T> GetAll();
        T Add(T itemToAdd);
        T Update(T itemToUpdate);
        bool Delete(T itemToDelete);
    }
}
