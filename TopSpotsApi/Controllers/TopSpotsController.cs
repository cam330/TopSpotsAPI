using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;
using TopSpotsApi.Models;
using System.IO;
using System.Net.Http;
using System.Net;

namespace TopSpotsApi.Controllers
{
    public class TopSpotsController : ApiController
    {

        // GET: api/TopSpots
        //public IEnumerable<TopSpotJson> Get()
        //{

        //TopSpotJson topSpot = JsonConvert.DeserializeObject<TopSpotJson>(File.ReadAllText(@"C:/dev/TopSpotsAPI/topspots.json"));

        //    yield return topSpot;
            
        //}

        public IEnumerable<TopSpot> Get()
        {
            var jsonArray = JsonConvert.DeserializeObject<IEnumerable<TopSpot>>(File.ReadAllText("C:/dev/TopSpotsAPI/topspots.json"));

            return jsonArray;
        }

        // GET: api/TopSpots/5
        //public TopSpot Get(int id)
        //{
        //var userdata = new topspot { name = "test", description = "this is a test" };
        //topspotjson topspot = jsonconvert.deserializeobject<topspotjson>(file.readalltext(@"c:/dev/topspotsapi/topspots.json"));

        //topspot[] arr = new topspot[] { userdata };
        //var ts = topspot;
        //var array = arr;
        //string json_data = jsonconvert.serializeobject(arr);

        //list<> parts = new list<ts.topspots[id]>();

        //parts.add(userdata);

        //    //Console.WriteLine(parts);


        //    return Ts.topspots[id];
        //}

        // post: api/topspots
        public HttpResponseMessage Post([FromBody] TopSpot topSpot)
        {

            var list = JsonConvert.DeserializeObject<List<TopSpot>>(File.ReadAllText("C:/dev/TopSpotsAPI/topspots.json"));
            list.Add(topSpot);
            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

            File.WriteAllText("C:/dev/TopSpotsAPI/topspots.json", convertedJson);

            Console.Write(list);

            return Request.CreateResponse(HttpStatusCode.OK, new
            {

                topSpot = topSpot

            });
        }

        // PUT: api/TopSpots/5
        public void Put(spotIndex index, [FromBody]TopSpot topSpot)
        {
            var list = JsonConvert.DeserializeObject<List<TopSpot>>(File.ReadAllText("C:/dev/TopSpotsAPI/topspots.json"));

            list[index.index].Name = topSpot.Name;
            list[index.index].Description = topSpot.Description;
            list[index.index].Location[0] = topSpot.Location[0];
            list[index.index].Location[1] = topSpot.Location[1];

            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

            Console.Write(convertedJson);
            File.WriteAllText("C:/dev/TopSpotsAPI/topspots.json", convertedJson);
        }

        // DELETE: api/TopSpots/5
        public HttpResponseMessage Delete([FromBody] spotIndex index)
        {
            var list = JsonConvert.DeserializeObject<List<TopSpot>>(File.ReadAllText("C:/dev/TopSpotsAPI/topspots.json"));
            list.RemoveAt(index.index);

            var convertedJson = JsonConvert.SerializeObject(list, Formatting.Indented);

            Console.Write(convertedJson);
            File.WriteAllText("C:/dev/TopSpotsAPI/topspots.json", convertedJson);

            return Request.CreateResponse(HttpStatusCode.OK, new
            {

                index = index

            });
        }
    }
}
