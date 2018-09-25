using System;
namespace TrustEDU.VM.Base.Types
{
    public class InteropContract : StackItem
    {
        private readonly IInteropContract _object;

        public InteropContract(IInteropContract value)
        {
            this._object = value;
        }

        public override bool Equals(StackItem other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(null, other)) return false;
            if (!(other is InteropContract i)) return false;
            return _object.Equals(i._object);
        }

        public override bool GetBoolean()
        {
            return _object != null;
        }

        public override byte[] GetByteArray()
        {
            throw new NotSupportedException();
        }

        public T GetInterface<T>() where T : class, IInteropContract
        {
            return _object as T;
        }
    }
}