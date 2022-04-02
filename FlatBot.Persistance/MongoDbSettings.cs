using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatBot.Persistance
{
    public class MongoDbSettings
    {
        public string DBName { get; set; }
        public string ConnectionString { get; set; } 
        public string Collection { get; set; }
    }
}
