using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace ApiTesting.Data.Data.Models
{
    public class Game
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string DeveloperId { get; set; }

        public virtual Developer Developer { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Genre { get; set; }

        public ICollection<Key> Keys { get; set; }

        public int? KeyCount => this.Keys.Count();
    }
}
