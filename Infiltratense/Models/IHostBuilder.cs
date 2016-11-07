using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infiltratense.Models
{
    public interface IService
    {
        IService NextService { get; set; }
        void InsertService(IService NewService);
        void Run();
    }
}
