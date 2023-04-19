using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float Speed;
    private float CurrentSpeed;
    Vector3 Direction;


    public float DashSpeed;
    public float DashTime; //Length
    public float DashCooldown;

    private float DashCounter;
    private float DashCooldownCounter;

    // Start is called before the first frame update
    void Start()
    {
        CurrentSpeed = Speed;
    }

    // Update is called once per frame
    void Update()
    {
        

        //Movement Keys
        if (DashCounter <= 0)
        {
            Direction = Vector3.zero;
            if (Input.GetKey(KeyCode.W))
            {
                Direction += new Vector3(0f, 1f, 0f).normalized;
            }

            if (Input.GetKey(KeyCode.D))
            {
                Direction += new Vector3(1f, 0f, 0f).normalized;

            }

            if (Input.GetKey(KeyCode.A))
            {
                Direction += new Vector3(-1f, 0f, 0f).normalized;

            }

            if (Input.GetKey(KeyCode.S))
            {
                Direction += new Vector3(0f, -1f, 0f).normalized;

            }
        }

        transform.position += Direction * CurrentSpeed * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DashCooldownCounter <= 0 && DashCounter <= 0) //Si los contadores estan en 0...
            {
                CurrentSpeed = DashSpeed; //Nueva velocidad mientras dure el dash
                DashCounter = DashTime; //El contador se vuelve el tiempo del Dash
                gameObject.layer = 8;
                Debug.Log("DASHING TIME" + Time.deltaTime);
            }
        }
        if (DashCounter > 0)
        {
            DashCounter -= Time.deltaTime;

            if (DashCounter <= 0)
            {
                CurrentSpeed = Speed;
                DashCooldownCounter = DashCooldown; //Se resetean la velocidad
                gameObject.layer = 3;
            }
        }
        else
        {

        }
        if (DashCooldownCounter > 0)
        {
            DashCooldownCounter -= Time.deltaTime; //Se va restando poco a poco
        }
    }
}