using Pelicari.AoC._2019.Entities;
using Pelicari.AoC._2019.Repositories;
using System.Linq;

namespace Pelicari.AoC._2019.Services
{
    public class IntCodeCompilerService : IIntCodeCompilerService
    {
        private IInputsRepository _inputsRepository;

        public IntCodeCompilerService(IInputsRepository inputsRepository)
        {
            _inputsRepository = inputsRepository;
        }

        private int Index1(int indexOp) => indexOp + 1;
        private int Index2(int indexOp) => indexOp + 2;
        private int IndexResult(int indexOp) => indexOp + 3;

        public string Compile(int day, int puzzle)
        {
            var file = _inputsRepository.GetInputs(day, puzzle).First();
            var values = file.Split(",").Select(int.Parse).ToList();
            int index = 0;
            while (index < values.Count)
            {
                var parsedOpCode = (OpCodeEnum)values[index];
                switch (parsedOpCode)
                {
                    case OpCodeEnum.Add:
                        values[values[IndexResult(index)]] = values[values[Index1(index)]] + values[values[Index2(index)]];
                        break;
                    case OpCodeEnum.Multiply:
                        values[values[IndexResult(index)]] = values[values[Index1(index)]] * values[values[Index2(index)]];
                        break;
                    case OpCodeEnum.End:
                        index += 4;
                        continue;
                }
                index += 4;
            }
            return string.Join(",", values);
        }
    }
}
