using Microsoft.AspNetCore.Mvc;
using Test.Models;
using System;

namespace Test.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordListController: ControllerBase
    {
        public WordListController()
        {
        }

        [HttpPost]
        [Consumes("application/x-www-form-urlencoded")]
        public IActionResult Post([FromForm]string text)
        {
            if(text == null) return Problem(statusCode: 400, title: "Need to enter an text into text field.");
            WordList wordList = new(text);

            return Ok(wordList.GetTopList());
        }
    }
}