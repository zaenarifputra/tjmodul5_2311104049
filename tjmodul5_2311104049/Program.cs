using System;
using System.Collections.Generic;


namespace tpmodul5_2311104049
{
    // Kelas Generic-Class
    class SimpleDataBase<T>
    {
        private List<T> storedData;
        private List<DateTime> inputDates;

        public SimpleDataBase()
        {
            storedData = new List<T>();
            inputDates = new List<DateTime>();
        }

        public void AddNewData(T data)
        {
            storedData.Add(data);
            inputDates.Add(DateTime.UtcNow);
        }

        public void PrintAllData()
        {
            for (int i = 0; i < storedData.Count; i++)
            {
                Console.WriteLine($"Data {i + 1} berisi: {storedData[i]}, yang disimpan pada waktu UTC: {inputDates[i]}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            SimpleDataBase<int> database = new SimpleDataBase<int>();

            Console.WriteLine("Masukkan tiga angka dua digit dari NIM:");

            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Masukkan angka ke-{i + 1}: ");
                int nimDigit;
                while (!int.TryParse(Console.ReadLine(), out nimDigit) || nimDigit < 10 || nimDigit > 99)
                {
                    Console.Write("Input tidak valid! Masukkan angka dua digit (10-99): ");
                }
                database.AddNewData(nimDigit);
            }

            Console.WriteLine("\nData yang telah dimasukkan:");
            database.PrintAllData();
            Console.ReadLine();
        }
    }
}
