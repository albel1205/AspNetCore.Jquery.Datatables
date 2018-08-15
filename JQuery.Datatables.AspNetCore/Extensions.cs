using JQuery.Datatables.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JQuery.Datatables.AspNetCore
{
    public static class ConfigureServicesExtensions
    {
        public static IServiceCollection AddMvcJQueryDataTables(this IServiceCollection services)
        {

            var dataTablesViewModelType = typeof(DataTableConfigVm).GetTypeInfo();
            var settings = new Settings
            {
                FileProvider = new EmbeddedFileProvider(dataTablesViewModelType.Assembly,
                                                        dataTablesViewModelType.Namespace + ".Common"),
            };
            services.AddSingleton(settings);
            services.Configure<RazorViewEngineOptions>(s => s.FileProviders.Add(settings.FileProvider));
            services.AddMvcCore(options => { options.UseHtmlEncodeModelBinding(); });

            return services;
        }

        public static void UseHtmlEncodeModelBinding(this MvcOptions opts)
        {
            var binderToFind = opts.ModelBinderProviders.FirstOrDefault(x => x.GetType() == typeof(DataTablesModelBinderProvider));

            if (binderToFind != null) return;

            opts.ModelBinderProviders.Insert(0, new DataTablesModelBinderProvider());
        }
    }
}

namespace JQuery.Datatables.AspNetCore.Builder
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class MvcJQueryDataTablesExtensions
    {
        public static IApplicationBuilder UseMvcJQueryDataTables(this IApplicationBuilder app)
        {
            var settings = app.ApplicationServices.GetService<global::JQuery.Datatables.AspNetCore.Settings>();
            if (settings == null)
            {
                throw new InvalidOperationException("Unable to find the required services. Please add all the required services by calling 'IServiceCollection.{}' inside the call to 'ConfigureServices(...)' in the application startup code.");
            }
            app.UseStaticFiles();

            {
                var options = new StaticFileOptions
                {
                    RequestPath = "",
                    FileProvider = settings.FileProvider
                };

                app.UseStaticFiles(options);
            }
            return app;
        }
    }
}
