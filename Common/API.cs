using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Common
{
    public class API
    {
        //[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        //上面这个可能不要 可能要，具体看你这个回调函数的调用方式是cdecl调用还是其他。
        //public  delegate  void  ChCallback(参数自己一一对应）；
       // [DllImport("Cmdll.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        //public static extern bool FUN(char *, double , double , double ,ChCallback CallBack,int );
        //参数自己对应写，我的意思是自己定义一个delegate  对应C++ 中的CALLBACKF 然后再放到 fun参数里
    }
}
