using System.Collections.Generic;
using Core;

namespace Algorithms.Stack
{
    class BasicCalculator
    {

        // https://leetcode.com/problems/basic-calculator/
        // Problem: 
        //Implement a basic calculator to evaluate a simple expression string.
        //The expression string may contain open ( and closing parentheses ), the plus + or minus sign -,
        // non-negative integers and empty spaces .

        // Example 3:

        //Input: "(1+(4+5+2)-3)+(6+8)"
        //Output: 23

        public static double Evaluate(string inputExpression)
        {
            // Gaurd Conditions
            inputExpression.ThrowIfNullOrWhiteSpace(nameof(inputExpression));

            var result = 0.0;
            Stack<int> stackOfOperands = new Stack<int>();
            Stack<char> stackOfOperators = new Stack<char>();
            
            foreach (var character in inputExpression)
            {
                // Skip any empty space
                if (character == ' ' ||
                    character == '(')
                {
                    continue;
                }
                if (character == ')')
                {
                    Compute(stackOfOperands, stackOfOperators);
                }
                if (char.IsDigit(character))
                {
                    stackOfOperands.Push(int.Parse(character.ToString()));
                }
                else
                {
                    // everything else should be operator
                    stackOfOperators.Push(character);
                }
            }

            result = stackOfOperands.Pop();

            return result;
        }

        private static void Compute(Stack<int> stackOfOperands, Stack<char> stackOfOperators)
        {
            var leftElement = stackOfOperands.Pop();
            var rightElement = stackOfOperands.Pop();
            int result = 0;

            var operatorToApply = stackOfOperators.Pop();

            if (operatorToApply == '+')
            {
                result = leftElement + rightElement;
            }
            else
            {
                result = rightElement - leftElement;
            }

            stackOfOperands.Push(result);
            
        }

        
    }
}
