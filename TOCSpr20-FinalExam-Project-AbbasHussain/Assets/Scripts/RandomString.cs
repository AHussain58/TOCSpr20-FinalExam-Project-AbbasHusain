using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class RandomString : MonoBehaviour
{
    
    // Start is called before the first frame update
    private Text thisText;
    int j = 0;
    int RandomPalindrome = 0;
   string finalString = "";
   
    void Start()
    {
        thisText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        RandomPalindrome = Random.Range(1, 3);
        if (j == 0)
        {
            GenerateRandomString(RandomPalindrome);
            j = 1;
        }




    }
  
    public void GenerateRandomString(int Strdecider)
    {
   
        string RString = "";
        string[] characters = new string[] { "x", "a", "1" };
            int stringLength = Random.Range(9, 15);
        for (int i = 0; i <= stringLength; i++)
        {
            RString = RString + characters[Random.Range(0, characters.Length)];


        }

        

        print(RString); 
                        
       
        if (Strdecider ==2)
        {
          
            var value = RString;
            var firstHalfLength = (int)(value.Length / 2);
            var secondHalfLength = value.Length - firstHalfLength;
            
            var splitPhone = new[]
            {
        value.Substring(0, firstHalfLength),
        value.Substring(firstHalfLength, secondHalfLength)
        };
           

            string FirstHalfofRandomS = splitPhone[0];
            print("These letters are First Half of Random String:" + FirstHalfofRandomS);

         
            string reverse = "";
            int Length = 0;

            Length = FirstHalfofRandomS.Length - 1;
            while (Length >= 0)
            {
                reverse = reverse + FirstHalfofRandomS[Length];
                Length--;
            }
           
            print("Reverse Latters of First Half :" + reverse);
            
            finalString = FirstHalfofRandomS + reverse; 
        }
        else
        {
            finalString = RString;
        }
        print(finalString);
        thisText.text = finalString; 

        string initial = "";

        int iLength = finalString.Length;

        for (int j = iLength - 1; j >= 0; j--)
        {
            initial = initial + finalString[j];
        }

        if (initial == finalString)
        {
            print(finalString + " is palindrome");

        }
        else
        {
            print(finalString + " is not a palindrome");
        }


        

    }


    


}