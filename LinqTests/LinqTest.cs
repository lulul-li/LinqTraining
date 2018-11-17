using System;
using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using LinqSample.WithoutLinq;
using LinqSample.YourOwnLinq;

namespace LinqTests
{
    [TestClass]
    public class LinqTest
    {
        [TestMethod]
        public void is_all_products_Cost_less_than_41_should_return_false()
        {
            var products = RepositoryFactory.GetProducts().ToList();

            var actual = products.YourAll(product => product.Cost < 41);

            Assert.IsFalse(actual);
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

        [TestMethod]
        public void Any_False()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = employees.YourAny(p => p.Name == "Annie");
            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void Any_True()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = employees.YourAny(p => p.Name == "Joey");
            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void FirstOrDefault()
        {
            var employees = RepositoryFactory.GetEmployees();
            var result = employees.MyFirstOrDefault(x => x.Age < 12);
            Assert.AreEqual(default(Employee), result);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Single()
        {
            var employees = RepositoryFactory.GetEmployees();
            var result = YourOwnLinq.YourSingle(employees,x => x.Role == RoleType.OP);
        }

        [TestMethod]
        public void Distinct()
        {
            var employees = RepositoryFactory.GetEmployees();
            var act = YourOwnLinq.YourDistinct(employees);
            
            var exp = employees.Distinct();
            exp.ToExpectedObject().ShouldEqual(act.ToList());
        }
    }
}