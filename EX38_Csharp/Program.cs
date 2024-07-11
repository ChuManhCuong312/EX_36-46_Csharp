using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Tạo một danh sách các số thực 4 byte
        List<float> listf = new List<float>();
        
        // Bổ sung các phần tử vào cuối danh sách
        listf.Add(3.5f);
        listf.Add(-1.2f);
        listf.Add(7.8f);
        listf.Add(-5.0f);
        
        // Hiển thị các phần tử của danh sách theo chỉ số
        Console.WriteLine("Danh sách ban đầu:");
        for (int i = 0; i < listf.Count; i++)
        {
            Console.WriteLine(listf[i]);
        }
        
        // Sắp xếp danh sách theo thứ tự tăng dần
        listf.Sort();
        
        // Hiển thị danh sách sau khi sắp xếp
        Console.WriteLine("Danh sách sau khi sắp xếp:");
        for (int i = 0; i < listf.Count; i++)
        {
            Console.WriteLine(listf[i]);
        }
    }
}
