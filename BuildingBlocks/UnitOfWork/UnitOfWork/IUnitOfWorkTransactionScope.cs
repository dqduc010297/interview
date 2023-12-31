﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    public interface IUnitOfWorkTransactionScope : IDisposable
    {
        IUnitOfWorkTransactionScope BeginTransaction();
        void Commit();
        void Rollback();
    }
}