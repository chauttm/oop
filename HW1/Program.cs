using System;
using System.Text;

class Person
{
    public string HoTen;
    public string MaSV;
    public string Lop;
    public string UsernameGithub;
    public string Email;

    public void PrintInfo()
    {
        Console.WriteLine(HoTen + "\t" + MaSV + "\t" + Lop + "\t" + UsernameGithub + "\t" + Email);
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Person person = new Person();
        person.HoTen = "Phạm Tùng Dương";
        person.MaSV = "12522018";
        person.Lop = "12422TN";
        person.UsernameGithub = "Tùng Dương24";
        person.Email = "Duongpham230524@gmail.com";

        person.PrintInfo();
        Console.ReadKey();
    }
}