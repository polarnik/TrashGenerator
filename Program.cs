/*
 * Created by SharpDevelop.
 * User: Polarnik
 * Date: 26.07.2012
 * Time: 16:12
 */
using System;
using System.IO;

namespace TrashGenerator
{
	class Program
	{
		public static void Main(string[] args)
		{
			int countFiles = 0;
			int sizeFiles = 1024;
			int randomSize = 0;
			string extension = "test";
			string workPath = Environment.CurrentDirectory;
			foreach(string arg in args)
			{
				if(arg.StartsWith("-fileCount=", StringComparison.CurrentCultureIgnoreCase))
				{
					countFiles = System.Convert.ToInt32(arg.Substring(11));
				}
				if(arg.StartsWith("-fileSize=", StringComparison.CurrentCultureIgnoreCase))
				{
					sizeFiles = System.Convert.ToInt32(arg.Substring(10));
				}
				if(arg.StartsWith("-randSize=", StringComparison.CurrentCultureIgnoreCase))
				{
					randomSize = System.Convert.ToInt32(arg.Substring(10));
					if(randomSize < 0)
					{
						randomSize = -randomSize;
					}
				}
				if(arg.StartsWith("-workPath=", StringComparison.CurrentCultureIgnoreCase))
				{
					workPath = arg.Substring(10);
					if(!System.IO.Directory.Exists(workPath))
					{
						workPath = Environment.CurrentDirectory;
					}
				}
				if(arg.StartsWith("-fileExt=", StringComparison.CurrentCultureIgnoreCase))
				{
					extension = arg.Substring(9);
				}
			}
			ConsoleColor conColor = Console.ForegroundColor;

			Console.Write("-fileCount= (Count Files)   : ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(countFiles);
			
			Console.ForegroundColor = conColor;
			Console.Write("-fileSize = (Size Files)    : ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(sizeFiles);
			
			Console.ForegroundColor = conColor;
			Console.Write("-randSize = (Random Size)   : ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.Write(randomSize);
			Console.ForegroundColor = ConsoleColor.DarkGray;
			Console.WriteLine(" (+/-)");
			
			Console.ForegroundColor = conColor;
			Console.Write("-fileExt  = (File Extension): ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(extension);
			
			Console.ForegroundColor = conColor;
			Console.Write("-workPath = (Work Path)     : ");
			Console.ForegroundColor = ConsoleColor.White;
			Console.WriteLine(workPath);
			
			Random autoRand = new Random( );
			for(int fileIndex=1; fileIndex <= countFiles; fileIndex++)
			{
                string fileName = string.Format("File_{0}_{1}", sizeFiles, fileIndex);
                FileStream fs = new FileStream(workPath + "\\" + fileName + "." + extension, FileMode.Create, FileAccess.Write, FileShare.Write);
				int fileSize = 0;
				int writeBufferSize = 4096;
				int randomValue = autoRand.Next(-randomSize, randomSize);
				int fileSizeNedd = sizeFiles + randomValue;
				while((fileSize + writeBufferSize) <= fileSizeNedd)
				{
					byte[] info = new byte[writeBufferSize];
					autoRand.NextBytes(info);
					fs.Write(info, 0, info.Length);
					fileSize = fileSize + writeBufferSize;
				}
				if(fileSize < fileSizeNedd)
				{
					byte[] info = new byte[fileSizeNedd-fileSize];
					autoRand.NextBytes(info);
					fs.Write(info, 0, info.Length);
				}
	
				Console.ForegroundColor = ConsoleColor.White;
				Console.Write(fs.Name + "\t");
				
				Console.ForegroundColor = ConsoleColor.Gray;
				Console.Write(fileSizeNedd);

				Console.ForegroundColor = ConsoleColor.DarkGray;
				Console.WriteLine(" Bytes");

				fs.Close();
			}
			Console.ForegroundColor = conColor;
			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}