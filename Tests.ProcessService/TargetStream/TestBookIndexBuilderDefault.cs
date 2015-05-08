using NUnit.Framework;
using System;
using PayrolleeMate.ProcessService.Interfaces;
using PayrolleeMate.ProcessService.Collection.Items;
using PayrolleeMate.ProcessService;
using PayrolleeMate.ProcessService.Collections;

namespace Tests.ProcessService
{
	[TestFixture ()]
	public class TestBookIndexBuilderDefault
	{
		uint codeOrder01 = 1;
		uint codeOrder02 = 2;
		uint codeOrder03 = 3;
		uint codeOrder04 = 4;
		uint codeOrder05 = 5;
		uint codeOrder06 = 6;
		uint codeOrder07 = 7;
		uint codeOrder08 = 8;
		uint codeOrder09 = 9;

		IBookIndex index01 { get; set; }
		IBookIndex index02 { get; set; }
		IBookIndex index03 { get; set; }
		IBookIndex index04 { get; set; }
		IBookIndex index05 { get; set; }

		IBookIndex index11 { get; set; }
		IBookIndex index12 { get; set; }
		IBookIndex index13 { get; set; }
		IBookIndex index14 { get; set; }
		IBookIndex index15 { get; set; }
		IBookIndex index16 { get; set; }
		IBookIndex index17 { get; set; }

		IBookIndex index21 { get; set; }
		IBookIndex index22 { get; set; }
		IBookIndex index23 { get; set; }
		IBookIndex index24 { get; set; }
		IBookIndex index25 { get; set; }
		IBookIndex index26 { get; set; }
		IBookIndex index27 { get; set; }
		IBookIndex index28 { get; set; }
		IBookIndex index29 { get; set; }

		IBookParty partyOne = new BookParty(BookParty.UNKNOWN_CONTRACT, BookParty.UNKNOWN_POSITION);

		uint articleCode0 = 1;
		uint articleCode1 = 2;
		uint articleCode2 = 3;

		[TestFixtureSetUp]
		public void TestSetup()
		{
			index01 = new BookIndex(partyOne, articleCode0, codeOrder01);
			index02 = new BookIndex(partyOne, articleCode0, codeOrder02);
			index03 = new BookIndex(partyOne, articleCode0, codeOrder03);
			index04 = new BookIndex(partyOne, articleCode0, codeOrder04);
			index05 = new BookIndex(partyOne, articleCode0, codeOrder05);
						  
			index11 = new BookIndex(partyOne, articleCode1, codeOrder01);
			index12 = new BookIndex(partyOne, articleCode1, codeOrder02);
			index13 = new BookIndex(partyOne, articleCode1, codeOrder03);
			index14 = new BookIndex(partyOne, articleCode1, codeOrder04);
			index15 = new BookIndex(partyOne, articleCode1, codeOrder05);
			index16 = new BookIndex(partyOne, articleCode1, codeOrder06);
			index17 = new BookIndex(partyOne, articleCode1, codeOrder07);
						  
			index21 = new BookIndex(partyOne, articleCode2, codeOrder01);
			index22 = new BookIndex(partyOne, articleCode2, codeOrder02);
			index23 = new BookIndex(partyOne, articleCode2, codeOrder03);
			index24 = new BookIndex(partyOne, articleCode2, codeOrder04);
			index25 = new BookIndex(partyOne, articleCode2, codeOrder05);
			index26 = new BookIndex(partyOne, articleCode2, codeOrder06);
			index27 = new BookIndex(partyOne, articleCode2, codeOrder07);
			index28 = new BookIndex(partyOne, articleCode2, codeOrder08);
			index29 = new BookIndex(partyOne, articleCode2, codeOrder09);
		}

		[Test ()]
		public void Should_Return_Free_CodeOrder_1_With_Missing_1 ()
		{
			IBookIndex[] testArray = new IBookIndex[] {
				index01, index02, index04, index05, 
				index12, index13, index14, index15, index16, index17, 
				index21, index22, index23, index24, index26, index27, index28, index29
			};

			IBookIndex testIndex = TargetStream.BookIndexBuilder.BuildIndexWithDefault (testArray, partyOne, articleCode1);

			Assert.AreEqual(codeOrder01, testIndex.CodeOrder());
		}

		[Test ()]
		public void Should_Return_Free_CodeOrder_4_With_Missing_4 ()
		{
			IBookIndex[] testArray = new IBookIndex[] {
				index01, index02, index04, index05,
				index11, index12, index13, index15, index16, index17, 
				index21, index22, index23, index24, index26, index27, index28, index29
			};

			IBookIndex testIndex = TargetStream.BookIndexBuilder.BuildIndexWithDefault (testArray, partyOne, articleCode1);

			Assert.AreEqual(codeOrder04, testIndex.CodeOrder());
		}

		[Test ()]
		public void Should_Return_Free_CodeOrder_8_With_Missing_8 ()
		{
			IBookIndex[] testArray = new IBookIndex[] {
				index01, index02, index04, index05,
				index11, index12, index13, index14, index15, index16, index17, 
				index21, index22, index23, index24, index26, index27, index28, index29
			};

			IBookIndex testIndex = TargetStream.BookIndexBuilder.BuildIndexWithDefault (testArray, partyOne, articleCode1);

			Assert.AreEqual(codeOrder08, testIndex.CodeOrder());
		}

		[Test ()]
		public void Should_Return_Free_CodeOrder_1_From_Missing_Collection ()
		{
			IBookIndex[] testArray = new IBookIndex[] {
				index01, index02, index03, index04, index05,
				index21, index22, index23, index24, index25, index26, index27, index28, index29
			};

			IBookIndex testIndex = TargetStream.BookIndexBuilder.BuildIndexWithDefault (testArray, partyOne, articleCode1);

			Assert.AreEqual(codeOrder01, testIndex.CodeOrder());
		}

		[Test ()]
		public void Should_Return_Free_CodeOrder_1_From_Empty_Collection ()
		{
			IBookIndex[] testArray = new IBookIndex[0];

			IBookIndex testIndex = TargetStream.BookIndexBuilder.BuildIndexWithDefault (testArray, partyOne, articleCode1);

			Assert.AreEqual(codeOrder01, testIndex.CodeOrder());
		}
	}
}

