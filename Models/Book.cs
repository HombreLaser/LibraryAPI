using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryAPI.Models {
    public class Book {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public DateTime PublicationDate { get; set; }

        public string[] Genres { get; set; }
        public int Edition { get; set; }
        public string ISBN { get; set; }
    }
}