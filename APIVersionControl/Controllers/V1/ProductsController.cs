using APIVersionControl.Models.DataModels.V1;
using APIVersionControl.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace APIVersionControl.Controllers.V1
{
	[ApiVersion("1.0")]
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

		[MapToApiVersion("1.0")]
		[HttpGet(Name = "GetProducts")]
		public async Task<IActionResult> GetProducts()
		{
			//_httpClient.DefaultRequestHeaders.Clear();
			//_httpClient.DefaultRequestHeaders.Add("app-id", AppId);

			var response = await _httpClient.GetStreamAsync(ApiTestURL);

			var products = await JsonSerializer.DeserializeAsync<ICollection<Product>>(response);

			return Ok(products);
		}
	}
}
