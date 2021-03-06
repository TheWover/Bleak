using System;
using System.Runtime.InteropServices;
using Bleak.Shared.SafeHandle;
using Microsoft.Win32.SafeHandles;
using static Bleak.Native.Enumerations;

namespace Bleak.Native
{
    internal static class PInvoke
    {
        // kernel32.dll imports
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool CloseHandle(IntPtr handle);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool FlushInstructionCache(SafeProcessHandle processHandle, IntPtr baseAddress, int regionSize);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool GetThreadContext(SafeThreadHandle threadHandle, IntPtr contextBuffer);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool IsWow64Process(SafeProcessHandle processHandle, out bool isWow64Process);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern SafeThreadHandle OpenThread(ThreadAccessMask desiredAccess, bool inheritHandle, int threadId);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool ReadProcessMemory(SafeProcessHandle processHandle, IntPtr baseAddress, IntPtr bytesReadBuffer, int bytesToRead, IntPtr numberOfBytesReadBuffer);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int ResumeThread(SafeThreadHandle threadHandle);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool SetThreadContext(SafeThreadHandle threadHandle, IntPtr contextBuffer);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int SuspendThread(SafeThreadHandle threadHandle);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern IntPtr VirtualAllocEx(SafeProcessHandle processHandle, IntPtr baseAddress, int allocationSize, AllocationType allocationType, MemoryProtection protectionType);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualFreeEx(SafeProcessHandle processHandle, IntPtr baseAddress, int freeSize, FreeType freeType);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool VirtualProtectEx(SafeProcessHandle processHandle, IntPtr baseAddress, int protectionSize, MemoryProtection protectionType, out MemoryProtection oldProtectionType);
        
        [DllImport("kernel32.dll")]
        internal static extern void WaitForSingleObject(SafeThreadHandle handle, int millisecondsToWait);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool Wow64GetThreadContext(SafeThreadHandle threadHandle, IntPtr contextBuffer);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool Wow64SetThreadContext(SafeThreadHandle threadHandle, IntPtr contextBuffer);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern int Wow64SuspendThread(SafeThreadHandle threadHandle);
        
        [DllImport("kernel32.dll", SetLastError = true)]
        internal static extern bool WriteProcessMemory(SafeProcessHandle processHandle, IntPtr baseAddress, IntPtr bufferToWrite, int bytesToWriteSize, IntPtr numberOfBytesWrittenBuffer);
        
        // ntdll.dll imports
        
        [DllImport("ntdll.dll", SetLastError = true)]
        internal static extern NtStatus NtQueryInformationProcess(SafeProcessHandle processHandle, ProcessInformationClass processInformationClass, IntPtr processInformationBuffer, int bufferSize, IntPtr returnLengthBuffer);
        
        [DllImport("ntdll.dll")]
        internal static extern ulong RtlNtStatusToDosError(NtStatus ntStatus);
        
        [DllImport("ntdll.dll", SetLastError = true)]
        internal static extern NtStatus RtlCreateUserThread(SafeProcessHandle processHandle, IntPtr securityDescriptorBuffer, bool createSuspended, int stackZeroBits, IntPtr stackReserved, IntPtr stackCommit, IntPtr startAddress, IntPtr parameter, out SafeThreadHandle threadHandle, IntPtr clientIdBuffer);
        
        // user32.dll imports
        
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool PostThreadMessage(int threadId, WindowsMessage message, VirtualKey wParameter, IntPtr lParameter);
    }
}