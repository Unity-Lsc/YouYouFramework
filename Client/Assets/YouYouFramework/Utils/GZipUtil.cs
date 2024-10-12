using System.IO;
using System.IO.Compression;


/// <summary>
/// ѹ��������
/// </summary>
public class GZipUtil
{
    #region Compress ѹ��ָ���ֽ�����
    /// <summary>
    /// ѹ��ָ���ֽ�����
    /// </summary>
    /// <param name="bytes">��ѹ���ֽ�����</param>
    /// <returns>����ѹ������ֽ�����</returns>
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

    #region Decompress ��ָ���ֽ������ѹ���ֽ�����
    /// <summary>
    /// ��ָ���ֽ������ѹ���ֽ�����
    /// </summary>
    /// <param name="bytes">����ѹ���ֽ�����</param>
    /// <returns>���ؽ�ѹ����ֽ�����</returns>
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