
namespace YouYou
{
    /// <summary>
    /// 更新组件 接口
    /// </summary>
    public interface IUpdateComponent
    {
        /// <summary>
        /// 更新方法
        /// </summary>
        void OnUpdate();

        /// <summary>
        /// 实例编号
        /// </summary>
        int InstanceId { get; }

    }
}