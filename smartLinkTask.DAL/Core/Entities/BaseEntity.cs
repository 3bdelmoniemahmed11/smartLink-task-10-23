using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace smartLinkTask.DAL.Core.Entities
{
    public class BaseEntity
    {
        [Column(Order = 0)]
        public Guid Id { get; set; }
        [Column(Order = 1)]
        public Guid CreatedByUserId { get; set; }
        [Column(Order = 2)]
        public DateTime CreationDate { get; set; }
        [Column(Order = 3)]
        public Guid? LastModifiedByUserId { get; set; }
        [Column(Order = 4)]
        public DateTime? LastModificationDate { get; set; }

        [Column(Order = 5)]
        [Required]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
