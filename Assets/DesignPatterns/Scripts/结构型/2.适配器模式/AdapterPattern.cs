/****************************************************
	文件：AdapterPattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/10 22:31:17
	功能：适配器模式（一般不使用此模式）
*****************************************************/

using UnityEngine;

namespace DesignPatterns
{
    //适配器模式
    //一般不使用
    //只有当需求突然改变，此时又急需快速实现功能，或者实现功能需要太多的改变
    //此时使用适配器模式，将 新功能 替换 旧功能
    public class AdapterPattern : MonoBehaviour
    {
        private void Start()
        {
            //旧功能：只能显示中文字幕
            LanguageMgr lanMgr = new LanguageMgr();
            Debug.Log("旧功能：" + lanMgr.GetText(new object()));

            //新功能：通过适配器 LanguageAdapter 适配了新功能：显示英文字幕
            lanMgr = new LanguageAdapter(new LanguageEnglishMgr());
            Debug.Log("新功能：" + lanMgr.GetText(new object()));

			//注意：只有创建对象的过程有修改，其余功能调用的地方均不变
			//适配器模式 适合应对突如其来的需求变动
        }
    }

    /// <summary>
    /// 旧功能（只能显示中文）
    /// </summary>
    public class LanguageMgr
    {
        public virtual string GetText(object key)
        {
            return "中文字幕";
        }
    }
    //现在需要更换语言为英文，但事先并未设计过
    //此时突然需要改动，可以使用适配器模式

    public class LanguageAdapter : LanguageMgr
    {
        private LanguageEnglishMgr mLanguageEnMgr;
        public LanguageAdapter(LanguageEnglishMgr enMgr)
        {
            mLanguageEnMgr = enMgr;
        }
        public override string GetText(object key)
        {
            return mLanguageEnMgr.GetEnText(key);
        }
    }
    public class LanguageEnglishMgr
    {
        public string GetEnText(object key)
        {
            return "英文字幕";
        }
    }
}
