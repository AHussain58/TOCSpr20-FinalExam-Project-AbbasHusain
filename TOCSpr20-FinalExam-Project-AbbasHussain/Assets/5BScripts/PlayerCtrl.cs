using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
     public float speed;
    private Rigidbody rb;
    public AudioSource audios;
    public Text countText;
    public Text winText;
    private int count;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audios = GetComponent<AudioSource>();
        count = 0;
        SetCountText();
        winText.text = "";


    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {

        string accessString = other.gameObject.GetComponent<PlaceString>().nameLable.text.ToString();
        if (other.gameObject.CompareTag("Pick Up"))
        {

            
            if (CheckForBalancedBracketing(accessString) == true)
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
               

            }
            else if (CheckForBalancedBracketing(accessString) == false)
            {
                audios.Play();
            }
           
        }

    }




    static public bool CheckForBalancedBracketing(string accessString)
    {
        
        const char LeftParenthesis = '(';
        const char RightParenthesis = ')';
        uint BracketCount = 0;

        try
        {
            checked  // Turns on overflow checking.
            {
                for (int Index = 0; Index < accessString.Length; Index++)
                {
                    switch (accessString[Index])
                    {
                        case LeftParenthesis:
                            BracketCount++;
                            continue;
                        case RightParenthesis:
                            BracketCount--;
                            continue;
                        default:
                            continue;
                    }  // end of switch()

                }
            }
        }

        catch (OverflowException)
        {
            return false;
        }

        if (BracketCount == 0)
        {
            return true;
        }

        return false;

    }  // end of CheckForBalancedBracketing()








    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        switch (count)
        {
            
            case 10:
                winText.text = "You have Picked all 10 Matching Parenthesis Hurrray !!!!! (:";

                break;
           
        }
      
    }

}
