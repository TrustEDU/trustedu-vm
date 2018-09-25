namespace TrustEDU.VM.Runtime
{
    public interface IScriptTable
    {
        byte[] GetScript(byte[] scriptHash);
    }
}