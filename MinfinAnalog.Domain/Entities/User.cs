using System;
using System.Collections.Generic;
using System.Text;

namespace MinfinAnalog.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserWatchlist> UserWatchlists { get; set; }
    }
}
