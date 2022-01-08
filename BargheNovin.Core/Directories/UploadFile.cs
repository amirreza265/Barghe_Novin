using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BargheNovin.Core.Generator;

namespace BargheNovin.Core.Directories
{
    public class UploadFile
    {
        /// <summary>
        /// Add file to paths 
        /// </summary>
        /// <param name="file">file</param>
        /// <param name="newName"> create new name </param>
        /// <param name="paths">File storage location</param>
        /// <returns>saved file name</returns>
        public static string AddFile(IFormFile file, bool newName = true, params string[] paths)
        {

            string newFileName;
            if (newName)
                newFileName = TextCodeGenerator.GenerateUniqCode()
                + Path.GetExtension(file.FileName);
            else
                newFileName = file.FileName;

            string newFilePath = CreatePath(newFileName, paths);

            using (Stream s = new FileStream(newFilePath, FileMode.Create))
            {
                file.CopyTo(s);
            }

            return newFileName;
        }

        /// <summary>
        /// remove oldfile if exist and add new file
        /// </summary>
        /// <param name="file"></param>
        /// <param name="oldFileName"></param>
        /// <param name="paths">directory</param>
        /// <param name="exceptionNames">Files that should not be deleted</param>
        /// <returns>new file name</returns>
        public static string ReplaceNew(IFormFile file, string oldFileName, string[] exceptionNames = null, params string[] paths)
        {
            string filePath = CreatePath(oldFileName,paths: paths);

            if (System.IO.File.Exists(filePath) && !(exceptionNames?.Length > 0 && exceptionNames.Contains(oldFileName)))
                System.IO.File.Delete(filePath);


            return AddFile(file,paths: paths);
        }
        public static void ReplaceFile(IFormFile file, string oldFileName,params string[] paths)
        {
            string filePath = CreatePath(oldFileName,paths: paths);

            if (System.IO.File.Exists(filePath))
                System.IO.File.Delete(filePath);


            string newFilePath = CreatePath(oldFileName, paths);

            using (Stream s = new FileStream(newFilePath, FileMode.Create))
            {
                file.CopyTo(s);
            }

        }

        public static string CreatePath(string fileName, params string[] paths)
        {
            var root = Path.Combine(paths);
            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
            root,
            fileName);
            return filePath;
        }

        public static void DeleteFile(string name, params string[] paths)
        {
            string filePath = CreatePath(name, paths);
            System.IO.File.Delete(filePath);
        }

        public static bool FileExists(string name, params string[] paths)
        {
            string filePath = CreatePath(name, paths);
            return System.IO.File.Exists(filePath);
        }

    }
}
