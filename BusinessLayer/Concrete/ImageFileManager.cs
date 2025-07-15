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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public ImageFile GetById(int id)
        {
            return _imageFileDal.Get(x => x.ImageID == id);
        }

        public List<ImageFile> GetList()
        {
            return _imageFileDal.List();
        }

        public void ImageFileAdd(ImageFile image)
        {
            _imageFileDal.Insert(image);
        }

        public void ImageFileDelete(ImageFile image)
        {
            _imageFileDal.Delete(image);
        }

        public void ImageFileUpdate(ImageFile image)
        {
            _imageFileDal.Update(image);
        }
    }
}
