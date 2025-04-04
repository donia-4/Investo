using System.ComponentModel.DataAnnotations.Schema;

namespace Investo.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id { get; set; }
        public string Name { get; set; }
        public int ProjectId { get; set; }//fk
        public List<Project> Projects { get; set; }
    }
}
