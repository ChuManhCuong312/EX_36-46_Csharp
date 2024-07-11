using System;
using System.Collections.Generic;
using System.Linq;

namespace BaiTap36
{
    // a. Tạo lớp trừu tượng Person
    public abstract class Person
    {
        private string _name;
        private string _id;

        // Thuộc tính Name
        public string Name
        {
            get { return _name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Tên không thể để trống.");
                }
                _name = value;
            }
        }

        // Thuộc tính Id
        public string Id
        {
            get { return _id; }
            set
            {
                // Kiểm tra giá trị trước khi gán
                if (value == null || value.Length != 8 || !value.All(char.IsDigit))
                {
                    throw new ArgumentException("ID phải có 8 chữ số và là số nguyên.");
                }
                _id = value;
            }
        }
    }

    // b. Tạo interface Kpi
    public interface Kpi
    {
        float kpi();
    }

    // c. Tạo lớp Student kế thừa từ Person và implement interface Kpi
    public class Student : Person, Kpi
    {
        private string _department;

        // Thuộc tính Department
        public string Department
        {
            get { return _department; }
            set
            {
                if (value != "ICT" && value != "ECO")
                {
                    throw new ArgumentException("Phòng ban phải là 'ICT' hoặc 'ECO'.");
                }
                _department = value;
            }
        }

        // Triển khai phương thức kpi từ interface Kpi
        public float kpi()
        {
            // Giả sử tính toán điểm KPI ở đây
            return 3.5f;
        }
    }

    // d. Hàm Main 
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            // e. Cấp phát obs là Student có name là "Nguyễn Tiến Dũng", id là "12345678", department là "ICT". Hiển thị kpi()
            try
            {
                Person obs = new Student
                {
                    Name = "Nguyễn Tiến Dũng",
                    Id = "12345678",
                    Department = "ICT"
                };

                if (obs is Student)
                {
                    Console.WriteLine($"KPI của sinh viên {obs.Name}: {(obs as Student).kpi()}");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // g. Cấp phát obs bị sai về id hoặc department và xem hiệu ứng.
            try
            {
                Person obs = new Student
                {
                    Name = "Nguyễn Văn A", // Tên hợp lệ
                    Id = "12345",          // ID không hợp lệ (không đủ 8 chữ số)
                    Department = "HR"      // Department không hợp lệ (không phải "ICT" hoặc "ECO")
                };
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            // h. Khai báo danh sách list1 và list2
            List<Person> list1 = new List<Person>();
            List<Person> list2 = new List<Person>();

            // i. Nhập danh sách list1 từ bàn phím cho sinh viên ngồi bàn 1 (lớp 23IT5 ngày 25/06/2024)
            Console.WriteLine("\nNhập danh sách sinh viên ngồi bàn 1 (lớp 23IT5 ngày 25/06/2024):");
            Console.WriteLine("Kết thúc nhập nếu nhập name là #");
            string inputName;
            do
            {
                Console.Write("Tên sinh viên: ");
                inputName = Console.ReadLine();
                if (inputName != "#")
                {
                    Student student = new Student();
                    student.Name = inputName;
                    Console.Write("ID (8 chữ số): ");
                    student.Id = Console.ReadLine();
                    Console.Write("Department (ICT hoặc ECO): ");
                    student.Department = Console.ReadLine();
                    list1.Add(student);
                }
            } while (inputName != "#");

            // j. Nhập danh sách list2 từ bàn phím cho sinh viên ngồi bàn 2 (lớp 23IT6 ngày 25/06/2024)
            Console.WriteLine("\nNhập danh sách sinh viên ngồi bàn 2 (lớp 23IT6 ngày 25/06/2024):");
            Console.WriteLine("Kết thúc nhập nếu nhập name là #");
            do
            {
                Console.Write("Tên sinh viên: ");
                inputName = Console.ReadLine();
                if (inputName != "#")
                {
                    Student student = new Student();
                    student.Name = inputName;
                    Console.Write("ID (8 chữ số): ");
                    student.Id = Console.ReadLine();
                    Console.Write("Department (ICT hoặc ECO): ");
                    student.Department = Console.ReadLine();
                    list2.Add(student);
                }
            } while (inputName != "#");

            // k. Khai báo list_list là List của List và thêm list1, list2 vào list_list
            List<List<Person>> list_list = new List<List<Person>>();
            list_list.Add(list1);
            list_list.Add(list2);

            // l. Tạo Dictionary dic11 cho list1 Student với trường khóa id
            Dictionary<string, Student> dic11 = new Dictionary<string, Student>();
            foreach (var person in list1)
            {
                if (person is Student student)
                {
                    dic11.Add(student.Id, student);
                }
            }

            // m. Tìm trong dic11 sinh viên có tên là "Nam" và hiển thị thông tin của họ
            Console.WriteLine("\nSinh viên có tên là \"Nam\" trong list1:");
            foreach (var student in dic11.Values)
            {
                if (student.Name.Contains("Nam"))
                {
                    Console.WriteLine($"Tên: {student.Name}, ID: {student.Id}, Department: {student.Department}");
                }
            }

            // Hiển thị các danh sách và dictionaries
            Console.WriteLine("\nDanh sách sinh viên ngồi bàn 1:");
            foreach (var person in list1)
            {
                if (person is Student student)
                {
                    Console.WriteLine($"Tên: {student.Name}, ID: {student.Id}, Department: {student.Department}");
                }
            }

            Console.WriteLine("\nDanh sách sinh viên ngồi bàn 2:");
            foreach (var person in list2)
            {
                if (person is Student student)
                {
                    Console.WriteLine($"Tên: {student.Name}, ID: {student.Id}, Department: {student.Department}");
                }
            }

            Console.WriteLine("\nDanh sách list_list:");
            for (int i = 0; i < list_list.Count; i++)
            {
                Console.WriteLine($"List {i + 1}:");
                foreach (var person in list_list[i])
                {
                    if (person is Student student)
                    {
                        Console.WriteLine($"Tên: {student.Name}, ID: {student.Id}, Department: {student.Department}");
                    }
                }
            }
        }
    }
}
