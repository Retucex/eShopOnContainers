// Unused usings
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers
{
    // No authorization at the API level
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FizzBuzzController : ControllerBase
    {
        // Non-descript parameter
        // Missing ProducesResponseType attribute for SwashBuckler doc gen
        [HttpGet("{num}")]
        // async not necessary
        // opt: If async is kept, method name should have Async suffix
        // return type should be IActionResult for added clarity + response code
        public async Task<string> FizzBuzz(int num)
        {
            // Business logic should be isolated from controller. Either through static class, or using Mediatr with Command/CommandHandler (would justify using async)
            // No checks for num < 1
            // No defined messages for inputs other than int (ie. error message for string input)

            // result should be a StringBuilder for better performance
            // opt: result should be string.Empty for better clarity.
            var result = "";
            // int -> var (consistency)
            // should be i = 1; i <= num (or else, starts at 0 and doesn't finish)
            for (int i = 0; i < num; i++)
            {
                /*********
                 * Logic can be simplified. A flag can be introduced to track if value was divisible by 3 or 5
                 * ie. if (i % 3 == 0)
                 *     {
                 *          isFizzOrBuzz = true
                 *          //...
                 *     }
                 *     //...
                 *     if (!isFizzOrBuzz)
                 *     {
                 *          result.Append(i.ToString());
                 *     }
                 *     
                 * Or can be achieved with nested ifs
                 * ie. if (i % 3 == 0 || i % 5 == 0)
                 *     {
                 *          if (i % 3 == 0) { //... }
                 *          if (i % 5 == 0) { //... }
                 *     }
                 *     else
                 *     {
                 *          //...
                 *     }
                 *********/

                // opt: if not using StringBuilder, can use result += "..." for better clarity
                if (i % 15 == 0)
                {
                    // strings should be defined as constants
                    // no localization
                    result = result + "FizzBuzz";
                }
                else if (i % 3 == 0)
                {
                    result = result + "Fizz";
                }
                else if(i % 5 == 0)
                {
                    result = result + "Buzz";
                }
                else
                {
                    result = result + i.ToString();
                }

                // newline is not OS agnostic (easily solved with StringBuilder)
                result = result + "\n";
            }

            return result;
        }
    }
}

// Other remarks:
// No tests