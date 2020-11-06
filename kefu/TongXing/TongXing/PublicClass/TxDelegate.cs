using System;
namespace SanNiuSignal
{
    /// <summary>
    /// 不带参数的委托
    /// </summary>
    public delegate void TxDelegate();
    /// <summary>
    /// 带一个参数的委托
    /// </summary>
    /// <typeparam name="T1">T1</typeparam>
    /// <param name="object1"></param>
    public delegate void TxDelegate<T1>(T1 object1);
    /// <summary>
    /// 带二个参数的委托
    /// </summary>
    /// <typeparam name="T1">T1</typeparam>
    /// <typeparam name="T2">T2</typeparam>
    /// <param name="object1">object1</param>
    /// <param name="object2">object2</param>
    public delegate void TxDelegate<T1,T2>(T1 object1,T2 object2);
#pragma warning disable CS1591 // 缺少对公共可见类型或成员的 XML 注释
    public delegate void TxDelegate<T1,T2,T3>(T1 object1,T2 object2,T3 object3);
#pragma warning restore CS1591 // 缺少对公共可见类型或成员的 XML 注释
}
