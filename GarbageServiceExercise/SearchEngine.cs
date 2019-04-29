using System.Collections.Generic;

namespace GarbageServiceExercise
{
    public class Company
    {
        public Company(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public List<string> Garbage { get; set; }
    }

    public interface ICompanyRepository
    {
        List<Company> FindBy(string keyword);
        void SaveNewCompany(string name, List<string> garbage);
    }

    public class SearchEngine
    {
        private readonly ICompanyRepository repo;
        private readonly GarbageParser parser;

        public SearchEngine(ICompanyRepository repo, GarbageParser parser)
        {
            this.repo = repo;
            this.parser = parser;
        }

        public FoundCompanies Search(string input)
        {
            var foundCompanies = new FoundCompanies();
            if (string.IsNullOrEmpty(input))
            {
                return foundCompanies; 
            }

            var keywords = parser.Parse(input);
            foreach(string keyword in keywords)
            {
                var companies = repo.FindBy(keyword);

                companies.ForEach(c => foundCompanies.Add(c.Name));
            }
            
            return foundCompanies;
        }
    }
}
