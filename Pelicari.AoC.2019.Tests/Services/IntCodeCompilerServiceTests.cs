using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Pelicari.AoC._2019.Repositories;
using Pelicari.AoC._2019.Services;

namespace Pelicari.AoC._2019.Tests.Services
{
    [TestClass]
    public class IntCodeCompilerServiceTests
    {
        private IInputsRepository _inputsRepository;
        private IntCodeCompilerService _intCodeCompilerService;
        public const int Day = 2;
        public const int PuzzleNumber = 1;

        [TestInitialize]
        public void OnInitialize()
        {
            _inputsRepository = Substitute.For<IInputsRepository>();
            _intCodeCompilerService = new IntCodeCompilerService(_inputsRepository);
        }

        [DataTestMethod]
        [DataRow("1,0,0,0,99", "2,0,0,0,99")]
        [DataRow("2,3,0,3,99", "2,3,0,6,99")]
        [DataRow("2,4,4,5,99,0", "2,4,4,5,99,9801")]
        [DataRow("1,1,1,4,99,5,6,0,99", "30,1,1,4,2,5,6,0,99")]
        public void Compile_WhenReceivingIntCode_ThenCompileCorrectly(string input, string expectedOutput)
        {
            //Arrange
            _inputsRepository.GetInputs(Day, PuzzleNumber).Returns(new[] { input });

            //Act
            var result = _intCodeCompilerService.Compile(Day, PuzzleNumber);

            //Assert
            result.Should().Be(expectedOutput);
        }
    }
}
