using System;
using System.Collections.Generic;
using Core;

namespace Algorithms.Stack
{
    public class BasicCalculator
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
            Stack<char> stackOfOperandsOrBraces = new Stack<char>();
            Stack<char> stackOfOperators = new Stack<char>();
            
            // Insert the first Digit into the stack, this shouldn't be evaluated
            // This can also include any left braces
            bool isFirstDigitVisited = false;

            for (int index = 0; index < inputExpression.Length; index++)
            {
                char currentChar = inputExpression[index];

                // Skip any empty space
                if (currentChar == ' ')
                {
                    continue;
                }

                if (currentChar == '(')
                {
                    stackOfOperandsOrBraces.Push(currentChar);
                    continue;
                }

                if (currentChar == '+' ||
                    currentChar == '-' )
                {
                    stackOfOperators.Push(currentChar);
                    continue;
                }

                if(char.IsNumber(currentChar) && 
                   isFirstDigitVisited == false)
                {
                    isFirstDigitVisited = true;
                    stackOfOperandsOrBraces.Push(currentChar);
                }
                else
                {
                    EvaluateAndPushResult(stackOfOperandsOrBraces, stackOfOperators, currentChar);
                }

            }

            result = stackOfOperandsOrBraces.Pop();

            return result;
        }

        private static void EvaluateAndPushResult(Stack<char> stackOfOperandsOrBraces, Stack<char> stackOfOperators, char currentChar)
        {
            if(currentChar == ')')
            {
                ComputeRightExpression(stackOfOperandsOrBraces, stackOfOperators);
            }
            else
            {
                var operatorToApply = stackOfOperators.Pop();
                var rightOperand = int.Parse(currentChar.ToString());
                var leftOperand =  int.Parse(stackOfOperandsOrBraces.Pop().ToString());
                var result = 0;

                if (operatorToApply == '+')
                {
                    result = leftOperand + rightOperand ;
                }
                else
                {
                    result = leftOperand - rightOperand ;
                }

                stackOfOperandsOrBraces.Push(result.ToString()[0]);
            }
        }

        private static void ComputeRightExpression(Stack<char> stackOfOperandsOrBraces, Stack<char> stackOfOperators)
        {
            throw new NotImplementedException();
        }
    }
}
