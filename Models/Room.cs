using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Personnel_Service.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int Slots { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public List<Worker> Workers { get; set; }

        public string GetWorkersCountString
        {
            get
            {
                if (Workers == null)
                {
                    return string.Format("{0}/{1}", 0, Slots);
                }

                return string.Format("{0}/{1}", Workers.Count, Slots);
            }
        }
    }
}
