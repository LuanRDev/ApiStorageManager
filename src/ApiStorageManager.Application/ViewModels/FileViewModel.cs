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
        public string CodigoEvento { get; set; }
        public string UrlAdress { get; set; }
        public string Meta { get; set; }
        public string Type { get; set; }
        public string Extension { get; set; }
        public byte[] Bytes { get; set; }
    }
}
