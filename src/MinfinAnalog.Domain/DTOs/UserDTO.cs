using System;
using System.Collections.Generic;
using System.Text;

namespace MinfinAnalog.Domain.DTOs
{
    public class UserDto
    {
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
