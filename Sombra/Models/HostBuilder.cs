using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombra.Models
{
    public class HostBuilder : IService
    {
        public IService NextService { get; set; }
        public virtual void Run()
        {
            NextService?.Run();
        }
        public virtual void InsertService(IService newService)
        {
            newService.NextService = NextService;
            NextService = newService;
        }
        public virtual T TryGetService<T>() where T : class
        {
            IService Pointer = this;
            while (Pointer.NextService != null)
            {
                if (Pointer is T)
                {
                    return Pointer as T;
                }
            }
            return null;
        }
    }

}
