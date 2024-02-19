using System;
using System.Diagnostics;

namespace SenderApp
{
    public class Program
    {
        public static void Main(String[] args)
        {
            var containerId = args.FirstOrDefault();
            const string filePath = @"mounted/message.txt";
            const string restartLetter = "R";
            Console.WriteLine("Sender Application Started");
            Console.WriteLine($"I will Write what you type in the file in {filePath}");
            while (true)
            {
                Console.WriteLine($"Write a message, or type {restartLetter} to restart the container with id {containerId}:");
                var txt = Console.ReadLine();
                if (string.Equals(txt, restartLetter))
                {

                    //var command = $"docker login {endpointBaseUri} -u {login} -p {password}";
                    var command = $"docker restart {containerId}";
                    Process process = new Process()
                    {
                        StartInfo = new ProcessStartInfo
                        {
                            FileName = "/bin/bash",
                            RedirectStandardOutput = true,
                            Arguments = $"-c \"{command}\"",
                            UseShellExecute = false,
                            CreateNoWindow = true,
                        }
                    };
                    process.Start();
                    string result = process.StandardOutput.ReadToEnd();
                    process.WaitForExit();
                    Console.WriteLine(result);

                    Console.WriteLine($"Container {containerId} restarted");
                }
                else
                {
                    if (File.Exists(filePath))
                        File.WriteAllText(filePath, txt);
                    else Console.WriteLine("File not exist, create it and wait for 5 sec.");
                }
            }

        }
    }
}