using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Shared.Models
{
    public class IssueSeverityDTO
    {
        public int IssueSeverityId { get; set; }
        public string Severity { get; set; }
     
    }
}
