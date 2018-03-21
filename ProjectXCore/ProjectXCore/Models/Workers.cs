using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectXCore.Models
{
    public class Workers : BaseEntity
    {
        [DisplayName("Worker ID")]
        public int Id { get; set; }

        [DisplayName("Worker Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Worker Login")]
        [Required]
        public string Login { get; set; }

        [DisplayName("Worker Email")]
        [Required]
        public string Email { get; set; }

        [DisplayName("Worker Phone number")]
        [Required]
        public int Phone { get; set; }

        [DisplayName("Worker Bio")]
        public string Details { get; set; }

        // many- to - many relations
        //public virtual ICollection<ProjectWorkers> ProjectsLink { get; set; }

        //public Workers()
        //{
        //    this.Projects = new HashSet<Project>();
        //}

    }

    public class WorkerDTO : BaseEntity
    {
        [DisplayName("Worker Name")]
        [Required]
        public string Name { get; set; }

        [DisplayName("Worker Phone number")]
        [Required]
        public int Phone { get; set; }
    }

}
