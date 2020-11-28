using Pelicari.AoC._2019.Entities;
using Pelicari.AoC._2019.Repositories;
using System;
using System.Linq;

namespace Pelicari.AoC._2019.Services
{
    public class FuelCalculatorService : IFuelCalculatorService
    {
        private IModulesRepository _modulesRepository;

        public FuelCalculatorService(IModulesRepository modulesRepository)
        {
            _modulesRepository = modulesRepository;
        }

        public long CalculateTotalFuel(int day, int puzzleNumber, bool considerFuelMass = true)
        {
            var modules = _modulesRepository.GetModules(day, puzzleNumber);

            if (modules == null || !modules.Any())
                return 0;

            return modules.Select(m => CalculateModuleFuel(m.Mass, considerFuelMass)).Sum();
        }

        private long CalculateModuleFuel(long mass, bool considerFuelMass)
        {
            if (mass <= 0) return 0;

            var fuel = Convert.ToInt64(Math.Floor(mass / 3.0) - 2);

            if (fuel <= 0)
                return 0;

            if(considerFuelMass)
                return CalculateModuleFuel(fuel, considerFuelMass) + fuel;
            return fuel;
        }
    }
}
