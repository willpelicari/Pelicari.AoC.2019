using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2019.Repositories;
using Pelicari.AoC._2019.Services;

namespace Pelicari.AoC._2019.Tests.Integrations
{
    [TestClass]
    public class Day1
    {
        private IFuelCalculatorService _fuelCalculatorService;

        [TestInitialize]
        public void OnInitialize()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IInputsRepository, InputsRepository>();
            serviceCollection.AddSingleton<IModulesRepository, ModulesRepository>();
            serviceCollection.AddSingleton<IFuelCalculatorService, FuelCalculatorService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _fuelCalculatorService = serviceProvider.GetService<IFuelCalculatorService>();
        }

        [TestMethod]
        public void Challenge1_WhenInputIsPassed_ThenAnswerIsCorrect()
        {
            //Act
            var result = _fuelCalculatorService.CalculateTotalFuel(1, 1, considerFuelMass: false);

            //Assert
            result.Should().Be(3384232);
        }

        [TestMethod]
        public void Challenge2_WhenInputIsPassed_ThenAnswerIsCorrect()
        {
            //Act
            var result = _fuelCalculatorService.CalculateTotalFuel(1, 1, considerFuelMass: true);

            //Assert
            result.Should().Be(5073456);
        }
    }
}
