using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressJumpBar : MonoBehaviour
{
    public Slider slider;
    public GameObject myPlayer;
    JumpHolder playerScript;

    private float targetProgress = 0;

    public float Fillspeed;

    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        playerScript = myPlayer.GetComponent<JumpHolder>();
    }

    void Start()
    {
        IncrementProgress(playerScript.maxChargePower);
    }

    // Update is called once per frame
    void Update()
    {
        Fillspeed = playerScript.chargedPower;
        if (slider.value < targetProgress && playerScript.isJumping == false && Input.GetKey(KeyCode.Space))
            slider.value += Fillspeed * Time.deltaTime;

        if (Input.GetKeyUp(KeyCode.Space))
            slider.value = 0;

    }
    public void IncrementProgress(float newProgress)
    {
        targetProgress = slider.value + newProgress;
    }
}
