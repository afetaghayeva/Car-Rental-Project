using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using RecapProject.Business.Abstract;
using RecapProject.Entities.Concrete;

namespace RecapProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly ICarImageService _carImageService;
        public ImagesController(IWebHostEnvironment webHostEnvironment, ICarImageService carImageService)
        {
            _webHostEnvironment = webHostEnvironment;
            _carImageService = carImageService;
        }

        [HttpPost("upload/{carId}")]
        public IActionResult Post([FromForm] IFormFile image,int carId)
        {
            if (image.Length <= 0) return BadRequest();
            var filePath = _webHostEnvironment.WebRootPath + @"\images\";
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(image.FileName);
            var imagePath = filePath +guid+extension;
            var result=_carImageService.Add(new CarImage(){CarId = carId,Date = DateTime.Now,ImagePath = imagePath});
            if (!result.Success)
            {
                return BadRequest(result);
            }
            using var fileStream = System.IO.File.Create(imagePath);
            image.CopyTo(fileStream);
            fileStream.Flush();
            return Ok(result);
        }

        [HttpPost("delete/{carImageId}")]
        public IActionResult Delete(int carImageId)
        {
            var carImage = _carImageService.GetByCarImageId(carImageId);
            if (carImage.Data==null)
            {
                return BadRequest("There is no such carImage");
            }
            var result = _carImageService.Delete(carImage.Data);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            string imagePath = carImage.Data.ImagePath;
            if (!Directory.Exists(imagePath))
            {
                return BadRequest("There is no such path");
            }
            System.IO.File.Delete(imagePath);
            return Ok(result);
        }

        //[HttpPost("update/{carImageId}")]
        //public IActionResult Update([FromForm] IFormFile image,int carImageId)
        //{
        //    var carImage = _carImageService.GetByCarImageId(carImageId);
        //    if (carImage.Data == null)
        //    {
        //        return BadRequest("There is no such carImage");
        //    }
        //    var result = _carImageService.Update(new CarImage() { Id = carImageId,CarId = carImage.Data.CarId, Date = DateTime.Now, ImagePath = carImage.Data.ImagePath });
        //    if (!result.Success)
        //    {
        //        return BadRequest(result);
        //    }
        //    using var fileStream = System.IO.File.Create(carImage.Data.ImagePath);
        //    image.CopyTo(fileStream);
        //    fileStream.Flush();
        //    return Ok(result);

        //}

    }
}
