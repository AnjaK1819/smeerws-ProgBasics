using System;
using UnityEngine;

public class ProgBasics : MonoBehaviour
{
    private static readonly System.Random getRandom = new System.Random();

    private static readonly int MAXCOFFEE = 3;
    private static readonly int MAXALARM = 4;

    private double coffee;
    private bool sleeping, awake, catFed;
    private string[] radioMessages;
    private TimeSpan timeSpan;

    void Start()
    {
        coffee   = 0f;
        sleeping = true;
        awake = catFed = true;
        radioMessages = getRadioMessages(MAXALARM, new TimeSpan(6,0,0));
    }

    void Update()
    {
        if(sleeping)
        {
            sleeping = false;
            writeCommentDreamLand();
            wakeUp();
            awake = true;
        }
        else if(awake)
        {
            awake = false;
            doMorningRoutine();
        }

    }

    private void writeCommentDreamLand()
    {
        Debug.Log("Mary is in a dream land");
    }

    private void wakeUp()
    {
        foreach(string item in radioMessages)
        {
            Debug.Log(item);
        }
    }

    private string[] getRadioMessages(int max, TimeSpan startTime)
    {
        string[] tmpArray = new string[max];

        TimeSpan tempTime = startTime;
        for(int i = 0; i < tmpArray.Length; i++)
        {
            //overloading timespan.ToString() with formating requires .NET Standard 2.0 resp. .NET 4.X
            tmpArray[i] = "It is " + tempTime.ToString(@"hh\:mm");
            tempTime = tempTime.Add(new TimeSpan(0, 20, 0));
            if(i < tmpArray.Length -1)
            {
                tmpArray[i] += "\n" + "Mary hits the button \"Snoozze\"! ";
            }
            else
            {
                tmpArray[i] += "\n" + "Mary stands up! ";
            }
        }
        return tmpArray;
    }

    /*called to print all radio messages at once*/
    private void printRadioMesssages(string[] rmarray)
    {
        foreach(string msg in rmarray)
        {
            Debug.Log(msg);
        }
    }

    /*called to prepare coffee and get coffee ready state*/
    private bool getCoffeeReady()
    {
        //stand up, prepare coffee
        bool coffeeReady = false;
        for(int i = 0; i <= MAXCOFFEE; i++)
        {
            //short if/else (?: operator)
            coffeeReady = (i == MAXCOFFEE) ? true : false;
            //We typically only rewrite short if/else statements with the conditional operator (?:) when 
            //they update the value of a variable, call a non-void method, 
            //or set a method argument conditionally.
            /* if (i == maxCoffee)
            {
                coffeeReady = true; 
            }
            else
            {
                coffeeReady = false;
            }*/
            Debug.Log("The coffee is running");
        }
        return coffeeReady;
    }

    private bool isMorningHygieneFinished()
    {
        bool takeShower = true;
        bool brushTeeth = true;
        return takeShower && brushTeeth;
    }

    private bool isDressedUpFinished()
    {
        int val = getRandom.Next(0, 3); //Magic val
        if (val == 1)
        {
            return true;
        }
        return false;
    }

    private void doMorningRoutine()
    {
        if (getCoffeeReady())
        {
            if (isMorningHygieneFinished() && isDressedUpFinished())
            {
                Debug.Log("Morning hygiene is completed ");
                Debug.Log("Mary put on her clothes");
                coffee = getRandom.NextDouble() * 1.5;
                catFed = (getRandom.Next(0, 2) == 0) ? true : false;
                Debug.Log("Mary drinks " + coffee + "liter of coffe drunken");
                if (catFed && (coffee >= 0.5f && coffee <= 1.5f)) //Magic val
                {
                    Debug.Log("I've fed the cat, I'm ready for the day");
                }
                else
                {
                    Debug.Log("This is not my day, the cat is not here!");
                }
            }
            else
            {
                Debug.Log("This is not my day! Problems to find proper clothes.");
            }
        }
        else
        {
            awake = true;
            Debug.Log("Oh no, the coffee is not ready!!");
        }
    }
}
