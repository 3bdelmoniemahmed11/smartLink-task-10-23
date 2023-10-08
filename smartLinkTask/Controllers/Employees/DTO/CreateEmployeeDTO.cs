namespace smartLinkTask.Controllers.Employees.DTO
{
    public class CreateEmployeeDTO
    {

        public Guid ? Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Group {   get; set; }
    }
}   
