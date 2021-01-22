using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assessment.DL.Entities
{
    public class Ticket
    {
        public int TicketId { get; set; }

        [Required]
        public int IssueTypeId { get; set; }

        [Required]
        public int IssueSeverityId { get; set; }

        [Required]
        public int ResolutionStatusId { get; set; }

        [StringLength(250)]
        public string Comments { get; set; }
        public IssueType IssueType { get; set; }
        public IssueSeverity IssueSeverity { get; set; }
        public ResolutionStatus ResolutionStatus { get; set; }
        public ResolutionSteps ResolutionSteps { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedByUserId { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedByUserId { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedByUserId { get; set; }

    }
}
