using System;

namespace MyBlog.IComm.IDomain
{
    /// <summary>
    /// 值对象顶层接口
    /// </summary>
    public interface IValueObject
    {
        Guid Id { get; set; }
    }
}
