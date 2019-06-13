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
        private const char LEFT_BRACE = '(';
        private const char RIGHT_BRACE = ')';
        private const char EMPTY_SPACE = ' ';
        private const string OPERATOR_PLUS = "+";
        private const string OPERATOR_MINUS = "-";

        public static long Evaluate(string inputExpression)
        {
            // Guard Conditions
            inputExpression.ThrowIfNullOrWhiteSpace(nameof(inputExpression));

            // Char Processor
            // This implementation is using Stack as a Basic Data Structure.
            // A new stack is created whenever a left braces is started
            // and ended when the right Brace is encountered.

            Stack<MathExpressionEvaluator> stackOfEvaluators = new Stack<MathExpressionEvaluator>();
            MathExpressionEvaluator currentMathExpressionEvaluator = new MathExpressionEvaluator();
            stackOfEvaluators.Push(currentMathExpressionEvaluator);

            string previousToken = string.Empty;

            foreach (var currentToken in inputExpression)
            {
                // Handle the number greater than 10 digits, a char can process only single character or digit less than 10.
                // 12 would come up as 2 characters '1' and '2'
                if (char.IsNumber(currentToken))
                {
                    previousToken += currentToken;
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(previousToken))
                {
                    ProcessToken(currentMathExpressionEvaluator, previousToken);
                }

                previousToken = string.Empty;

                switch (currentToken)
                {
                    case EMPTY_SPACE:
                        break;

                    case LEFT_BRACE:
                        currentMathExpressionEvaluator = new MathExpressionEvaluator();
                        stackOfEvaluators.Push(currentMathExpressionEvaluator);
                        break;

                    case RIGHT_BRACE:
                        long evaluatorResult = currentMathExpressionEvaluator.CalculateResult();
                        stackOfEvaluators.Pop();
                        bool isAnyStackOfEvaluatorPending = stackOfEvaluators.TryPeek(out MathExpressionEvaluator previousEvaluator);
                        if (isAnyStackOfEvaluatorPending)
                        {
                            previousEvaluator.ProcessToken(evaluatorResult.ToString());
                            currentMathExpressionEvaluator = previousEvaluator;
                        }
                        break;

                    default:
                        ProcessToken(currentMathExpressionEvaluator, currentToken.ToString());    
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(previousToken))
            {
                ProcessToken(currentMathExpressionEvaluator, previousToken);
            }


            // All tokens are processed, evaluate the results
            long result = CalculateFinalResult(stackOfEvaluators);
            return result;
        }

        private static void ProcessToken(MathExpressionEvaluator currentMathExpressionEvaluator, string token)
        {
            currentMathExpressionEvaluator.ProcessToken(token);
        }

        private static long CalculateFinalResult(Stack<MathExpressionEvaluator> stackOfEvaluators)
        {
            // All tokens are processed, evaluate the results
            var lastStackOfEvaluator = stackOfEvaluators.Pop();
            return lastStackOfEvaluator.CalculateResult();
        }


        public class MathExpressionEvaluator
        {
            // This class uses the stack of operands and operator to evaluate the expression.
            // Whenever a operand is addded, it is evaluated eagerly provided there is an operator in the stack.
            private readonly Stack<long> _stackOfOperands;
            private readonly Stack<string> _stackOfOperators;

            public MathExpressionEvaluator()
            {
                _stackOfOperands = new Stack<long>();
                _stackOfOperators = new Stack<string>();
            }


            public void ProcessToken(string inputToken)
            {
                // Gaurd Conditions
                inputToken.ThrowIfNullOrWhiteSpace(nameof(inputToken));
                
                switch (inputToken)
                {
                    case OPERATOR_PLUS:
                    case OPERATOR_MINUS:
                        _stackOfOperators.Push(inputToken);
                        break;

                    default:
                        bool conversionResult = long.TryParse(inputToken, out long currentInteger);

                        if (!conversionResult)
                        {
                            throw new InvalidOperationException("The Token is invalid. It Can't be processed by the Mathematical Evaluator");
                        }

                        _stackOfOperands.Push(currentInteger);

                        if (CannotEvaluate(_stackOfOperands, _stackOfOperators))
                        {
                            break;
                        }

                        EvaluateAndUpdateStack(_stackOfOperands, _stackOfOperators);
                        break;
                }
            }

            /// <summary>
            /// Evaluates the stack by applying the 2 operands with the operator
            /// </summary>
            /// <param name="stackOfOperands"></param>
            /// <param name="stackOfOperators"></param>
            private static void EvaluateAndUpdateStack(Stack<long> stackOfOperands, Stack<string> stackOfOperators)
            {
                long rightOperand = stackOfOperands.Pop();
                long leftOperand = stackOfOperands.Pop();
                string operatorToApply = stackOfOperators.Pop();

                long result = 0;

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

            private static bool CannotEvaluate(Stack<long> stackOfOperands, Stack<string> stackOfOperators)
            {
                // A stack can be evaluated if there is at least 1 operator in operator stack 
                // and a minimum of 2 operands in operands stack

                if (stackOfOperators.Count > 0 && stackOfOperands.Count > 1)
                {
                    return false;
                }

                return true;
            }

            public long CalculateResult()
            {
                return _stackOfOperands.Pop();
            }
        }
    }
}
