using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using LinqSample.WithoutLinq;
using LinqSample.YourOwnLinq;

namespace LinqTests
{
    [TestClass]
    public class LinqTest
    {
        [TestMethod]
        public void find_products_that_price_between_200_and_500()
        {
            var products = RepositoryFactory.GetProducts().ToList();

            var actual1 = products.Where(product => product.IsTopSaleProducts());
            var actual = new List<Product>();
            foreach (var p in products)
            {
                if (p.IsTopSaleProducts())
                {
                    actual.Add(p);
                }
            }

            var expected = new List<Product>()
            {
                new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }


        [TestMethod]
        public void find_products_that_price_between_200_and_500_and_cost_more_than_20()
        {
            var products = RepositoryFactory.GetProducts();

            //var actual = new List<Product>();
            var actual = WithoutLinq.Find(products, p => p.Price > 200 && p.Price < 500 && p.Cost > 20);

            //foreach (var p in products)
            //{
            //    if (p.IsTopSaleProducts() && p.Cost >20)
            //    {
            //        actual.Add(p);
            //    }
            //}
            var expected = new List<Product>()
            {
                new Product {Id = 2, Cost = 21, Price = 210, Supplier = "Yahoo"},
                new Product {Id = 3, Cost = 31, Price = 310, Supplier = "Odd-e"},
                new Product {Id = 4, Cost = 41, Price = 410, Supplier = "Odd-e"},
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [TestMethod]
        public void find_employee_that_age_more_30_item_index_more_2()
        {
            var employees = RepositoryFactory.GetEmployees();

            //var actual = WithoutLinq.more30(WithoutLinq.skip(employees, 2), p => p.Age > 30);
            //var actual = WithoutLinq.Find<Employee>(employees, (p, Index) => p.Age > 30 && Index >= 2);
            var actual = employees.Find<Employee>((p, Index) => p.Age > 30 && Index >= 2);

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

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [TestMethod]
        public void YourWhere_YourSelect()
        {
            var employees = RepositoryFactory.GetEmployees();


            var actual = employees.YourWhere(e => e.Age < 25).YourSelect(e => $"{e.Role}:{e.Name}");

            //foreach (var titleName in actual)
            //{
            //    Console.WriteLine(titleName);
            //}

            var expected = new List<string>()
            {
                "OP:Andy",
                "Engineer:Frank",
            };

            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }

        [TestMethod]
        public void Take()
        {
            var employees = RepositoryFactory.GetEmployees();
            var act = employees.Ytake(2);
            var expected = new List<Employee>
            {
                new Employee {Name = "Joe", Role = RoleType.Engineer, MonthSalary = 100, Age = 44, WorkingYear = 2.6},
                new Employee {Name = "Tom", Role = RoleType.Engineer, MonthSalary = 140, Age = 33, WorkingYear = 2.6},
            };

            expected.ToExpectedObject().ShouldEqual(act.ToList());
        }


        [TestMethod]
        public void Skip()
        {
            var employees = RepositoryFactory.GetEmployees();
            var act = employees.skip(6);
            var expected = new List<Employee>
            {
                new Employee {Name = "Frank", Role = RoleType.Engineer, MonthSalary = 120, Age = 16, WorkingYear = 2.6},
                new Employee {Name = "Joey", Role = RoleType.Engineer, MonthSalary = 250, Age = 40, WorkingYear = 2.6},
            };

            expected.ToExpectedObject().ShouldEqual(act.ToList());
        }

        [TestMethod]
        public void TakeWhile()
        {
            var employees = RepositoryFactory.GetEmployees();
            var act = WithoutLinq.YTakeWhile(employees, 2, p => p.MonthSalary > 150);
            var expected = new List<Employee>
            {
                new Employee {Name = "Kevin", Role = RoleType.Manager, MonthSalary = 380, Age = 55, WorkingYear = 2.6},
                new Employee {Name = "Bas", Role = RoleType.Engineer, MonthSalary = 280, Age = 36, WorkingYear = 2.6},
            };
            expected.ToExpectedObject().ShouldEqual(act.ToList());
        }
        [Ignore]
        [TestMethod]
        public void SkipWhile()
        {
            var employees = RepositoryFactory.GetEmployees();
            var act = employees.Whileskip(3, p => p.MonthSalary < 150);
            var expected = new List<Employee>
            {
                new Employee {Name = "Kevin", Role = RoleType.Manager, MonthSalary = 380, Age = 55, WorkingYear = 2.6},
                new Employee {Name = "Bas", Role = RoleType.Engineer, MonthSalary = 280, Age = 36, WorkingYear = 2.6},
                new Employee {Name = "Mary", Role = RoleType.OP, MonthSalary = 180, Age = 26, WorkingYear = 2.6},
                new Employee {Name = "Frank", Role = RoleType.Engineer, MonthSalary = 120, Age = 16, WorkingYear = 2.6},
                new Employee {Name = "Joey", Role = RoleType.Engineer, MonthSalary = 250, Age = 40, WorkingYear = 2.6},
            };
            expected.ToExpectedObject().ShouldEqual(act.ToList());
        }

        [TestMethod]
        public void All()
        {
            var products = RepositoryFactory.GetProducts().ToList();
            var resp = products.MyAll(x => x.Cost < 41);
            Assert.AreEqual(resp, false);
        }

        [TestMethod]
        public void Any()
        {
            var employees = RepositoryFactory.GetEmployees().ToList();
            var result = employees.MyAny(x => x.Name == "Annie");
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FirstorDefault()
        {
            //default();
        }

        [TestMethod]
        public void Single()
        {
            var employees = RepositoryFactory.GetEmployees();
            var result = YourOwnLinq.MySingle(employees, x => x.Role == RoleType.Manager);
            Assert.AreEqual(new Employee {Name = "Kevin", Role = RoleType.Manager, MonthSalary = 380, Age = 55, WorkingYear = 2.6},result);
        }

        [TestMethod]
        public void Distinct()
        {
            var employees = RepositoryFactory.GetEmployees();
            var result = YourOwnLinq.MyDistinct(employees);
            var expected = employees.Distinct();
            expected.ToExpectedObject().ShouldEqual(result);
        }
           
        [TestMethod]
        public void groupSalary()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = WithoutLinq.YourGroup(employees, 3, e => e.MonthSalary);
 
            var expected = new List<int>()
            {
                620,
                540,
                370
            };
 
            expected.ToExpectedObject().ShouldEqual(actual.ToList());
        }
        [TestMethod]
        public void First()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = WithoutLinq.YourFirst(employees, e => e.Age > 30);
 
            var expected = new Employee
            {
                Name = "Joe",
                Role = RoleType.Engineer,
                MonthSalary = 100,
                Age = 44,
                WorkingYear = 2.6
            };
 
 
            expected.ToExpectedObject().ShouldEqual(actual);
        }
 
        [TestMethod]
        public void Last()
        {
            var employees = RepositoryFactory.GetEmployees();
            var actual = WithoutLinq.YourLast(employees, e => e.Age > 30);
 
            var expected = new Employee
            {
                Name = "Joey",
                Role = RoleType.Engineer,
                MonthSalary = 250,
                Age = 40,
                WorkingYear = 2.6
            };
 
 
            expected.ToExpectedObject().ShouldEqual(actual);
        }
    }
}
    
