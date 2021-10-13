using System;
using System.Collections.Generic;
using System.Text;

namespace MinfinAnalog.Domain.Models
{
    class UserModel
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Email { get; set; }
    }
}
