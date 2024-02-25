using System;
using System.Collections.Generic;

public class Account
{
    public string AccountNumber { get; set; }
    public string CustomerID { get; set; }
    public string CustomerName { get; set; }
    public decimal Balance { get; set; }
    public decimal InterestRate { get; set; }

    public Account(string accountNumber, string customerID, string customerName, decimal balance, decimal interestRate)
    {
        AccountNumber = accountNumber;
        CustomerID = customerID;
        CustomerName = customerName;
        Balance = balance;
        InterestRate = interestRate;
    }

    public void Deposit(decimal amount, DateTime transactionDate)
    {
        Balance += amount;
        Console.WriteLine($"Đã nhập {amount} Euros vào tài khoản số {AccountNumber} vào ngày {transactionDate.ToShortDateString()}");
    }

    public void Withdraw(decimal amount, DateTime transactionDate)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            Console.WriteLine($"Đã rút {amount} Euros từ tài khoản số {AccountNumber} vào ngày {transactionDate.ToShortDateString()}");
        }
        else
        {
            Console.WriteLine($"Không đủ số dư trong tài khoản số {AccountNumber} để rút {amount} Euros");
        }
    }

    public void PrintAccountInfo()
    {
        Console.WriteLine($"Thông tin tài khoản số {AccountNumber}:");
        Console.WriteLine($"- Chủ tài khoản: {CustomerName}");
        Console.WriteLine($"- Số tiền hiện có: {Balance} Euros");
    }
}

public class Bank
{
    private List<Account> accounts;

    public Bank()
    {
        accounts = new List<Account>();
    }

    public void OpenAccount(string accountNumber, string customerID, string customerName, decimal balance, decimal interestRate)
    {
        Account account = new Account(accountNumber, customerID, customerName, balance, interestRate);
        accounts.Add(account);
        Console.WriteLine($"Đã mở tài khoản mới cho {customerName} với số tài khoản {accountNumber}");
    }

    public Account FindAccount(string accountNumber)
    {
        foreach (Account account in accounts)
        {
            if (account.AccountNumber == accountNumber)
            {
                return account;
            }
        }

        return null;
    }

    public void Deposit(string accountNumber, decimal amount, DateTime transactionDate)
    {
        Account account = FindAccount(accountNumber);
        if (account != null)
        {
            account.Deposit(amount, transactionDate);
        }
        else
        {
            Console.WriteLine($"Không tìm thấytài khoản có số hiệu {accountNumber}");
        }
    }

    public void Withdraw(string accountNumber, decimal amount, DateTime transactionDate)
    {
        Account account = FindAccount(accountNumber);
        if (account != null)
        {
            account.Withdraw(amount, transactionDate);
        }
        else
        {
            Console.WriteLine($"Không tìm thấy tài khoản có số hiệu {accountNumber}");
        }
    }

    public void CalculateInterest()
    {
        foreach (Account account in accounts)
        {
            decimal interest = account.Balance * account.InterestRate / 100;
            account.Balance += interest;
        }
        Console.WriteLine("Đã tính lãi suất cho tất cả các tài khoản");
    }

    public void PrintReport()
    {
        Console.WriteLine("Báo cáo tài khoản:");
        foreach (Account account in accounts)
        {
            account.PrintAccountInfo();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Bank bank = new Bank();

        // Mở tài khoản mới
        bank.OpenAccount("001", "901", "Alice", 100, 5);
        bank.OpenAccount("002", "902", "Bob", 50, 5);
        bank.OpenAccount("003", "901", "Alice", 200, 10);
        bank.OpenAccount("004", "903", "Eve", 200, 10);

        // Nhập tiền vào tài khoản
        bank.Deposit("001", 100, new DateTime(2005, 7, 15));
        bank.Deposit("001", 100, new DateTime(2005, 7, 31));
        bank.Deposit("002", 150, new DateTime(2005, 7, 1));
        bank.Deposit("002", 150, new DateTime(2005, 7, 15));
        bank.Deposit("003", 200, new DateTime(2005, 7, 5));
        bank.Deposit("004", 250, new DateTime(2005, 7, 31));

        // Rút tiền từ tài khoản
        bank.Withdraw("001", 10, new DateTime(2005, 7, 10));
        bank.Withdraw("002", 20, new DateTime(2005, 7, 15));
        bank.Withdraw("003", 30, new DateTime(2005, 7, 31));
        bank.Withdraw("004", 40, new DateTime(2005, 7, 31));

        // Tính lãi suất và in báo cáo
        bank.CalculateInterest();
        bank.PrintReport();

        Console.ReadKey();
    }
}

