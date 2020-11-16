﻿using CodeClinic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CodeClinic.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {

        DbSet<IssueTicket> Issues {get;set;}
   
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
