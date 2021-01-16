using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace OfxNet.IntegrationTests
{
    public class OfxDocumentTests
    {
        private static readonly string caminho = Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp3.1", "");

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                    new object[] { @$"{caminho}\SampleBankStatement-1.ofx", 1, 3 },
                    new object[] { @$"{caminho}\SampleBankStatement-2.ofx", 1, 2 },
                    new object[] { @$"{caminho}\SampleCreditCardStatement.ofx", 1, 1 },
                    new object[] { @$"{caminho}\SampleMultiStatement.ofx", 2, 3 },
                    new object[] { @$"{caminho}\SampleSignOnResponse.ofx", 0, 0 },
                    new object[] { @$"{caminho}\Sample-itau.ofx", 1, 3 },
                    new object[] { @$"{caminho}\Sample-santander.ofx", 1, 3 },
            };

        //[Fact(DisplayName = "Itau222")]
        //[Trait("OfxNet", "Parse")]
        [Theory]
        [Trait("OfxNet", "Load")]
        [MemberData(memberName: nameof(Data))]
        public void OfxDocumentLoad_Succeeds(string path, int statementCount, int txCount)
        {
            var actual = OfxDocument.Load(path);
            Assert.NotNull(actual);
        }

        [Theory]
        [Trait("OfxNet", "Load")]
        [MemberData(memberName: nameof(Data))]
        public void OfxDocumentLoad_GetStatements_ReturnsCorrectNumberOfStatementsAndTransactions(string path, int statementCount, int txCount)
        {
            var actual = OfxDocument.Load(path);
            Assert.NotNull(actual);

            var allStatements = actual.GetStatements();
            Assert.Equal(statementCount, allStatements.Count());

            var allTransactions = allStatements.SelectMany(s => s.TransactionList.Transactions);
            Assert.Equal(txCount, allTransactions.Count());
        }


        [Fact(DisplayName = "Itau")]
        [Trait("OfxNet", "Parse")]
        public void CanParseItau()
        {
            var actual = OfxDocument.Load(@$"{caminho}\Sample-itau.ofx").GetStatements();

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
            var actual = OfxDocument.Load(@$"{caminho}\BB.ofx").GetStatements();


            var statement = actual.First();
            Assert.IsType<OfxBankStatement>(statement);

            var bankStatement = statement as OfxBankStatement;

            Assert.Equal("7642-2", bankStatement.Account.AccountNumber);
            Assert.Equal("4001-0", bankStatement.Account.BranchId);
            Assert.Equal("1", bankStatement.Account.BankId);

            Assert.Equal(34, statement.TransactionList.Transactions.Count());

            Assert.Equal(1, 1);

        }

        [Fact(DisplayName = "HSBC")]
        [Trait("OfxNet", "Parse")]
        public void CanParseHSBC()
        {
            var actual = OfxDocument.Load(@$"{caminho}\HSBC.ofx").GetStatements();


            var statement = actual.First();
            Assert.IsType<OfxBankStatement>(statement);
            var bankStatement = statement as OfxBankStatement;

            Assert.Equal("05290655162", bankStatement.Account.AccountNumber);
            Assert.Null(bankStatement.Account.BranchId);
            Assert.Equal("399", bankStatement.Account.BankId);

            Assert.Equal(17, statement.TransactionList.Transactions.Count());
        }

        [Fact(DisplayName = "Siscoob")]
        [Trait("OfxNet", "Parse")]
        public void CanParseSicoob()
        {
            var actual = OfxDocument.Load(@$"{caminho}\Siscoob.ofx").GetStatements();

            var statement = actual.First();
            Assert.IsType<OfxBankStatement>(statement);

            var bankStatement = statement as OfxBankStatement;

            Assert.Equal("112763", bankStatement.Account.AccountNumber);
            Assert.Equal("3337", bankStatement.Account.BranchId);
            Assert.Equal("756", bankStatement.Account.BankId);

            Assert.Equal(57, statement.TransactionList.Transactions.Count());
        }
    }
}
