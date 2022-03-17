using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBot.Domain.Entities
{
    public class RawOlxOffer
    {
        public string Price { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}
