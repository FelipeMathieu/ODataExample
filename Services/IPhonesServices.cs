using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public interface IPhonesServices
    {
        IQueryable<Phones> GetAll();
    }
}
