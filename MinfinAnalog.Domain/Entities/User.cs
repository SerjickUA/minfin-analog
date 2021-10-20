using System;
using System.Collections.Generic;

namespace MinfinAnalog.Domain.Entities
{
    public class User
    {
        public User()
        {
            UserWatchlists = new List<UserWatchlist>();
        }
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Email { get; set; }
        public virtual ICollection<UserWatchlist> UserWatchlists { get; set; }
    }
}
