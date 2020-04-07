/****************************************************
	文件：AbstractFactoryPattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/8 1:23:49
	功能：抽象工厂模式
*****************************************************/

using System;
using UnityEngine;

namespace DesignPatterns
{
    public class AbstractFactoryPattern : MonoBehaviour
    {
        private void Start()
        {
            //当一个工厂只用创建一种对象的时候可以使用工厂方法
            //当一个工厂需要创建一系列不同类型的对象时，需要使用抽象工厂
            EnemyLv1Factory enemyLv1Factory = new EnemyLv1Factory();
            EnemyBossFactory enemyBossFactory = new EnemyBossFactory();

            enemyLv1Factory.CreateEnemy(new object());
            enemyLv1Factory.CreateWeapon(new object());

            enemyBossFactory.CreateEnemy(new object());
            enemyBossFactory.CreateWeapon(new object());

			//抽象工厂时工厂方法的一种扩展
			//同一工厂现在可以生产一系列不同对象

			//抽象工厂也存在不小缺陷：
			//若要扩展工厂生产对象的类型，比如新增防具对象，不同敌人工厂需要生产不同防具
			//此时需要新增防具接口，以及不同防具的实现，同时还要修改不同类型敌人工厂（新增很多，修改也很多）

			//改进的方法有两种：
			//使用简单工厂 + 抽象工厂（实现简单）
			//使用反射 + 抽象工厂（反射存在性能问题，使用需慎重，如果频繁使用则需要缓存）
        }

        #region Factory
        /// <summary>
        /// 抽象工厂
        /// </summary>
        public interface IEnemyFactory
        {
            IEnemy CreateEnemy(object data);
            IWeapon CreateWeapon(object data);
        }
        public class EnemyLv1Factory : IEnemyFactory
        {
            public IEnemy CreateEnemy(object data)
            {
                return new EnemyLv1(data);
            }

            public IWeapon CreateWeapon(object data)
            {
                return new WeaponLv1(data);
            }
        }
        public class EnemyLv2Factory : IEnemyFactory
        {
            public IEnemy CreateEnemy(object data)
            {
                return new EnemyLv2(data);
            }

            public IWeapon CreateWeapon(object data)
            {
                return new WeaponLv2(data);
            }
        }
        public class EnemyBossFactory : IEnemyFactory
        {
            public IEnemy CreateEnemy(object data)
            {
                return new EnemyBoss(data);
            }

            public IWeapon CreateWeapon(object data)
            {
                return new WeaponBoss(data);
            }
        }
        #endregion


        #region Enemy
        /// <summary>
        /// 抽象敌人
        /// </summary>
        public interface IEnemy { }
        public class EnemyLv1 : IEnemy
        {
            public EnemyLv1(object data)
            {
                Debug.Log("生产敌人：EnemyLv1");
            }
        }
        public class EnemyLv2 : IEnemy
        {
            public EnemyLv2(object data)
            {
                Debug.Log("生产敌人：EnemyLv2");
            }
        }
        public class EnemyBoss : IEnemy
        {
            public EnemyBoss(object data)
            {
                Debug.Log("生产敌人：EnemyBoss");
            }
        }
        #endregion


        #region Weapon
        /// <summary>
        /// 抽象武器
        /// </summary>
        public interface IWeapon { }
        public class WeaponLv1 : IWeapon
        {
            public WeaponLv1(object data)
            {
                Debug.Log("生产武器：WeaponLv1");
            }
        }
        public class WeaponLv2 : IWeapon
        {
            public WeaponLv2(object data)
            {
                Debug.Log("生产武器：WeaponLv2");
            }
        }
        public class WeaponBoss : IWeapon
        {
            public WeaponBoss(object data)
            {
                Debug.Log("生产武器：WeaponBoss");
            }
        }
        #endregion
    }
}
