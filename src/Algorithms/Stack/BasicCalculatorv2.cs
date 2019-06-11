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
        private const string OPERATOR_PLUS = "+";
        private const string OPERATOR_MINUS = "-";
        private const char EMPTY_SPACE = ' ';

        public static long Evaluate(string inputExpression)
        {
            // Gaurd Conditions
            inputExpression.ThrowIfNullOrWhiteSpace(nameof(inputExpression));

            // Char Processor

            Stack<Evaluator> stackOfEvaluators = new Stack<Evaluator>();
            Evaluator currentEvaluator = new Evaluator();
            stackOfEvaluators.Push(currentEvaluator);
            string previousToken = "";

            // TODO : Check how it works for a string like 11 (2 digits)
            for (var index = 0; index < inputExpression.Length; index++)
            {
                char currentToken = inputExpression[index];

                if (char.IsNumber(currentToken))
                {
                    previousToken += currentToken;
                    continue;
                }

                if (!string.IsNullOrWhiteSpace(previousToken))
                {
                    ProcessToken(currentEvaluator, previousToken);
                }

                previousToken = string.Empty;

                switch (currentToken)
                {
                    case EMPTY_SPACE:
                        break;

                    case LEFT_BRACE:
                        currentEvaluator = new Evaluator();
                        stackOfEvaluators.Push(currentEvaluator);
                        break;

                    case RIGHT_BRACE:
                        long evaluatorResult = currentEvaluator.CalculateResult();
                        stackOfEvaluators.Pop();
                        bool isAnyStackOfEvaluatorPending = stackOfEvaluators.TryPeek(out Evaluator previousEvaluator);
                        if (isAnyStackOfEvaluatorPending)
                        {
                            previousEvaluator.ProcessToken(evaluatorResult.ToString());
                            currentEvaluator = previousEvaluator;
                        }
                        break;

                        default:
                        ProcessToken(currentEvaluator, currentToken.ToString());    
                        break;
                }
            }

            if (!string.IsNullOrWhiteSpace(previousToken))
            {
                ProcessToken(currentEvaluator, previousToken);
            }


            // All tokens are processed, evaluate the results
            long result = CalculateFinalResult(stackOfEvaluators);
            return result;
        }

        private static void ProcessToken(Evaluator currentEvaluator, string token)
        {
            currentEvaluator.ProcessToken(token);
        }

        private static long CalculateFinalResult(Stack<Evaluator> stackOfEvaluators)
        {
            // All tokens are processed, evaluate the results
            var lastStackOfEvaluator = stackOfEvaluators.Pop();
            return lastStackOfEvaluator.CalculateResult();
        }


        public class Evaluator
        {
            private readonly Stack<long> _stackOfOperands;
            private readonly Stack<string> _stackOfOperators;

            public Evaluator()
            {
                _stackOfOperands = new Stack<long>();
                _stackOfOperators = new Stack<string>();
            }


            public void ProcessToken(string inputToken)
            {
                // This implementation is using Stack as a Basic Data Structure.
                // A new stack is created whenever a left braces is started
                // and ended when the right Brace is encountered.


                // Gaurd Conditions
                inputToken.ThrowIfNullOrWhiteSpace(nameof(inputToken));


                switch (inputToken)
                {
                    case OPERATOR_PLUS:
                    case OPERATOR_MINUS:
                        _stackOfOperators.Push(inputToken);
                        break;

                    default:
                        long currentInteger = long.Parse(inputToken);
                        _stackOfOperands.Push(currentInteger);

                        if (CannotEvaluate(_stackOfOperands, _stackOfOperators))
                        {
                            break;
                        }

                        EvaluateAndUpdateStack(_stackOfOperands, _stackOfOperators);
                        break;
                }
            }

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
                // A stack can be evaluated if there is atleast 1 operator in operator stack 
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
