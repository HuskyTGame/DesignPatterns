using System.Collections.Generic;
/****************************************************
	文件：CompositePattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/11 0:39:42
	功能：组合模式（将基本对象组合成组合对象，应用场景尚不明）
*****************************************************/

using UnityEngine;

namespace DesignPatterns
{
    public class CompositePattern : MonoBehaviour
    {
        private void Start()
        {
			//组合模式：使用场景尚不明确（待以后更新）
			
            Leader bigLeader = new Leader("大首领");
            bigLeader.Add(new AtkMember("大首领的攻击小队"));
            bigLeader.Add(new DefMember("大首领的防御小队"));
            Leader midLeaderA = new Leader("首领A");
            bigLeader.Add(midLeaderA);
            midLeaderA.Add(new AtkMember("首领A的攻击小队"));
            midLeaderA.Add(new NormalMember("首领A的普通小队"));
            Leader smaLeaderA = new Leader("小队长A");
            Leader smaLeaderB = new Leader("小队长B");
            Leader smaLeaderC = new Leader("小队长C");
            midLeaderA.Add(smaLeaderA);
            midLeaderA.Add(smaLeaderB);
            midLeaderA.Add(smaLeaderC);
            smaLeaderA.Add(new AtkMember("小队长A的攻击小队"));
            smaLeaderB.Add(new DefMember("小队长B的防御小队"));
            smaLeaderB.Add(new NormalMember("小队长B的普通小队"));

            //树状结构展示
            bigLeader.Display(1);
            Debug.Log("////////------------分割线------------////////");
            //内部逻辑
            bigLeader.Do();
        }
    }

    public abstract class EntityBase
    {
        protected string mName;//节点名
        public EntityBase(string name)
        {
            mName = name;
        }
        public abstract void Add(EntityBase entity);//添加子节点
        public abstract void Remove(EntityBase entity);//删除子节点
        public abstract void Display(int depth);//（递归）展示节点
        public abstract void Do();//各个节点内部逻辑
    }
    //组合节点（非叶子节点，可以 添加/删除 子节点）
    public class Leader : EntityBase
    {
        private List<EntityBase> mchildren;//存储所有子节点
        public Leader(string name) : base(name)
        {
            mchildren = new List<EntityBase>();
        }

        public override void Add(EntityBase entity)
        {
            mchildren.Add(entity);
        }
        public override void Remove(EntityBase entity)
        {
            mchildren.Remove(entity);
        }
        public override void Display(int depth)
        {
            Debug.Log(new string('-', depth) + mName);
            for (int i = 0; i < mchildren.Count; i++)
            {
                mchildren[i].Display(depth + 2);
            }
        }
        public override void Do()
        {
            Debug.Log(mName + "正在指挥他的小弟...");
            for (int i = 0; i < mchildren.Count; i++)
            {
                mchildren[i].Do();
            }
        }
    }
    //叶子节点（不具有 添加/删除 子节点的功能）
    public class AtkMember : EntityBase
    {
        public AtkMember(string name) : base(name)
        {
        }

        public override void Add(EntityBase entity)
        {
        }
        public override void Remove(EntityBase entity)
        {
        }
        public override void Display(int depth)
        {
            Debug.Log(new string('-', depth) + mName);
        }
        public override void Do()
        {
            Debug.Log(mName + "正在准备进攻...");
        }
    }
    //叶子节点（不具有 添加/删除 子节点的功能）
    public class DefMember : EntityBase
    {
        public DefMember(string name) : base(name)
        {
        }

        public override void Add(EntityBase entity)
        {
        }
        public override void Remove(EntityBase entity)
        {
        }
        public override void Display(int depth)
        {
            Debug.Log(new string('-', depth) + mName);
        }
        public override void Do()
        {
            Debug.Log(mName + "正在进行防御...");
        }
    }
    //叶子节点（不具有 添加/删除 子节点的功能）
    public class NormalMember : EntityBase
    {
        public NormalMember(string name) : base(name)
        {
        }

        public override void Add(EntityBase entity)
        {
        }
        public override void Remove(EntityBase entity)
        {
        }
        public override void Display(int depth)
        {
            Debug.Log(new string('-', depth) + mName);
        }
        public override void Do()
        {
            Debug.Log(mName + "正在划水...");
        }
    }
}