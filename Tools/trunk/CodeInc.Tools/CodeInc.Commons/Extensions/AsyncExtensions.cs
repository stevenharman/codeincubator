using System;

namespace CodeInc.Commons.Extensions
{
    public static class AsyncExtensions
    {
        public static void DoAsync(this Action theFunction)
        {
            theFunction.BeginInvoke(asyncResult => { return; }, null);
        }

        /// <summary>
        /// Fires an Async call with no input
        /// </summary>
        /// <typeparam name="TResult">The Type returned by the method</typeparam>
        /// <param name="theFunction">The method to execute</param>
        /// <param name="callback">The <seealso cref="Action{T}"/> to call after the Async call returns</param>
        public static void DoAsync<TResult>(this Func<TResult> theFunction, Action<TResult> callback)
        {
            theFunction.BeginInvoke(asyncResult => callback(theFunction.EndInvoke(asyncResult)), null);
        }

        /// <summary>
        /// Fires an Async call with an input but no result returned
        /// </summary>
        /// <typeparam name="TInput">The Type of the input</typeparam>
        /// <param name="function">The method to execute</param>
        /// <param name="input">The input argument for the method</param>
        /// <param name="callback">The <seealso cref="Action"/> to call after the Async call returns</param>
        public static void DoAsync<TInput>(this Action<TInput> function, TInput input, Action callback)
        {
            function.BeginInvoke(input, asyncResult => callback(), null);
        }

        /// <summary>
        /// Fires an Async call with an input and a result returned
        /// </summary>
        /// <typeparam name="TInput">The Type of the input</typeparam>
        /// <typeparam name="TResult">The Type returned by the method</typeparam>
        /// <param name="function">The method to execute</param>
        /// <param name="input">The input argument for the method</param>
        /// <param name="callback">The <seealso cref="Action{T}"/> to call after the Async call returns</param>
        public static void DoAsync<TInput, TResult>(this Func<TInput, TResult> function, TInput input, Action<TResult> callback)
        {
            function.BeginInvoke(input, asyncResult => callback(function.EndInvoke(asyncResult)), null);
        }

        /// <summary>
        /// Fires an Async call with an input and a result returned. Also allows for a custom Exception handler.
        /// </summary>
        /// <typeparam name="TInput">The Type of the input</typeparam>
        /// <typeparam name="TResult">The Type returned by the method</typeparam>
        /// <param name="function">The method to execute</param>
        /// <param name="input">The input argument for the method</param>
        /// <param name="callback">The <seealso cref="Action{T}"/> to call after the Async call returns</param>
        /// <param name="errorHandler">The <seealso cref="Action{T}"/> to handle any exceptions that occur during the call.</param>
        public static void DoAsync<TInput, TResult>(this Func<TInput, TResult> function, TInput input,
                                                    Action<TResult> callback, Action<Exception> errorHandler)
        {
            function.BeginInvoke(input, asyncResult =>
                                            {
                                                try
                                                {
                                                    callback(function.EndInvoke(asyncResult));
                                                }
                                                catch (Exception e)
                                                {
                                                    errorHandler(e);
                                                }
                                            }, null);
        }
    }
}