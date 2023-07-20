using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace APIVersionControl
{
	public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerGenOptions>
	{
		private readonly IApiVersionDescriptionProvider _provider;


		public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
		{
			_provider = provider;
		}


		private OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
		{
			var info = new OpenApiInfo
			{
				Title = "My .Net Api - Ejercicio Sessión 9",
				Version = description.ApiVersion.ToString(),
				Description = "This is API version control for Sesion's 9",
				Contact = new OpenApiContact
				{
					Name = "Tyliz",
					Email = "jidelabarrarosas@gmail.com",
				},

			};

			if (description.IsDeprecated)
				info.Description += "This version has been deprecated";

			return info;
		}

		public void Configure(string? name, SwaggerGenOptions options)
		{
			Configure(options);
		}

		public void Configure(SwaggerGenOptions options)
		{
			// add swagger documentation for each API version we have
			foreach (var description in _provider.ApiVersionDescriptions)
			{
				options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
			}
		}
	}
}
