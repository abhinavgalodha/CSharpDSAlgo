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

            var result = 0;
            Stack<string> stackOfOperandsOrBraces = new Stack<string>();
            Stack<string> stackOfOperators = new Stack<string>();
            
            // Insert the first Digit into the stack, this shouldn't be evaluated
            // This can also include any left braces
            bool isFirstDigitVisited = false;

            for (int index = 0; index < inputExpression.Length; index++)
            {
                string currentChar = inputExpression[index].ToString();

                // Skip any empty space
                if (currentChar == " ")
                {
                    continue;
                }
                if (currentChar == "(")
                {
                    stackOfOperandsOrBraces.Push(currentChar);
                    continue;
                }

                if (currentChar == "+" ||
                    currentChar ==  "-" )
                {
                    stackOfOperators.Push(currentChar);
                    continue;
                }

                if (currentChar.IsInteger() &&
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
            

            var resultChar = stackOfOperandsOrBraces.Pop();
            result = int.Parse(resultChar.ToString());
            return result;
        }

        private static void EvaluateAndPushResult(Stack<string> stackOfOperandsOrBraces, Stack<string> stackOfOperators, string currentChar)
        {
            if(currentChar == ")")
            {
                ComputeRightExpression(stackOfOperandsOrBraces, stackOfOperators);
            }
            else
            {
                var leftOperandChar = stackOfOperandsOrBraces.Pop();

                // if left operand is left brace then we can't execute..
                if (leftOperandChar == "(")
                {
                    stackOfOperandsOrBraces.Push(leftOperandChar);
                    stackOfOperandsOrBraces.Push(currentChar);
                    return;
                }

                var operatorToApply = stackOfOperators.Pop();
                int result = EvaluateMathematicalExpression(operatorToApply, currentChar, leftOperandChar);

                stackOfOperandsOrBraces.Push(result.ToString());
            }
        }

        private static void ComputeRightExpression(Stack<string> stackOfOperandsOrBraces, Stack<string> stackOfOperators)
        {
            var rightOperand = stackOfOperandsOrBraces.Pop();
            var leftOperand = stackOfOperandsOrBraces.Pop();
            if (leftOperand == "(")
            {
                // if the expression is like (4), then push the result 4, directly into the stack
                stackOfOperandsOrBraces.Push(rightOperand);
            }
            else
            {
                var operatorToApply = stackOfOperandsOrBraces.Pop();
                int result = EvaluateMathematicalExpression(operatorToApply, rightOperand, leftOperand);
                stackOfOperandsOrBraces.Push(result.ToString());
            }

        }

        private static int EvaluateMathematicalExpression(string operatorToApply, string rightOperandChar, string leftOperandChar)
        {
            var rightOperand = int.Parse(rightOperandChar);
            var leftOperand = int.Parse(leftOperandChar);
            var result = 0;

            if (operatorToApply == "+")
            {
                result = leftOperand + rightOperand;
            }
            else
            {
                result = leftOperand - rightOperand;
            }

            return result;
        }
    }
}
