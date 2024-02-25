using System;
using System.Collections.Generic;

public class Item
{
    public string Name;
    public double Price;
    public double Discount;

    public Item(string name, double price, double discount)
    {
        Name = name;
        Price = price;
        Discount = discount;
    }
}

public class BillLine
{
    public Item Product;
    public int Quantity;

    public BillLine(Item product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public double GetTotal()
    {
        double priceAfterDiscount = Product.Price - Product.Discount;
        return priceAfterDiscount * Quantity;
    }
}

public class GroceryBill
{
    protected List<BillLine> productList;

    public GroceryBill()
    {
        productList = new List<BillLine>();
    }

    public void AddProduct(Item product, int quantity)
    {
        BillLine billLine = new BillLine(product, quantity);
        productList.Add(billLine);
    }

    public double GetTotal()
    {
        double total = 0;
        foreach (BillLine billLine in productList)
        {
            total += billLine.GetTotal();
        }
        return total;
    }

    public void PrintBill()
    {
        Console.WriteLine("Hóa đơn mua hàng:");
        foreach (BillLine billLine in productList)
        {
            Console.WriteLine($"Hàng hóa: {billLine.Product.Name}, Giá: {billLine.Product.Price}, Số lượng: {billLine.Quantity}, Tổng tiền: {billLine.GetTotal()}");
        }
        Console.WriteLine($"Tổng cộng: {GetTotal()}");
    }
}

public class DiscountBill : GroceryBill
{
    private bool customerDiscount;

    public DiscountBill(bool customerDiscount)
    {
        this.customerDiscount = customerDiscount;
    }

    public int GetDiscountedProductCount()
    {
        int count = 0;
        foreach (BillLine billLine in productList)
        {
            if (billLine.Product.Discount > 0)
            {
                count += billLine.Quantity;
            }
        }
        return count;
    }

    public double GetDiscountAmount()
    {
        double discountAmount = 0;
        foreach (BillLine billLine in productList)
        {
            discountAmount += billLine.Product.Discount * billLine.Quantity;
        }
        return discountAmount;
    }

    public double GetDiscountPercentage()
    {
        double totalAmount = GetTotal();
        if (totalAmount > 0)
        {
            double discountAmount = GetDiscountAmount();
            return (discountAmount / totalAmount) * 100;
        }
        return 0;
    }
}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Chương trình thanh toán hóa đơn");
        Console.WriteLine("--------------------");

        // Tạo đối tượng GroceryBill
        GroceryBill groceryBill = new GroceryBill();

        // Nhập thông tin sản phẩm và số lượng từ người dùng
        Console.Write("Nhập tên sản phẩm: ");
        string productName = Console.ReadLine();

        Console.Write("Nhập giá sản phẩm: ");
        double productPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập giảm giá sản phẩm: ");
        double productDiscount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập số lượng sản phẩm: ");
        int productQuantity = Convert.ToInt32(Console.ReadLine());

        // Tạo đối tượng Item từ thông tin nhập vào
        Item product = new Item(productName, productPrice, productDiscount);
        groceryBill.AddProduct(product, productQuantity);

        // In hóa đơn
        Console.WriteLine();
        groceryBill.PrintBill();

        // Tạo đối tượng DiscountBill cho khách hàng có giảm giá
        Console.WriteLine();
        Console.WriteLine("Chương trình thanh toán hóa đơn có giảm giá");
        Console.WriteLine("-----------------------");

        Console.Write("Bạn có giảm giá không? (true/false): ");
        bool hasDiscount = Convert.ToBoolean(Console.ReadLine());

        DiscountBill discountBill = new DiscountBill(hasDiscount);

        // Nhập thông tin sản phẩm và số lượng từ người dùng
        Console.Write("Nhập tên sản phẩm: ");
        productName = Console.ReadLine();

        Console.Write("Nhập giá sản phẩm: ");
        productPrice = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập giảm giá sản phẩm: ");
        productDiscount = Convert.ToDouble(Console.ReadLine());

        Console.Write("Nhập số lượng sản phẩm: ");
        productQuantity = Convert.ToInt32(Console.ReadLine());

        // Tạo đối tượng Item từ thông tin nhập vào
        product = new Item(productName, productPrice, productDiscount);
        discountBill.AddProduct(product, productQuantity);

        // In hóa đơn có giảm giá
        Console.WriteLine();
        discountBill.PrintBill();

        // In thông tin giảm giá
        Console.WriteLine();
        Console.WriteLine($"Số sản phẩm được giảm giá: {discountBill.GetDiscountedProductCount()}");
        Console.WriteLine($"Số tiền giảm giá: {discountBill.GetDiscountAmount()}");
        Console.WriteLine($"Tỷ lệ giảm giá: {discountBill.GetDiscountPercentage()}%");

        Console.WriteLine("Nhấn phím bất kỳ để thoát...");
        Console.ReadKey();
    }
}
