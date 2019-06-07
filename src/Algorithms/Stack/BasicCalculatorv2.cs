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

            int result = 0;
            Stack<Evaluator> stackOfEvaluators = new Stack<Evaluator>();

            Evaluator currentEvaluator = new Evaluator();

            foreach (var token in inputExpression)
            {
                string currentToken = token.ToString();

                if (currentToken == EMPTY_SPACE)
                {
                    continue;
                }

                if (currentToken == LEFT_BRACE)
                {
                    currentEvaluator = new Evaluator();
                    stackOfEvaluators.Push(currentEvaluator);
                }
                else if (currentToken == RIGHT_BRACE)
                {
                    int evaluatorResult = currentEvaluator.CalculateResult();
                    stackOfEvaluators.Pop();
                    bool isAnyStackOfEvaluatorPending = stackOfEvaluators.TryPop(out Evaluator previousEvaluator);
                    if (isAnyStackOfEvaluatorPending)
                    {
                        previousEvaluator.ProcessToken(evaluatorResult.ToString());
                    }
                }
                else
                {
                    currentEvaluator.ProcessToken(currentToken);
                }
            }

            // All tokens are processed, evaluate the results
            result = currentEvaluator.CalculateResult();
            return result;
        }


        public class Evaluator
        {
            private readonly Stack<int> _stackOfOperands;
            private readonly Stack<string> _stackOfOperators;

            public Evaluator()
            {
                _stackOfOperands = new Stack<int>();
                _stackOfOperators = new Stack<string>();
            }


            public void ProcessToken(string inputToken)
            {
                // This implementation is using Stack as a Basic Data Structure.
                // A new stack is created whenever a left braces is started
                // and ended when the right Brace is encountered.


                // Gaurd Conditions
                inputToken.ThrowIfNullOrWhiteSpace(nameof(inputToken));

                foreach (var token in inputToken)
                {
                    string currentToken = token.ToString();

                    switch (currentToken)
                    {
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

            private static bool CannotEvaluate(Stack<int> stackOfOperands, Stack<string> stackOfOperators)
            {
                // A stack can be evaluated if there is atleast 1 operator in operator stack 
                // and a minimum of 2 operands in operands stack

                if (stackOfOperators.Count > 0 && stackOfOperands.Count > 1)
                {
                    return false;
                }

                return true;
            }

            public int CalculateResult()
            {
                return _stackOfOperands.Pop();
            }
        }
    }
}
