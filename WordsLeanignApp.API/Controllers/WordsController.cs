﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WordsLearningApp.BLL.DTO;
using WordsLearningApp.BLL.Interfaces;

namespace WordsLeanignApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WordsController : ControllerBase
    {
        private readonly IWordsService wordsService;
        public WordsController(IWordsService wordsService)
        {
            this.wordsService = wordsService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<WordDTO> GetWords()
        {
            List<WordDTO> words = wordsService.GetAllWords().ToList();
            return words;
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult GetWord(int id)
        {
            WordDTO wordDTO = wordsService.GetWord(id);
            if (wordDTO == null)
            {
                return NotFound();
            }
            return Ok(wordDTO);
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult PostWord([FromBody]WordDTO wordDTO)
        {
            wordsService.CreateWord(wordDTO);
            int wordId = 0;
            return Created($"{Request.Path}/{wordId}", wordDTO);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult PutWord(int id, [FromBody]WordDTO wordDTO)
        {
            int rowAffected = wordsService.EditWord(wordDTO).Result;

            if (rowAffected == -1)
            {
                return NotFound();
            }

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            wordsService.DeleteWord(id);
            return NoContent();
        }
    }
}
