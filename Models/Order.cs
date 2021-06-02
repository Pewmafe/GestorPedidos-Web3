using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class Order : IAuditable
    {
        public int Id { get; set; }

        public int IdClient { get; set; }
        public int IdState { get; set; }
        public int OrderNumber { get; set; }

        public string Coments { get; set; }
    }
}
