using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreDemo.ViewComponents
{
    public class CommentList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var commnetValues = new List<CommentUser>
            {
                new CommentUser
                {
                    Id = 1,
                    UserName = "Feyza",
                },
                new CommentUser
                {
                    Id = 2,
                    UserName = "Emine",
                },
                new CommentUser
                {
                    Id = 3,
                    UserName = "Azize",
                }
            };
            return View(commnetValues);
        }
    }
}
