using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CreationalPattern
{
    /// <summary>抽象工厂</summary>
    /// <remarks>与抽象方法的区别在于需要创建对象的复杂程度上</remarks>
    /// <remarks>为系统结构提供了非常灵活强大的动态扩展机制，只要我们更换一下具体的工厂方法，系统其他地方无需一点变换，就有可能将系统功能进行改头换面的变化。</remarks>
    public class AbstractFactory
    {
        #region Factory相关

        public abstract class LogFactory
        {
            public abstract Log Create();
        }

        /// <summary>
        /// EventFactory类
        /// </summary>
        public class EventFactory : LogFactory
        {
            public override Log Create()
            {
                return new EventLog();
            }
        }

        /// <summary>
        /// FileFactory类
        /// </summary>
        public class FileFactory : LogFactory
        {
            public override Log Create()
            {
                return new FileLog();
            }
        }

        #endregion

        #region Log相关

        public abstract class Log
        {
            public abstract string Write();
        }

        /// <summary>EventLog类</summary>
        public class EventLog : Log
        {
            public override string Write()
            {
                return "EventLog Write Success!";
            }
        }

        /// <summary>FileLog类</summary>
        public class FileLog : Log
        {
            public override string Write()
            {
                return "FileLog Write Success!";
            }
        }
        #endregion
    }
}