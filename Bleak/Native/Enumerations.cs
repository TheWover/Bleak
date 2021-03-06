using System;

namespace Bleak.Native
{
    internal static class Enumerations
    {
        [Flags]
        internal enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000
        }
        
        [Flags]
        internal enum ContextFlags
        {
            Control = 0x10001
        }
        
        [Flags]
        internal enum FreeType
        {
            Release = 0x8000
        }
        
        [Flags]
        internal enum MemoryProtection
        {
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoCache = 0x200
        }
        
        [Flags]
        internal enum NtStatus : uint
        {
            Success = 0x00
        }
        
        [Flags]
        internal enum ProcessInformationClass
        {
            BasicInformation = 0x00,
            Wow64Information = 0x1A
        }
        
        [Flags]
        internal enum RelocationType : byte
        {
            HighLow = 0x03,
            Dir64 = 0x0A
        }
        
        [Flags]
        internal enum ThreadAccessMask
        {
            SpecificRightsAll = 0xFFFF,
            StandardRightsAll = 0x1F0000,
            AllAccess = SpecificRightsAll | StandardRightsAll
        }
        
        [Flags]
        internal enum ThreadCreationFlags
        {
            HideFromDebugger = 0x04
        }
        
        [Flags]
        internal enum VirtualKey
        {
            LeftButton = 0x01
        }

        [Flags]
        internal enum WindowsMessage
        {
            Keydown = 0x100
        }
    }
}