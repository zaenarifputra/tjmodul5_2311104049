using System;
using System.Collections.Generic;

namespace tjmodul5_2311104049
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

    // Kelas Generic Penjumlahan
    class Penjumlahan
    {
        // Method Generic untuk menjumlahkan 3 angka
        public void JumlahTigaAngka<T>(T angka1, T angka2, T angka3)
        {
            dynamic a = angka1;
            dynamic b = angka2;
            dynamic c = angka3;

            dynamic hasil = a + b + c;

            Console.WriteLine($"Hasil penjumlahan: {hasil}");
        }
    }

    class Program
    {
        static void Main()
        {
            SimpleDataBase<int> database = new SimpleDataBase<int>();

            Console.WriteLine("== Program SimpleDataBase ==\n");
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

            Console.WriteLine("\n== Program Penjumlahan ==\n");
            Console.Write("\nMasukkan NIM Anda: ");
            string nim = Console.ReadLine();

            if (nim.Length < 8)
            {
                Console.WriteLine("NIM harus memiliki minimal 8 digit.");
                return;
            }

            // Ambil 3 bagian pertama dari NIM (2 digit pertama, kedua, dan ketiga)
            string angka1 = nim.Substring(0, 2);
            string angka2 = nim.Substring(2, 2);
            string angka3 = nim.Substring(4, 2);

            // Ambil digit terakhir dari NIM
            char lastDigit = nim[nim.Length - 1];

            Penjumlahan penjumlahan = new Penjumlahan();

            // Menentukan tipe data berdasarkan aturan dari soal
            if (lastDigit == '1' || lastDigit == '2')
            {
                float num1 = float.Parse(angka1);
                float num2 = float.Parse(angka2);
                float num3 = float.Parse(angka3);
                penjumlahan.JumlahTigaAngka(num1, num2, num3);
            }
            else if (lastDigit == '3' || lastDigit == '4' || lastDigit == '5')
            {
                double num1 = double.Parse(angka1);
                double num2 = double.Parse(angka2);
                double num3 = double.Parse(angka3);
                penjumlahan.JumlahTigaAngka(num1, num2, num3);
            }
            else if (lastDigit == '6' || lastDigit == '7' || lastDigit == '8')
            {
                int num1 = int.Parse(angka1);
                int num2 = int.Parse(angka2);
                int num3 = int.Parse(angka3);
                penjumlahan.JumlahTigaAngka(num1, num2, num3);
            }
            else if (lastDigit == '9' || lastDigit == '0')
            {
                long num1 = long.Parse(angka1);
                long num2 = long.Parse(angka2);
                long num3 = long.Parse(angka3);
                penjumlahan.JumlahTigaAngka(num1, num2, num3);
            }
            else
            {
                Console.WriteLine("Digit terakhir NIM tidak valid.");
            }

            Console.ReadLine();
        }
    }
}
