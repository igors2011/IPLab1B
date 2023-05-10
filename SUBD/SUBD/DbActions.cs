using Microsoft.EntityFrameworkCore;
using SUBD.Models;

namespace SUBD
{
	public class DbActions
	{
		public void AddProduct()
		{
			Console.WriteLine("Название продукта");
			string Name = Console.ReadLine() ?? string.Empty;
			using var context = new Context();
			context.Add(new Product()
			{
				Name = Name
			});
			context.SaveChanges();
			Console.WriteLine("Продукт успешно добавлен");
		}
		public void AddStore()
		{
			Console.WriteLine("Название магазина");
			string Name = Console.ReadLine() ?? string.Empty;
			Console.WriteLine("Адрес магазина");
			string Address = Console.ReadLine() ?? string.Empty;
			using var context = new Context();
			context.Add(new Store()
			{
				Name = Name,
				Address = Address
			});
			context.SaveChanges();
			Console.WriteLine("Магазин успешно добавлен");
		}
		public void GetProducts()
		{
			using var context = new Context();
			var result = context.Products.ToList();
			foreach (var product in result)
			{
				Console.WriteLine($"{product.Id}. {product.Name}");
			}
		}
		public void GetStores()
		{
			using var context = new Context();
			var result = context.Stores.ToList();
			foreach (var store in result)
			{
				Console.WriteLine($"{store.Id}. Название: {store.Name} Адрес: {store.Address}");
			}
		}
		public void AddProductInStore()
		{
			using var context = new Context();
			Console.WriteLine("Номер магазина");
			int StoreId = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Номер продукта");
			int ProductId = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine("Количество");
			int Count = Convert.ToInt32(Console.ReadLine());
			context.ProductsInStore.Add(new ProductInStore() { Product = context.Products.FirstOrDefault(x => x.Id == ProductId) ?? new(), Store = context.Stores.FirstOrDefault(x => x.Id == StoreId) ?? new(), Count = Count });
			context.SaveChanges();
			Console.WriteLine("Продукт добавлен в магазин");
		}
		public void GetProductsInStores()
		{
			using var context = new Context();
			var result = context.ProductsInStore
				.Include(x => x.Product)
				.Include(x => x.Store)
				.ToList();
			foreach (var PIS in result)
			{
				Console.WriteLine($"Продукт: {PIS.Product.Name} Магазин: {PIS.Store.Name} Количество: {PIS.Count}");
			}
		}
		public void GetProductsInStore()
		{
			using var context = new Context();
			Console.WriteLine("Номер магазина?");
			var StoreId = Convert.ToInt32(Console.ReadLine());
			var result = context.ProductsInStore
				.Include(x => x.Product)
				.Where(x => x.StoreId == StoreId)
				.ToList();
			foreach (var PIS in result)
			{
				Console.WriteLine($"Продукт: {PIS.Product.Name} Количество: {PIS.Count}");
			}
		}
		public void UpdateProduct()
		{
			using var context = new Context();
			Console.WriteLine("Номер продукта?");
			var ProductId = Convert.ToInt32(Console.ReadLine());
			var Product = context.Products.FirstOrDefault(x => x.Id == ProductId);
			if (Product == null)
			{
				Console.WriteLine("Продукт не найден");
				return;
			}
			Console.WriteLine("Новое название?");
			var Name = Console.ReadLine() ?? string.Empty;
			Product.Name = Name;
			context.Products.Update(Product);
			context.SaveChanges();
			Console.WriteLine("Продукт обновлен");
		}
		public void UpdateStore()
		{
			using var context = new Context();
			Console.WriteLine("Номер магазина?");
			var StoreId = Convert.ToInt32(Console.ReadLine());
			var Store = context.Stores.FirstOrDefault(x => x.Id == StoreId);
			if (Store == null)
			{
				Console.WriteLine("Магазин не найден");
				return;
			}
			Console.WriteLine("Новое название?");
			var Name = Console.ReadLine() ?? string.Empty;
			Store.Name = Name;
			context.Stores.Update(Store);
			context.SaveChanges();
			Console.WriteLine("Магазин обновлен");
		}
		public void DeleteProduct()
		{
			using var context = new Context();
			Console.WriteLine("Номер продукта?");
			var ProductId = Convert.ToInt32(Console.ReadLine());
			var Product = context.Products.FirstOrDefault(x => x.Id == ProductId);
			if (Product == null)
			{
				Console.WriteLine("Продукт не найден");
				return;
			}
			context.ProductsInStore.RemoveRange(context.ProductsInStore.Where(x => x.ProductId == ProductId));
			context.Remove(Product);
			context.SaveChanges();
			Console.WriteLine("Продукт удален");
		}
		public void DeleteStore()
		{
			using var context = new Context();
			Console.WriteLine("Номер магазина?");
			var StoreId = Convert.ToInt32(Console.ReadLine());
			var Store = context.Stores.FirstOrDefault(x => x.Id == StoreId);
			if (Store == null)
			{
				Console.WriteLine("Магазин не найден");
				return;
			}
			context.ProductsInStore.RemoveRange(context.ProductsInStore.Where(x => x.StoreId == StoreId));
			context.Stores.Remove(Store);
			context.SaveChanges();
			Console.WriteLine("Магазин удален");
		}
	}
}
