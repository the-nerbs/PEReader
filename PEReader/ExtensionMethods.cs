using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PEReader
{
    internal static class ExtensionMethods
    {
        /// <summary>
        /// Reads a marshal-able type fro ma stream.
        /// </summary>
        /// <typeparam name="T">
        ///   The type to read. Must be capable of being read using
        ///   <see cref="Marshal.PtrToStructure(IntPtr, Type)"/>.
        /// </typeparam>
        /// <param name="stream">[this] The stream to read from.</param>
        /// <returns>The value read from the stream.</returns>
        public static T Read<T>(this Stream stream)
        {
            int len = Marshal.SizeOf(typeof(T));

            var bytes = new byte[len];
            if (stream.Read(bytes, 0, len) != len)
            {
                throw new IOException("Not enough data in the stream");
            }

            var hBytes = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T)Marshal.PtrToStructure(hBytes.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                hBytes.Free();
            }
        }


        /// <summary>
        /// Reads an ASCII-encoded, NUL-terminated string from a stream.
        /// </summary>
        /// <param name="stream">[this] The stream to read from.</param>
        /// <returns>The string read from the stream.</returns>
        public static string ReadAsciiZeroTerminated(this Stream stream)
        {
            var builder = new StringBuilder();

            for (int ch = stream.ReadByte();
                 ch > 0;
                 ch = stream.ReadByte())
            {
                builder.Append((char)(ch & 0xFF));
            }

            return builder.ToString();
        }

        /// <summary>
        /// Reads a UTF8-encoded, NUL-terminated string from a stream.
        /// </summary>
        /// <param name="stream">[this] The stream to read from.</param>
        /// <returns>The string read from the stream.</returns>
        public static string ReadUtf8ZeroTerminated(this Stream stream)
        {
            var bytes = new List<byte>();

            for (int ch = stream.ReadByte();
                 ch > 0;
                 ch = stream.ReadByte())
            {
                bytes.Add((byte)(ch & 0xFF));
            }

            return Encoding.UTF8.GetString(bytes.ToArray());
        }

        /// <summary>
        /// Reads a UTF8-encoded string of known length from a stream.
        /// </summary>
        /// <param name="stream">[this] The stream to read from.</param>
        /// <param name="length">The length of the string.</param>
        /// <returns>The string read from the stream.</returns>
        public static string ReadUtf8(this Stream stream, int length)
        {
            var bytes = new byte[length];

            for (int i = 0; i < length; i++)
            {
                int ch = stream.ReadByte();
                bytes[i] = (byte)(ch & 0xFF);
            }

            return Encoding.UTF8.GetString(bytes).TrimEnd('\0');
        }


        /// <summary>
        /// Aligns a stream to the next multiple of <paramref name="count"/> bytes.
        /// If the stream is already aligned, this does not advance the stream.
        /// </summary>
        /// <param name="stream">[this] The stream to align.</param>
        /// <param name="count">The number of bytes to align to.</param>
        public static void AlignToBytes(this Stream stream, int count)
        {
            while ((stream.Position % count) != 0)
            {
                stream.ReadByte();
            }
        }
    }
}
