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
    [System.Obsolete]
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
             
                position = new Vector3(Random.Range(-80, 96f), 5f, Random.Range(36, 120));
                GameObject newobject;
                newobject = Instantiate(collecttible, position, Quaternion.identity);
                newobject.GetComponent<PlaceString>().nameLable.text = notbalanced;
                notbalancedSpawned++;
              
            }
        }
        collecttible.active = false;
    }


    
    void Update()
    {
        
    }
    public static string RandomString(int length)
    {
        const string chars = "(xa1)";
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[newrandom.Next(s.Length)]).ToArray());
    }

    public static bool IsBalanced(string inputStr)
    {
        Dictionary<char, char> bracketPairs = new Dictionary<char, char>() {
            { '(', ')' }
            
        };

        Stack<char> brackets = new Stack<char>();

        try
        {
            
            foreach (char k in inputStr)
            {
               
                if (bracketPairs.Keys.Contains(k))
                {
                    
                    brackets.Push(k);
                }
                else
                    
                    if (bracketPairs.Values.Contains(k))
                {
                    
                    if (k == bracketPairs[brackets.First()])
                    {
                        brackets.Pop();
                    }
                    else
                        
                        return false;
                }
                else
                    
                    continue;
            }
        }
        catch
        {
           
            return false;
        }

        
        return brackets.Count() == 0 ? true : false;
    }
}
