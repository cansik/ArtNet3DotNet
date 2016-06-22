using System;

namespace ArtDotNet
{
	[Flags]
	public enum OpCode
	{
		OpPoll = 0x2000,
		OpPollReply = 0x2100,
		OpDiagData = 0x2300,
		OpCommand = 0x2400,
		OpOutput = 0x5000,
		OpSync = 0x5200
		//alternate OpDmx
	}
}

