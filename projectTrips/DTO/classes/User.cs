using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.classes
{
    public partial class User
    {
        public short IdUser { get; set; }

        public string LastName { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? PasswordIn { get; set; }

        public bool? FirstAidCertificate { get; set; }
    }
}
