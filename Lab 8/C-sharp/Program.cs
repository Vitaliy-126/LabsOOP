using System;
using DataStructures;
namespace C_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            SinglyLinkedList list = new SinglyLinkedList();
            int size;
            Console.Write("Введите кол-во чисел для генерации: ");
            while(!int.TryParse(Console.ReadLine(),out size)||size<0)
            {
                Console.Write("Вы ошиблись с вводом, попробуйте ещё раз: ");
            }
            Random random = new Random();
            Console.Write("Сгенерированные числа: ");
            for(int i = 0; i < size; i++)
            {
                short number = (short)random.Next(-100, 101);
                list.Add(number);
                Console.Write(number.ToString()+" ");
            }
            Console.WriteLine();
            Console.WriteLine("Односвязный список: ");
            for(int i = 0; i < list.Size; i++)
            {
                Console.Write(list[i]+" ");
            }
            Console.WriteLine();
            Console.WriteLine($"Кол-во чисел кратных 3: {list.QuantityMultiplesOfThree()}");
            list.RemoveLargeForAverage();
            Console.WriteLine("Список после удаления елементов, которые больше за среднее значение:");
            for (int i = 0; i < list.Size; i++)
            {
                Console.Write(list[i]+" ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
