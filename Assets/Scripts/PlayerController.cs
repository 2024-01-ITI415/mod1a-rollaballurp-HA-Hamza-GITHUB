using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    public float speed = 0; 
    public TextMeshProUGUI countText;
    private int count;
    public GameObject winTextObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent <Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void FixedUpdate() 
   {
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);     
        rb.AddForce(movement);
        rb.AddForce(movement * speed);
   }

   void OnTriggerEnter(Collider other) 
   {
        if (other.gameObject.CompareTag("PickUp")) 
       {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
       }
       
   }
    
    void OnMove (InputValue movementValue)
   {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x; 
        movementY = movementVector.y; 
   }

   void SetCountText() 
   {
       countText.text =  "Count: " + count.ToString();
       if (count >= 8)
       {
           winTextObject.SetActive(true);
       }
   }
}
