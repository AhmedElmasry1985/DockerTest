// See https://aka.ms/new-console-template for more information

const string filePath = @".\mounted\message.txt";
Console.WriteLine("Receiver Application Started");
Console.WriteLine($"I will read the content of the file in {filePath} every 5 sec.");
while (true)
{
    Thread.Sleep(5000);
    Console.WriteLine(File.Exists(filePath)
        ? File.ReadAllText(filePath)
        : "File not exist, create it and wait for 5 sec.");
}
