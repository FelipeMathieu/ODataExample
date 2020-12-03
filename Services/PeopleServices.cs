using Context;
using Models;
using System;
using System.Linq;

namespace Services
{
    public class PeopleServices : IPeopleServices
    {
        private readonly ODataContext context;

        public PeopleServices(ODataContext context)
        {
            this.context = context;
        }

        public IQueryable<People> GetAll()
        {
            return context.People;
        }
    }
}
