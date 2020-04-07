/****************************************************
	文件：SimpleFactoryPattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/7 23:42:2
	功能：简单工厂模式
*****************************************************/

using UnityEngine;

namespace DesignPatterns
{
    public class SimpleFactoryPattern : MonoBehaviour
    {
        private void Start()
        {
            //因为简单工厂：EnemySimpleFactory 的存在
            //生产不同等级的敌人变得很简单
            //可以将敌人的生产集中在一个位置
            EnemyLv1 enemyLv1 = EnemySimpleFactory.Create(1, new object()) as EnemyLv1;
			EnemyLv3 enemyLv3 = EnemySimpleFactory.Create(3, new object()) as EnemyLv3;
			//弊端：倘若增加敌人的类型，比如增加一个 Boss 类型的敌人
			//则生产敌人的工厂需要修改 Create() 方法  （违背了 对修改关闭 原则）
			//解决方法：使用 工厂方法模式（Factory Method Pattern）
        }

        public class EnemySimpleFactory
        {
            public static EnemyBase Create(int enemyLv, object data)
            {
                switch (enemyLv)
                {
                    case 1:
                        return new EnemyLv1(data);
                    case 2:
                        return new EnemyLv2(data);
                    case 3:
                        return new EnemyLv3(data);
                }
                return null;
            }
        }
        /// <summary>
        /// 敌人基类
        /// </summary>
        public class EnemyBase { }
        /// <summary>
        /// 等级为1的敌人
        /// </summary>
        public class EnemyLv1 : EnemyBase
        {
            public EnemyLv1(object data)
            {
                Debug.Log("生产敌人：EnemyLv1");
            }
        }
        /// <summary>
        /// 等级为2的敌人
        /// </summary>
        public class EnemyLv2 : EnemyBase
        {
            public EnemyLv2(object data)
            {
                Debug.Log("生产敌人：EnemyLv2");
            }
        }
        /// <summary>
        /// 等级为3的敌人
        /// </summary>
        public class EnemyLv3 : EnemyBase
        {
            public EnemyLv3(object data)
            {
                Debug.Log("生产敌人：EnemyLv3");
            }
        }
    }
}
