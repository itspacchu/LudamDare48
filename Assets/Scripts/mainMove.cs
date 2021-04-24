using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    public float rotationSpeed = 50.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;
    private Vector3 move;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    

    void Update()
    {

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        float rot = Input.GetAxis("Horizontal")*Time.deltaTime*rotationSpeed;
        this.transform.Rotate(new Vector3(0,rot,0));
        controller.Move(this.transform.forward * Time.deltaTime * playerSpeed);


        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
