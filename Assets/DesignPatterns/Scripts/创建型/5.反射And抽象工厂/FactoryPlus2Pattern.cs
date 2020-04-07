/****************************************************
	文件：FactoryPlus2Pattern.cs
	作者：HuskyT
	邮箱：1005240602@qq.com
	日期：2020/4/8 2:24:40
	功能：反射 + 抽象工厂（抽象工厂的极大优化）
*****************************************************/

using System;
using System.Reflection;
using UnityEngine;

namespace DesignPatterns
{
    public class FactoryPlus2Pattern : MonoBehaviour
    {
        private void Start()
        {
            //使用 反射 极大限度减少了代码修改量
            //缺点：性能消耗很大
            //（若初始化创建一次对象，可以使用反射；若需要反复创建则需要增加缓存）

            FactoryReflection.CreateEnemy("EnemyLv1");
            FactoryReflection.CreateWeapon("WeaponLv1");
            FactoryReflection.CreateArmor("ArmorLv1");

            FactoryReflection.CreateEnemy("EnemyBoss");
            FactoryReflection.CreateWeapon("WeaponBoss");
            FactoryReflection.CreateArmor("ArmorBoss");

            //使用反射，在创建不同对象时只需要修改 字符串（类型名称）
            //进一步优化：加入配置表，依照配置生成对象，不需要手动修改字符串
            //(配置表比较简单，此处省略)
        }


        public class FactoryReflection
        {
            public static string NAME_SPACE = "DesignPatterns";

            public static IEnemy CreateEnemy(string type)
            {
                return Create<IEnemy>(type);
            }
            public static IWeapon CreateWeapon(string type)
            {
                return Create<IWeapon>(type);
            }
            public static IArmor CreateArmor(string type)
            {
                return Create<IArmor>(type);
            }

            private static T Create<T>(string className) where T : class
            {
                //无参：
                //  return Activator.CreateInstance(Type.GetType(NAME_SPACE + ".FactoryPlus2Pattern+" + className)) as T;

                //有参：
                return Activator.CreateInstance(Type.GetType(NAME_SPACE + ".FactoryPlus2Pattern+" + className), new object()) as T;
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