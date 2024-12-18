using CarSharing.Application.Common.Interfaces;
using CarSharing.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Infrastructure.Repositories
{

    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarSharingDBContext _context;
        public UnitOfWork(CarSharingDBContext context)
        {
            _context = context;
            Cars = new CarRepository(context);
            Borrowings = new BorrowingRepository(context);
            Users = new AppUserRepository(context);
        }
        public ICarRepository Cars { get; }
        public IBorrowingRepository Borrowings {  get; }
        public IAppUserRepository Users {  get; }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
