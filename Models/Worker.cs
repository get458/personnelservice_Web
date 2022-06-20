using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Personnel_Service.Models
{
    public class Worker
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Nationality { get; set; }
    }
}
