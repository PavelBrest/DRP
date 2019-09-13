using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DRP.Core.CQRS.Abstractions.Events
{
    public interface IEvent : INotification
    {
    }
}
