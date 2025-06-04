namespace DirectoryInfo_FileInfo
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id} , Name: {Name} , Salary: {Salary}");
        }
    }
}
