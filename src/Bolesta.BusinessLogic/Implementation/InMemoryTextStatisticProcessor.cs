using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Bolesta.BusinessLogic.Models;

namespace Bolesta.BusinessLogic.Implementation
{
    public class InMemoryTextStatisticProcessor : ITextStatisticProcessor
    {
        private readonly string _text;

        public InMemoryTextStatisticProcessor(string text)
        {
            _text = text;
        }

        public TextStatistic GetTextStatistic()
        {
            var characterCount = GetSymbolCount();

            var characters = GetUniqueCharacters();
            var characterOccurrences = characters
                .Select(character => new CharacterOccurrence
                {
                    Character = character, Occurrence = GetCharacterOccurence(character, characterCount)
                })
                .ToList();

            var textStatistic = new TextStatistic
            {
                SymbolCount = characterCount,
                LetterCount = GetLetterCount(),
                WordCount = GetWordCount(),
                LetterOccurrences = characterOccurrences
            };

            return textStatistic;
        }

        private long GetSymbolCount()
        {
            return _text.Length;
        }

        private long GetLetterCount()
        {
            return _text.Count(char.IsLetter);
        }

        private long GetWordCount()
        {
            return Regex.Matches(_text, @"((\w+(\s?)))").Count;
        }

        private IEnumerable<char> GetUniqueCharacters()
        {
            return _text.ToUpper().Distinct().ToArray();
        }

        private decimal GetCharacterOccurence(char character, long characterCount)
        {
            return (decimal) _text.ToUpper().Count(ch => ch == character) / characterCount;
        }
    }
}