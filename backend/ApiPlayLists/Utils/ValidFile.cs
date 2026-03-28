using System;

namespace ApiPlayLists.Utils;

public class ValidFile
{

    public static bool IsRealMp3(IFormFile file)
    {
        using var stream = file.OpenReadStream();
        using var reader = new BinaryReader(stream);

        var bytes = reader.ReadBytes(3);

        // "ID3"
        if (bytes[0] == 0x49 && bytes[1] == 0x44 && bytes[2] == 0x33)
            return true;

        stream.Position = 0;
        bytes = reader.ReadBytes(2);

        // Frame sync MP3
        return bytes[0] == 0xFF &&
               (bytes[1] == 0xFB || bytes[1] == 0xF3 || bytes[1] == 0xF2);
    }

    public static bool IsRealImage(IFormFile file)
    {
        using var stream = file.OpenReadStream();
        using var reader = new BinaryReader(stream);

        var header = reader.ReadBytes(12);

        // JPG/JPEG
        if (header.Length >= 3 &&
            header[0] == 0xFF &&
            header[1] == 0xD8 &&
            header[2] == 0xFF)
            return true;

        // PNG
        if (header.Length >= 8 &&
            header[0] == 0x89 &&
            header[1] == 0x50 &&
            header[2] == 0x4E &&
            header[3] == 0x47 &&
            header[4] == 0x0D &&
            header[5] == 0x0A &&
            header[6] == 0x1A &&
            header[7] == 0x0A)
            return true;

        // GIF
        if (header.Length >= 4 &&
            header[0] == 0x47 &&
            header[1] == 0x49 &&
            header[2] == 0x46 &&
            header[3] == 0x38)
            return true;

        // WEBP (RIFF....WEBP)
        if (header.Length >= 12 &&
            header[0] == 0x52 && // R
            header[1] == 0x49 && // I
            header[2] == 0x46 && // F
            header[3] == 0x46 && // F
            header[8] == 0x57 && // W
            header[9] == 0x45 && // E
            header[10] == 0x42 && // B
            header[11] == 0x50)  // P
            return true;

        return false;
    }

}
