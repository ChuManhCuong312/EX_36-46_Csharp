using System;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        // Khởi tạo List of List
        List<List<string>> myList = new List<List<string>>();
        myList.Add(new List<string> { "a", "b" });
        myList.Add(new List<string> { "c", "d", "e" });
        myList.Add(new List<string> { "qwerty", "asdf", "zxcv" });
        myList.Add(new List<string> { "a", "b" });

        // Duyệt qua các phần tử trong myList sử dụng for
        for (int i = 0; i < myList.Count; i++)
        {
            List<string> subList = myList[i];
            for (int j = 0; j < subList.Count; j++)
            {
                string item = subList[j];
                Console.WriteLine(item);
            }
        }
    }
}
