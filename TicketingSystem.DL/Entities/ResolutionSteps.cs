using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assessment.DL.Entities
{
    public class ResolutionSteps
    {
        [Key]
        public int ResolutionStepId { get; set; }
        public int ResolutionStatusId { get; set; }
        public int TicketId { get; set; }
        public string Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedByUserId { get; set; }
    }
}
