namespace TrustEDU.VM.Base
{
    public interface ICryptography
    {
        byte[] Hash160(byte[] message);

        byte[] Hash256(byte[] message);

        bool VerifySignature(byte[] message, byte[] signature, byte[] pubkey);
    }
}