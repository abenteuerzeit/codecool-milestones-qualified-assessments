using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpMilestone
{
    public enum EmployeeRole : byte
    {
        FrontendDeveloper,
        BackendDeveloper,
        ManualTester,
        UiUxDesigner,
        ScrumMaster,
        ProductOwner
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public EmployeeRole Role { get; set; }

        public Employee(int id, string name, int salary, EmployeeRole role)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Role = role;
        }
    }

    public class Division
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee Manager { get; set; }
        public Employee[] Employees { get; set; }
    }

    public static class LinqMethods
    {
        /// <summary>
        ///     Get the employee with given ID
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Employee GetEmployeeById(IEnumerable<Employee> employees, int id)
            => employees.FirstOrDefault(x => x.Id == id);

        /// <summary>
        ///     Return the total amount of money required to pay all given employees
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static int GetTotalSalaryBudget(IEnumerable<Employee> employees)
            => employees.Select(x => x.Salary).Sum();

        /// <summary>
        ///     Get the best earning employee
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static Employee GetBestEarningEmployee(IEnumerable<Employee> employees)
            => employees.OrderByDescending(x => x.Salary).FirstOrDefault();
           
        
        /// <summary>
        ///     Get names of all employees of given role
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetNamesOfEmployeesOfRole(IEnumerable<Employee> employees, EmployeeRole role)
            => employees.Where(x => x.Role == role).Select(x => x.Name);


        /// <summary>
        ///     Get the average value of salaries of all employees of given role
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="role"></param>
        /// <returns></returns>
        public static double GetAverageSalaryOfRole(IEnumerable<Employee> employees, EmployeeRole role)
            => employees.Where(x => x.Role == role).Select(x => x.Salary).Average();

        /// <summary>
        ///     Get the role that has least employees
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public static EmployeeRole GetRoleWithLeastEmployees(IEnumerable<Employee> employees)
        {
            var groupByRole = employees.GroupBy(x => x.Role);
            var minCount = groupByRole.Min(x => x.Count());
            return groupByRole.First(x => x.Count() == minCount).Key;
        }


        /// <summary>
        ///     Get the division with greatest pay gap between its manager and employees
        ///     Pay Gap formula: Manager_Salary - Average_Employees_Salary
        /// </summary>
        /// <param name="divisions"></param>
        /// <returns></returns>
       public static Division GetDivisionWithGreatestManagerEmployeePayGap(IEnumerable<Division> divisions)
        {
            var payGaps = divisions.Select(x => new
            {
                Division = x,
                PayGap = x.Manager.Salary - x.Employees.Average(e => e.Salary)
            });

            return payGaps.OrderByDescending(x => x.PayGap).First().Division;
        }

        /// <summary>
        ///     Get the best earning employee of given role
        /// </summary>
        /// <param name="employees"></param>
        /// <param name="role"></param>
        /// <returns></returns>
public static Employee GetBestEarningEmployeeOfRole(Division[] divisions, EmployeeRole role)
    => divisions.SelectMany(d => d.Employees).Where(x => x.Role == role).OrderByDescending(x => x.Salary).FirstOrDefault();

        /// <summary>
        ///     Get the division with the highest total employee salary
        /// </summary>
        /// <param name="divisions"></param>
        /// <returns></returns>
        public static Division GetDivisionWithHighestTotalEmployeeSalary(IEnumerable<Division> divisions)
        {
            var totalSalaries = divisions.Select(x => new
            {
                Division = x,
                TotalSalary = x.Employees.Sum(e => e.Salary)
            });

            return totalSalaries.OrderByDescending(x => x.TotalSalary).First().Division;
        }
    }
}
