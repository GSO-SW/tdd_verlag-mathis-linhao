using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Verlag;

namespace VerlagTests
{
    [TestClass]
    internal class ISBNTests
	{
		[TestMethod]
		public void ISBN_PuefzifferBerechnen()
		{
			//Arrange
			string isbn13 = "978-377043616";
			ISBN i = new ISBN();

			//Act 
			i.ISBN13 = isbn13;

			//Assert
			Assert.AreEqual("978-3770436163", i.ISBN13);

		}

		[TestMethod]
		public void ISBN_ISBN10Berchnen()
		{
			//Arrange
			string isbn13 = "978-3770436064";
			string isbn10 = "3770436067";

			//Act 
			ISBN b = new ISBN(isbn13,isbn10);

			//Assert
			Assert.AreEqual("3770436067", b.ISBN10);

		}
	}
}
