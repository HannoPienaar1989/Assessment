using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assessment.Shared.Models
{
    public class IssueTypeDTO
    {
        public int IssueTypeId { get; set; }

        public string Type { get; set; }
    }
}
