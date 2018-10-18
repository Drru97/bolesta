using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Bolesta.BusinessLogic.Models;

namespace Bolesta.BusinessLogic.Implementation
{
    public class InMemoryTextStatisticProcessor : ITextStatisticProcessor
    {
        private string _text;

        public InMemoryTextStatisticProcessor()
        {
            _text = string.Empty;
        }
        
        public InMemoryTextStatisticProcessor(string text)
        {
            _text = text;
        }

        public string Text
        {
            get => _text;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException();
                }

                _text = value;
            }
        }
        
        public TextStatistic GetTextStatistic()
        {
            var characters = GetUniqueCharacters();
            var characterOccurrences = characters
                .Select(character => new CharacterOccurrence
                {
                    Character = character, 
                    Occurrence = GetCharacterOccurence(character),
                    Count = GetCharactersCount(character)
                })
                .ToList();

            var words = GetUniqueWords();
            var wordOccurrences = words
                .Select(word => new WordOccurrence
                {
                    Word = word,
                    Occurrence = GetWordOccurrence(word),
                    Count = GetWordCount(word)
                })
                .ToList();
            
            var textStatistic = new TextStatistic
            {
                SymbolCount = GetCharactersCount(),
                LetterCount = GetLetterCount(),
                WordCount = GetWordCount(),
                LetterOccurrences = characterOccurrences,
                WordOccurrences = wordOccurrences
            };

            return textStatistic;
        }

        private long GetCharactersCount(char character = '\0')
        {
            return character == '\0' ? _text.Length : _text.Count(ch => ch.ToString().Equals(character.ToString(), 
                StringComparison.InvariantCultureIgnoreCase));
        }

        private long GetLetterCount()
        {
            return _text.Count(char.IsLetter);
        }

        private long GetWordCount(string word = null)
        {
            return string.IsNullOrWhiteSpace(word) 
                ? Regex.Matches(_text, @"((\w+(\s?)))").Count 
                : Regex.Matches(_text, "\\b" + Regex.Escape(word) + "\\b", RegexOptions.IgnoreCase).Count;
        }

        private IEnumerable<char> GetUniqueCharacters()
        {
            return _text.ToUpper().Distinct().ToArray();
        }

        private decimal GetCharacterOccurence(char character)
        {
            var currentCharacterCount = GetCharactersCount(character);
            var totalCharactersCount = GetCharactersCount();
            
            return (decimal) currentCharacterCount / totalCharactersCount;
        }

        private IEnumerable<string> GetUniqueWords(char separator = ' ')
        {
            var trimChars = new[] {',', '.', '?', '!'};
            var words = _text.ToUpper().Split(separator);
            for (var i = 0; i < words.Length; i++)
            {
                words[i] = words[i].Trim(trimChars);
            }

            return words;
        }

        private decimal GetWordOccurrence(string word)
        {
            var currentWordCount = GetWordCount(word);
            var totalWordsCount = GetWordCount();

            return (decimal) currentWordCount / totalWordsCount;
        }
    }
}
