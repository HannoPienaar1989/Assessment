using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assessment.DL.Entities
{
    public class ResolutionStatus
    {
        public int ResolutionStatusId { get; set; }
        [Required]
        [StringLength(300)]
        public string Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedByUserId { get; set; }
    }
}
