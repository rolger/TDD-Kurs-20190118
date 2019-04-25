using System.Collections.Generic;

namespace GarbageServiceExercise
{
    public class GarbageParser
    {
        public virtual List<string> Parse(string inputData)
        {
            var parsedValues = new List<string> { inputData };

            return parsedValues;
        }
    }
}
