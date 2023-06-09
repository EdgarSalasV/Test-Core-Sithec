using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Text.RegularExpressions;
using Test_Core_Sithec.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Test_Core_Sithec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MathOperationController : ControllerBase
    {
        [HttpGet("GetOperationBetween2Numbers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public dynamic GetOperationBetween2Numbers(int num1, string optr, int num2)
        {

            if (IsOperatorValid(optr))
            {
                return Conflict("Operador debe ser +, -, * ó /");
            }
            DataTable dummy = new DataTable();
            return dummy.Compute($"{num1} {optr} {num2}", string.Empty);

        }
        
        [HttpPost("PostOperationBetween2Numbers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public dynamic PostOperationBetween2Numbers(int num1, string optr, int num2)
        {
            if (IsOperatorValid(optr))
            {
                return Conflict("Operador debe ser +, -, * ó /");
            }
            DataTable dummy = new DataTable();
            return dummy.Compute($"{num1} {optr} {num2}", string.Empty);

        }

        public static bool isNumber(string num)
        {
            Regex rx = new Regex(@"^([1-9]\d*(\.)\d*|0?(\.)\d*[1-9]\d*|[1-9]\d*)$");
            return rx.IsMatch(num);
        } 
        public static bool IsOperatorValid(string optr)
        {
            string[] operatorList = { "+", "-", "*", "/" };
            return !Array.Exists(operatorList, item => item == optr);
        }
    }
}
