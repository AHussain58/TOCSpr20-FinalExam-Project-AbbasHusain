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

            
            if (CheckForBalancedParen(accessString) == true)
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
               

            }
            else if (CheckForBalancedParen(accessString) == false)
            {
                audios.Play();
            }
           
        }

    }




    static public bool CheckForBalancedParen(string accessString)
    {
        
        const char LeftParent = '(';
        const char RightParenth = ')';
        uint ParenthCount = 0;

        try
        {
            checked  
            {
                for (int j = 0; j < accessString.Length; j++)
                {
                    switch (accessString[j])
                    {
                        case LeftParent:
                            ParenthCount++;
                            continue;
                        case RightParenth:
                            ParenthCount--;
                            continue;
                        default:
                            continue;
                    } 

                }
            }
        }

        catch (OverflowException)
        {
            return false;
        }

        if (ParenthCount == 0)
        {
            return true;
        }

        return false;

    }  








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
