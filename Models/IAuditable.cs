using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public interface IAuditable
    {
        int CreatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        int UpdateBy { get; set; }
        DateTime UpdateDate { get; set; }
        int DeletedBy { get; set; }
        DateTime DeletedDate { get; set; }
        bool Deleted { get; set; }
    }
}
