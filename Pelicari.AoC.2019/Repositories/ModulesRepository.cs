using Pelicari.AoC._2019.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Pelicari.AoC._2019.Repositories
{
    public class ModulesRepository : IModulesRepository
    {
        private IInputsRepository _inputsRepository;

        public ModulesRepository(IInputsRepository inputsRepository)
        {
            _inputsRepository = inputsRepository;
        }

        public IEnumerable<Module> GetModules(int day, int puzzleNumber)
        {
            var modules = new List<Module>();
            var inputs = _inputsRepository.GetInputs(day, puzzleNumber);

            if (inputs == null || !inputs.Any())
                return null;

            foreach (var input in inputs)
                if (long.TryParse(input, out var parsedLong))
                    modules.Add(new Module() { Mass = parsedLong });

            return modules;
        }
    }
}
