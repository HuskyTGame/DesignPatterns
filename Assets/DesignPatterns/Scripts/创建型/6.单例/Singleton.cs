/****************************************************
	文件：Singleton.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/10 19:16:22
	功能：单例模式（懒汉式）
*****************************************************/

namespace DesignPatterns
{
    public class Singleton<T> where T : class, new()
    {
        private static T mInstance;
        public static T Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new T();
                }
                return mInstance;
            }
        }
    }
}
