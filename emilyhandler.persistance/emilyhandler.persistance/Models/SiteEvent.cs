using System;
using System.Collections.Generic;
using System.Text;
using Vibrant.InfluxDB.Client;

namespace emilyhandler.persistance.Models
{
    public class SiteEvent
    {
        [InfluxTimestamp]
        public DateTime TimeStamp { get; set; }

        [InfluxTag("event")]
        public string Event { get; set; }

        [InfluxTag("name")]
        public string Name { get; set; }

        [InfluxField("value")]
        public string Value { get; set; }

    }
}
