using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace RollABallSimulation
{
    public class PlayerControllerSimulation : MonoBehaviour
    {
        public float speed;
        public float jumpForceScaler;
        public Joystick joystick;
        public Button jumpButton;

        [SerializeField]
        private GameLogicSimulation m_GameLogic;


        private Rigidbody rb;
        private bool jump;
        private bool canJump;

        PopupMessageSimulation popupMessage;
        GameObject GameController;

        void Start()
        {
            GameController = GameObject.Find("GameController");
            popupMessage = GameController.GetComponent<PopupMessageSimulation>();
            popupMessage.Close();

            rb = GetComponent<Rigidbody>();
            jump = false;
            canJump = true;
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
            if (other.gameObject.CompareTag("Bomb"))
            {
                other.gameObject.SetActive(false);
                m_GameLogic.DeleteScore();
                
                popupMessage = GameController.GetComponent<PopupMessageSimulation>();
                popupMessage.Open("Text", "Restart");

            }
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

