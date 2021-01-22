using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Shared.Models
{
    public class ResolutionStepsDTO
    {
       // public int ResolutionStepId { get; set; }
        public int ResolutionStatusId { get; set; }
        public int TicketId { get; set; }
        public string Description { get; set; }
    }
}
