using System;
using System.ServiceModel.Dispatcher;

namespace Aire.Services.Infrastructure
{
    internal class WcfExceptionHandler : ExceptionHandler
    {
        // todo: add proper exception handling here.
        public override bool HandleException(Exception exception)
                => true;
    }
}