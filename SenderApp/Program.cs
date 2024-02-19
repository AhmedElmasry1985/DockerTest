// See https://aka.ms/new-console-template for more information

const string filePath = @".\mounted\message.txt";
Console.WriteLine("Sender Application Started");
Console.WriteLine($"I will Write what you type in the file in {filePath}");
while (true)
{
    Console.WriteLine("Write a message:");
    var txt = Console.ReadLine();
    if(File.Exists(filePath)) 
        File.WriteAllText(filePath,txt);  
    else Console.WriteLine("File not exist, create it and wait for 5 sec.");
}

// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, What is your name?");
// var name = Console.ReadLine();
// Console.WriteLine($"Welcome {name}");