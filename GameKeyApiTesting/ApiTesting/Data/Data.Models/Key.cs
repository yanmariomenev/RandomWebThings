using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTesting.Data.Data.Models
{
    public class Key
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        public string KeyCode { get; set; } = Guid.NewGuid().ToString();

        public DateTime CreatedOn { get; set; }

        public DateTime? UsedOn { get; set; }

        public bool IsUsed { get; set; }

        public string GameId { get; set; }
        public virtual Game Game { get; set; }
    }
}
