using Context;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Services
{
    public class PersonNumbersServices : IPersonNumbersServices
    {
        private readonly ODataContext context;

        public PersonNumbersServices(ODataContext context)
        {
            this.context = context;
        }

        public IQueryable<PersonNumbers> GetAll()
        {
            return context.PersonNumbers;
        }
    }
}
