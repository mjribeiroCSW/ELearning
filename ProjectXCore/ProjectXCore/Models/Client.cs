using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectXCore.Models
{
    public class Client : BaseEntity
    {
        //public int Id { get; set; }

        [DisplayName("Client Name")]
        public string Name { get; set; }

        [DisplayName("Client Mail")]
        public string Email { get; set; }

        [DisplayName("Client Owner Name")]
        public string OwnerName { get; set; }
    }

    public class ClientDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }  
        public ICollection<ProjectDTO> ListProjects { get; set; }
    }
}
