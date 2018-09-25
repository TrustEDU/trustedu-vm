using System;
using TrustEDU.VM.Base;

namespace TrustEDU.VM.Runtime
{
    public interface IScriptContainer : IInteropContract
    {
        byte[] GetMessage();
    }
}