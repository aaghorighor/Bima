namespace Suftnet.Co.Bima.Api.Models
{
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.Extensions.Logging;
    using Suftnet.Co.Bima.Core;
    using System.Text;

    public class ModelStateError
    {
        public static string AddErrorsToModelState(IdentityResult identityResult, ModelStateDictionary modelState)
        {
            var builder = new StringBuilder();
            
            foreach (var e in identityResult.Errors)
            {
                modelState.TryAddModelError(e.Code, e.Description);
              
                builder.AppendLine("Description " + e.Description);
            }

            EngineContext.Current.Resolve<ILogger<ModelStateDictionary>>().LogError(builder.ToString());

            return builder.ToString();
        }

        public static string AddErrorToModelState(string code, string description, ModelStateDictionary modelState)
        {
            var builder = new StringBuilder();

            modelState.TryAddModelError(code, description);
          
            builder.AppendLine("Description " + description);

            EngineContext.Current.Resolve<ILogger<ModelStateDictionary>>().LogError(builder.ToString());

            return builder.ToString();
        }       
    }
}
