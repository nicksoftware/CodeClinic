using CodeClinic.Application.Common.Interfaces;
using System;

namespace CodeClinic.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
