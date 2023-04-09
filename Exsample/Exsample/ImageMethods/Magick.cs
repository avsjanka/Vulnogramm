using SkiaSharp;

namespace Exsample.ImageMethods;
using ImageMagick;
using SkiaSharp.QrCode;
public class Magick
{
    private string path = "";
    
    protected string StreetBeat( string force)
    {
        string str = string.Empty;
        foreach (char chr in force)
        {
            if (Convert.ToString(Convert.ToByte(chr), 2).Length == 8)
                str += (Convert.ToString(Convert.ToByte(chr), 2));
            else
            {
                string buffer = "";
                while (Convert.ToString(Convert.ToByte(chr), 2).Length + buffer.Length != 8)
                    buffer += "0";
                str += buffer;
                str += (Convert.ToString(Convert.ToByte(chr), 2));
            }
        }
        return str;
    }
    
    public MagickImage Watermark()
    {
        MagickImage image = new MagickImage(path);
        using (MagickImage watermark = new MagickImage("Watermark/Watermark.png"))
        {
            image.Composite(watermark, 0, 0, CompositeOperator.Over);
            image.Write(path);
        } 
        return image;
    }
    
    protected static int from_bin_to_int(string str)
    {
        int num = 0;
        for (int i = str.Length - 1, pow = 0; i > -1; i--, pow++)
        {
            if (str[i] == '1')
                num += Convert.ToInt32(Math.Pow(2, pow));
        }
        return num;
    }

    public MagickImage NewText(string text)
    {
        MagickImage result = new MagickImage(path);

        return result;
    }
    public MagickImage TheLastofUS(string virus)
    {
        MagickImage result = new MagickImage(path);
        string your_virus = StreetBeat(virus);
        using (result)
        {
            result.ColorSpace = ColorSpace.sRGB;
            using (var pc = result.GetPixels())
            {
                for (int y = 0, i = 0; (y < 1 + your_virus.Length / result.Width) && i < your_virus.Length; y++)
                {
                    for (int x = 0; x < result.Width && i <your_virus.Length; x++, i+=4)
                    {
                        var episod= pc.GetPixel(x, y);
                        string first = "00" + Convert.ToString(episod.GetChannel(0),2);
                        string second = "00" + Convert.ToString(episod.GetChannel(1), 2);
                        string _in = "";
                        _in += your_virus[i]; 
                        _in += your_virus[i + 1];
                        if (first.EndsWith(_in) == false)
                        {
                            first = first.Substring(0, first.Length - 2);
                            first += _in;
                            episod.SetChannel(0,Convert.ToByte(from_bin_to_int(first)));
                        }
                        _in = "";
                        _in += your_virus[i+2]; 
                        _in += your_virus[i + 3];
                        if (second.EndsWith(_in) == false)
                        {
                            second = second.Substring(0, second.Length - 2);
                            second += _in;
                            episod.SetChannel(1,Convert.ToByte(from_bin_to_int(second)));
                        }
                    }
                }
            }
            result.Write(path);
        }
        return result;
    }
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

