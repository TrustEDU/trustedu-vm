using System;
using System.IO;
using TrustEDU.VM.Base;

namespace TrustEDU.VM.Runtime
{
    public class ExecutionContext : IDisposable
    {
        public readonly byte[] Script;
        internal readonly int RVCount;
        internal readonly BinaryReader OpReader;
        private readonly ICryptography crypto;

        public RandomAccessStack<StackItem> EvaluationStack { get; } = new RandomAccessStack<StackItem>();
        public RandomAccessStack<StackItem> AltStack { get; } = new RandomAccessStack<StackItem>();

        public int InstructionPointer
        {
            get
            {
                return (int)OpReader.BaseStream.Position;
            }
            set
            {
                OpReader.BaseStream.Seek(value, SeekOrigin.Begin);
            }
        }

        public OpCode NextInstruction => (OpCode)Script[OpReader.BaseStream.Position];

        private byte[] _scriptHash = null;
        public byte[] ScriptHash
        {
            get
            {
                if (_scriptHash == null)
                    _scriptHash = crypto.Hash160(Script);
                return _scriptHash;
            }
        }

        internal ExecutionContext(ExecutionEngine engine, byte[] script, int rvcount)
        {
            this.Script = script;
            this.RVCount = rvcount;
            this.OpReader = new BinaryReader(new MemoryStream(script, false));
            this.crypto = engine.Crypto;
        }

        public void Dispose()
        {
            OpReader.Dispose();
        }
    }
}
