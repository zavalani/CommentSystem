using CommentSystem.Models;
using CommentSystem.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CommentSystem.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : ControllerBase
    {
        private readonly CommentRepo _repo;

        public CommentsController(CommentRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_repo.GetAll());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Comments comment)
        {
            if (string.IsNullOrWhiteSpace(comment.Username) || string.IsNullOrWhiteSpace(comment.Text))
                return BadRequest("Invalid input");

            comment.CommentDate = DateTime.Now;
            var created = _repo.Add(comment);
            return Ok(created);
        }
    }
}
