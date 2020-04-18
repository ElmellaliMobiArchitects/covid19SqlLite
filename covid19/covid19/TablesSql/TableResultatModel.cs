using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace covid19.TablesSql
{
    public class TableResultatModel

    {
        [JsonProperty("id")]
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }

        public string Data { get; set; }
    }
}
