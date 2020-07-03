using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Shift.Web.Config
{
    public static class CultureConfig
    {
        public static void ConfigureCulture(this IApplicationBuilder app)
        {
            var dataFormat = new DateTimeFormatInfo
            {
                ShortDatePattern = "dd/MM/yyyy",
                LongDatePattern = "dd/MM/yyyy HH:mm",
                ShortTimePattern = "HH:mm",
                LongTimePattern = "HH:mm"
            };

            var supportedCultures = new List<CultureInfo>
            {
                new CultureInfo("pt-BR") { DateTimeFormat = dataFormat }
            };

            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("pt-BR"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            }); 
        }
    }
}
