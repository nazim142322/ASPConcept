namespace WebApplication1.Models.OneToOne
{
    public class Employee
    {
        public int EmployeeId {get; set;}
        public String Name {get; set;}  
        public String Gender { get; set;}

        public EmployeeDetail Details { get; set;} //reference navigation property  

    }
}
