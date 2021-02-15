using System;
using RecapProject.Business.Concrete;
using RecapProject.DataAccess.Concrete.InMemory;

namespace RecapProject.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new InMemoryCarDal());
            foreach (var car in carManager.GetAll())
            {
                System.Console.WriteLine(car);
            }
        }
    }
}
