using MediatR;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace DRP.Core.Backend.Decorators
{
    internal class SecurityRequestDecorator<TRequest, Tout> : IPipelineBehavior<TRequest, Tout>
        where TRequest : class, IRequest<Tout>
    {
        public Task<Tout> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<Tout> next)
        {
            if (!CheckPermissions(request))
                throw new SecurityException();

            return next();
        }

        private bool CheckPermissions(TRequest request)
        {
            return true;
        }
    }
}
