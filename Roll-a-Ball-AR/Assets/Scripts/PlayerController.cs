using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForceScaler;
    public Joystick joystick;
    public Button jumpButton;
    //public Text countText;
    //public Text winText;


    private Rigidbody rb;
    private int count;
    private bool jump;
    private bool canJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        jump = false;
        canJump = true;
        //winText.text = "";
        SetCountText();
        jumpButton.onClick.AddListener(SetJump);
    }

    void FixedUpdate()
    {
        float moveHorizontal = joystick.Horizontal;
        float moveVertical = joystick.Vertical;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);

        if (jump)
        {
            rb.AddForce(Vector3.up * speed * jumpForceScaler, ForceMode.Impulse);
            jump = false;
            canJump = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            ++count;
            SetCountText();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.impulse.y > 0.0f)
        {
            canJump = true;
        }
    }

    void SetCountText()
    {
        //countText.text = "Count: " + count.ToString();
        //if (count >= 10)
        //{
        //    winText.text = "You Win!";
        //}
    }

    void SetJump()
    {
        if (canJump)
            jump = true;
    }
}
