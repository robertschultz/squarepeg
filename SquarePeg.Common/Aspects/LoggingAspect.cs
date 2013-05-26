namespace SquarePeg.Common.Aspects
{
    using System;
    using System.Diagnostics;
    using PostSharp.Aspects;

    using SquarePeg.Common.DependencyInjection;
    using ServiceStack.Logging;

    /// <summary> 
    /// Aspect that, when applied on a method, emits a trace message before and 
    /// after the method execution. 
    /// </summary> 
    [Serializable]
    public class LoggingAspect : OnMethodBoundaryAspect
    {
        /// <summary> 
        /// Method invoked before the execution of the method to which the current 
        /// aspect is applied. 
        /// </summary> 
        /// <param name="args">Information about the method being executed.</param> 
        public override void OnEntry(MethodExecutionArgs args)
        {
            Trace.TraceInformation(
                "{0}.{1}: Enter",
                args.Method.DeclaringType.FullName, 
                args.Method.Name);
            
            Trace.Indent();
        }

        /// <summary>
        /// Method invoked after successful execution of the method to which the current
        /// aspect is applied.
        /// </summary>
        /// <param name="args">Information about the method being executed.</param>
        public override void OnSuccess(MethodExecutionArgs args)
        {
            Trace.Unindent();
            Trace.TraceInformation(
                "{0}.{1}: Success",
                args.Method.DeclaringType.FullName, 
                args.Method.Name);
        }

        /// <summary> 
        /// Method invoked after failure of the method to which the current 
        /// aspect is applied. 
        /// </summary> 
        /// <param name="args">Information about the method being executed.</param> 
        public override void OnException(MethodExecutionArgs args)
        {
            var log = SharedContainer.Container.Resolve<ILog>();
            log.Fatal("SDfsdfsdf");

            Trace.Unindent();
            Trace.TraceInformation(
                "{0}.{1}: Exception {2}",
                args.Method.DeclaringType.FullName, 
                args.Method.Name,
                args.Exception.Message);
        }

        public override void RuntimeInitialize(System.Reflection.MethodBase method)
        {


            base.RuntimeInitialize(method);
        }
    }

}
