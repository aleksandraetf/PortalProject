using NewsPortal.Repository.News;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Repository.UnitOfWork
{
    public interface INewsUnitOfWork : IDisposable
    {
        INewsRepository News { get; }
        int Complete();

    }
}
