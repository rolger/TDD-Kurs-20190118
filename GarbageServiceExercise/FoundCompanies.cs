using System;
using System.Collections.Generic;

namespace GarbageServiceExercise
{
    public class FoundCompanies
    {
        public List<string> CompanyNames { get; }

        public FoundCompanies()
        {
            CompanyNames = new List<string>();
        }

        public void Add(string name)
        {
            if (!CompanyNames.Contains(name))
            {
                CompanyNames.Add(name);
            }
        }
    }
}