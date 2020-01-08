using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingWallpaper
{

    /// <summary>
    /// 壁纸图片信息类
    /// </summary>
    class PictureInfo
    {
        //壁纸的热点说明信息
        public List<string> hotspot { get; set; }

        //壁纸的主题
        public string imgTitle { get; set; }

        //壁纸图片的地址
        public Uri imageUri
    }
}
