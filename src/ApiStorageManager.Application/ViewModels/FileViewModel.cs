using System.ComponentModel.DataAnnotations;

namespace ApiStorageManager.Application.ViewModels
{
    public class FileViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Empresa { get; set; }
        public int CodigoEvento { get; set; }
        public string Metadata { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public byte[] Bytes { get; set; }
    }
}
