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
        [TestMethod]
        public void Challenge1_WhenInputIsPassed_ThenAnswerIsCorrect()
        {
            //Arrange
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IInputsRepository, InputsRepository>();
            serviceCollection.AddSingleton<IModulesRepository, ModulesRepository>();
            serviceCollection.AddSingleton<IFuelCalculatorService, FuelCalculatorService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            var fuelCalculatorService = serviceProvider.GetService<IFuelCalculatorService>();

            //Act
            var result = fuelCalculatorService.CalculateTotalFuel(1, 1);

            //Assert
            result.Should().Be(3384232);
        }
    }
}
