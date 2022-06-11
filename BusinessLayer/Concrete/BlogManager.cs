using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            this.blogDal = blogDal;
        }
        

        public List<Blog> GetBlogListWhitCategory()
        {
            return blogDal.GetListWithCategory();
        }

        public List<Blog> GetList()
        {
            return blogDal.GetListAll();
        }
        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return blogDal.GetListWithCategoryByWriter(id);
        }
        public List<Blog> GetBlogListByWriter(int id)
        {
            return blogDal.GetListAll(x => x.WriterID == id);
        }
        public List<Blog> GetLast3Blog()
        {
            return blogDal.GetListAll().Take(3).ToList();
        }

        public void TAdd(Blog t)
        {
            blogDal.Insert(t);
        }

        public void TDelete(Blog t)
        {
            blogDal.Delete(t);
        }

        public void TUpdate(Blog t)
        {
            blogDal.Update(t);
        }

        public Blog TGetById(int id)
        {
            return blogDal.GetById(id);
        }
    }
}
