using System;
using Ninject;
using Ninject.Modules;

namespace Bleum.Inject
{
    class Program
    {
        private static int a;

        private static int b;

        static Program()
        {
            a = 2;
            b = 3;
        }

        static void Main(string[] args)
        {
            a = 1;
            b = 2;

            IKernel kernal = new StandardKernel(new WarriorModule());

            //Samurai s = kernal.Get<Samurai>();// 构造函数注入

            //Samurai s = new Samurai() { Weapon = kernal.Get<IWeapon>() };// 属性注入

            //Samurai s = new Samurai();
            //s.Arm(kernal.Get<IWeapon>());// 方法注入

            Samurai s = new Samurai();
            s._weapon = kernal.Get<IWeapon>();// 字段注入

            s.Attact("enemy");

            Console.ReadKey();
        }
    }

    public interface IWeapon
    {
        void Hit(string target);
    }

    public class Sword : IWeapon
    {
        public void Hit(string target)
        {
            Console.WriteLine("Hit the target {0} by sword", target);
        }
    }

    public class Samurai
    {
        /// <summary>
        /// 字段依赖注入
        /// </summary>
        [Inject]
        public IWeapon _weapon;

        ///// <summary>  
        ///// 构造函数依赖注入  
        ///// </summary>  
        //[Inject]
        //public Samurai(IWeapon weapon)
        //{
        //    _weapon = weapon;
        //}

        ///// <summary>  
        ///// 定义注入接口属性  
        ///// </summary>  
        //[Inject]
        //public IWeapon Weapon
        //{
        //    get
        //    {
        //        return _weapon;
        //    }
        //    set
        //    {
        //        _weapon = value;
        //    }
        //}

        ///// <summary>  
        ///// 方法注入  
        ///// </summary>  
        //[Inject]
        //public void Arm(IWeapon weapon)
        //{
        //    _weapon = weapon;
        //}

        public void Attact(string target)
        {
            _weapon.Hit(target);
        }
    }

    public class WarriorModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IWeapon>().To<Sword>();
            Bind<Samurai>().ToSelf();
        }
    }
}
