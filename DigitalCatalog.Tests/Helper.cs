using DigitalCatalogue;
using System.Collections;
using System.Collections.Generic;

namespace DigitalCatalog.Tests
{
	public static class Helper
	{
		public static IEnumerable<Book> GetElements(this IEnumerable source)
		{
			foreach (Book b in source)
			{
				yield return b;
			}
		}
	}
}
