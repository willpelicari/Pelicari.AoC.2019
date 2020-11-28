using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Pelicari.AoC._2019.Entities;
using Pelicari.AoC._2019.Repositories;
using Pelicari.AoC._2019.Services;

namespace Pelicari.AoC._2019.Tests.Services
{
    [TestClass]
    public class FuelCalculatorServiceTests
    {
        private IModulesRepository _moduleRepository;
        private FuelCalculatorService _fuelCalculatorService;
        public const int Day = 1;
        public const int PuzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            _moduleRepository = Substitute.For<IModulesRepository>();
            _fuelCalculatorService = new FuelCalculatorService(_moduleRepository);
        }

        [TestMethod]
        public void CalculateModuleFuel_WhenModuleIsNull_ThenReturnZero()
        {
            //Arrange
            var module = null as Module;
            _moduleRepository.GetModules(Day, PuzzleNumber).Returns(new[] { module });

            //Act
            var result = _fuelCalculatorService.CalculateTotalFuel(1, 1);

            //Assert
            result.Should().Be(0);
        }

        [TestMethod]
        public void CalculateModuleFuel_WhenModuleMassIsSmallerThanSix_ThenReturnZero()
        {
            //Arrange
            var module = new Module() { Mass = 5 };
            _moduleRepository.GetModules(Day, PuzzleNumber).Returns(new[] { module });

            //Act
            var result = _fuelCalculatorService.CalculateTotalFuel(1, 1);

            //Assert
            result.Should().Be(0);
        }

        [DataTestMethod]
        [DataRow(12, 2)]
        [DataRow(14, 2)]
        [DataRow(1969, 654)]
        [DataRow(100756, 33583)]
        public void CalculateModuleFuel_WhenNotConsideringFuelMass_ThenCalculateRightAmout(int mass, int expectedFuel)
        {
            //Arrange
            var module = new Module() { Mass = mass };
            _moduleRepository.GetModules(Day, PuzzleNumber).Returns(new[] { module });

            //Act
            var result = _fuelCalculatorService.CalculateTotalFuel(1, 1, false);

            //Assert
            result.Should().Be(expectedFuel);
        }

        [DataTestMethod]
        [DataRow(14, 2)]
        [DataRow(1969, 966)]
        [DataRow(100756, 50346)]
        public void CalculateModuleFuel_WhenConsideringFuelMass_ThenCalculateRightAmout(int mass, int expectedFuel)
        {
            //Arrange
            var module = new Module() { Mass = mass };
            _moduleRepository.GetModules(Day, PuzzleNumber).Returns(new[] { module });

            //Act
            var result = _fuelCalculatorService.CalculateTotalFuel(1, 1, true);

            //Assert
            result.Should().Be(expectedFuel);
        }
    }
}
