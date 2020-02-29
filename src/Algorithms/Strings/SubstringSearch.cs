

namespace Algorithms.Strings
{
    public class SubStringSearch
    {
        public bool Find(string inputString, string patternString)
        {
            inputString.ThrowIfNullOrWhiteSpace(nameof(inputString));
            patternString.ThrowIfNullOrWhiteSpace(nameof(patternString));

            if (patternString.Length > inputString.Length)
            {
                return false;
            }


        }
    }
}
