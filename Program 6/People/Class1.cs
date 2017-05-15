using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Text.RegularExpressions;
using System.IO;

namespace People
{
    #region Employee name and age
    public abstract class Employee : IComparable<Employee>
    {
        internal object Income;

        public String Name { get; set; }
        public int Age { get; set; }
        public Employee(String name, int age)
        {
            Name = name;
            Age = age;
        }

        public int CompareTo(Employee e)
        {
            return Name.CompareTo(e.Name);
        }
        public Employee() : this("", 0) { }

        
        public override string ToString()
        {
            return String.Format("{0} {1}", Name, Age);
        }
        public abstract Decimal GetIncome();
    }
    #endregion

    public class SalaryEmployee : Employee // derive from a class to another class. inhereted. doesnt work on constructors

    {
        public decimal Salary { get; set; }
        public SalaryEmployee(String name, int age, decimal salary) : base(name, age)
        {
            Salary = salary;
        }


        public SalaryEmployee() : this("", 0, 24000) { }


        public override string ToString()
        {
            return base.ToString() +
                String.Format("0:f2", Salary);
        }

        public override Decimal GetIncome() { return Salary; }
    }
    public class HourlyEmployee : Employee

    {
        public decimal Hours { get; set; }
        public decimal Wage {get; set; }
        public HourlyEmployee(String name, int age, decimal wage, decimal hrs) : base(name, age)
        {
            Hours = hrs;
            Wage = wage;
        }
        public HourlyEmployee() : this("", 0, 12.50m, 40) { }

        public override string ToString()
        {
            return base.ToString() +
            String.Format("{0:f2} {1:f2}", Wage, Hours);
        }

        public override Decimal GetIncome()
        {
            
            {
                return Wage * Hours *52;
            }
        }
    }


    public class EmployeeList
    {
        List<Employee> employees = new List<Employee>();

        public int Length { get { return employees.Count; } }

    
    // you can use [] notation for any type of collection
    // and the reason this works is because of indexers
    


    public Employee this[int n]
        {
            get { return employees[n]; }


            set { employees[n] = value; }

        }


        public void Add(Employee emp)

        {
            employees.Add(emp);
        }

        public void AddRange(String s)


        {
            

            String[] data = System.Text.RegularExpressions.Regex.Split(s.Trim(), @"\s+");


            employees.Clear();

            for (int i = 0; i < data.Length; i += 3)
                if (i + 3 < data.Length && Regex.IsMatch(data[i + 3], @"\d+(\.\d*)?"))
                {
                    employees.Add(
                        new HourlyEmployee(
                            data[i],
                            Convert.ToInt32(data[i + 1]),
                            Convert.ToDecimal(data[i + 2]),
                            Convert.ToDecimal(data[i + 3])
                            ));
                    i++;
                }

                else
                    employees.Add(
                        new SalaryEmployee(
                            data[i],
                            Convert.ToInt32(data[i + 1]),
                            Convert.ToDecimal(data[i + 2])));
        }

        public void Clear()

        {
            employees.Clear();
        }
        public void SortByName()
        {
            employees.Sort((e1, e2) => e2.Name.CompareTo(e1.Name));
        }
        public void SortByAge()
        {
            employees.Sort((Employee e1,Employee e2) => e2.Age.CompareTo(e1.Age) ); // => = return send 
        }

        public void SortByIncome()
        {
            employees.Sort((Employee e1, Employee e2) => e2.GetIncome().CompareTo(e1.GetIncome()));
        }


        public override string ToString()
        {
            string result = "";
            for (int i = 0; i < Length; i++)
                result += this[i] + "\n";
            return result;
        }
    }

}








#region class notes
// objects learn them


// different kinds of languages: imperatvie language = c#,c++,c,java are static, everything is step by step, 
// dynamic languages = dont have to define head of time = js, python
// functional = main building block = js, python
// declartive = sql, html, css

#endregion