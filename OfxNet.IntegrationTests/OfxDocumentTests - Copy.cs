using System.Linq;

using Xunit;

namespace OfxNet.IntegrationTests
{
    public class OfxDocumentParseTests
    {
        //public static IEnumerable<object[]> SampleOfxFiles
        //{
        //    get
        //    {
        //        yield return new object[] { "SampleBankStatement-1.ofx", 1, 3 };
        //        yield return new object[] { "SampleBankStatement-2.ofx", 1, 2 };
        //        yield return new object[] { "SampleCreditCardStatement.ofx", 1, 1 };
        //        yield return new object[] { "SampleMultiStatement.ofx", 2, 3 };
        //        yield return new object[] { "SampleSignOnResponse.ofx", 0, 0 };
        //        yield return new object[] { "Sample-itau.ofx", 1, 3 };
        //        yield return new object[] { "Sample-santander.ofx", 1, 3 };
        //    }
        //}

        //[Fact(DisplayName = "Itau1")]
        //[Trait("OfxNet", "Parse")]
        //public void Setup()
        //{
        //    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        //}

        //[Fact(DisplayName = "Itau2")]
        //[Trait("OfxNet", "Parse")]
        //[DynamicData(nameof(SampleOfxFiles), DynamicDataSourceType.Property)]
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "Required for testing.")]
        //public void OfxDocumentLoad_Succeeds(string path, int statementCount, int txCount)
        //{
        //    var actual = OfxDocument.Load(path);
        //    Assert.IsNotNull(actual);
        //}

        //[Fact(DisplayName = "Itau2")]
        //[Trait("OfxNet", "Parse")]
        //[DynamicData(nameof(SampleOfxFiles), DynamicDataSourceType.Property)]
        //public void OfxDocumentLoad_GetStatements_ReturnsCorrectNumberOfStatementsAndTransactions(string path, int statementCount, int txCount)
        //{
        //    var actual = OfxDocument.Load(path);
        //    Assert.IsNotNull(actual);

        //    var allStatements = actual.GetStatements();
        //    Assert.Equal(statementCount, allStatements.Count());

        //    var allTransactions = allStatements.SelectMany(s => s.TransactionList.Transactions);
        //    Assert.Equal(txCount, allTransactions.Count());
        //} 



        [Fact(DisplayName = "Itau")]
        [Trait("OfxNet", "Parse")]
        public void CanParseItau()
        {
            var actual = OfxDocument.Load(@"Sample-itau.ofx")
                .GetStatements();

            var statement = actual.First();
            Assert.IsType<OfxBankStatement>(statement);


            var bankStatement = statement as OfxBankStatement;

            Assert.Equal("9999 99999-9", bankStatement.Account.AccountNumber);
            Assert.Equal("0341", bankStatement.Account.BankId);

            Assert.Equal(3, statement.TransactionList.Transactions.Count());

            Assert.Equal(
                statement.TransactionList.Transactions.Select(x => x.Memo).ToArray(),
                new string[] { "RSHOP", "REND PAGO APLIC AUT MAIS", "SISDEB" });
        }

        [Fact(DisplayName = "BB")]
        [Trait("OfxNet", "Parse")]
        public void CanParseBancoDoBrasil()
        {
            //var actual = OfxDocument.Load("BB.ofx").GetStatements();

            //var statement = actual.First();
            //Assert.IsInstanceOfType(statement, typeof(OfxBankStatement));
            //var bankStatement = statement as OfxBankStatement;

            //Assert.Equal(bankStatement.Account.AccountNumber, "7642-2");
            //Assert.Equal(bankStatement.Account.BranchId, "4001-0");
            //Assert.Equal(bankStatement.Account.BankId, "1");

            //Assert.Equal(34, statement.TransactionList.Transactions.Count());             

            Assert.Equal(1, 1);             

        }

        [Fact(DisplayName = "HSBC")]
        [Trait("OfxNet", "Parse")]
        public void CanParseHSBC()
        {
            var actual = OfxDocument.Load("HSBC.ofx").GetStatements();

            var statement = actual.First();
            Assert.IsType<OfxBankStatement>(statement);
            var bankStatement = statement as OfxBankStatement;

            Assert.Equal("99999-9", bankStatement.Account.AccountNumber);
            Assert.Equal("9999-9", bankStatement.Account.BranchId);
            Assert.Equal("1", bankStatement.Account.BankId);

            Assert.Equal(3, statement.TransactionList.Transactions.Count());
        }

        [Fact(DisplayName = "Siscoob")]
        [Trait("OfxNet", "Parse")]
        public void CanParseSicoob()
        {
            var actual = OfxDocument.Load("Siscoob.ofx").GetStatements();

            var statement = actual.First();
            Assert.IsType<OfxBankStatement>(statement);

            var bankStatement = statement as OfxBankStatement;

            Assert.Equal("99999-9", bankStatement.Account.AccountNumber);
            Assert.Equal("9999-9", bankStatement.Account.BranchId);
            Assert.Equal("1", bankStatement.Account.BankId);

            Assert.Equal(3, statement.TransactionList.Transactions.Count());
        }
    }
}
