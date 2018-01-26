using System.Collections;
using System.Collections.Generic;
using System;
namespace MyUtility
{
    public class MBuffer
    {

        public static byte[] strToBuffer(string str)
        {
            return Convert.FromBase64String(str);
        }



        public static int[,] bufferToIntArray(byte[] buffer, int rowSize, int colSize)
        {
            if (buffer.Length != rowSize * colSize * sizeof(int))
            {
                throw new ArgumentException("buffer.length is not equal (rowSize * colSize * sizeof(int))");
            }

            int[,] arr = new int[rowSize, colSize];
            Buffer.BlockCopy(buffer, 0, arr, 0, arr.Length * sizeof(int));
            return arr;
        }

        public static byte[] intArrayToBuffer(int[,] arr)
        {
            byte[] buffer = new byte[arr.Length * sizeof(int)];
            Buffer.BlockCopy(arr, 0, buffer, 0, buffer.Length);
            return buffer;
        }

    }
}

