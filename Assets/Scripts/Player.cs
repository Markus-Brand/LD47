using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameInputs _inputs;

    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        _inputs = new GameInputs();
        _inputs.Gameplay.Jump.performed += ctx => Jump();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        _inputs.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _inputs.Gameplay.Disable();
    }

    private void Jump()
    {
        Debug.Log("Lol");
        rigidbody2D.AddForce(new Vector2(0, 100));
    }
}
