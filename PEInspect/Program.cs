using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PEReader;

namespace PEInspect
{
    class Program
    {
        static void Main(string[] args)
        {
            PeFile pe32 = new PeFile(@"..\Win32_Debug\Dll.dll");
            PeFile pe64 = new PeFile(@"..\x64_Debug\Dll.dll");

            PeFile trace = new PeFile(@"E:\Projects\Trace\Trace\bin\Debug\Trace.exe");
            PeFile thisAsm = new PeFile(Assembly.GetExecutingAssembly().Location);
            PeFile net3 = new PeFile(@"E:\Projects\Github Repos\VSCoverageViewer\bin\Debug_x86\VSCoverageViewer.exe");
            PeFile net4 = new PeFile(@"E:\Projects\Github Repos\VSCoverageViewer\bin\Release_x86\VSCoverageViewer.exe");
            PeFile net5 = new PeFile(@"E:\Projects\Lexer\StateMachines.Sandbox\bin\Debug\StateMachines.Sandbox.exe");
        }
    }
}
