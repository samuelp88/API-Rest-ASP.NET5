using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalcAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        [HttpGet("square-root/{firstNumber}")]
        public IActionResult SquareRoot(string firstNumber)
        {
            if (IsNumeric(firstNumber))
            {
                var operation = Math.Sqrt((double) ConvertToDecimal(firstNumber));
                return Ok(operation.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("mean/{firstNumber}/{secondNumber}")]
        public IActionResult Mean(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var operation = (ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber)) / 2;
                return Ok(operation.ToString());
            }
            return BadRequest("Invalid Input");
        }


        [HttpGet("divide/{firstNumber}/{secondNumber}")]
        public IActionResult Divide(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var operation = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);
                return Ok(operation.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
        public IActionResult Multiplication(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var operation = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);
                return Ok(operation.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("subtract/{firstNumber}/{secondNumber}")]
        public IActionResult Subtract(string firstNumber, string secondNumber)
        {
            if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var operation = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(operation.ToString());
            }
            return BadRequest("Invalid Input");
        }

        [HttpGet("sum/{firstNumber}/{secondNumber}")]
        public IActionResult Sum(string firstNumber, string secondNumber)
        {
            if(IsNumeric(firstNumber) && IsNumeric(secondNumber))
            {
                var sum = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);
                return Ok(sum.ToString());
            }
            return BadRequest("Invalid Input");
        }

        private bool IsNumeric(string strNumber)
        {
            return double.TryParse(
                strNumber,
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, 
                out double number);
        }

        private decimal ConvertToDecimal(string strNumber)
        {
            if(decimal.TryParse(strNumber, out decimal result))
            {
                return result;
            }
            return 0;
        }
    }
}
