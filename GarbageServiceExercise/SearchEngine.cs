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

        public FoundCompanies Search(string input)
        {
            return null;
        }
    }
}
