using System;

namespace KudoCode.Contracts.Api
{
	public class CommandHandlerDelegates<TRequestDto, TEntity, TOut> : IDisposable
    {
        public delegate void BeforeExecuteDelegate(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler);

        public delegate void AfterExecuteDelegate(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler);

        public delegate void BeforeGetEntityDelegate(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler);

        public delegate void AfterGetEntityDelegate(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler);

        public BeforeGetEntityDelegate BeforeGetEntity = (handler) => { };
        public AfterGetEntityDelegate AfterGetEntity = (handler) => { };

        public BeforeExecuteDelegate BeforeExecute = (handler) => { };
        public AfterExecuteDelegate AfterExecute = (handler) => { };

        public void Dispose()
        {
            BeforeExecute = null;
            AfterExecute = null;
            BeforeGetEntity = null;
            AfterGetEntity = null;
        }
    }

    public class QueryHandlerDelegates<TRequestDto, TEntity, TOut> : IDisposable
    {
        public delegate void BeforeGetEntityDelegate(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler);

        public delegate void AfterGetEntityDelegate(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler);

        public delegate void BeforeExecuteDelegate(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler);

        public delegate void AfterExecuteDelegate(IAbstractEntityHandler<TRequestDto, TEntity, TOut> handler);

        public BeforeGetEntityDelegate BeforeGetEntity = (handler) => { };
        public AfterGetEntityDelegate AfterGetEntity = (handler) => { };

        public BeforeExecuteDelegate BeforeExecute = (handler) => { };
        public AfterExecuteDelegate AfterExecute = (handler) => { };


        public void Dispose()
        {
            BeforeExecute = null;
            AfterExecute = null;
            BeforeGetEntity = null;
            AfterGetEntity = null;
        }
    }

    public class WorkerHandlerDelegates<TRequestDto, TOut> : IDisposable
    {
        public delegate void BeforeExecuteDelegate(IAbstractHandler<TRequestDto, TOut> handler);

        public delegate void AfterExecuteDelegate(IAbstractHandler<TRequestDto, TOut> handler);

        public delegate void BeforeGetEntityDelegate(IAbstractHandler<TRequestDto, TOut> handler);

        public delegate void AfterGetEntityDelegate(IAbstractHandler<TRequestDto, TOut> handler);

        public BeforeGetEntityDelegate BeforeGetEntity = (handler) => { };
        public AfterGetEntityDelegate AfterGetEntity = (handler) => { };

        public BeforeExecuteDelegate BeforeExecute = (handler) => { };
        public AfterExecuteDelegate AfterExecute = (handler) => { };

        public void Dispose()
        {
            BeforeExecute = null;
            AfterExecute = null;
            BeforeGetEntity = null;
            AfterGetEntity = null;
        }
    }
}