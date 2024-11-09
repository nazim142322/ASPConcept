using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.OneToOne
{
    public class EmployeeDetail
    {
        [Key]
        public int EmployeeDetailId { get; set; }
        public string qualification { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string country { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; } 
        public Employee Employee { get; set; }//reference navigation property

    }
}
