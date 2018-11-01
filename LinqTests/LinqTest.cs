using ExpectedObjects;
using JoeyIsFat;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace LinqTests
{
    [TestClass]
    public class LinqTest
    {
        [TestMethod]
        public void find_products_that_price_between_200_and_500()
        {
            var products = RepositoryFactory.GetProducts().ToList();
            var actual = products.Where(product => product.IsTopSaleProducts());

            var expected = new List<Product>()
            {
                new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Ignore]
        [TestMethod]
        public void find_products_that_price_between_200_and_500_and_cost_more_than_50()
        {
            var products = RepositoryFactory.GetProducts();

            var expected = new List<Product>()
            {
                //new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
            };

            //expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Ignore]
        [TestMethod]
        public void find_employee_that_age_more_30_item_index_more_2()
        {
            var employees = RepositoryFactory.GetEmployees();

            var expected = new List<Employee>()
            {
                //new Employee {Name = "Joe", Role = RoleType.Engineer, MonthSalary = 100, Age = 44, WorkingYear = 2.6},
                //new Employee {Name = "Tom", Role = RoleType.Engineer, MonthSalary = 140, Age = 33, WorkingYear = 2.6},
                new Employee {Name = "Kevin", Role = RoleType.Manager, MonthSalary = 380, Age = 55, WorkingYear = 2.6},
                //new Employee {Name = "Andy", Role = RoleType.OP, MonthSalary = 80, Age = 22, WorkingYear = 2.6},
                new Employee {Name = "Bas", Role = RoleType.Engineer, MonthSalary = 280, Age = 36, WorkingYear = 2.6},
                //new Employee {Name = "Mary", Role = RoleType.OP, MonthSalary = 180, Age = 26, WorkingYear = 2.6},
                //new Employee {Name = "Frank", Role = RoleType.Engineer, MonthSalary = 120, Age = 16, WorkingYear = 2.6},
                new Employee {Name = "Joey", Role = RoleType.Engineer, MonthSalary = 250, Age = 40, WorkingYear = 2.6},
            };

            //foreach (var item in actual)
            //{
            //    Console.WriteLine(item.Price);
            //}

            //expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Ignore]
        [TestMethod]
        public void YourWhere_YourSelect()
        {
            var employees = RepositoryFactory.GetEmployees();

            //var actual = employees
            //    .YourWhere(e => e.Age < 25)
            //    .YourSelect(e => $"{e.Role}:{e.Name}");

            //foreach (var titleName in actual)
            //{
            //    Console.WriteLine(titleName);
            //}

            var expected = new List<string>()
            {
                "OP:Andy",
                "Engineer:Frank",
            };

            //expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [Ignore]
        [TestMethod]
        public void Take()
        {
            var employees = RepositoryFactory.GetEmployees();
            var expected = new List<Employee>
            {
                new Employee {Name = "Joe", Role = RoleType.Engineer, MonthSalary = 100, Age = 44, WorkingYear = 2.6},
                new Employee {Name = "Tom", Role = RoleType.Engineer, MonthSalary = 140, Age = 33, WorkingYear = 2.6},
            };

            //expected.ToExpectedObject().ShouldEqual(act.ToList());
        }

        [Ignore]
        [TestMethod]
        public void Skip()
        {
            var employees = RepositoryFactory.GetEmployees();
            var expected = new List<Employee>
            {
                new Employee {Name = "Frank", Role = RoleType.Engineer, MonthSalary = 120, Age = 16, WorkingYear = 2.6},
                new Employee {Name = "Joey", Role = RoleType.Engineer, MonthSalary = 250, Age = 40, WorkingYear = 2.6},
            };

            //expected.ToExpectedObject().ShouldEqual(act.ToList());
        }

        [Ignore]
        [TestMethod]
        public void TakeWhile()
        {
            var employees = RepositoryFactory.GetEmployees();
            var expected = new List<Employee>
            {
                new Employee {Name = "Kevin", Role = RoleType.Manager, MonthSalary = 380, Age = 55, WorkingYear = 2.6},
                new Employee {Name = "Bas", Role = RoleType.Engineer, MonthSalary = 280, Age = 36, WorkingYear = 2.6},
            };
            //expected.ToExpectedObject().ShouldEqual(act.ToList());
        }

        [Ignore]
        [TestMethod]
        public void SkipWhile()
        {
            var employees = RepositoryFactory.GetEmployees();
            var expected = new List<Employee>
            {
                new Employee {Name = "Kevin", Role = RoleType.Manager, MonthSalary = 380, Age = 55, WorkingYear = 2.6},
                new Employee {Name = "Bas", Role = RoleType.Engineer, MonthSalary = 280, Age = 36, WorkingYear = 2.6},
                new Employee {Name = "Mary", Role = RoleType.OP, MonthSalary = 180, Age = 26, WorkingYear = 2.6},
                new Employee {Name = "Frank", Role = RoleType.Engineer, MonthSalary = 120, Age = 16, WorkingYear = 2.6},
                new Employee {Name = "Joey", Role = RoleType.Engineer, MonthSalary = 250, Age = 40, WorkingYear = 2.6},
            };
            //expected.ToExpectedObject().ShouldEqual(act.ToList());
        }
    }
}