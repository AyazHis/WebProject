using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace WebProject.Blogging.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string? BlogTitle { get; set; }
        public byte[]? BlogPhoto { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
