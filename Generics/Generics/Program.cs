namespace Generics;


//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის პირველივე შემხვედრი ობიექტის ინდექსს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ბოლო შემხვედრი ობიექტის ინდექსს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ყველა შემხვედრი ობიექტის ინდექსებს დაა დააბრუნებს ინდექსების ლისტს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ობიექტს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ბოლო ობიექტს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ყველა ობიექტს.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ობიექტის მაქსიმალურ მნიშვნელობას.
//დაწერეთ ფუნქცია რომელიც ლისტში იპოვის ობიექტის მინიმალურ მნიშვნელობას.


internal class Program
{
    public static void Main(string[] args)
    {
        List<int> list = new List<int>() { 20, 30, 40, 30, 50};
       var index = IndexOfFirstEqualElement(list, 30); 
        var index2 = IndexOfLastEqualElement(list, 30);
        Console.Write(" index of first equal element : ");
        Console.Write(index);
        Console.WriteLine();
        Console.Write(" index of last equal element : ");
        Console.WriteLine(index2);
        Console.WriteLine();
        Console.Write("list of indexes : ");
        List<int> indexes = ListOfIndexes(list, 30);
        foreach (var item in indexes)
        {
            Console.Write($" [{item}] ");
        }
        Console.WriteLine();
        var lastElement = ElementAtLastIndex(list);
        Console.Write("element at last index : ");
        Console.Write(lastElement);

        Console.WriteLine();
        Console.Write(" every element of list : ");
        EveryElemet(list);

        Console.WriteLine();
        Console.Write(" max element of list : ");
        Console.Write(MaxElement(list));
        Console.WriteLine();
        Console.Write("Min element of list : ");
        Console.WriteLine(MinElement(list));

    }

    public static int IndexOfFirstEqualElement<T>(IList<T> collection, T value)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].Equals(value))
            {
                return i;
            }

        }
        return -1;
    }
    public static int IndexOfLastEqualElement<T>(IList<T> collection, T value)/* where T : IComparable<T>*/
    {
        for (int i = collection.Count - 1; i >= 0; i--)
        {
            if (collection[i].Equals(value))
            {
                return i;
            }

        }
        return -1;
    }
    public static List<int> ListOfIndexes<T>(IList<T> collection, T value) 
    {
        List<int> indexes = new List<int>();
        for (int i = 0; i < collection.Count; i++)
        {
            if (collection[i].Equals(value))
            {
                indexes.Add(i);
                
            }

        }
        return indexes;

    }

    public static T ElementAtLastIndex<T>(IList<T> collection)
    {
        
     return collection[collection.Count - 1];
        
    }
    public static void EveryElemet<T>(IList<T> collection)
    {
        for (int i = 0; i < collection.Count; i++)
        {
            Console.Write($" [{collection[i]}] ");
        }
    }

        public static T MaxElement<T>(List<T> collection)
    {
       collection.Sort();
        return collection[collection.Count - 1];

    }

    public static T MinElement<T>(List<T> collection)
    {
        collection.Sort();
        return collection[0];

    }






}

