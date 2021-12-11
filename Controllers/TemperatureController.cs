using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TemperatureLibrary;

namespace TempDWA.Controllers
{
    public class TemperatureController : ControllerBase
    {
        [HttpPost]
        [Route("api/temp")]
        public IActionResult GetTemp([FromQuery] FunctionRequest temp)
        {
            Temperature t1 = new Temperature(temp.Temper, temp.Scale, temp.To);
            if (t1.Scale == 'C' || t1.Scale == 'K' || t1.Scale == 'F' || t1.To == 'C' || t1.To == 'K' || t1.To == 'F')
            {

                return Ok(Temperature.GetConversion(t1));
            }
            else
            {
                return BadRequest("Error de formato. Debe introducir las escalas [F], [C] o [K]");
            }

        }


    }
}