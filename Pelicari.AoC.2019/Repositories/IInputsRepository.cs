using System.Collections.Generic;

namespace Pelicari.AoC._2019.Repositories
{
    public interface IInputsRepository
    {
        IEnumerable<string> GetInputs(int day, int puzzleNumber);
    }
}