using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportGenerationRPA.Models
{
    public class FincertRecords
    {
        public int ID { get; set; }

        public string? Country { get; set; }

        public string? LastName { get; set; }

        public string? GivenName { get; set; }

        public string? Schedule { get; set; }

        public double? Item { get; set; }

        public string? DateOfBirth { get; set; }

        public string? Aliases { get; set; }

        public string? Entity { get; set; }

        public string? Title { get; set; }
    }
}
