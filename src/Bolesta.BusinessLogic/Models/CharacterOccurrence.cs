using System;

namespace Bolesta.BusinessLogic.Models
{
    public class CharacterOccurrence
    {
        private const int PercentConstant = 100;
        private decimal _occurrence;
        
        public char Character { get; set; }

        public decimal Occurrence
        {
            get => _occurrence;
            set
            {
                if (value < 0m || value > 1m)
                {
                    throw new ArgumentException();
                }

                _occurrence = value;
            }
        }

        public decimal PercentageOccurrence
        {
            get => _occurrence * PercentConstant;
            set
            {
                if (value < 0m || value > 100m)
                {
                    throw new ArgumentException();
                }

                _occurrence = value / PercentConstant;
            }
        }
    }
}
