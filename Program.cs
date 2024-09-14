using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using TestWork;

class Program
{
    static void Main()
    {

        using (var db = new ApplicationContext())
        {
            FinanceManager.Initialize(db);

            bool exit = false;

            while (!exit)
            {
                DisplayMenu();

                Console.Write("Введите номер команды: ");
                if (int.TryParse(Console.ReadLine(), out int userChoice) && Enum.IsDefined(typeof(Menu), userChoice))
                {
                    Menu selectedOption = (Menu)userChoice;

                    switch (selectedOption)
                    {
                        case Menu.AddTransaction:
                            Console.WriteLine("Добавление новой транзакции...");
                            FinanceManager.AddTransaction(1, 500, "Desc", TransactionType.Income);
                            break;

                        case Menu.GetAllTransaction:
                            Console.WriteLine("Получение всех транзакций...");
                            FinanceManager.GetTransactions(1);
                            break;

                        case Menu.TotalIncome:
                            Console.WriteLine("Расчет общего дохода...");
                            FinanceManager.GetTotalIncome(1);
                            break;

                        case Menu.TotalExpense:
                            Console.WriteLine("Расчет общих расходов...");
                            FinanceManager.GetTotalExpense(1);
                            break;

                        case Menu.FilterTransactions:
                            Console.WriteLine("Фильтрация транзакций...");
                            FinanceManager.FilterTransactions(1, TransactionType.Income, DateTime.Now.AddDays(-10), DateTime.Now);
                            break;

                        case Menu.ShowFinancialReport:
                            Console.WriteLine("Отображение финансового отчета...");
                            FinanceManager.PrintFinancialReport(1);
                            break;

                        case Menu.Exit:
                            Console.WriteLine("Выход из программы...");
                            exit = true;
                            break;

                        default:
                            Console.WriteLine("Выбрана недействительная опция.");
                            break;
                    }
                }
            }
        }

    }
    private static void DisplayMenu()
    {
        foreach (Menu option in Menu.GetValues(typeof(Menu)))
        {
            Console.WriteLine($"{(int)option}: {option}");
        }
    }

    public enum Menu
    {
        AddTransaction,
        GetAllTransaction,
        TotalIncome,
        TotalExpense,
        FilterTransactions,
        ShowFinancialReport,
        Exit
    }
}