using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.CreationalPattern
{
    /*
     不变中存在变化,,适合复合
     */
    /// <summary>创建对象组织的所有构造步骤接口</summary>
    /// <remarks>IBuilder拥有创建的整体流程,一经定义,一般不做修改</remarks>
    public interface IBuider
    {
        void BuilderPart1();
        void BuilderPart2();
        void BuilderPart3();
    }
    /// <summary>服装对象</summary> 
    public class Dress
    {
        /// <summary>构建帽子</summary> 
        public void BuildHat()
        {
            Console.Write("戴帽子");
        }
        /// <summary>构建上衣</summary> 
        public void BuilderWaist()
        {
            Console.Write("穿上衣");
        }
        /// <summary>构建裤子</summary> 
        public void BuilderTrousers()
        {
            Console.Write("穿裤子");
        }
    }
    /// <summary>创建者</summary>
    /// <remark>我需要知道整体流程并且实现他们(通过接口保证全流程都有)</remark>
    public class Builder : IBuider
    {
        private Dress _dress;
        public Builder(Dress dress)
        {
            this._dress = dress;
        }
        public void BuilderPart1()
        {
            this._dress.BuildHat();
        }
        public void BuilderPart2()
        {
            this._dress.BuilderWaist();
        }
        public void BuilderPart3()
        {
            this._dress.BuilderTrousers();
        }
        public Dress Build()
        {
            return this._dress;
        }
    }
    /// <summary>指导者</summary> 
    public class Director
    {
        public void Build(IBuider builder)
        {
            builder.BuilderPart1();
            builder.BuilderPart2();
            builder.BuilderPart3();
        }
    }
}
