using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sombra.Models
{
    public class HostService : IService
    {
        public IService NextService { get; set; }
        public virtual void Run()
        {
            NextService?.Run();
        }
        public virtual void InsertService(IService NewService)
        {
            NewService.NextService = NextService;
            NextService = NewService;
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

    public class ReactorService : HostService, IService
    {

    }
}
