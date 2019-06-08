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

            int result;
            Stack<Evaluator> stackOfEvaluators = new Stack<Evaluator>();
            Evaluator currentEvaluator = new Evaluator();
            stackOfEvaluators.Push(currentEvaluator);

            // TODO : Check how it works for a string like 11 (2 digits)
            foreach (char token in inputExpression)
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
                    bool isAnyStackOfEvaluatorPending = stackOfEvaluators.TryPeek(out Evaluator previousEvaluator);
                    if (isAnyStackOfEvaluatorPending)
                    {
                        previousEvaluator.ProcessToken(evaluatorResult.ToString());
                        currentEvaluator = previousEvaluator;
                    }
                }
                else
                {
                    currentEvaluator.ProcessToken(currentToken);
                }
            }

            // All tokens are processed, evaluate the results
            result = CalculateFinalResult(stackOfEvaluators);
            return result;
        }

        private static int CalculateFinalResult(Stack<Evaluator> stackOfEvaluators )
        {
            // All tokens are processed, evaluate the results
            var lastStackOfEvaluator = stackOfEvaluators.Pop();
            return lastStackOfEvaluator.CalculateResult();
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


                switch (inputToken)
                {
                    case OPERATOR_PLUS:
                    case OPERATOR_MINUS:
                        _stackOfOperators.Push(inputToken);
                        break;

                    default:
                        int currentInteger = int.Parse(inputToken);
                        _stackOfOperands.Push(currentInteger);

                        if (CannotEvaluate(_stackOfOperands, _stackOfOperators))
                        {
                            break;
                        }

                        EvaluateAndUpdateStack(_stackOfOperands, _stackOfOperators);
                        break;
                }
            }

            private static void EvaluateAndUpdateStack(Stack<int> stackOfOperands, Stack<string> stackOfOperators)
            {
                int rightOperand = stackOfOperands.Pop();
                int leftOperand = stackOfOperands.Pop();
                string operatorToApply = stackOfOperators.Pop();

                int result = 0;

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
