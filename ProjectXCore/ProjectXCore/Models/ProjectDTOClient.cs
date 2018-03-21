using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectXCore.Models
{
    public class ProjectDTOClient : BaseEntity
    {
        [Required]
        public string ProjectCode { get; set; }

        [DisplayName("Project Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Project Info")]
        public string Details { get; set; }

        [DisplayName("Project Beginning Date")]
        [Required]
        public string BeginDate { get; set; }

        [DisplayName("Project End Date")]
        public string EndDate { get; set; }     
        
        [Required]
        public int Client { get; set; }
    }
}
