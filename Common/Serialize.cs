using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Pbzx.Common
{
    public class Serialize
    {
        /// <summary>
        /// 将对象序列化成二进制流
        /// </summary>
        /// <param name="objVal">对象值</param>
        /// <returns>二进制流</returns>
        public static byte[] getSearialize(object objVal)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, objVal);
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            byte[] myDate = new byte[ms.Length];
            ms.Read(myDate, 0, Convert.ToInt32(ms.Length));
            ms.Close();
            ms.Dispose();
            return myDate;
        }
        /// <summary>
        /// 反序列化二进制流
        /// </summary>
        /// <param name="objVal">二进制流对象</param>
        /// <returns>对象</returns>
        public static object getDesearialize(object objVal)
        {
            byte[] myDate = (byte[])objVal;//强类型转换
            MemoryStream ms = new MemoryStream();
            ms.Write(myDate, 0, Convert.ToInt32(myDate.Length));
            ms.Seek(0, SeekOrigin.Begin);
            BinaryFormatter bf = new BinaryFormatter();
            object result = bf.Deserialize(ms);
            ms.Close();
            ms.Dispose();
            return result;
        }
    }
}
