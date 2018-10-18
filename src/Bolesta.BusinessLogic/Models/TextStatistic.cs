using System;
using System.Collections.Generic;
using System.Linq;

namespace Bolesta.BusinessLogic.Models
{
    public class TextStatistic
    {
        private const decimal Epsilon = 1e-6m;
        private IList<CharacterOccurrence> _letterOccurrences;
        private IList<WordOccurrence> _wordOccurrences;
        
        public long SymbolCount { get; set; }
        public long LetterCount { get; set; }
        public long WordCount { get; set; }

        public IList<CharacterOccurrence> LetterOccurrences
        {
            get => _letterOccurrences;
            set
            {
                EnsureValidLetterOccurrences(value);

                _letterOccurrences = value;
            }
        }

        public IList<WordOccurrence> WordOccurrences
        {
            get => _wordOccurrences;
            set
            {
              //  EnsureValidWordOccurrences(value);

                _wordOccurrences = value;
            }
        }

        private static void EnsureValidLetterOccurrences(IList<CharacterOccurrence> value)
        {
            if (value == null)
            {
                throw new ArgumentException();
            }

            var occurrencesSum = value.Select(lo => lo.Occurrence).Sum();
            if (Math.Abs(occurrencesSum - 1m) > Epsilon)
            {
                throw new ArgumentException();
            }
        }
        
        private static void EnsureValidWordOccurrences(IList<WordOccurrence> value)
        {
            if (value == null)
            {
                throw new ArgumentException();
            }

            var occurrencesSum = value.Select(wo => wo.Occurrence).Sum();
            if (Math.Abs(occurrencesSum - 1m) > Epsilon)
            {
                throw new ArgumentException();
            }
        }
    }
}
