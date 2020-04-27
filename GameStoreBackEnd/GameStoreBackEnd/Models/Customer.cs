using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GameStoreBackEnd.Models
{
    public class Customer//: IdentityUser
    {
        #region Properties
        public int CustomerId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
        
        [Required]
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
