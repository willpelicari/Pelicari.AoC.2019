﻿using System.Collections.Generic;
using System.IO;

namespace Pelicari.AoC._2019.Repositories
{
    public class InputsRepository : IInputsRepository
    {
        public IEnumerable<string> GetInputs(int day, int puzzleNumber)
        {
            StreamReader file = new StreamReader($"Repositories/Inputs/{day:00}-{puzzleNumber:00}.txt");

            var inputs = new List<string>();

            string input;
            while ((input = file.ReadLine()) != null)
                inputs.Add(input);

            return inputs;
        }
    }
}
