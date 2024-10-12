using System.IO;
using System.IO.Compression;


/// <summary>
/// 压缩工具类
/// </summary>
public class GZipUtil
{
    #region Compress 压缩指定字节数组
    /// <summary>
    /// 压缩指定字节数组
    /// </summary>
    /// <param name="bytes">待压缩字节数组</param>
    /// <returns>返回压缩后的字节数组</returns>
    public static byte[] Compress(byte[] bytes)
    {
        if (bytes == null || bytes.Length <= 0) return bytes;

        using (var compressedStream = new MemoryStream())
        {
            using (var compressionStream = new GZipStream(compressedStream, CompressionMode.Compress))
            {
                compressionStream.Write(bytes, 0, bytes.Length);
            }
            return compressedStream.ToArray();
        }
    }
    #endregion

    #region Decompress 从指定字节数组解压出字节数组
    /// <summary>
    /// 从指定字节数组解压出字节数组
    /// </summary>
    /// <param name="bytes">待解压的字节数组</param>
    /// <returns>返回解压后的字节数组</returns>
    public static byte[] Decompress(byte[] bytes)
    {
        if (bytes == null || bytes.Length <= 0) return bytes;
        using (var originalStream = new MemoryStream(bytes))
        {
            using (var decompressedStream = new MemoryStream())
            {
                using (var decompressionStream = new GZipStream(originalStream, CompressionMode.Decompress))
                {
                    decompressionStream.CopyTo(decompressedStream);
                }
                return decompressedStream.ToArray();
            }
        }
    }
    #endregion
}