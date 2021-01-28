namespace Suftnet.Co.Bima.Api.Extensions
{   
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    using Microsoft.Extensions.Logging;
    using Suftnet.Co.Bima.Core;

    public static class Extensions
    {  
        public static IEnumerable<string> ToErrorList(this ModelStateDictionary modelState)
        {
            var builder = new StringBuilder();
            var errors = new List<string>();

             if (!modelState.IsValid)
            {
                IEnumerable<ModelError> modelerrors = modelState.SelectMany(x => x.Value.Errors);
                foreach (var modelerror in modelerrors)
                {
                    errors.Add(modelerror.ErrorMessage);
                    builder.AppendLine("Description " + modelerror.ErrorMessage);
                }
            }

            EngineContext.Current.Resolve<ILogger>().LogError(builder.ToString());

            return errors;
        }

        public static string Errors(this ModelStateDictionary modelState)
        {
            var errors = new StringBuilder();

            if (!modelState.IsValid)
            {
                IEnumerable<ModelError> modelerrors = modelState.SelectMany(x => x.Value.Errors);
                foreach (var modelerror in modelerrors)
                {
                    if(modelerror.Exception != null)
                    {
                        errors.AppendLine(modelerror.Exception.Message);
                    }
                    else
                    {
                        errors.AppendLine(modelerror.ErrorMessage);
                    }                   
                }
            }

            EngineContext.Current.Resolve<ILogger<ModelStateDictionary>>().LogError(errors.ToString());

            return errors.ToString();
        }

        public static Dictionary<string, string> GetModelErrorsWithKeys(this ModelStateDictionary errDictionary)
        {
            var builder = new StringBuilder();
            var errors = new Dictionary<string, string>();
            errDictionary.Where(k => k.Value.Errors.Count > 0).ToList().ForEach(i =>
            {
                var er = string.Join(", ", i.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                errors.Add(i.Key, er);
            });

            EngineContext.Current.Resolve<ILogger<ModelStateDictionary>>().LogError(builder.ToString());

            return errors;
        }

    }

}