using System;
using System.Collections.Generic;

namespace Interface_segregation_principle_ISP
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IReadonlyRepository readonlyRepository = new EmployeeRepository();
            readonlyRepository.GetAll();
            readonlyRepository.GetById(123);
            
            IRepository repository = new EmployeeRepository();
            repository.GetAll();
            repository.GetById(123);
            repository.Insert(new Employee());
            repository.Delete(123);
            repository.Update(1, new Employee());
        }
    }


    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthday { get; set; }
    }

    #region BadCode
    public interface IReadonlyRepository
    {
        Employee GetById(int Id);
        IList<Employee> GetAll();
    }

    public interface IRepository : IReadonlyRepository
    {
        void Update(int Id, Employee modifiedEmployee);
        void Insert(Employee employee);

        void Delete(int Id);
    }

    public class EmployeeRepository : IRepository
    {
        public void Delete(int Id)
        {

        }

        public IList<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int Id)
        {
            return new Employee();
        }

        public void Insert(Employee employee)
        {

        }

        public void Update(int Id, Employee modifiedEmployee)
        {

        }
    }
    #endregion



    #region Better
    public interface ICanAdd
    {
        void Insert(Employee employee);
    }

    public interface ICanUpdate
    {
        void Update(int Id, Employee modifiedEmployee);
    }

    public interface ICanDelete
    {
        void Delete(int Id);
    }

    public interface ICanRead
    {
        IList<Employee> ReadAll();

        Employee GetEmployeeById(int Id);
    }

    public class BetterRepository : ICanAdd, ICanUpdate, ICanDelete, ICanRead
    {
        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployeeById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int Id, Employee modifiedEmployee)
        {
            throw new NotImplementedException();
        }
    }
    #endregion


}
