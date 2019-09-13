using System;

namespace DRP.Core.CQRS
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class HandlerDecoratorAttribute : Attribute
    {
        public Type Decorator { get; set; }

        public HandlerDecoratorAttribute(Type decorator)
        {
            Decorator = decorator;
        }
    }
}
