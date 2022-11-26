using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        // [Bind(nameof(Person.PersonName), nameof(Person.Email), nameof(Person.Password), nameof(Person.ConfirmPassword))]
        // Example JSON: { "PersonName": "William", "Email": "william@gmail.com", "Phone": "123456", "Password": "william123, "ConfirmPassword": "william123" }
        // [FromBody][ModelBinder(BinderType = typeof(PersonModelBinder))]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                string errors = string.Join("\n", ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(err => err.ErrorMessage));

                return BadRequest(errors);
            }

            return Content($"{person}");
        }
    }
}
