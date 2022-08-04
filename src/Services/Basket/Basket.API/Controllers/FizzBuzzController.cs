using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        [HttpGet("{num}")]
        public async Task<string> FizzBuzz(int num)
        {
            var result = "";
            for (int i = 1; i <= num; i++)
            {
                if (i % 3 == 0)
                {
                    result = result + "Fizz";
                }
                else if(i % 5 == 0)
                {
                    result = result + "Buzz";
                }
                else if (i % 15 == 0)
                {
                    result = result + "FizzBuzz";
                }
                else
                {
                    result = result + i.ToString();
                }

                result = result + "\n";
            }

            return result;
        }
    }
}
