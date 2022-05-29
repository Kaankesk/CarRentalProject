using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager : IFileHelper
    {
        public object PathConstants { get; private set; }

        public void Delete(string root)
        {
            File.Delete(root);
        }

        public string Update(IFormFile file,string root,string guid)
        {
            var path = root + guid;
            File.Delete(path);           
            using (FileStream fileStream = File.Create(path))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return path;
        }

        public string Upload(IFormFile file, string root)
        {
            var extension = Path.GetExtension(file.FileName);
            var guid = Guid.NewGuid().ToString();
            var fileName = guid + extension;
            var path = root + guid + extension;
            using (FileStream fileStream = File.Create(path))
            {
                file.CopyTo(fileStream);
                fileStream.Flush();
            }
            return fileName;
        }
    }
}
