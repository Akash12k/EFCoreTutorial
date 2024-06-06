using System.ComponentModel.DataAnnotations.Schema;

namespace EFCoreTutorial.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string PhoneNumber {  get; set; }    


        public StudentAddress studentAddress { get; set; }

        
        [NotMapped]
        public string NotMappedColumn { set; get; }
    }
}
