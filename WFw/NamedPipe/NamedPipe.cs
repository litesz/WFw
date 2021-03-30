using System.IO.Pipes;
using System.Security.Principal;

namespace WFw.NamedPipe
{
    /// <summary>
    /// 
    /// </summary>
    public interface INamedPipe
    {
        /// <summary>
        /// 
        /// </summary>
        string ServiceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string PipeName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        PipeDirection PipeDirection { get; set; }

        /// <summary>
        /// 
        /// </summary>
        PipeOptions PipeOptions { get; set; }

        /// <summary>
        /// 
        /// </summary>
        TokenImpersonationLevel TokenImpersonationLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        NamedPipeClientStream NamedPipeClient { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class NamedPipe : INamedPipe
    {
        /// <summary>
        /// 
        /// </summary>
        public string ServiceName { get; set; } = "localhost";
        /// <summary>
        /// 
        /// </summary>
        public string PipeName { get; set; } = "testpipe";

        /// <summary>
        /// 
        /// </summary>
        public PipeDirection PipeDirection { get; set; } = PipeDirection.InOut;

        /// <summary>
        /// 
        /// </summary>
        public PipeOptions PipeOptions { get; set; } = PipeOptions.Asynchronous;

        /// <summary>
        /// 
        /// </summary>
        public TokenImpersonationLevel TokenImpersonationLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public NamedPipeClientStream NamedPipeClient { get; set; } = new NamedPipeClientStream("localhost", "testpipe", PipeDirection.InOut, PipeOptions.Asynchronous, TokenImpersonationLevel.None);

    }
}
