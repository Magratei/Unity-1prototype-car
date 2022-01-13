using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    [SerializeField] GameObject centerMas;
    [SerializeField] private float horsePower;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;

    [SerializeField] List<WheelCollider> allWeels;
    private int wheelOnGround;
    
    private float speed;
    private float rpm;
    private float turnSpeed = 25.0f;
    private static float horizontalInput;
    private float verticalInput;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerMas.transform.position;
    }

    
    void FixedUpdate()
    {
        if (IsOnGround())
        {
            //инициалимзируем переменные аксами с соответсвующими настройками по клавишам
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            playerRb.AddRelativeForce(Vector3.forward * horsePower * verticalInput);

            //перемещаем авто вперед по нпжптию кнеопок w s 
            //transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);


            //крутим авто вокруг своей оси по нажатию a d
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput);

            speed = Mathf.Round(playerRb.velocity.magnitude * 3.6f);
            speedometerText.SetText("Speed: " + speed + "km/h");

            rpm = Mathf.Round((speed % 30) * 40);
            rpmText.SetText("Rpm: " + rpm);
        }

    }

    bool IsOnGround()
    {
        wheelOnGround = 0;
        foreach (WheelCollider weel in allWeels)
        {
            if (weel.isGrounded)
            {
                wheelOnGround++;
            }
        }
        if (wheelOnGround == 4)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
