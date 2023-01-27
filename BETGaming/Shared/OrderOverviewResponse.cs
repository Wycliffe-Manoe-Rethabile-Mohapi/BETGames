using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BETGaming.Shared
{
    public class OrderOverviewResponse
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Totalprice { get; set; }
        public string Product { get; set; }
        public string ProductImageUrl { get; set; }
    }
}
