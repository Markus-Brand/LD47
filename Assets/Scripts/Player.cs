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
        _inputs.Gameplay.North.performed += ctx => MoveBy(Vector2Int.up);
        _inputs.Gameplay.East.performed += ctx => MoveBy(Vector2Int.right);
        _inputs.Gameplay.South.performed += ctx => MoveBy(Vector2Int.down);
        _inputs.Gameplay.West.performed += ctx => MoveBy(Vector2Int.left);
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

    private Vector2Int GetPosition()
    {
        return new Vector2Int((int) Math.Round(transform.position.x), (int) Math.Round(transform.position.y));
    }

    private bool CanMoveTo(Vector2Int target)
    {
        var results = Physics2D.OverlapBoxAll(target, new Vector2(0.95f, 0.95f), 0.0f);
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].gameObject.layer == LayerMask.NameToLayer("Obstacle")) return false;
        }
        return true;
    }

    private void MoveTo(Vector2Int target)
    {
        //TODO: Animate this here
        transform.position = new Vector3(target.x, target.y, transform.position.z);
    }

    private void MoveBy(Vector2Int delta)
    {
        if (CanMoveTo(GetPosition() + delta))
        {
            MoveTo(GetPosition() + delta);
        }
    }
}
