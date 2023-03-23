using System.Net.Mime;
// See https://aka.ms/new-console-template for more information

using DataStruct.BinaryTree;
using DataStruct.ByteArray;
using DataStruct.Process;

Console.WriteLine("Hello,DataStruct World!");

ShowMenu();
static void ShowMenu()
{
    Console.WriteLine("1-BianaryTree");
    Console.WriteLine("2-Sort");
    Console.WriteLine("3-Philosopher");
    Console.WriteLine("4-Byte[]");
    string choose = string.Empty;
    choose = Console.ReadLine();
    if (choose == "1")
    {
        CodeTimer.Time("new", 1, () => { MyBinaryTreeBasicTest.Test(); });
    }
    else if (choose == "2")
    {
        CodeTimer.Time("new", 1, () => { MyBinaryTreeBasicTest.Test(); });
    }
    else if (choose == "3")
    {
        PhilosopherDemo.startprocess();
    }
    else if (choose == "4")
    {
        ByteArrayTest1.test();
    }
    else if (choose == "0")
    {
        Environment.Exit(0);
    }
    else
    {
        ShowMenu();
    }
}
Console.ReadKey();