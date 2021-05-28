using System.Diagnostics;
using WFw;

namespace System
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ExceptionExtensions
    {
        public static string ToLogMessage(this Exception exception)
        {
            return ToLogMessage(exception, Guid.NewGuid().ToString("N"));
        }

        public static string ToLogMessage(this Exception exception, string requestId, string spiltStr = "\r\n")
        {
            StackTrace st = new StackTrace(exception, true);

            //Get the first stack frame
            StackFrame frame = st.GetFrame(0);

            //Get the file name
            string fileName = frame.GetFileName();

            //Get the method name
            string methodName = frame.GetMethod().Name;

            //Get the line number from the stack frame
            int line = frame.GetFileLineNumber();

            //Get the column number
            int col = frame.GetFileColumnNumber();

            if (exception is ArgumentException ae)
            {
                return $"{exception.Message}{spiltStr}requestId:{requestId}{spiltStr}paramName:{ae.ParamName}{spiltStr}fileName:{fileName}{spiltStr}methodName:{methodName}{spiltStr}position:{line}-{col}";
            }
            else if (exception is WFwException we)
            {
                return $"{exception.Message}{spiltStr}requestId:{requestId}{spiltStr}paramName:{we.LogParam}{spiltStr}fileName:{fileName}{spiltStr}methodName:{methodName}{spiltStr}position:{line}-{col}";
            }
            else
            {
                return $"{exception.Message}{spiltStr}requestId:{requestId}{spiltStr}paramName:{exception.Message}{spiltStr}fileName:{fileName}{spiltStr}methodName:{methodName}{spiltStr}position:{line}-{col}";
            }
        }

    }
}
