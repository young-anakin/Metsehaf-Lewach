using System.ComponentModel.DataAnnotations;

namespace LewachBookTrading.Model
{
    public class Trash
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
