using System.Net.Mime;
using SkiaSharp;

namespace Exsample.ImageMethods;
using ImageMagick;
public class Magick
{
    private string path = "";

    public MagickImage Recoloring(string str)
    {
        MagickImage result = new MagickImage(path);
        using (result)
        {
            result.ColorSpace = ColorSpace.sRGB;
            using (var pc = result.GetPixels())
            {
                for (int y = 0; y < result.Height; y++)
                {
                    for (int x = 0; x < result.Width; x++)
                    {
                        var pixel = pc.GetPixel(x, y);
                    }
                }
                var popular_colors = result.UniqueColors();
                popular_colors.Write(path);
            }
        }
        return result;
    }

    public MagickImage Watermark(string str)
    {
        MagickImage image = new MagickImage(path);
        using (MagickImage watermark = new MagickImage("Watermark/Watermark.png"))
        {
            image.Composite(watermark, image.Width - 500, image.Height - 500, CompositeOperator.Over);
            image.Write(path);
        } 
        return image;
    }
    

    protected bool is_ligth(Pixel color)
    {
        if (color.GetChannel(0) > 127 || color.GetChannel(1) > 127 || color.GetChannel(2) > 127)
            return true;
        else
            return false;
    }
    
    protected ColorRGB make_color(ColorRGB color)
    {
        ColorRGB new_color = new ColorRGB(255,255,255);
        int[] secure_color = { 0,17,34, 51,68,85, 102, 119, 136, 153, 170, 187, 204, 221, 238, 255};
        int[] color_map = { color.R, color.G, color.B };
        for(int i=0;i < 3;i++)
        {
            int place = 0;
            int dcolor = 255;
            int anticolor = 255 - color_map[i]+51;
            for(int j = 0; j < secure_color.Length; j++)
            {
                int cur_dcolor = Math.Abs( anticolor- secure_color[j]);
                if(cur_dcolor < dcolor)
                {
                    dcolor= cur_dcolor;
                    place= j;
                }
            }
            color_map[i] = secure_color[place];
        }
        new_color = new ColorRGB(Convert.ToByte(color_map[0]), Convert.ToByte(color_map[1]), Convert.ToByte(color_map[2]));
        return new_color;
    }
    
    public Magick(string _path)
    {
        path = _path;
    }
}

