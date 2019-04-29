using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace GarbageServiceExercise
{
    public class GarbageSearchEngineTest
    {
        [Fact]
        public void IfInputIsEmptyThenNoCompanyIsReturned()
        {
            GarbageParser parser = null;
            ICompanyRepository repo = null;

            var sut = new SearchEngine(repo, parser);
            var result = sut.Search("");

            result.CompanyNames.Should().BeEmpty();
        }

        [Fact]
        public void IfSearchWithInputFindsACompanyThenThisCompanyIsReturned()
        {
            Mock<GarbageParser> parser = BuildParserWith("WIEN");
            Mock<ICompanyRepository> repo = BuildRepoWith(new Dictionary<string, string>() {
                { "WIEN", "MA48" }
            });

            var sut = new SearchEngine(repo.Object, parser.Object);
            var result = sut.Search("WIEN");

            result.CompanyNames.Should().ContainSingle("MA48");
        }
        [Fact]
        public void IfSearchWithInputFindsTwoCompaniesThenBothAreReturned()
        {
            Mock<GarbageParser> parser = BuildParserWith("WIEN");
            Mock<ICompanyRepository> repo = BuildRepoWith(new Dictionary<string, string>() {
                { "WIEN", "MA48 MA49" }
            });

            var sut = new SearchEngine(repo.Object, parser.Object);
            var result = sut.Search("WIEN");

            result.CompanyNames.Should().BeEquivalentTo("MA48", "MA49");
        }


        [Fact]
        public void MultipleCompaniesFoundIfMultipleKeywords()
        {
            Mock<GarbageParser> parser = BuildParserWith("WIEN, GLAS");
            Mock<ICompanyRepository> repo = BuildRepoWith(new Dictionary<string, string>() {
                { "WIEN", "MA48" },
                { "GLAS", "MA49" }
            });

            var sut = new SearchEngine(repo.Object, parser.Object);
            var result = sut.Search("WIEN, GLAS");

            result.CompanyNames.Should().BeEquivalentTo("MA48", "MA49");
        }

        [Fact]
        public void MultipleCompaniesFoundIfMultipleKeywordsWithSameCompany()
        {
            Mock<GarbageParser> parser = BuildParserWith("WIEN, GLAS");
            Mock<ICompanyRepository> repo = BuildRepoWith(new Dictionary<string, string>() {
                { "WIEN", "MA48" },
                { "GLAS", "MA48" }
            });

            var sut = new SearchEngine(repo.Object, parser.Object);
            var result = sut.Search("WIEN, GLAS");

            result.CompanyNames.Should().BeEquivalentTo("MA48");
        }

        private Mock<GarbageParser> BuildParserWith(string keywords)
        {
            var parser = new Mock<GarbageParser>();

            var keywordList = new List<string>();
            foreach (var keyword in keywords.Split(", "))
            {
                keywordList.Add(keyword);
            }
            parser.Setup(p => p.Parse(keywords)).Returns(keywordList);
            return parser;
        }

        private Mock<ICompanyRepository> BuildRepoWith(Dictionary<string, string> map)
        {
            var repo = new Mock<ICompanyRepository>();

            foreach (var pair in map)
            {
                var companyList = new List<Company>();
                foreach (var company in pair.Value.Split())
                {
                    companyList.Add(new Company(company));
                }
                repo.Setup(r => r.FindBy(pair.Key)).Returns(companyList);
            }
            return repo;
        }


    }
}
