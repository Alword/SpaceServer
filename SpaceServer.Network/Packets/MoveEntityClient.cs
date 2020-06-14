using SpaceServer.Network.Abstractions;
using SpaceServer.Network.Enums;
using SpaceServer.Network.Types;
using System;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace SpaceServer.Network.Packets
{
    public class MoveEntityClient : BasePacket
    {
        public uint EntityId { get; private set; }
        public uint Time { get; private set; }
        public int StepCount { get; private set; }
        public MoveDirection[] Movement { get; private set; }
        private BitArray Steps { get; set; }

        public MoveEntityClient(uint entityId, uint time, MoveDirection[] movement)
        {
            this.EntityId = entityId;
            this.Time = time;
            this.Movement = movement;
        }

        public MoveEntityClient(ref byte[] buf) : base(ref buf) { }

        public override byte[] ToByteArray()
        {
            StepCount = Movement.Length;

            // convert to bit
            Steps = new BitArray(Movement.Length * 3);

            int i = 0;
            foreach (var move in Movement)
            {
                Steps[i++] = ((int)move & 1) > 0;
                Steps[i++] = ((int)move & 2) > 0;
                Steps[i++] = ((int)move & 4) > 0;
            }

            return ArrayBuilder.Build<byte>(
                Varint.Encode(EntityId),
                Varint.Encode(Time),
                Varint.Encode(StepCount),
                ArrayBuilder.Build(Steps)
                );

        }

        public override bool TryRead(ref byte[] buf)
        {
            EntityId = Varint.ReadUInt(ref buf);
            Time = Varint.ReadUInt(ref buf);
            StepCount = Varint.ReadInt(ref buf);
            Steps = new BitArray(buf);
            buf = new byte[0];

            Movement = new MoveDirection[StepCount];
            // convert from movement
            int i = 0;
            while (i < StepCount * 3)
            {
                Movement[i / 3] = (MoveDirection)(Convert.ToInt32(Steps[i++]) * 1 +
                    Convert.ToInt32(Steps[i++]) * 2 +
                    Convert.ToInt32(Steps[i++]) * 4);
            }

            return true;
        }
    }
}
