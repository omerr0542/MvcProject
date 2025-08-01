﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetList();
        void ImageFileAdd(ImageFile image);
        void ImageFileDelete(ImageFile image);
        void ImageFileUpdate(ImageFile image);
        ImageFile GetById(int id);
    }
}
