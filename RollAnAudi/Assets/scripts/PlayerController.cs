using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;
    
    //use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>(); //adding a Rigidbody to an object will put its motion under Unity's physics engine
        count = 0;
        SetCountText();
        winText.text = "";
    }

    //called before performing any physics calculations
    void FixedUpdate() 
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical); //y-axis = 0, because the ball shouldn't move up
        rb.AddForce(movement * speed); //moving the ball by applying forces to the Rigidbody
    }

    //called when Player object first touches a trigger collider
    void OnTriggerEnter(Collider other)
    {   //if Player touches an object with the tag "Pick Up", that object gets deactivated
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            SetCountText();
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if(count >= 59)
        {
            winText.text = "Vorsprung durch Technik";
        }
    }
}