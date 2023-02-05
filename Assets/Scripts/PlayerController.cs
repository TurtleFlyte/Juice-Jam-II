using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Vector2 input;

    public float accel;
    public float turnSpeed;
    public float maxSpeed;

    Rigidbody2D rb;
    public GameManager gm;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        // If up pressed
        if (input.normalized.y > 0)
        {
            // Add force
            rb.AddRelativeForce(Vector2.up * accel);

            // If we are going too fast, cap speed
            if (rb.velocity.magnitude > maxSpeed)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed*Time.deltaTime;
            }
        }

        // If down pressed
        if (input.normalized.y < 0)
        {
            // Add force
            rb.AddRelativeForce(Vector2.down * accel);

            // If we are going too fast, cap speed
            if (rb.velocity.magnitude > maxSpeed/2)
            {
                rb.velocity = rb.velocity.normalized * maxSpeed/2 * Time.deltaTime;
            }
        }

        // If right/left pressed add torque to turn
        if (input.normalized.x > 0 || input.normalized.x < 0)
        {
            // Scale the amount you can turn based on current velocity so slower turning below max speed
            float scale = Mathf.Lerp(0f, turnSpeed, rb.velocity.magnitude / maxSpeed * Time.deltaTime);
            // Axis is opposite what we want by default
            rb.AddTorque(-input.normalized.x * scale);
        }

        // Clamps the players position to inside set bounds of the game world
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -gm.xBounds, gm.xBounds), Mathf.Clamp(transform.position.y, -gm.yBounds, gm.yBounds), transform.position.z);
    }

    // Move function that gets called by Unity's input system
    public void Move(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    public float angVelocity
    {
        get { return rb.angularVelocity; }
    }

    public float Velocity
    {
        get { return rb.velocity.magnitude; }
    }
}
