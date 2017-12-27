using PostawNaMilionAzure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PostawNaMilionAzure.ViewModel
{
    public class GameViewModel
    {
        public GameViewModel(int _stepTotalValue)
        {
            StepTotalValue = _stepTotalValue;
        }

        public float SumValue { get; set; }

        public Question Question { get; set; }

        public List<CategoryDict> CategoryDict { get; set; }

        public int NumberQuestion { get; set; }

        public TypeResultGame TypeResultGame { get; set; }

        public bool IsCategory { get; set; }

        public int StepTotalValue { get; set; }

    }
}