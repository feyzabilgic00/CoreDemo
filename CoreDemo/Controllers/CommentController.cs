using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult CommentListByBlog(int id)
        {
            ViewBag.Id = id;
            var comments = _commentService.GetComments(id);
            return PartialView(comments);
        }
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }
    }
}
