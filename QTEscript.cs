using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QTEscript : MonoBehaviour {

    public GameObject DisplayBox;
    public GameObject PassBox;
    public int QTEGen;
    public int waitingForKey;
    public int CorrectKey;
    public int CountingDown;
    public int FTGen;
    public string Str;


    public void Update()
    {

        if (waitingForKey == 0)
        {
            
            QTEGen = Random.Range(1, 4);
            CountingDown = 1;

            StartCoroutine(CountDown());
          
            if (QTEGen == 1)
            {
                waitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[E]";
            }
            if (QTEGen == 2)
            {
                waitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[R]";
            }
            if (QTEGen == 3)
            {
                waitingForKey = 1;
                DisplayBox.GetComponent<Text>().text = "[T]";
            }
        }

        if (QTEGen == 1)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("EKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 2)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("RKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
        if (QTEGen == 3)
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetButtonDown("TKey"))
                {
                    CorrectKey = 1;
                    StartCoroutine(KeyPressing());
                }
                else
                {
                    CorrectKey = 2;
                    StartCoroutine(KeyPressing());
                }
            }
        }
    }

    public IEnumerator KeyPressing()
    {
        QTEGen = 4;

       
        //correct key is pressed
        if (CorrectKey == 1)
        {
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "PASS!";
            
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            CountingDown = 1;

        }
        //incorrect key is pressed
        if (CorrectKey == 2)
        {
            
            CountingDown = 2;
            FTGen = Random.Range(1, 4);
            switch (FTGen)// this how you do rdm responses 
            {
                case 1:
                    PassBox.GetComponent<Text>().text = "Wrong Guy, Bro";
                    break;
                case 2:
                    PassBox.GetComponent<Text>().text = "Oof you wanged it.";
                    break;
                default:
                    PassBox.GetComponent<Text>().text = "When was the last time you left your house?";
                    break;
            }
            
            
            yield return new WaitForSeconds(1.5f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            CountingDown = 1;

        }
    }

    public IEnumerator CountDown()
    {
        yield return new WaitForSeconds(3.5f);

        //did not press any key in time
        if (CountingDown == 1)
        {
            QTEGen = 4;
            CountingDown = 2;
            PassBox.GetComponent<Text>().text = "You waited too long and made it super awkward.";
            yield return new WaitForSeconds(3f);
            CorrectKey = 0;
            PassBox.GetComponent<Text>().text = "";
            DisplayBox.GetComponent<Text>().text = "";
            yield return new WaitForSeconds(1.5f);
            waitingForKey = 0;
            CountingDown = 1;
        }
    }


}


/*
public int FTGen;

some kind of fxn

FTGen = Random.Range(1,5)

if (FTGen == 1) 
    {
        PassBox.GetComponent<Text>().text = "Have you ever interacted with humans before?";
    }
if (FTGen == 2) 
    {
        PassBox.GetComponent<Text>().text = "Oof, you really wanged that one.";
    }
etc...
*/
