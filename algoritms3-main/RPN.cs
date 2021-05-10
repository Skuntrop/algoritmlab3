using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class RPN
    {
        private string brackets = "()";
        private string openBrackets = "(";
        public string str;
        private string operations = "+-/*=%sincostanctglog^";

        public RPN(string _str)
        {
            str = _str;
        }

        private int GetOperationsPriority (string op)
        {
            return op == "+" || op == "-" ? 1 :
        op == "*" || op == "/" || op == "%"? 2 :
        op == "="? 0 :
        op == "sin"|| op == "cos" || op == "tan" || op == "ctg" || op =="log" || op == "exp"? 4 :
        op == "^"? 3: -1;
        }

        private string[] StrToArray(string str)
        {
            var result = new List<string>();
            for (var i = 0; i < str.Length; i++)
            {
                if (Char.IsDigit(str[i]) || (str[i] == '-' && (i == 0 || openBrackets.Contains(str[i - 1]) || operations.Contains(str[i - 1])) && Char.IsDigit(str[i + 1])))
                {
                    var a = str[i].ToString();
                    if (str.Length != i + 1)
                    {


                        while (Char.IsDigit(str[i + 1]))
                        {
                            i++;
                            a += str[i].ToString();
                            if (str.Length <= i + 1)
                                break;
                        }
                    }
                    result.Add(a);
                }
                else
                {
                    if ((str[i] == '-' && (i == 0 || openBrackets.Contains(str[i - 1]) || operations.Contains(str[i - 1])))
                                           && !operations.Contains(str[i + 1]))
                    {
                        result.Add(str[i].ToString() + str[i + 1].ToString());
                        i++;
                    }
                    else if (i + 4 < str.Length && operations.Contains(str[i].ToString() + str[i + 1].ToString() + str[i + 2].ToString() + str[i + 3].ToString()))
                    {
                        i += 4;
                        result.Add(str[i].ToString() + str[i + 1].ToString() + str[i + 2].ToString() + str[i + 3].ToString());
                    }
                    else if (i + 3 < str.Length && operations.Contains(str[i].ToString() + str[i + 1].ToString() + str[i + 2].ToString()) && str[i + 3] == '(')
                    {
                        var j = i + 4;
                        var s = "";
                        while (str[j] != ')')
                        {
                            s += str[j].ToString();
                            j++;
                        }

                        var a = new RPN(s);
                        result.Add(a.ToRPN() + "," + str[i].ToString() + str[i + 1].ToString() + str[i + 2].ToString());
                        i += j - i + 5;
                    }
                    else
                    {
                        result.Add(str[i].ToString());
                    }
                }
            }
            return result.ToArray();
        }

        public string ToRPN()
        {
            var pForm = StrToArray(str);
            var result = new Stack<string>();
            var operation = new Stack<string>();
            foreach(var c in pForm)
            {
                if (openBrackets.Contains(c))
                {
                    operation.Push(c);
                }
                else if (brackets.Contains(c))
                {
                    while(!openBrackets.Contains(operation.Peek()))
                    {
                        result.Push(operation.Pop());
                    }
                    operation.Pop();
                }
                else if (operations.Contains(c))
                {

                    while (operation.Count != 0 && GetOperationsPriority(operation.Peek()) >= GetOperationsPriority(c))
                        result.Push(operation.Pop());
                    operation.Push(c);
                }
                else
                {
                    result.Push(c);
                }
            }
            while(operation.Count != 0)
            {
                result.Push(operation.Pop());
            }
            return ToStr(result);
        }

        private string ToStr(Stack<string> res)
        {
            var result = new StringBuilder();
            var array = res.ToArray();
            for (var i = array.Length - 1; i >= 0; i--)
            {
                result.Append(array[i].ToString());
                if (i != 0)
                    result.Append(",");
            }
            return result.ToString();
        }
    }

}
