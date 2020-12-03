using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class PhonesServices : IPhonesServices
    {
        private readonly ODataContext context;

        public PhonesServices(ODataContext context)
        {
            this.context = context;
        }

        public IQueryable<Phones> GetAll()
        {
            return context.Phones;
        }
    }
}
