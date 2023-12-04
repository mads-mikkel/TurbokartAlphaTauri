using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turbokart.Domain.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Brugernavn { get; set; }
        public string Password { get; set; }
    }
}
