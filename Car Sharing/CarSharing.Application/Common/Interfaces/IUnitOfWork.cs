using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharing.Application.Common.Interfaces
{
    public interface IUnitOfWork
    {
        ICarRepository Cars { get; }
        IBorrowingRepository Borrowings { get; }

        // Ik wou in deze interface ook de IAppUserRepository toevoegen maar aangezien de identity user in de infrastructure layer is kan ik geen using gebruiken om toegang te krijgen  tot de ApplicationUser klasse.
        // Ik vind het niet elegant maar ik heb besloten om die niet toe te voegen in de interface maar wel in de UnitOfWork klasse
        void Save();
    }
}
