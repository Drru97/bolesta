using System;

namespace Bolesta.BusinessLogic.Models
{
    public class WordOccurrence
    {
        private const int PercentConstant = 100;
        private long _count;
        private decimal _occurrence;
        
        public string Word { get; set; }

        public long Count
        {
            get => _count;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException();
                }

                _count = value;
            }
        }
        
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
