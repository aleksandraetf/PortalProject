using NewsPortal.Repository.UsersRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewsPortal.Repository.UnitOfWork
{
    public interface IUserUnitOfWork : IDisposable
    {
        IUserRepository User { get; }
        int Complete();

    }
}
