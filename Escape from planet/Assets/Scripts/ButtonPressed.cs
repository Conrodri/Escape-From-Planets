using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    public bool isAPressed;
    public bool isDPressed;
    public GameObject myPlayer;
    Move2D playerScript;

    void Start()
    {
        playerScript = myPlayer.GetComponent<Move2D>();
    }

    void Update()
    {
        //is A and D pressed player stop
        if (Input.GetKeyDown(KeyCode.A))
            isAPressed = true;

        if  (Input.GetKeyDown(KeyCode.D))
            isDPressed = true;

        if (Input.GetKeyUp(KeyCode.A))
            isAPressed = false;

        if (Input.GetKeyUp(KeyCode.D))
            isDPressed = false;

        if (isAPressed == true && isDPressed == true && playerScript.isGrounded == true)
            playerScript.moveSpeed = 0;

        if ((isAPressed == true || isDPressed == true) && (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A)))
        {
            playerScript.moveSpeed = 0;
            isAPressed = false;
            isDPressed = false;
        }
            
        if (isAPressed == false || isDPressed == false)
            playerScript.moveSpeed = 7;
    }

}
