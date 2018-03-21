using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectXCore.Models
{
    public class Project : BaseEntity
    {
        public int Id { get; set; }
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

        // one-to-many Relation
        public Client Client { get; set; }
        //[DisplayName("is Project Complete?")]
        //public char Complete { get; set; }

        // many to many relations
        public virtual ICollection<ProjectWorkers> WorkersLink { get; set; }
        //public Project()
        // {
        //this.Workers = new HashSet<Workers>();
        //}
    }
    public class ProjectDTO
    {
        public string ProjectCode { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
    }

    public class ProjectDTOAll
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
        // one-to-many Relation
        public Client Client { get; set; }
        public ICollection<Workers> WorkersList { get; set; }
    }

}