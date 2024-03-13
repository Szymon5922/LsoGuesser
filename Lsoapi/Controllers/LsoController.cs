using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LsoAPI.Services;
using LsoAPI.Entities;
using LsoAPI.Models;

namespace LsoAPI.Controllers
{
    [Route("api/LsoController")]
    [ApiController]
    public class LsoController : ControllerBase
    {
        private readonly ILsoService _lsoService;
        public LsoController(ILsoService service)
        {
            _lsoService = service;
        }
        [HttpGet]
        public ActionResult<SongDto> GetRandomSong() 
        {
            SongDto song = _lsoService.GetRandom();
            return Ok(song);
        }
        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<SongDto>> GetAll()
        {
            IEnumerable<SongDto>? songs = _lsoService.GetAll();
            return Ok(songs);
        }
        [HttpGet("GetSong/{id}")]
        public ActionResult<SongDto> GetSong(int id)
        {
            SongDto song = _lsoService.GetById(id);
            return song != null ? Ok(song) : NotFound();
        }
        [HttpGet("RandomSong/{stt?}")]
        public ActionResult<SongGuessDto> GetRandomSongGuess([FromRoute] int stt=4)
        {
            SongGuessDto data = _lsoService.GetRandomSongGuessData(stt);
            return Ok(data);
        }
        [HttpGet("RandomLine/{stt?}")]
        public ActionResult<LineGuessDto> GetRandomLineGuess([FromRoute]int stt=4)
        {
            LineGuessDto data = _lsoService.GetRandomLineGuessData(stt);
            return Ok(data);
        }
        [HttpPost]
        public ActionResult AddSong([FromBody] CreateSongDto dto)
        {
            int id = _lsoService.Create(dto);
            return Created($"Song created with id:{id}",null);
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteSong(int id) 
        {
            bool isDeleted = _lsoService.Delete(id);
            return isDeleted ? NoContent() : NotFound();
        }
    }
}
