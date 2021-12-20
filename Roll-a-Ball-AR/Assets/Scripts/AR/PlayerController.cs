using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RollABallAR
{
    public class PlayerController : MonoBehaviour
    {
        public float speed;
        public float jumpForceScaler;
        public Joystick joystick;
        public Button jumpButton;
        //public Text countText;
        //public Text winText;

        [SerializeField]
        private GameLogic m_GameLogic;


        private Rigidbody rb;
        private bool jump;
        private bool canJump;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            jump = false;
            canJump = true;
            //winText.text = "";
            jumpButton.onClick.AddListener(SetJump);
            m_GameLogic.StartGame();
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
                m_GameLogic.AddScore();
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if (collision.impulse.y > 0.0f)
            {
                canJump = true;
            }
        }

        void SetJump()
        {
            if (canJump)
                jump = true;
        }
    }
}


