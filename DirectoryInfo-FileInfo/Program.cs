using Microsoft.VisualBasic;
using System.Text.Json;
using System.Xml;

namespace DirectoryInfo_FileInfo
{
    internal class Program
    {
        static string path = "C:\\Users\\Gasimoff\\OneDrive\\Masaüstü\\DirectoryInfo-FileInfo\\DirectoryInfo-FileInfo\\Files";
        static string filepath = Path.Combine(path, "Database.json");
        static void Main(string[] args)
        {
            Department firstdepartment = new(1, "CS");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            if (!File.Exists(filepath))
            {
                string json = JsonSerializer.Serialize(firstdepartment);
                File.WriteAllText(filepath, json);
            }
            while (true)
            {
                Console.WriteLine("Menu");
                Console.WriteLine("1. Add employee");
                Console.WriteLine("2. Get employee by id");
                Console.WriteLine("3. Remove employee");
                Console.WriteLine("0. Quit");
                Console.Write("Emeliyyati sechin: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddEmployee(firstdepartment);
                        break;
                    case "2":
                        GetEmployee(firstdepartment);
                        break;
                    case "3":
                        RemoveEmployee(firstdepartment);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Yanlish sechim.");
                        break;
                }
            }
        }
        static void AddEmployee(Department department)
        {
            Console.WriteLine("Ishci ID-sini daxil edin: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Ishcinin adi: ");
            string name = Console.ReadLine();
            Console.WriteLine("Emek haqqi: ");
            double salary = double.Parse(Console.ReadLine());

            Employee employee = new Employee();
            employee.Id = id;
            employee.Name = name;
            employee.Salary = salary;
            department.AddEmployee(employee);

            string json = JsonSerializer.Serialize(department.Employees);
            File.WriteAllText(filepath, json);
            Console.WriteLine("Ishci elave edildi");

        }
        static void GetEmployee(Department department)
        {
            Console.Write("Ishci ID-sini daxil edin: ");
            int id = int.Parse(Console.ReadLine());

            Employee employee = department.GetEmployeeById(id);
            if (employee != null)
                employee.ShowInfo();
            else
                Console.WriteLine("Ishci tapilmadi.");
        }

        static void RemoveEmployee(Department department)
        {
            Console.Write("Silmek istediyiniz Ishcinin ID-sini yazin: ");
            int id = int.Parse(Console.ReadLine());

            if (department.RemoveEmployee(id))
            {
                string json = JsonSerializer.Serialize(department.Employees);
                File.WriteAllText(filepath, json);
                Console.WriteLine("Ishci cixarildi ve fayl yenilendi.");
            }
            else
                Console.WriteLine("Ishci tapilmadi.");
        }
    }
}
