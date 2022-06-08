using Microsoft.AspNetCore.Identity;
using MessageBoard.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MessageBoard.Models
{
    public class ApplicationUser : IdentityUser
    {
        private static string _userId { get; set; }

        public static void Register(RegisterViewModel model)
        {
            var apiCallTask = ApiHelper.PostRegister(model);
            var result = apiCallTask.Result;

            JValue jsonResponse = JsonConvert.DeserializeObject<JValue>(result);
            
            _userId = jsonResponse.ToString();

        }
    }
}