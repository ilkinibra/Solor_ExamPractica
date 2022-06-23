using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solor_BackEnd.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
       
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
