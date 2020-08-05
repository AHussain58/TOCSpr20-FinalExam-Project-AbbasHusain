using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class RandomBracketString : MonoBehaviour
{
    // Start is called before the first frame update
    private Text thisText;
    //int j = 0;
    //int RandomPalindrome = 0;
    //string finalString = "";
    //string RString = "";
    static string[] validandnotvalids = new string[100];
    static public System.Random ran = new System.Random();
    public static Random random = new Random();
    private static System.Random newrandom = new System.Random();


    void Start()
    {
        thisText = GetComponent<Text>();




        string random;


        for (int i = 0; i < 18; i++)
        {
            random = RandomString(ran.Next(9, 15));
            if (IsBalanced(random))
            {
                validandnotvalids[i] = random;
                print(random);
            }
            else
            {
                i--;
            }
        }



    }




    // Update is called once per frame
    void Update()
    {

       



    }



    public static string RandomString(int length)
    {
        const string chars = "(xa1)";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[newrandom.Next(s.Length)]).ToArray());
    }

    public static bool IsBalanced(string input)
    {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
            { '(', ')' },
            { '{', '}' },
            { '[', ']' },
            { '<', '>' }
        };

        Stack<char> brackets = new Stack<char>();

        try
        {
            // Iterate through each character in the input string
            foreach (char c in input)
            {
                // check if the character is one of the 'opening' brackets
                if (bracketPairs.Keys.Contains(c))
                {
                    // if yes, push to stack
                    brackets.Push(c);
                }
                else
                    // check if the character is one of the 'closing' brackets
                    if (bracketPairs.Values.Contains(c))
                {
                    // check if the closing bracket matches the 'latest' 'opening' bracket
                    if (c == bracketPairs[brackets.First()])
                    {
                        brackets.Pop();
                    }
                    else
                        // if not, its an unbalanced string
                        return false;
                }
                else
                    // continue looking
                    continue;
            }
        }
        catch
        {
            // an exception will be caught in case a closing bracket is found, 
            // before any opening bracket.
            // that implies, the string is not balanced. Return false
            return false;
        }

        // Ensure all brackets are closed
        return brackets.Count() == 0 ? true : false;
    }
}







