using KudoCode.Contracts;
using KudoCode.Contracts.Web;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KudoCode.Web.Api.Controllers
{
    [Route("api/Media")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private IConfiguration _configuration;

        public MediaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Upload")]
        //[EnableCors("AllowOrigin")]
        public async Task<ActionResult> Upload(ICollection<IFormFile> files)
        {
            try
            {
                const string accountName = "kudocodesocial";
                const string key = "0E97K5ebxUaFYpgQZsRHm7v89LnCK6lcA9wgx8l8hz7wCRrE6gSAidJN7+JlVC/uX81RGuL/gJH6TPaQD8te/w==";

                var storageAccount = new CloudStorageAccount(new StorageCredentials(accountName, key), true);
                var filePaths = new List<FileUploadResult>();

                foreach (var item in files)
                {
                    var fileName = $"{item.FileName}_{Guid.NewGuid()}";
                    var blobClient = storageAccount.CreateCloudBlobClient();
                    var container = blobClient.GetContainerReference("social");
                    await container.CreateIfNotExistsAsync();
                    await container.SetPermissionsAsync(new BlobContainerPermissions()
                    {
                        PublicAccess = BlobContainerPublicAccessType.Blob
                    });


                    var blob = container.GetBlockBlobReference(fileName);
                    using (var stream = item.OpenReadStream())
                        await blob.UploadFromStreamAsync(stream);

                    filePaths.Add(new FileUploadResult() { OriginalName = item.FileName, CloudName = fileName, Url= blob.StorageUri.PrimaryUri.ToString() });
                }

                // Put your code here
                return StatusCode(200, filePaths);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
