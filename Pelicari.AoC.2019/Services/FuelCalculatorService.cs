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

        public long CalculateTotalFuel(int day, int puzzleNumber)
        {
            var modules = _modulesRepository.GetModules(day, puzzleNumber);

            if (modules == null || !modules.Any())
                return 0;

            return modules.Select(m => CalculateModuleFuel(m)).Sum();
        }

        private long CalculateModuleFuel(Module module)
        {
            if (module == null || module.Mass < 6)
                return 0;
            return Convert.ToInt64(Math.Floor(module.Mass / 3.0) - 2);
        }
    }
}
