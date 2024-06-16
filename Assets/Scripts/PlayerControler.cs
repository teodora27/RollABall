using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerControler : MonoBehaviour
{
    public float speed=0;
    public TextMeshProUGUI countText;
    public GameObject winText;
    private Rigidbody rb;
    private int count;
    private float movementx, movementy;

    // Start is called before the first frame update
    void Start()
    {
        winText.SetActive(false);
        rb = GetComponent<Rigidbody>();
        count=0;
        SetCountText();
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementx = movementVector.x;
        movementy = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: "+ count.ToString();
        if(count == 8)
        {
             winText.SetActive(true);
        }
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementx, 0.0f, movementy);
        rb.AddForce(movement*speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUp"))
        {
             other.gameObject.SetActive(false);
             count++;
             SetCountText();
        }
       
    }
}
