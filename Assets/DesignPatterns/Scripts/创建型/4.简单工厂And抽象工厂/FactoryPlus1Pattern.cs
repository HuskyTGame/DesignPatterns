/****************************************************
	文件：FactoryPlus1Pattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/8 2:0:39
	功能：简单工厂 + 抽象工厂（对纯抽象工厂的优化）
*****************************************************/

using System;
using UnityEngine;

namespace DesignPatterns
{
    public class FactoryPlus1Pattern : MonoBehaviour
    {
        private void Start()
        {
            //当扩展工厂生产对象的类型，比如新增防具对象，不同敌人工厂需要生产不同防具时
            //使用抽象工厂：对每一个类型的敌人工厂都需要新增生产 防具对象 的方法（修改太多）
            //使用简单工厂：将分散开来的修改集中在一个简单工厂中（修改较为简单）

            SimpleFactory.CreateEnemy("EnemyLv1");
            SimpleFactory.CreateWeapon("WeaponLv1");
            SimpleFactory.CreateArmor("ArmorLv1");

            SimpleFactory.CreateEnemy("EnemyBoss");
            SimpleFactory.CreateWeapon("WeaponBoss");
            SimpleFactory.CreateArmor("ArmorBoss");

            //此时依旧存在修改
            //还可以使用 反射 进行分枝判断
        }

        /// <summary>
        /// 简单工厂
        /// </summary>
        public class SimpleFactory
        {
            public static IEnemy CreateEnemy(string type)
            {
                switch (type)
                {
                    case "EnemyLv1":
                        return new EnemyLv1(new object());
                    case "EnemyLv2":
                        return new EnemyLv2(new object());
                    case "EnemyBoss":
                        return new EnemyBoss(new object());
                }
                return null;
            }
            public static IWeapon CreateWeapon(string type)
            {
                switch (type)
                {
                    case "WeaponLv1":
                        return new WeaponLv1(new object());
                    case "WeaponLv2":
                        return new WeaponLv2(new object());
                    case "WeaponBoss":
                        return new WeaponBoss(new object());
                }
                return null;
            }
            //新增
            public static IArmor CreateArmor(string type)
            {
                switch (type)
                {
                    case "ArmorLv1":
                        return new ArmorLv1(new object());
                    case "ArmorLv2":
                        return new ArmorLv2(new object());
                    case "ArmorBoss":
                        return new ArmorBoss(new object());
                }
                return null;
            }
        }


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


        #region （新增）Armor
        /// <summary>
        /// 抽象盔甲
        /// </summary>
        public interface IArmor { }
        public class ArmorLv1 : IArmor
        {
            public ArmorLv1(object data)
            {
                Debug.Log("生产盔甲：ArmorLv1");
            }
        }
        public class ArmorLv2 : IArmor
        {
            public ArmorLv2(object data)
            {
                Debug.Log("生产盔甲：ArmorLv2");
            }
        }
        public class ArmorBoss : IArmor
        {
            public ArmorBoss(object data)
            {
                Debug.Log("生产盔甲：ArmorBoss");
            }
        }
        #endregion
    }
}