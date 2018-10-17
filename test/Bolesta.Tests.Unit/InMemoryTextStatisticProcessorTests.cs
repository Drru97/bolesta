using Bolesta.BusinessLogic.Implementation;
using Xunit;

namespace Bolesta.Tests.Unit
{
    public class InMemoryTextStatisticProcessorTests
    {
        [Fact]
        public void GetTextStatistic()
        {
            const string text = "Hello, Java Man, how are you doing?";
            const int letters = 26;
            var processor = new InMemoryTextStatisticProcessor(text);

            var statistic = processor.GetTextStatistic();

            Assert.NotNull(statistic);
            Assert.Equal(text.Length, statistic.SymbolCount);
            Assert.Equal(letters, statistic.LetterCount);
        }
    }
}
