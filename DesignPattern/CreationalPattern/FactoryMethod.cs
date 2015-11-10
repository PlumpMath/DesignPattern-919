using System;

namespace DesignPattern.CreationalPattern
{
    /// <summary>工厂方法,采用聚合</summary>
    /// <remarks>我们无需知道工厂是如何加工东西的</remarks>
    /// <remarks>只需要告诉工厂我们需要的是什么就好了</remarks>
    /// <remarks>意图是 定义一个用于创建对象的接口，让子类决定实例化哪一个类。Factory Method 使一个类的实例化延迟到其子类。</remarks>
    /// <remarks>工厂方法不仅用于创建对象接口,也可以创建方法的接口,具体怎么用都是随意的</remarks>
    /// <remarks></remarks>
    public class FactoryMethod
    {
        #region 方法工厂

        /// <summary>写日志的仅仅是</summary>
        public class MethodFactory
        {
            /// <summary>工厂方法</summary>
            /// <param name="logType"></param>
            public string WriteFactory(string logType)
            {
                switch (logType.ToLower())
                {
                    case "event":
                        return WriteEvent();
                        break;
                    case "file":
                        return WriteFile();
                        break;
                    default:
                        return null;
                        break;
                }
            }

            /// <summary>写入事件日志</summary>
            private string WriteEvent()
            {
                return "EventLog Success!";
            }

            /// <summary>写入文件日志</summary>
            private string WriteFile()
            {
                return "FileLog Success!";
            }
        }

        #endregion

        #region 类工厂

        public class ClassFactory
        {
            public IWriteLog WriteFactory(string logType)
            {
                switch (logType.ToLower())
                {
                    case "event":
                        return new WriteEventLog();
                        break;
                    case "file":
                        return new WriteFileLog();
                        break;
                    default:
                        return new WriteDefaultLog();
                        break;
                }
            }
        }

        public interface IWriteLog
        {
            /// <summary>写日志</summary>
            string WriteLog();

            /// <summary>读取日志</summary>
            string ReadLog();
        }

        public class WriteEventLog : IWriteLog
        {
            public string WriteLog()
            {
                return "Write EventLog Success!";
            }

            public string ReadLog()
            {
                return "Read EventLog Success!";
            }
        }

        public class WriteFileLog : IWriteLog
        {
            public string WriteLog()
            {
                return "Write FileLog Success!";
            }

            public string ReadLog()
            {
                return "Read FileLog Success!";
            }
        }

        public class WriteDefaultLog : IWriteLog
        {
            public string WriteLog()
            {
                return "Write DefaultLog Success!";
            }

            public string ReadLog()
            {
                return "Read DefaultLog Success!";
            }
        }

        #endregion
    }
}