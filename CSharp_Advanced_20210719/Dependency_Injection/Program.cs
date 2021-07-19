using System;

namespace Dependency_Injection
{
    class Program
    {
        static void Main(string[] args)
        {
            ICarService carService = new CarService();
            carService.RepairCar(new MockCar());
            carService.RepairCar(new Car());

        }
    }

    #region Bad Code
   
    public class BadCar //Programmierer B benötigt 5 Tage
    {
        public string Brand { get; set; }
        public string Type { get; set; }

        public DateTime ConstructionDate { get; set; }
        public int PS { get; set; }
    }


    public class BadCarService //Programmierer A benötigt 3 Tage
    {
        public void RepairCar(BadCar car)
        {
            //Mach was
        }
    }
    #endregion



    #region BetterCode
    public interface ICar
    {
        string Brand { get; set; }
        string Type { get; set; }
        DateTime ConstructionDate { get; set; }
        int PS { get; set; }
    }

    public interface ICarService
    {
        void RepairCar(ICar car);

        void CheckCar(ICar car);
    }


    public class Car : ICar // 5 Tage
    {
        public string Brand { get; set; }
        public string Type { get; set; }
        public DateTime ConstructionDate { get; set; }
        public int PS { get; set; }
    }

    public class MockCar : ICar
    {
        public string Brand { get; set; } = "VW";
        public string Type { get; set; } = "Käfer";
        public DateTime ConstructionDate { get; set; } = DateTime.Now;
        public int PS { get; set; } = 40;
    }

    public class CarService : ICarService // 3 Tage
    {
        public void CheckCar(ICar car)
        {
            throw new NotImplementedException();
        }

        public void RepairCar(ICar car)
        {
            //Machwas
        }
    }
    #endregion
}
