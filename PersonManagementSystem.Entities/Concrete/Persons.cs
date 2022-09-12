namespace PersonManagementSystem.Entities
{
    using PersonManagementSystem.Entities.Abstract;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Persons:IEntity
    {
        [Key]
        public int PersonId { get; set; }

        
        [StringLength(50)]
        public string FirstName { get; set; }

        
        [StringLength(50)]
        public string LastName { get; set; }

        
        [StringLength(80)]
        public string Email { get; set; }

        
        [StringLength(20)]
        public string Username { get; set; }

        
        [StringLength(15)]
        public string Password { get; set; }

        public int RoleId { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual Role Role { get; set; }
    }
}
