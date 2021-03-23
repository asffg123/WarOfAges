using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    // Unit direction for movement
    public Vector2 FacingDirection;

    // Unit speed
    public float MovementSpeed;

    // Adding Rigidbody
    public Rigidbody2D Rbody;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Unit is allowed to move in a direction
        Rbody.velocity = FacingDirection * MovementSpeed;
    }
}
