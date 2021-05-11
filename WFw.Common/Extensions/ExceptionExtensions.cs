using System.Diagnostics;
using WFw;

namespace System
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class ExceptionExtensions
    {

        public static string ToLogMessage(this Exception exception, string requestId)
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
                return $"{exception.Message}\r\nrequestId:{requestId}\r\nparamName:{ae.ParamName}\r\nfileName:{fileName}\r\nmethodName:{methodName}\r\nposition:{line}-{col}";
            }
            else if (exception is WFwException we)
            {
                return $"{exception.Message}\r\nrequestId:{requestId}\r\nparamName:{we.LogParam}\r\nfileName:{fileName}\r\nmethodName:{methodName}\r\nposition:{line}-{col}";
            }
            else
            {
                return $"{exception.Message}\r\nrequestId:{requestId}\r\nparamName:{exception.Message}\r\nfileName:{fileName}\r\nmethodName:{methodName}\r\nposition:{line}-{col}";
            }
        }

    }
}
