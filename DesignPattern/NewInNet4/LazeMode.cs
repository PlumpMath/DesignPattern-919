using System;

namespace DesignPattern.NewInNet4
{
    /// <summary>Lazy延迟加载,用于数据</summary>
    public class LazeMode
    {
        #region 基于lazy的单例模式,具体实现类似于单例模式,中间又加了一层而已,防止过多的数据进行加载,具体可见源码
        private static readonly Lazy<LazeMode> Lazy =
         new Lazy<LazeMode>(() => new LazeMode());
        public static LazeMode Instance { get { return Lazy.Value; } }

        private LazeMode()
        {
        }
        #endregion

        #region 基于lazy的数据加载(无需ctor)
        Lazy<LazyPerson> Person;
        public string GetPerson()
        {
            Person = new Lazy<LazyPerson>(PersonLoader,true);
            string des = Person.IsValueCreated.ToString();
            des += Person.Value.Name;
            des += Person.IsValueCreated;
            return des;
        }

        public LazyPerson PersonLoader()
        {
            var person=new LazyPerson();
            person.Male = true;
            person.Name = "岳珅";
            return person;
        }
        #endregion
    }

    #region entity

    public class LazyPerson
    {
        public string Name { get; set; }
        public bool Male { get; set; }
    }

    #endregion
}