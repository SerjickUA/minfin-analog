using System;
using System.Collections.Generic;
using System.Text;

namespace MinfinAnalog.Domain.Entities
{
    public class UserWatchlist
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
    }
}
