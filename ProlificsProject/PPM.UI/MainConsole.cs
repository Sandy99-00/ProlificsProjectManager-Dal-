using PPM.Model;
using System;
public class MainConsole
{
    public static int Mainfuncion()  
    {
        Thread.Sleep(100);
        Console.ForegroundColor=ConsoleColor.Blue;
        Console.WriteLine       ("╭───────────────────────── The Project Is ─────────────────────────╮");
        Console.ForegroundColor = ConsoleColor.Red;
        System.Console.WriteLine("|------------------Welcome to ProlificsProjectManager--------------|");
         Thread.Sleep(100);
        Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.WriteLine("|---------------------Choose the Required Option!------------------|");
         Thread.Sleep(100);
        System.Console.WriteLine("|                                                                  |");
        Console.ForegroundColor = ConsoleColor.Cyan;
        System.Console.WriteLine("|      1.Project Module                                            |");
        Thread.Sleep(100);
        System.Console.WriteLine("|      2.Employee Module                                           |");
        Thread.Sleep(100);
        System.Console.WriteLine("|      3.Role Module                                               |");
         Thread.Sleep(100);
    
        System.Console.WriteLine("|      4.Add Employee to project                                   |");
         Thread.Sleep(100);
        System.Console.WriteLine("|      5.Delete Employee from project                              |");
         Thread.Sleep(100);
        System.Console.WriteLine("|      6.View Project Details                                      |");
         Thread.Sleep(100);
        System.Console.WriteLine("|      7.SaveApp                                                   |");
        Thread.Sleep(100);
        System.Console.WriteLine("|      8.Quit                                                      |");
         Thread.Sleep(100);
        System.Console.ResetColor();
        Console.WriteLine       ("╰──────────────────────────────────────────────────────────────────╯");

        System.Console.WriteLine("Choose a option to continue");
       int selectOption = int.Parse(Console.ReadLine());
       return selectOption;
    }
    public static void Exitfunction()
    {
        Console.ForegroundColor=ConsoleColor.Blue;
        Console.WriteLine("Thanks for using the application");
        Console.ResetColor();
        Environment.Exit(0);
    }
    public static void defaultfunction()
    {
      System.Console.WriteLine("Invalid Option");
    }

    
}
                                                    