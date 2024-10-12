using System;

public static class XXTEAUtil
{
    public static readonly byte[] SoketKey = {102, 120, 22, 24, 88, 6, 119, 88};

    /// <summary>
    /// 加密
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte[] Encrypt(byte[] data)
    {
        if (data.Length == 0)
        {
            return data;
        }

        return ToByteArray(Encrypt(ToIntArray(data, true), ToIntArray(SoketKey, false)), false);
    }

    /// <summary>
    /// 解密
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    public static byte[] Decrypt(byte[] data)
    {
        if (data.Length == 0)
        {
            return data;
        }

        return ToByteArray(Decrypt(ToIntArray(data, false), ToIntArray(SoketKey, false)), true);
    }

    public static string Encrypt(string source, string key)
    {
        System.Text.Encoding encoder = System.Text.Encoding.UTF8;
        byte[] bytData = encoder.GetBytes(source);
        byte[] bytKey = encoder.GetBytes(key);
        if (bytData.Length == 0)
        {
            return "";
        }

        return System.Convert.ToBase64String(
            ToByteArray(Encrypt(ToIntArray(bytData, true), ToIntArray(bytKey, false)), false));
    }

    public static string Decrypt(string source, string key)
    {
        if (source.Length == 0)
        {
            return "";
        }

        // reverse 
        System.Text.Encoding encoder = System.Text.Encoding.UTF8;
        byte[] bytData = System.Convert.FromBase64String(source);
        byte[] bytKey = encoder.GetBytes(key);

        return 
            encoder.GetString(ToByteArray(Decrypt(ToIntArray(bytData, false), ToIntArray(bytKey, false)), true));
    }

    private static int[] Encrypt(int[] v, int[] k)
    {
        int n = v.Length - 1;

        if (n < 1)
        {
            return v;
        }

        if (k.Length < 4)
        {
            int[] key = new int[4];

            System.Array.Copy(k, 0, key, 0, k.Length);
            k = key;
        }

        int z = v[n], y = v[0];
        int delta = -1640531527;
        int sum = 0, e;
        int p, q = 6 + 52 / (n + 1);

        while (q-- > 0)
        {
            sum = (int) (sum + delta);
            e = sum.RightMove(2) & 3;
            // Debug.LogError("e=" + e);
            // Debug.LogError("sum=" + sum);
            for (p = 0; p < n; p++)
            {
                y = v[p + 1];
                z = v[p] += (z.RightMove(5) ^ y << 2) + (y.RightMove(3) ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
            }

            y = v[0];
            z = v[n] += (z.RightMove(5) ^ y << 2) + (y.RightMove(3) ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
        }

        return v;
    }

    private static int[] Decrypt(int[] v, int[] k)
    {
        int n = v.Length - 1;

        if (n < 1)
        {
            return v;
        }

        if (k.Length < 4)
        {
            int[] key = new int[4];

            System.Array.Copy(k, 0, key, 0, k.Length);
            k = key;
        }

        int z = v[n], y = v[0], delta = -1640531527, sum, e;
        int p, q = 6 + 52 / (n + 1);

        sum = q * delta;
        while (sum != 0)
        {
            e = sum.RightMove(2) & 3;
            for (p = n; p > 0; p--)
            {
                z = v[p - 1];
                y = v[p] -= (z.RightMove(5) ^ y << 2) + (y.RightMove(3) ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
            }

            z = v[n];
            y = v[0] -= (z.RightMove(5) ^ y << 2) + (y.RightMove(3) ^ z << 4) ^ (sum ^ y) + (k[p & 3 ^ e] ^ z);
            sum = sum - delta;
        }

        return v;
    }

    public static int[] ToIntArray(byte[] data, bool includeLength)
    {
        int n = (data.Length & 3) == 0 ? data.Length.RightMove(2) : (data.Length.RightMove(2)) + 1;
        int[] result;

        if (includeLength)
        {
            result = new int[n + 1];
            result[n] = data.Length;
        }
        else
        {
            result = new int[n];
        }


        n = data.Length;
        for (int i = 0; i < n; i++)
        {
            result[i.RightMove(2)] |= (0x000000ff & data[i]) << ((i & 3) << 3);
        }

        return result;
    }

    public static byte[] ToByteArray(int[] data, bool includeLength)
    {
        int n = data.Length << 2;
        if (includeLength)
        {
            int m = data[data.Length - 1];

            if (m > n)
            {
                return null;
            }
            else
            {
                n = m;
            }
        }

        byte[] result = new byte[n];

        for (int i = 0; i < n; i++)
        {
            result[i] = (byte) ((data[i.RightMove(2)].RightMove((i & 3) << 3)) & 0xff);
        }

        return result;
    }

    public static string Base64Decode(string data)
    {
        try
        {
            var encoder = System.Text.Encoding.UTF8;
            byte[] todecodeByte = Convert.FromBase64String(data);
            return encoder.GetString(todecodeByte);
        }
        catch (Exception e)
        {
            throw new Exception("Error in base64Decode" + e.Message);
        }
    }

    public static string Base64Encode(string data)
    {
        try
        {
            var encDataByte = System.Text.Encoding.UTF8.GetBytes(data);
            string encodedData = Convert.ToBase64String(encDataByte);
            return encodedData;
        }
        catch (Exception e)
        {
            throw new Exception("Error in base64Encode" + e.Message);
        }
    }

    public static int RightMove(this int value, int pos)
    {
        //移动 0 位时直接返回原值
        if (pos != 0)
        {
            // int.MaxValue = 0x7FFFFFFF 整数最大值
            int mask = int.MaxValue;
            //无符号整数最高位不表示正负但操作数还是有符号的，有符号数右移1位，正数时高位补0，负数时高位补1
            value = value >> 1;
            //和整数最大值进行逻辑与运算，运算后的结果为忽略表示正负值的最高位
            value = value & mask;
            //逻辑运算后的值无符号，对无符号的值直接做右移运算，计算剩下的位
            value = value >> pos - 1;
        }

        return value;
    }
}