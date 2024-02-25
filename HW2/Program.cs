using System;
using System.Collections.Generic;

class Person
{
    public string Name;
    public string Address;
    public decimal Salary;
}
class Program
{
    static void Main()
    {
        List<Person> personList = new List<Person>();

        // Hàm 1: Hiển thị giao diện người dùng và Nhập dữ liệu
        Console.WriteLine("Nhập thông tin cá nhân:");

        for (int i = 0; i < 3; i++)
        {
            Person person = new Person();

            Console.WriteLine($"Nhập thông tin của người thứ {i + 1}:");
            Console.Write("Tên: ");
            person.Name = Console.ReadLine();

            Console.Write("Địa chỉ: ");
            person.Address = Console.ReadLine();

            decimal salary =0;
            bool isValidSalary = false;
            while (!isValidSalary)
            {
                Console.Write("Lương: ");
                string salaryInput = Console.ReadLine();
                isValidSalary = decimal.TryParse(salaryInput, out salary);

                if (!isValidSalary)
                {
                    Console.WriteLine("Lương không hợp lệ. Vui lòng nhập lại.");
                }
            }
            person.Salary = salary;

            personList.Add(person);
        }

        // Hàm 2: Thực hiện chức năng
        Console.WriteLine("\nThông tin cá nhân đã nhập:");
        foreach (Person person in personList)
        {
            Console.WriteLine($"Tên: {person.Name}");
            Console.WriteLine($"Địa chỉ: {person.Address}");
            Console.WriteLine($"Lương: {person.Salary}\n");
        }

        personList.Sort((p1, p2) => p1.Salary.CompareTo(p2.Salary));

        Console.WriteLine("3 người có lương thấp nhất:");
        for (int i = 0; i < 3 && i < personList.Count; i++)
        {
            Person person = personList[i];
            Console.WriteLine($"Tên: {person.Name}");
            Console.WriteLine($"Địa chỉ: {person.Address}");
            Console.WriteLine($"Lương: {person.Salary}\n");
        }

        Console.ReadKey();
    }
}