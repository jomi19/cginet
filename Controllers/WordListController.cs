using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Test.Models;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordListController: ControllerBase
    {
        public WordListController()
        {
        }
        [HttpGet]
        public IActionResult GetById(int id)
        {
            return Ok();
        }

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Post([FromForm] string text)
        {
            WordList wordList = new(text);

            return Ok(wordList.GetTopList());
        }
    }
}