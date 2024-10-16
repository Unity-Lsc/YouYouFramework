

/// <summary>
/// String的一些扩展工具类
/// </summary>
public static class StringUtil 
{
    /// <summary>
    /// 判断对象是否为Null、DBNull、Empty或空白字符串
    /// </summary>
    public static bool IsNullOrEmpty(string value) {

        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return true;
        }
        return false; ;
    }

    /// <summary>
    /// 把string类型转换成int
    /// </summary>
    public static int ToInt(string str) {
        int.TryParse(str, out int temp);
        return temp;
    }

    /// <summary>
    /// 把string类型转换成long
    /// </summary>
    public static long ToLong(string str) {
        long.TryParse(str, out long temp);
        return temp;
    }

    /// <summary>
    /// 把string类型转换成float
    /// </summary>
    public static float ToFloat(string str) {
        float.TryParse(str, out float temp);
        return temp;
    }
}