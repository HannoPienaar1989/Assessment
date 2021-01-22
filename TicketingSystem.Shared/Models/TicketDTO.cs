using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace Assessment.Shared.Models
{
    public class TicketDTO
    {
        public int TicketId { get; set; }
        [Required]
        public int IssueTypeId { get; set; }
        [Display(Name = "Issue Type")]
        public IssueTypeDTO IssueType { get; set; }
        [Required]
        public int IssueSeverityId { get; set; }
        [Display(Name = "Issue Severity")]
        public IssueSeverityDTO IssueSeverity { get; set; }
        [Required]
        public int ResolutionStatusId { get; set; }
        [Display(Name = "Resolution Status")]
        public ResolutionStatusDTO ResolutionStatus { get; set; }
        [Display(Name = "Resolution Steps")]
        public ResolutionStepsDTO ResolutionSteps { get; set; }

        [StringLength(250)]
        public string Comments { get; set; }

        public DateTime CreatedAt { get; set; }
        public string CreatedByUserId { get; set; }

        public DateTime UpdatedAt { get; set; }
        public string UpdatedByUserId { get; set; }
        public DateTime DeletedAt { get; set; }
        public string DeletedByUserId { get; set; }
    }
}
