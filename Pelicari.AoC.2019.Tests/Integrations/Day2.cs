using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pelicari.AoC._2019.Repositories;
using Pelicari.AoC._2019.Services;

namespace Pelicari.AoC._2019.Tests.Integrations
{
    [TestClass]
    public class Day2
    {
        private IIntCodeCompilerService _intCodeCompilerService;

        [TestInitialize]
        public void OnInitialize()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<IInputsRepository, InputsRepository>();
            serviceCollection.AddSingleton<IModulesRepository, ModulesRepository>();
            serviceCollection.AddSingleton<IIntCodeCompilerService, IntCodeCompilerService>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            _intCodeCompilerService = serviceProvider.GetService<IIntCodeCompilerService>();
        }

        [TestMethod]
        public void Challenge1_WhenInputIsPassed_ThenAnswerIsCorrect()
        {
            //Act
            var result = _intCodeCompilerService.Compile(2, 1);
            var firstPosition = result.Split(",")[0];

            //Assert
            firstPosition.Should().Be("3765464");
        }
    }
}
