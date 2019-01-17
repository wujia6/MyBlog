using System;

namespace MyBlog.IComm.IDomain
{
    /// <summary>
    /// 实体顶层接口
    /// </summary>
    public interface IEntity
    {
        Guid Id { get; set; }

        string Code { get; set; }
    }
}
