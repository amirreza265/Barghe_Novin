using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BargheNovin.Core.Directories
{
    public static class ImageResize
    {
        public static void MakeSquerImage(string imageName, int imageSize = 240, params string[] paths)
        {
            var root = Path.Combine(paths);
            var imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                    root,
                    imageName);

            using (Image<Rgba32> image = (Image<Rgba32>)Image.Load(imgPath))
            {
                if (imageSize <= 0)
                {
                    imageSize = (image.Height < image.Width)?image.Height:image.Width;
                }

                image.Mutate(x =>x
                .Resize(imageSize, (int)(imageSize * ((float)(image.Height / image.Width))))
                .Crop(
                    (imageSize > x.GetCurrentSize().Width) ? x.GetCurrentSize().Width : imageSize,
                    (imageSize > x.GetCurrentSize().Height) ? x.GetCurrentSize().Height : imageSize));

                image.Save(imgPath); // Automatic encoder selected based on extension.
            }
        }
        public static void Resize(string imageName, int imageWidth = 240, int imageHeight = 240, params string[] paths)
        {
            var root = Path.Combine(paths);
            var imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                    root,
                    imageName);

            int max = (imageWidth > imageHeight) ?imageWidth:imageHeight;
            using (Image<Rgba32> image = (Image<Rgba32>)Image.Load(imgPath))
            {
                image.Mutate(x => x
                     .Resize(imageWidth,imageHeight)
                     .Crop(
                     (imageWidth > x.GetCurrentSize().Width) ? x.GetCurrentSize().Width : imageWidth,
                     (imageHeight > x.GetCurrentSize().Height)? x.GetCurrentSize().Height : imageHeight)
                     );

                image.Save(imgPath); // Automatic encoder selected based on extension.
            }
        }

        public static void Resize(string imageName, int maxHeight = 360, params string[] paths)
        {
            var root = Path.Combine(paths);
            var imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                    root,
                    imageName);

            using (Image<Rgba32> image = (Image<Rgba32>)Image.Load(imgPath))
            {
                image.Mutate(x => {
                    var imageWidth = maxHeight * x.GetCurrentSize().Width / x.GetCurrentSize().Height;
                    x.Resize(imageWidth, maxHeight)
                      .Crop(
                      (imageWidth > x.GetCurrentSize().Width) ? x.GetCurrentSize().Width : imageWidth,
                      (maxHeight > x.GetCurrentSize().Height) ? x.GetCurrentSize().Height : maxHeight);
                     });

                image.Save(imgPath); // Automatic encoder selected based on extension.
            }
        }
    }
}
