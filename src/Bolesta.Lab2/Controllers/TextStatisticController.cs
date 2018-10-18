using Bolesta.BusinessLogic;
using Bolesta.BusinessLogic.Models;
using Bolesta.Lab2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bolesta.Lab2.Controllers
{
    [Route("[controller]")]
    public class TextStatisticController : ControllerBase
    {
        private ITextStatisticProcessor _textStatisticProcessor;

        public TextStatisticController(ITextStatisticProcessor textStatisticProcessor)
        {
            _textStatisticProcessor = textStatisticProcessor;
        }

        // POST /textstatistic/
        public IActionResult ProcessText([FromBody] ProcessTextRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _textStatisticProcessor.Text = request.Text;
            var textStatistic = _textStatisticProcessor.GetTextStatistic();

            return Ok(new ProcessTextResponse {TextStatistic = textStatistic});
        }
    }
}
