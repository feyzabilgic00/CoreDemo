using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents.Comment
{
    public class CommentListByBlog : ViewComponent
    {
        private readonly ICommentService _commentService;
        public CommentListByBlog(ICommentService commentService)
        {
            _commentService = commentService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.GetComments(id);
            return View(values);
        }
    }
}
