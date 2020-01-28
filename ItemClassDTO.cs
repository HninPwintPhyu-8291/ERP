using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCErp.DTO
{
   public class ItemClassDTO
    {
        public int Id { get; set; }
        public string Code{ get; set; }
        public string Name { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public int ModifiedBy { get; set; }
        public bool Active { get; set; }
    }
}
