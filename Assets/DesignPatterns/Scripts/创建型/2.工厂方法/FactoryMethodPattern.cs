/****************************************************
	文件：FactoryMethodPattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/8 0:34:36
	功能：工厂方法模式
*****************************************************/

using System;
using UnityEngine;

namespace DesignPatterns
{
    public class FactoryMethodPattern : MonoBehaviour
    {
        private void Start()
        {
            //工厂方法 相对于 简单工厂
            //优点：
            //1.保留了对于对象创建的封装性
            //2.新增对象类型时，避免了对于工厂内部的修改，而是新增对象工厂
            //缺点：
            //增加了代码量 和 结构复杂度
            EnemyLv1 enemyLv1 = EnemyLv1Factory.Create(new object());
            EnemyBoss enemyBoss = EnemyBossFactory.Create(new object());
            //更优的方法：使用 反射 来消除分枝判断（反射性能消耗大，需要结合缓存使用）
        }

        /// <summary>
        /// 工厂基类
        /// </summary>
        public class EnemyFactoryBase { }
        public class EnemyLv1Factory : EnemyFactoryBase
        {
            public static EnemyLv1 Create(object data)
            {
                return new EnemyLv1(data);
            }
        }
        public class EnemyLv2Factory : EnemyFactoryBase
        {
            public static EnemyLv2 Create(object data)
            {
                return new EnemyLv2(data);
            }
        }
        public class EnemyBossFactory : EnemyFactoryBase
        {
            public static EnemyBoss Create(object data)
            {
                return new EnemyBoss(data);
            }
        }
        /// <summary>
        /// 对象基类
        /// </summary>
        public class EnemyBase { }
        public class EnemyLv1 : EnemyBase
        {
            public EnemyLv1(object data)
            {
                Debug.Log("生产敌人：EnemyLv1");
            }
        }
        public class EnemyLv2 : EnemyBase
        {
            public EnemyLv2(object data)
            {
                Debug.Log("生产敌人：EnemyLv2");
            }
        }
        public class EnemyBoss : EnemyBase
        {
            public EnemyBoss(object data)
            {
                Debug.Log("生产敌人：Boss");
            }
        }
    }
}
