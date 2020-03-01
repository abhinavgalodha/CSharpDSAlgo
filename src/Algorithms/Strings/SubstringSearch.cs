using Core;

namespace Algorithms.Strings
{
    public class SubStringSearch
    {
        public static bool Search(string textToSearchFrom, string patternString)
        {
            textToSearchFrom.ThrowIfNullOrWhiteSpace(nameof(textToSearchFrom));
            patternString.ThrowIfNullOrWhiteSpace(nameof(patternString));

            var patternLength = patternString.Length;
            var textToSearchFromLength = textToSearchFrom.Length;

            if (patternLength > textToSearchFromLength)
            {
                return false;
            }

            for (int textIndex = 0; textIndex < textToSearchFromLength - patternLength; textIndex++)
            {
                int patternIndex;
                for (patternIndex = 0; patternIndex < patternLength; patternIndex++)
                {
                    var charText = textToSearchFrom[textIndex + patternIndex];
                    var charPattern = patternString[patternIndex];

                    if (charText != charPattern)
                    {
                        break;
                    }
                }

                if (patternIndex == patternString.Length)
                { 
                    return true;
                }
            }
            return false;
        }
    }
}
