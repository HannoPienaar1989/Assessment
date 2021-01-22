using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Shared.Models
{
    public class ResolutionStatusDTO
    {
        public int ResolutionStatusId { get; set; }
        public string Status { get; set; }
    }
}
