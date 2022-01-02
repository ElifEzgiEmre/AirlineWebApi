using AirlineWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AirlineWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AirlineController : ControllerBase
    {
        Result _result = new Result();
        List<Airplane> staticList = new List<Airplane>();

        [HttpGet]
        public List<Airplane> GetUser()
        {
            staticList = new List<Airplane>();
            staticList = AddAirplane();

            return staticList;
        }

        [HttpGet("{id}")]
        public Airplane GetUser(int id)
        {
            staticList = new List<Airplane>();
            staticList = AddAirplane();

            Airplane resultObject = new Airplane();
            resultObject = staticList.FirstOrDefault(x => x.airplane_id == id);
            return resultObject;
        }


        [HttpPost]
        public Result Post(Airplane airplane)
        {

            staticList = new List<Airplane>();
            staticList = AddAirplane();

            var airplaneCheck = staticList.FirstOrDefault(x => x.airplane_id == airplane.airplane_id);

            if (airplaneCheck == null)
            {
                staticList.Add(airplane);
                _result.Status = 1;
                _result.Message = "Yeni eleman listeye eklendi.";
                _result.AirplaneList = staticList;
            }

            else
            {
                _result.Status = 0;
                _result.Message = "Eleman zaten listede var.";

            }
            return _result;
        }


        [HttpPut]
        public Result Update(Airplane newValue)
        {
            staticList = AddAirplane();
            Airplane? oldValue = staticList.Find(o => o.airplane_id == newValue.airplane_id);

            if (oldValue != null)
            {
                _result.Status = 1;
                _result.Message = "Başarıyla güncellendi.";
                staticList.Add(newValue);
                staticList.Remove(oldValue);
                _result.AirplaneList = staticList;

            }

            else
            {
                _result.Status = 0;
                _result.Message = "Bu eleman listede yok.";

            }
            return _result;
        }
        [HttpDelete("{id}")]
        public Result Delete(int id)
        {
            staticList = AddAirplane();
            Airplane? oldValue = staticList.Find(o => o.airplane_id == id);

            if (oldValue != null)
            {
                _result.Status = 1;
                _result.Message = "Kulllanıcı başarıyla silindi.";

                staticList.Remove(oldValue);
                _result.AirplaneList = staticList;

            }

            else
            {
                _result.Status = 0;
                _result.Message = "Kullanıcı bu listede yok.";

            }

            return _result;
        }




        public List<Airplane> AddAirplane()
        {

            staticList.Add(new Models.Airplane { airplane_id = 1, total_number_of_seats = 220, airplane_models = "Airbus", airplane_type = "A350-900", leg_number = 1, flight_number = 1 });
            staticList.Add(new Models.Airplane { airplane_id = 2, total_number_of_seats = 110, airplane_models = "Airbus", airplane_type = "A330-300", leg_number = 2, flight_number = 2 });
            staticList.Add(new Models.Airplane { airplane_id = 3, total_number_of_seats = 130, airplane_models = "Airbus", airplane_type = "A350-200", leg_number = 1, flight_number = 3 });

            staticList.Add(new Models.Airplane { airplane_id = 4, total_number_of_seats = 130, airplane_models = "Boeing", airplane_type = "787-9", leg_number = 1, flight_number = 4 });
            staticList.Add(new Models.Airplane { airplane_id = 5, total_number_of_seats = 110, airplane_models = "Boeing", airplane_type = "737-800", leg_number = 2, flight_number = 6 });
            staticList.Add(new Models.Airplane { airplane_id = 6, total_number_of_seats = 240, airplane_models = "Boeing", airplane_type = "737-900ER", leg_number = 1, flight_number = 8 });
            return staticList;
        }
    }
}
