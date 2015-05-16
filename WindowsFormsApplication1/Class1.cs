using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

    public class RTTDataSet
    {
        [BsonId]
        public ObjectId Id { get; set; }

        public string name { get; set; }
        public string configuration { get; set; }

        public List<DateTime> datetimeList { get; set; }
        public List<int> rttvalueList { get; set; }



    }

