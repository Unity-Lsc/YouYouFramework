using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 字节操作类
/// </summary>
public sealed class BitUtil
{
    /// <summary>
    /// 获取取第index位
    /// </summary>
    /// <param name="b"></param>
    /// <param name="index">index从0开始</param>
    /// <returns></returns>
    public static int GetBit(byte b, int index)
    {
        return (b & (1 << index)) > 0 ? 1 : 0;
    }

    /// <summary>
    /// 将第index位设为1
    /// </summary>
    /// <param name="b"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static byte SetBit(byte b, int index)
    {
        return (byte) (b | (1 << index));
    }

    /// <summary>
    /// 将第index位设为0
    /// </summary>
    /// <param name="b"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static byte ClearBit(byte b, int index)
    {
        return (byte) (b & (byte.MaxValue - (1 << index)));
    }

    /// <summary>
    /// 将第index位取反
    /// </summary>
    /// <param name="b"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public static byte ReverseBit(byte b, int index)
    {
        return (byte) (b ^ (byte) (1 << index));
    }
}