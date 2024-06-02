using Bet.Bussiness.Interfaces;
using Bet.Common;
using Bet.Common.Enum;
using Bet.Common.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BetDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachmentController : ControllerBase
    {

        public IAttachmentBussiness _attachmentBussiness;

        public AttachmentController(IAttachmentBussiness attachmentBussiness) {           
            this._attachmentBussiness = attachmentBussiness;
        }

        [HttpGet]
        [Route("Images")]
        [AllowAnonymous]
        public async Task GetImages(string fileName)
        {
            try
            {                
                byte[] data = await this._attachmentBussiness.GetImage(fileName);
                // quản lý cache ảnh
                HttpContext.Response.ContentType = "image/jpg";
                await HttpContext.Response.Body.WriteAsync(data, 0, data.Length);
            }
            catch (Exception ex)
            {
                LogCustom.LogError(ex, "Error GetImages");
            }
            return;
        }

        [HttpPost]
        [Route("Upload/{type}")]
        [AllowAnonymous]

        public async Task<ServiceResult> UploadImages(IFormFile[] data, string type = "Images")
        {
            ServiceResult serviceResult = new ServiceResult();
            try
            {
                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    foreach(IFormFile file in HttpContext.Request.Form.Files)
                    {                        
                        string location = !string.IsNullOrEmpty(type) ? type: "Files";
                        using (FileStream fileStream = new FileStream($"{BetUtil.RootPath}/wwwroot/{location}/{file.FileName}", FileMode.OpenOrCreate, FileAccess.Write))
                        {
                            file.CopyTo(fileStream);
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                LogCustom.LogError(ex, "Error UploadImages");
                return ServiceResult.ExceptionCustom(ex, "Error UploadImages");
            }
            return serviceResult; 
        }

        [HttpGet("Images/Download")]
        public async Task<IActionResult> DownloadImages(string fileName)
        {            
            try
            {
                var imageEntity = await this._attachmentBussiness.GetImage(fileName);

                if (imageEntity != null && imageEntity.Length > 0)
                {
                    var fileContentResult = new FileContentResult(imageEntity, "application/octet-stream")
                    {
                        FileDownloadName = fileName
                    };
                    return fileContentResult;
                }
                
            }
            catch(Exception ex)
            {
                LogCustom.LogError(ex, "Error DownloadImage");
                return Ok(ServiceResult.ExceptionCustom(ex, "Error DownloadImage"));
            }
            return Ok(new ServiceResult());

        }
    }
}
