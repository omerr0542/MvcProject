﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void DeleteContent(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content GetByID(int ID)
        {
            return _contentDal.Get(x => x.ContentID == ID);
        }

        public List<Content> GetList()
        {
            return _contentDal.List(); 
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDal.FilterWithIncludes(x => x.HeadingID == id, x => x.Writer);
        }

        public void UpdateContent(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
