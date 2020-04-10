/****************************************************
	文件：BridgePattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/11 0:9:38
	功能：桥接模式（依赖倒置，依赖抽象而非实现）
*****************************************************/

using UnityEngine;

namespace DesignPatterns
{
    public class BridgePattern : MonoBehaviour
    {
        private void Start()
        {
            //依赖抽象  而非  具体实现
            //抽象 是 Has a 关系
            ResLoader resloader = new ResLoader(new ABRes());
            resloader.Load();//加载AB包
        }
    }

    //抽象（抽象 Has a 抽象）
    public abstract class LoaderBase
    {
        protected ResBase mRes;
        public LoaderBase(ResBase res)
        {
            mRes = res;
        }
        public abstract void Load();
    }
    public abstract class ResBase
    {
        public abstract void Load();
    }
    //实现
    public class ResLoader : LoaderBase
    {
        public ResLoader(ResBase res) : base(res)
        {
        }

        public override void Load()
        {
            mRes.Load();
        }
    }
    public class ABRes : ResBase
    {
        public override void Load()
        {
            Debug.Log("加载AB包");
        }
    }
    public class AssetRes : ResBase
    {
        public override void Load()
        {
            Debug.Log("加载Asset");
        }
    }
    public class ResourceRes : ResBase
    {
        public override void Load()
        {
            Debug.Log("加载Resource");
        }
    }
}