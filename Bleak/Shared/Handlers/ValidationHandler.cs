using System;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices;
using Bleak.Injection.Objects;

namespace Bleak.Shared.Handlers
{
    internal static class ValidationHandler
    {
        internal static void ValidateDllArchitecture(InjectionWrapper injectionWrapper)
        {
            // Ensure the architecture of the remote process matches the architecture of the DLL

            if (injectionWrapper.ProcessManager.IsWow64 != (injectionWrapper.PeParser.PeHeaders.PEHeader.Magic == PEMagic.PE32))
            {
                throw new ApplicationException("The architecture of the remote process did not match the architecture of the DLL");
            }

            // Ensure that x64 injection is not being attempted from an x86 build

            if (!Environment.Is64BitProcess && !injectionWrapper.ProcessManager.IsWow64)
            {
                throw new ApplicationException("x64 injection is not supported when compiled under x86");
            }
        }
        
        internal static void ValidateOperatingSystem()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                throw new PlatformNotSupportedException("This library is intended for Windows use only and will not work on Linux");
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                throw new PlatformNotSupportedException("This library is intended for Windows use only and will not work on OSX");
            }

            if (!Environment.Is64BitOperatingSystem)
            {
                throw new PlatformNotSupportedException("This library is intended for 64 bit Windows use only and will not work on 32 bit versions");
            }
        }
    }
}