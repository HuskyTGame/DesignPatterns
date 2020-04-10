/****************************************************
	文件：DecoratorPattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/10 19:52:56
	功能：装饰模式（动态为对象添加额外职责）
*****************************************************/

using UnityEngine;

namespace DesignPatterns
{
    public class DecoratorPattern : MonoBehaviour
    {
        private void Start()
        {
            //均继承自同一接口（IEntity）
            Npc npc1 = new Npc();
            LookBev lookBev = new LookBev();
            MoveBev moveBev = new MoveBev();
            SayBev sayBev = new SayBev();
            LeaveBev leaveBev = new LeaveBev();

            //动态为对象添加职责
            lookBev.Decorate(npc1);//使用 LookBev 装饰 Npc
            moveBev.Decorate(lookBev);
            sayBev.Decorate(moveBev);
            leaveBev.Decorate(sayBev);

            leaveBev.Do();
        }
    }

    public interface IEntity
    {
        void Do();
    }
    public class Npc : IEntity
    {
        public void Do()
        {
            Debug.Log("Npc doing......");
        }
    }

    public abstract class Decorator : IEntity
    {
        private IEntity mEntity;
        public virtual void Do()
        {
            if (mEntity != null)
            {
                mEntity.Do();
            }
        }
        /// <summary>
        /// 装饰（为对象entity 添加 新行为LookBev/MoveBev...）
        /// </summary>
        /// <param 被装饰的对象="entity"></param>
        public void Decorate(IEntity entity)
        {
            mEntity = entity;
        }
    }
    public class LookBev : Decorator
    {
        public override void Do()
        {
            base.Do();
            NewBev();
        }
		//LookBev 的新逻辑
        private void NewBev()
        {
            Debug.Log("Looking...");
        }
    }
    public class MoveBev : Decorator
    {
        public override void Do()
        {
            base.Do();
            NewBev();
        }
        private void NewBev()
        {
            Debug.Log("Moveing....");
        }
    }
    public class SayBev : Decorator
    {
        public override void Do()
        {
            base.Do();
            NewBev();
        }
        private void NewBev()
        {
            Debug.Log("Say hi.....");
        }
    }
    public class LeaveBev : Decorator
    {
        public override void Do()
        {
            base.Do();
            NewBev();
        }
        private void NewBev()
        {
            Debug.Log("Say bye......");
        }
    }
}
