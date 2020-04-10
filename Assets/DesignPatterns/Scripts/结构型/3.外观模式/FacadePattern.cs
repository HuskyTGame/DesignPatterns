/****************************************************
	文件：FacadePattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/10 23:8:16
	功能：外观模式（为复杂的子系统们提供简单对外接口）
*****************************************************/

using UnityEngine;

namespace DesignPatterns
{
    public class FacadePattern : MonoBehaviour
    {
        private void Start()
        {
			//外观类
            FacadeSys facadeSys = new FacadeSys();
			//方便 外部调用 复杂模块 内部的 子系统中的方法
			facadeSys.SysOneMethod();
			facadeSys.SysTwoMethod();
			facadeSys.SysThreeMethod();
        }
    }
    //一个复杂模块中 包含多个子系统
    //此时外部需要调用 子系统中的功能
    //直接调用子系统会显得混乱
    //因此 引入 Facade（外观）类，作为方法的中转
    public class FacadeSys
    {
        private SubSysOne mSysOne;
        private SubSysTwo mSysTwo;
        private SubSysThree mSysThree;

        public FacadeSys()
        {
            mSysOne = new SubSysOne();
            mSysTwo = new SubSysTwo();
            mSysThree = new SubSysThree();
        }
        //中转 子系统的方法 供外部调用
        public void SysOneMethod()
        {
            mSysOne.Method();
        }
        public void SysTwoMethod()
        {
            mSysTwo.Method();
        }
        public void SysThreeMethod()
        {
            mSysThree.Method();
        }
    }
    public class SubSysOne
    {
        public void Method()
        {
            Debug.Log("子系统1的方法");
        }
    }
    public class SubSysTwo
    {
        public void Method()
        {
            Debug.Log("子系统2的方法");
        }
    }
    public class SubSysThree
    {
        public void Method()
        {
            Debug.Log("子系统3的方法");
        }
    }
}