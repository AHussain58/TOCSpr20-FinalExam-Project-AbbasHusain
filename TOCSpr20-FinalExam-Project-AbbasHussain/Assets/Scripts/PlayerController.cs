using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
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

            
            if (CheckRand(accessString) == true)
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
                
            }
            else if(CheckRand(accessString) == false)
            {
                audios.Play();
            }

        }

    }

    public bool CheckRand(string accessString)
    {
        string initial = "";
        int iLength = accessString.Length;
        for (int j = iLength - 1; j >= 0; j--)
        {
            initial = initial + accessString[j];
        }
        if (initial == accessString)
        {
            return true;
        }
        else
            return false;
    }


 


    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        switch (count)
        {
            case 1:
                winText.text = "You have Picked 1st Palindrom Collectible";

                break;

            case 2:
                winText.text = "You have Picked 2nd Palindrom Collectible";

                break;

            case 3:
                winText.text = "You have Picked 3rd Palindrom Collectible";

                break;

            case 4:
                winText.text = "You have Picked 4th Palindrom Collectible";

                break;

            case 5:
                winText.text = "You have Picked 5th Palindrom Collectible";

                break;

            case 6:
                winText.text = "You have Picked 6th Palindrom Collectible";

                break;

            case 7:
                winText.text = "You have Picked 7th Palindrom Collectible";

                break;
            case 8:
                winText.text = "You have Picked 8th Palindrom Collectible";

                break;
            case 9:
                winText.text = "You have Picked 9th Palindrom Collectible";

                break;
            case 10:
                winText.text = "You have Picked 10th Palindrom Collectible";

                break;
           
        }
      
    }



}
