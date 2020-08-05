using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class RandomPos : MonoBehaviour
{
    GameObject collecttible;
    Vector3 position;
    private Text thisText;
    static string[] validandnotvalids = new string[100];
    static public System.Random ran = new System.Random();
    public static Random random = new Random();
    private static System.Random newrandom = new System.Random();


    void Start()
    {
        collecttible = GameObject.FindGameObjectWithTag("Pick Up");
        string balanced,notbalanced;
        int balancedSpawned = 0;
        int notbalancedSpawned = 0;
        
        while (balancedSpawned < 10)
        {
            

             balanced = RandomString(ran.Next(9, 15));
             if (IsBalanced(balanced))
             {
                // validandnotvalids[i] = randomstring;
                 position = new Vector3(Random.Range(-90, 120f), 8f, Random.Range(36, 140));
                GameObject newobject;
                newobject =Instantiate(collecttible, position, Quaternion.identity);
                 newobject.GetComponent<PlaceString>().nameLable.text = balanced;
                 balancedSpawned++;
                
             } 
        }
        while (notbalancedSpawned < 20)
        {


            notbalanced = RandomString(ran.Next(9, 15));
            if (!IsBalanced(notbalanced))
            {
                // validandnotvalids[i] = randomstring;
                position = new Vector3(Random.Range(-80, 96f), 5f, Random.Range(36, 120));
                GameObject newobject;
                newobject = Instantiate(collecttible, position, Quaternion.identity);
                newobject.GetComponent<PlaceString>().nameLable.text = notbalanced;
                notbalancedSpawned++;
              
            }
        }
        collecttible.active = false;
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
            { '(', ')' }
            
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
