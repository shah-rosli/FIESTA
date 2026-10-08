using FIESTA_Backend.Models;
using FIESTA_Backend.Models.Common;

namespace FIESTA_Backend.Utility
{
    public class FilesBiz
    {
        public FilesBiz()
        {

        }
        public void UploadFiles(string rootPath, string uploadPath, string docNumber, List<Attachments> lsAttachments, string attachmentkey, IFormFileCollection files)
        {
            uploadPath = AppProperties.UploadPath_R14;
            //docNumber = docNumber;// paramsObj.R14_NUMBER;
            //var files = HttpContext.Current.Request.Files;
            attachmentkey = "R14_R14_Attachments";


            string destinationFolder = string.Format("{0}\\{1}\\{2}", rootPath, uploadPath, docNumber);

            foreach(IFormFile file in files)
            {
                Directory.CreateDirectory(destinationFolder);

                var response = lsAttachments.Find(r => r.ATTACHMENT_ACTUAL_FILE_NAME == file.FileName);
                var fileSavePath = System.IO.Path.Combine(destinationFolder, response.ATTACHMENT_SYSTEM_FILE_NAME);

                using (Stream fileStream = new FileStream(fileSavePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    fileStream.Flush();
                }
            }

            //for (int i = 0; i < files.AllKeys.Length; i++)
            //{
            //    if (files.AllKeys[i] == attachmentkey)
            //    {
            //        HttpPostedFile file = files[i];

            //        var response = lsAttachments.Find(r => r.ATTACHMENT_ACTUAL_FILE_NAME == file.FileName);
            //        //var destinationPath = HttpContext.Current.Server.MapPath("sdfa");
            //        var fileSavePath = System.IO.Path.Combine(destinationFolder, response.ATTACHMENT_SYSTEM_FILE_NAME);

            //        //string pathString = System.IO.Path.Combine(folderName, "SubFolder");
            //        System.IO.Directory.CreateDirectory(destinationFolder);

            //        file.SaveAs(fileSavePath);

            //    }
            //}

        }
    }
}
