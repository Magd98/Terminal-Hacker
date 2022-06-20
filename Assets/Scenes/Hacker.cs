using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    //Game Configurations
    const string menu = "Type Menu to return back";
    string[] Lvl1Passwords = { "aisle", "self", "books", "shelf", "borrow", "genre" };
    string[] Lvl2Passwords = { "knife", "detective", "blood", "killer", "body", "crimescene" };
    string[] Lvl3Passwords = { "planet", "stars", "shuttle", "quantum physics", "galaxy", "rocket" };
    
    //Game State
    int level;
    string password;
    enum Screen { MainMenu,WaitPassword,Win };
    Screen CurrentScreen;
    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();   
        
    }
     
    void ShowMainMenu() 
    {
        CurrentScreen = Screen.MainMenu;
        Terminal.ClearScreen();
        Terminal.WriteLine("Welcome to Hack or Die!! \nWhere to Start Hacking..Dare to Choose :>\n \n 1.Library\n 2.Crime\n 3.Nasa \n \n Enter Your Selection:");

    }
    void OnUserInput(string input)
    {
        if (input == "Menu")
        {
            ShowMainMenu();
        }
        else if (CurrentScreen == Screen.MainMenu)
        {
            RunMainMenu(input);
        }
        else if (CurrentScreen== Screen.WaitPassword)
        {
            CheckPassword(input);
        }
    }



    void RunMainMenu(string input)
    {
        bool isValidNumber = (input == "1" || input == "2"||input=="3");
        if (isValidNumber)
        {
            level = int.Parse(input);
            AskForPassword();
        }
        else
        {
            Terminal.WriteLine("Please Choose A Valid Level");
            Terminal.WriteLine(menu);
        }
        
    }

    void AskForPassword()
    {
        CurrentScreen = Screen.WaitPassword;
        Terminal.ClearScreen();
        SetRandomPassword();
        Terminal.WriteLine("Welcome to Level " + level ); 
        Terminal.WriteLine("Please Enter the Password Your hint is " + password.Anagram());
        Terminal.WriteLine(menu);
    }

   void SetRandomPassword()
    {
        switch (level)
        {
            case 1:
                password = Lvl1Passwords[Random.Range(0, Lvl1Passwords.Length)];
                break;
            case 2:

                password = Lvl2Passwords[Random.Range(0, Lvl2Passwords.Length)];
                break;
            case 3:
                password = Lvl3Passwords[Random.Range(0, Lvl3Passwords.Length)];
                break;
            default:
                Debug.LogError("Invalid Level Number");
                break;
        }
    }

    void CheckPassword(string input)
    {
        if (password == input)
        {
            DisplayWin();
            
        }
        else
        {
            AskForPassword();
            Terminal.WriteLine("Sorry,That is Incorrect..Try Again");
          

        }
    }

     void DisplayWin()
    {
        CurrentScreen = Screen.Win;
        Terminal.ClearScreen();
        ShowlevelReward();
        Terminal.WriteLine(menu);
    }

    void ShowlevelReward()
    {
        switch(level)
        {
            case 1:
                Terminal.WriteLine("Have a book....Wooohooo !! ");
                Terminal.WriteLine(@"
    ___________
   /          //
  /          //
 /__________//     
(__________(/

");
                break;
            case 2:
                Terminal.WriteLine("Grab Your Knife....Kill Kill Kill !!");
                Terminal.WriteLine(@"
       )xxxxx[;;;;;;;;;;;;;;;;>
       )xxxxx[;;;;;;;;;;;;;;;;>
");
                break;
            case 3:
                Terminal.WriteLine("...Please Stand By...");
                Terminal.WriteLine(@"
     .'.
     |o|
    .'o'.
    |.-.|
    '   '
     ( )
      )
     ( )
");
                break;
            default:
                Debug.LogError("Invalid Token");
                break;


                 
        }    
    }
    // Update is called once per frame
    void Update()
    {
    }
}
