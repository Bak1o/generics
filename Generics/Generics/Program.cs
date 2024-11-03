using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Generics;


//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის პირველივე შემხვედრი ობიექტის ინდექსს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ბოლო შემხვედრი ობიექტის ინდექსს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ყველა შემხვედრი ობიექტის ინდექსებს დაა დააბრუნებს ინდექსების ლისტს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ობიექტს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ბოლო ობიექტს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ყველა ობიექტს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ობიექტის მაქსიმალურ მნიშვნელობას.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ობიექტის მინიმალურ მნიშვნელობას.

delegate bool ProductChecker(Product product);
delegate bool CustomPredicate<T>(T element);
internal class Program
{
    public static void Main(string[] args)
    {
      
        var productService = new ProductService();
        var products = productService.GetProducts();
        
        


      var indexFirst =  IndexOfFirstEqualElement(products, p => p.Id == 2);
       var  indexLast = IndexOfLastEqualElement(products, p => p.Name == "Airpod");
        Console.WriteLine();

        Console.WriteLine($" index of First equal elements : {indexFirst} ");
        Console.WriteLine($" index of Last equal elements : {indexLast} ");
        Console.WriteLine();

        Console.Write(" List of indexes of equal elements : ");
        var indexes = GetListOfIndexes(products, p => p.Name == "Airpod");
        foreach (var item in indexes)
        {
            Console.Write($" [{item}] ");
        }
        Console.WriteLine();
        Console.WriteLine();
        var product = GetObject(products, p => p.Id == 3);
        Console.WriteLine($"Get equal element in the list : [{product}] ");
        Console.WriteLine();
        Console.WriteLine();

        var lastElement = GetLastElement(products);

        Console.WriteLine($" Last Element in the List : [{lastElement}]");
        Console.WriteLine();
        Console.WriteLine(" All elements in the list ");
       
        var allProducts = GetAlltElements(products);

        

        foreach (var item in allProducts)
        {
            Console.WriteLine($"[{item}]");
        }
        Console.WriteLine();
        Console.WriteLine();

        var maxPrice = MaxPrice(products);
        Console.WriteLine($"Max price non generic way : {maxPrice}");
        Console.WriteLine();
        var minPrice = MinPrice(products);
        Console.WriteLine($"Min price non generic way : {minPrice}");
        Console.WriteLine();
        Console.WriteLine();


        //  აქ ფასების ლისტი შევქმენი პროდუქტის ლისტიდან

        var prices = Transform(products, p => p.Price);

        //    შ ე კ ი თ ხ ვ ა
        // ქვემოთ აგრეგატის ფუნქცია რომ არის სამივე ტე სხვადასხვა ტიპის შეიძლება იყოს ხომ?

        // ტეებს რომ მივანიჭე TResult, T1 და T2
        // TResult result = seed  ამაზე ერრორი ამოაგდო TResult-ს T2 ში ვერ გადავიყვანო
        // ანუ სხვადასხვა სახელიტ ტეებს სხვადასხვა ტიპებად არიქვამს, მაგრამ T სახელით ბევრ ადგილას სხვადასხვა ტიპებზე 
        // პრობლემა არ აქვს?

        var max = Aggregate(prices, prices[0], (result, itemValue) => itemValue > result ? itemValue : result);
        var min = Aggregate(prices, prices[0], (result, itemValue) => itemValue < result ? itemValue : result);


        Console.WriteLine($" Maximum Price Generic way : {max}");
        Console.WriteLine($" Minimum Price Generic way : {min}");



    }

    public static int IndexOfFirstEqualElement(IList<Product> source, ProductChecker check)
    {
        for (int i = 0; i < source.Count; i++)
        {
            if (check(source[i]))
            {
                return i;   
            }
        }
        return -1;
    }

    public static int IndexOfLastEqualElement(IList<Product> source, ProductChecker check)
    {
        for (int i = source.Count - 1; i >= 0; i--)
        {
            if (check(source[i]))
            {
                return i;
            }
        }
        return -1;
    }

    public static List<int> GetListOfIndexes(IList<Product> source,ProductChecker check)
    {
        var indexes = new List<int>();
        for (int i = 0; i < source.Count; i++)
        {
            if (check(source[i]))
            {
                indexes.Add(i);
            }
              
        }
        return indexes;
    }
    public static T GetObject<T>(IList<T> source, CustomPredicate<T> check)
    {
        foreach (var item in source)
        {
            if (check(item))
            {
                return item;
            }

        }
        return default;
    }

    public static List<T> GetAlltElements<T>(IList<T> source)
    {
        var indexes = new List<T>();
        for (int i = 0; i < source.Count; i++)
        {

            indexes.Add(source[i]);
            

        }
        return indexes;
    }
    public static T GetLastElement<T>(IList<T> source)
    {
        return source[source.Count - 1];
    }

    public static T Aggregate<T>(List<T> source, T seed, Func<T, T, T> function)
    {
        T result =  seed;

        foreach (var item in source)
        {
            result = function(result, item);
        }
        return result;
    }

    public static decimal MaxPrice(List<Product> source)
    {
        var result = source[0].Price;
        foreach (Product item in source)
        {
            result = item.Price > result ? item.Price : result;
        }
        return result;
    }

    public static decimal MinPrice(List<Product> source)
    {
        var result = source[0].Price;
        foreach (Product item in source)
        {
            result = item.Price < result ? item.Price : result;
        }
        return result;
    }

    public static List<TResult> Transform<TSource,TResult>(List<TSource> source, Func<TSource, TResult> transorm)
    {
        var results = new List<TResult>();
        foreach (var item in source)
        {
            TResult result = transorm(item);
            results.Add(result);
        }
        return results;
    }








}

