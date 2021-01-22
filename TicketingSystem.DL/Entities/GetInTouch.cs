using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Assessment.DL.Entities
{
    public class GetInTouch
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Number { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
