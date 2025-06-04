namespace DirectoryInfo_FileInfo
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }

        public Department(int id , string name)
        {
            Id = id;
            Name = name;
            Employees = new List<Employee>();
        }

        public void AddEmployee(Employee employee)
        {
            Employees.Add(employee);
        }

        public Employee GetEmployeeById(int id)
        {
            foreach (var emp in Employees)
            {
                if(emp.Id == id) return emp;
            }
            return null;
        }

        public bool RemoveEmployee(int id)
        {
            var emp = GetEmployeeById(id);
            if (emp != null)
            {
                Employees.Remove(emp); return true;
            }
            return false;
        }

    }
}
