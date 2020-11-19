using CodeClinic.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeClinic.Application.UnitTests.Common
{
    class CommandTestBase : IDisposable
    {
        

        public CommandTestBase()
        {
            //_context = ContextFactory.Create();
        }

        public void Dispose()
        {
            //ContextFactory.Destroy(_context);
        }
    }
}
