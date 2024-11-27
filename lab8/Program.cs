using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("Оберіть завдання для виконання:");
            Console.WriteLine("1: Просте використання делегатів");
            Console.WriteLine("2: Групове перетворення методів, що делегуються");
            Console.WriteLine("3: Універсальні делегати (калькулятор)");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Task1();
                    break;
                case "2":
                    Task2();
                    break;
                case "3":
                    Task3();
                    break;
                default:
                    Console.WriteLine("Невірний вибір.");
                    break;
            }
        }

        // Завдання 1
        static void Task1()
        {
            Console.WriteLine("Завдання 1: Обчислення значень функції F(x)");
            Console.Write("Введіть число x: ");

            string input = Console.ReadLine();
            if (double.TryParse(input, out double x))
            {
                FunctionDelegate function;
                if (x > 0)
                {
                    function = CalculatePositive;
                }
                else
                {
                    function = CalculateNonPositive;
                }

                double result = function(x);
                Console.WriteLine($"Результат: F({x}) = {result}");
            }
            else if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Потрібно було ввести число.");
            }
            else
            {
                Console.WriteLine("Невірний формат числа.");
            }
        }

        delegate double FunctionDelegate(double x);

        static double CalculatePositive(double x)
        {
            return Math.Sin(2 * x);
        }

        static double CalculateNonPositive(double x)
        {
            return 1 - 2 * Math.Sin(2 * x);
        }

        // Завдання 2
        static void Task2()
        {
            Console.WriteLine("Завдання 2: Розклад занять за днями тижня");
            Console.Write("Введіть номер дня тижня (1-7): ");

            string dayInput = Console.ReadLine();
            if (int.TryParse(dayInput, out int day) && day >= 1 && day <= 7)
            {
                Action[] scheduleActions = { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday };
                scheduleActions[day - 1].Invoke();
            }
            else
            {
                Console.WriteLine("Невірний номер дня тижня. Введіть число від 1 до 7.");
            }
        }

        static void Monday()
        {
            Console.WriteLine("Понеділок: Математика, Фізика, Програмування");
        }

        static void Tuesday()
        {
            Console.WriteLine("Вівторок: Історія, Хімія, Фізичне виховання");
        }

        static void Wednesday()
        {
            Console.WriteLine("Середа: Література, Географія, Англійська мова");
        }

        static void Thursday()
        {
            Console.WriteLine("Четвер: Біологія, Фізика, Математика");
        }

        static void Friday()
        {
            Console.WriteLine("П'ятниця: Інформатика, Хімія, Історія");
        }

        static void Saturday()
        {
            Console.WriteLine("Субота: Фізичне виховання, Мистецтво");
        }

        static void Sunday()
        {
            Console.WriteLine("Неділя: Вихідний день");
        }

        // Завдання 3
        static void Task3()
        {
            Console.WriteLine("Завдання 3: Консольний арифметичний калькулятор");
            Console.Write("Введіть перше число: ");
            string firstInput = Console.ReadLine();
            Console.Write("Введіть друге число: ");
            string secondInput = Console.ReadLine();
            Console.Write("Введіть операцію (+, -, *, /): ");
            string operation = Console.ReadLine();

            if (double.TryParse(firstInput, out double num1) && double.TryParse(secondInput, out double num2))
            {
                Func<double, double, double> calculator;

                switch (operation)
                {
                    case "+":
                        calculator = Add;
                        break;
                    case "-":
                        calculator = Subtract;
                        break;
                    case "*":
                        calculator = Multiply;
                        break;
                    case "/":
                        if (num2 != 0)
                        {
                            calculator = Divide;
                        }
                        else
                        {
                            Console.WriteLine("Ділення на нуль неможливе.");
                            return;
                        }
                        break;
                    default:
                        Console.WriteLine("Невідома операція.");
                        return;
                }

                double result = calculator(num1, num2);
                Console.WriteLine($"Результат: {num1} {operation} {num2} = {result}");
            }
            else
            {
                Console.WriteLine("Потрібно було ввести коректні числа.");
            }
        }

        static double Add(double a, double b)
        {
            return a + b;
        }

        static double Subtract(double a, double b)
        {
            return a - b;
        }

        static double Multiply(double a, double b)
        {
            return a * b;
        }

        static double Divide(double a, double b)
        {
            return a / b;
        }
    }
}

