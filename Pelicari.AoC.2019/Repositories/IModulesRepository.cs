using Pelicari.AoC._2019.Entities;
using System.Collections.Generic;

namespace Pelicari.AoC._2019.Repositories
{
    public interface IModulesRepository
    {
        IEnumerable<Module> GetModules(int day, int puzzleNumber);
    }
}