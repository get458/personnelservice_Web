using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personnel_Service.Models
{
    public class RoomConnection
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public int RoomId { get; set; }
    }
}
