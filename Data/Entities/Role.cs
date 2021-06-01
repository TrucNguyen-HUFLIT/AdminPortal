using System.Collections.Generic;

namespace Data.Entities
{
    public class Role
    {
        public int RoleId { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}
