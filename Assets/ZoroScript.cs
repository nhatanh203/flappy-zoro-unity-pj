using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoroScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public float rotationSpeed = 360f; // Rotation speed in degrees per second
    private bool isAcrobatic = false;
    private bool isClockwise = false;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            isAcrobatic = true;
            isClockwise = !isClockwise;
        }

        if (isAcrobatic)
        {
            float rotationAmount = rotationSpeed * Time.deltaTime;
            float rotationDirection = isClockwise ? 1f : -1f;
            transform.Rotate(Vector3.forward, rotationDirection * rotationAmount);
            if (Mathf.Abs(transform.rotation.eulerAngles.z) >= 360f)
            {
                isAcrobatic = false;
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
