using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    public float Speed, RotationSpeed, StrenghtJump;
    private Animator anim;
    private bool CanJump = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float MovSpeed = Time.deltaTime * Speed;
        float RotSpeed = Time.deltaTime * RotationSpeed;
        float JumpSpeed = Time.deltaTime * StrenghtJump;

        Rigidbody r = GetComponent<Rigidbody>();
        anim.SetBool("IsRunning", false);


        if (r)
        {
            if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(new Vector3(0, RotSpeed, 0));
            }
            if (Input.GetKey(KeyCode.Q))
            {
                transform.Rotate(new Vector3(0, -RotSpeed, 0));
            }
            if (Input.GetKey(KeyCode.Z))
            {
                r.AddForce(transform.forward * MovSpeed);
                anim.SetBool("IsRunning", true);
            }
            if (Input.GetKey(KeyCode.S))
            {
                r.AddForce(-transform.forward * MovSpeed);
            }
            if (Input.GetKey(KeyCode.Space))
            {
                Debug.Log(CanJump);
                if (CanJump)
                    r.AddForce(new Vector3(0, JumpSpeed, 0));
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            CanJump = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain")
        {
            CanJump = false;
        }
    }

}
