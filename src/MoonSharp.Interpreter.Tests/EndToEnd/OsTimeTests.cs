using NUnit.Framework;

namespace MoonSharp.Interpreter.Tests.EndToEnd
{
	[TestFixture]
	public class OsTimeTests
	{
		[Test]
		public void OsTime()
		{
			string script = @"return os.date(""*t"", os.time{ year = 2020, month = 1, day = 1 });";

			Script s = new Script();
			DynValue t = s.DoString(script);

			Assert.AreEqual(2020, t.Table.Get("year").Number);
			Assert.AreEqual(1, t.Table.Get("month").Number);
			Assert.AreEqual(1, t.Table.Get("day").Number);
		}

		[Test]
		public void OsTimeWithInvalidDomain1()
		{
			string script = @"return os.date(""*t"", os.time{ year = 2020, month = 0, day = 1 });";

			Script s = new Script();
			DynValue t = s.DoString(script);

			Assert.AreEqual(2019, t.Table.Get("year").Number);
			Assert.AreEqual(12, t.Table.Get("month").Number);
			Assert.AreEqual(1, t.Table.Get("day").Number);
		}

		[Test]
		public void OsTimeWithInvalidDomain2()
		{
			string script = @"return os.date(""*t"", os.time{ year = 2020, month = 1, day = 34 });";

			Script s = new Script();
			DynValue t = s.DoString(script);

			Assert.AreEqual(2020, t.Table.Get("year").Number);
			Assert.AreEqual(2, t.Table.Get("month").Number);
			Assert.AreEqual(3, t.Table.Get("day").Number);
		}
	}
}
