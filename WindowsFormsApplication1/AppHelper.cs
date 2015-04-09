using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
        public class CurrentJob
        {
            [BsonId]
            public ObjectId Id { get; set; }
            public string resultPath { get; set; }
            public string resultFilename { get; set; }
            public string paramss { get; set;  }

            [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
            public List<DateTime> y_time { get; set; }
            public List<int> x_rtt { get; set; }

            public CurrentJob() { }

            public CurrentJob(string setpath)
            {
                resultPath = setpath;

                string[] tmpResultFileName = resultPath.Split('\\');

                resultFilename = tmpResultFileName[1];
            }

        }

        public static class MongoDriverHelper
        {
            static public MongoClient client { get; set; }
            static public IMongoDatabase dbs { get; set; }
            static public IMongoCollection<CurrentJob> list { get; set; }

            static public void setupInstance()
            {
                client = new MongoClient();
                dbs = client.GetDatabase("rtt");
                list = dbs.GetCollection<CurrentJob>("sets");
     
            }
        }

        public static class RegexObjects
        {
            private static string re1_dateTime = ".*?";	// Non-greedy match on filler
            private static string re2_dateTime = "((?:[0]?[1-9]|[1][012])[-:\\/.](?:(?:[0-2]?\\d{1})|(?:[3][01]{1}))[-:\\/.](?:(?:[1]{1}\\d{1}\\d{1}\\d{1})|(?:[2]{1}\\d{3})))(?![\\d])";	// MMDDYYYY 1
            private static string re3_dateTime = ".*?";	// Non-greedy match on filler
            private static string re4_dateTime = "((?:(?:[0-1][0-9])|(?:[2][0-3])|(?:[0-9])):(?:[0-5][0-9])(?::[0-5][0-9])?(?:\\s?(?:am|AM|pm|PM))?)";	// HourMinuteSec 1

            private static string re1_rtt = ".*?";	// Non-greedy match on filler
            private static string re2_rtt = "(Average)";	// Word 1
            private static string re3_rtt = "(\\s+)";	// White Space 1
            private static string re4_rtt = "(=)";	// Any Single Character 1
            private static string re5_rtt = "(\\s+)";	// White Space 2
            private static string re6_rtt = "(\\d+)";	// Integer Number 1

            private static string regexStringDateTime = re1_dateTime + re2_dateTime + re3_dateTime + re4_dateTime;
            private static string regexStringRTT = re1_rtt + re2_rtt + re3_rtt + re4_rtt + re5_rtt + re6_rtt;

            public static Regex dateTimeObject = new Regex(regexStringDateTime, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            public static Regex rttDelayObject = new Regex(regexStringRTT, RegexOptions.IgnoreCase | RegexOptions.Singleline);

        }


        public static class TransformData
        {
            private static List<DateTime> y_time = new List<DateTime>();
            private static List<int> x_rtt = new List<int>();

            public static bool processData(string path, CurrentJob job)
            {
                try
                {
                    Match dateTime, rtt;
                    string line;
                    
                    using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
              //              sb.Append(Path.GetDirectoryName(path) + @"\").Append(Path.GetFileNameWithoutExtension(path)).Append(".bin");

                            using (StreamReader rdr = new StreamReader(fileStream))
                            {

                                line = rdr.ReadLine();

                                string[] parameters = line.Split(' ');

                                StringBuilder sb = new StringBuilder();

                         //       sb.Append(parameters[2]).Append(parameters[4]).Append(parameters[6]).
                           //             Append(parameters[8]).Append(parameters[10]).Append(parameters[12]);

                                job.paramss = line;// sb.ToString();


                                while ((line = rdr.ReadLine()) != null)
                                {
                                    if (string.IsNullOrWhiteSpace(line) || line.Contains("Pi") ||
                                            line.Contains("Re") || (line.Contains("Pa")) || line.Contains("Ap"))
                                        continue;

                                    dateTime = RegexObjects.dateTimeObject.Match(line);
                                    rtt = RegexObjects.rttDelayObject.Match(line);

                                    sb.Clear();
                                    sb.Append(dateTime.Groups[1]).Append(" ").Append(dateTime.Groups[2]).Append(" ");

                                    if (dateTime.Success)
                                    {
                                        y_time.Add(DateTime.Parse(sb.ToString()));
                                    }
                                    else if (rtt.Success)
                                    {
                                        x_rtt.Add(int.Parse(rtt.Groups[5].ToString()));
                                    }

                                }
                            }
                        }

                    job.x_rtt = x_rtt;
                    job.y_time = y_time;

                    return true;
                }
                catch (Exception)
                { return false; }
            }
        }
    }


