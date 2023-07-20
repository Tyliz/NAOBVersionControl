using APIVersionControl.Models.DataModels.V2;
using APIVersionControl.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIVersionControl.Controllers.V2
{
	[ApiVersion("2.0")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private const string ApiTestURL = "https://fakestoreapi.com/products";
		private readonly HttpClient _httpClient;


		public ProductsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		[MapToApiVersion("2.0")]
		[HttpGet(Name = "GetProducts")]
		public async Task<IActionResult> GetProducts()
		{
			//_httpClient.DefaultRequestHeaders.Clear();
			//_httpClient.DefaultRequestHeaders.Add("app-id", AppId);

			var response = await _httpClient.GetStreamAsync(ApiTestURL);

			var productsV1 = await JsonSerializer.DeserializeAsync<ICollection<Models.DataModels.V1.Product>>(response);

			var productsV2 = productsV1?.Select(product => Product.Create(product));

			return Ok(productsV2);
		}
	}
}
