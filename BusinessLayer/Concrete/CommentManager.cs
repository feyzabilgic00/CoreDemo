using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        private readonly ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        public void AddComment(Comment comment)
        {
            _commentDal.Add(comment);
        }

        public Comment GetComment(int id)
        {
            return _commentDal.GetById(x => x.Id == id);
        }

        public List<Comment> GetComments(int id)
        {
            return _commentDal.GetAll(x => x.Blog.Id == id);
        }
    }
}
