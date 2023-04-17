using System.ComponentModel.DataAnnotations;

namespace Friends
{
    public class Friends
    {
        [Key]
        public int Id  { get; set; }
        [Required]
        public string Name { get; set; }=string.Empty;
        public int age { get; set; }
        public string Role { get; set; } = string.Empty;
        public int Salary { get; set; }
     }
    
}
