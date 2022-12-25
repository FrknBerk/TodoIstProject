using Microsoft.Extensions.DependencyInjection;
using Project.Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.DependencyResolvers
{
    internal class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection serviceCollection)
        {
            throw new NotImplementedException();
        }
    }
}
