using Core;
using System.Collections.Generic;

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
            Stack<string> stackOfOperandsOrBraces = new Stack<string>();
            Stack<string> stackOfOperators = new Stack<string>();

            // Insert the first Digit into the stack, this shouldn't be evaluated
            // This can also include any left braces
            bool isFirstDigitVisited = false;

            foreach (var token in inputExpression)
            {
                string currentChar = token.ToString();

                switch (currentChar)
                {
                    // Skip any empty space
                    case " ":
                        continue;
                    case "(":
                        stackOfOperandsOrBraces.Push(currentChar);
                        continue;
                    case "+":
                    case "-":
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

            int finalResult = 0;

            if (stackOfOperators.Count > 0)
            {
                string leftOperand = stackOfOperandsOrBraces.Pop();
                string rightOperand = stackOfOperandsOrBraces.Pop();
                string operatorToApply = stackOfOperators.Pop();
                finalResult = EvaluateMathematicalExpression(operatorToApply, rightOperand, leftOperand);
            }
            else
            {
                var resultString = stackOfOperandsOrBraces.Pop();
                finalResult = int.Parse(resultString.ToString());
            }

            return finalResult;
        }

        private static void EvaluateAndPushResult(Stack<string> stackOfOperandsOrBraces, Stack<string> stackOfOperators, string currentChar)
        {
            if (currentChar == ")")
            {
                ComputeRightExpression(stackOfOperandsOrBraces, stackOfOperators);
            }
            else
            {
                string leftOperandChar = stackOfOperandsOrBraces.Pop();

                // if left operand is left brace then we can't execute..
                if (leftOperandChar == "(")
                {
                    stackOfOperandsOrBraces.Push(leftOperandChar);
                    stackOfOperandsOrBraces.Push(currentChar);
                    return;
                }

                string operatorToApply = stackOfOperators.Pop();
                int result = EvaluateMathematicalExpression(operatorToApply, currentChar, leftOperandChar);

                stackOfOperandsOrBraces.Push(result.ToString());
            }
        }

        private static void ComputeRightExpression(Stack<string> stackOfOperandsOrBraces, Stack<string> stackOfOperators)
        {
            string rightOperand = stackOfOperandsOrBraces.Pop();
            string leftOperand = stackOfOperandsOrBraces.Pop();
            if (leftOperand == "(")
            {
                // if the expression is like (4), then push the result 4, directly into the stack
                stackOfOperandsOrBraces.Push(rightOperand);
            }
            else
            {
                string operatorToApply = stackOfOperators.Pop();
                int result = EvaluateMathematicalExpression(operatorToApply, rightOperand, leftOperand);

                // Remove the "(" bracket as the right brace is evaluated.
                stackOfOperandsOrBraces.Pop();
                stackOfOperandsOrBraces.Push(result.ToString());
            }

        }

        private static int EvaluateMathematicalExpression(string operatorToApply, string rightOperandChar, string leftOperandChar)
        {
            int rightOperand = int.Parse(rightOperandChar);
            int leftOperand = int.Parse(leftOperandChar);
            int result = 0;

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
