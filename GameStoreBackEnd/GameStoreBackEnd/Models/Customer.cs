using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Models
{
    public class Customer
    {
        #region Properties
        public int CustomerId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        public string Type { get; set; }

        public IEnumerable<Game> Games { get; set; }
        #endregion

        #region Constructors
        public Customer()
        {
        }
        #endregion
    }
}
