using System;
using Core;
using System.Collections.Generic;

namespace Algorithms.Stack
{
    // https://leetcode.com/problems/basic-calculator/
    // Problem: 
    //Implement a basic calculator to evaluate a simple expression string.
    //The expression string may contain open ( and closing parentheses ), the plus + or minus sign -,
    // non-negative integers and empty spaces .

    // Example 3:
    //Input: "(1+(4+5+2)-3)+(6+8)"
    //Output: 23

    public class BasicCalculatorV2
    {
        private const string LEFT_BRACE = "(";
        private const string RIGHT_BRACE = ")";
        private const string OPERATOR_PLUS = "+";
        private const string OPERATOR_MINUS = "-";
        private const string EMPTY_SPACE = " ";

        public static int Evaluate(string inputExpression)
        {
            // Gaurd Conditions
            inputExpression.ThrowIfNullOrWhiteSpace(nameof(inputExpression));

            foreach (var token in inputExpression)
            {
                string currentToken = token.ToString();
            }
        }
        

        public class Evaluator
        {
            private Stack<int> _stackOfOperands;
            private Stack<string> _stackOfOperators;

            public Evaluator()
            {
                _stackOfOperands = new Stack<int>();
                _stackOfOperators = new Stack<string>();
            }


            public int Evaluate(string inputExpression)
            {
                // This implementation is using Stack as a Basic Data Structure.
                // A new stack is created whenever a left braces is started
                // and ended when the right Brace is encountered.


                // Gaurd Conditions
                inputExpression.ThrowIfNullOrWhiteSpace(nameof(inputExpression));
            
                foreach (var token in inputExpression)
                {
                    string currentToken = token.ToString();

                    switch (currentToken)
                    {
                        // Skip any empty space
                        case EMPTY_SPACE:
                            continue;

                        case OPERATOR_PLUS:
                        case OPERATOR_MINUS:
                            _stackOfOperators.Push(currentToken);
                            continue;

                        default:
                            var currentInteger = int.Parse(currentToken);
                            _stackOfOperands.Push(currentInteger);

                            if (CannotEvaluate(_stackOfOperands, _stackOfOperators))
                            {
                                continue;
                            }

                            EvaluateAndUpdateStack(_stackOfOperands, _stackOfOperators);
                        
                            break;
                    }
                }

                int finalResult = _stackOfOperands.Pop();
                return finalResult;
            }

            private static void EvaluateAndUpdateStack(Stack<int> stackOfOperands, Stack<string> stackOfOperators)
            {
                var rightOperand = stackOfOperands.Pop();
                var leftOperand = stackOfOperands.Pop();
                var operatorToApply = stackOfOperators.Pop();

                var result = 0;

                if (operatorToApply == OPERATOR_PLUS)
                {
                    result = leftOperand + rightOperand;
                }
                else
                {
                    result = leftOperand - rightOperand;
                }

                stackOfOperands.Push(result);
            }

            private static bool CannotEvaluate(Stack<int> stackOfOperands , Stack<string> stackOfOperators)
            {
                // A stack can be evaluated if there is atleast 1 operator in operator stack 
                // and a minimum of 2 operands in operands stack

                if (stackOfOperators.Count > 0 && stackOfOperands.Count > 1)
                {
                    return false;
                }

                return true;
            }
        }
    }
}
