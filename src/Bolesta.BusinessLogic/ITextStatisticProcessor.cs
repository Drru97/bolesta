using Bolesta.BusinessLogic.Models;

namespace Bolesta.BusinessLogic
{
    public interface ITextStatisticProcessor
    {
        string Text { get; set; }
        
        TextStatistic GetTextStatistic();
    }
}
