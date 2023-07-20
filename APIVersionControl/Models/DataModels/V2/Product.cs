namespace APIVersionControl.Models.DataModels.V2
{
	public class Product
	{
		public Guid InternalId { get; set; }
		public int id { get; set; }
		public string title { get; set; }
		public float price { get; set; }
		public string description { get; set; }
		public string category { get; set; }
		public string image { get; set; }


		public static Product Create(V1.Product model)
		{
			return new Product
			{
				InternalId = Guid.NewGuid(),
				id = model.id,
				title = model.title,
				price = model.price,
				description = model.description,
				category = model.category,
				image = model.image,
			};
		}
	}
}
