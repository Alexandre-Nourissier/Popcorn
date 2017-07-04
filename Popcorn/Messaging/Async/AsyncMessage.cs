using GalaSoft.MvvmLight.Messaging;
using System;
using System.Threading.Tasks;

namespace Popcorn.Messaging.Async
{
    /// <summary>
    /// awaitable message
    /// </summary>
    /// <typeparam name="TMessage"></typeparam>
    internal class AsyncMessage<TMessage> : MessageBase
        where TMessage : MessageBase
    {
        private readonly TaskCompletionSource<object> _source = new TaskCompletionSource<object>();
        public TMessage InnerMessage { get; private set; }
        public Task<object> Task => this._source.Task;

        public AsyncMessage(TMessage innerMessage)
        {
            InnerMessage = innerMessage;
        }

        public void SetResult(object result)
        {
            _source.SetResult(result);
        }

        public void SetException(Exception ex)
        {
            _source.SetException(ex);
        }
    }
}