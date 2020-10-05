﻿using System;
using System.Collections;
using DefaultNamespace;
using UnityEngine;


public class SerializedPlayer
{
    public float x;
    public float y;

    public float rotation;

    public SerializedPlayer(float x, float y, float rotation)
    {
        this.x = x;
        this.y = y;
        this.rotation = rotation;
    }
}
public class Player : Rewindable
{
    public GameObject RewindScreen;
    private GameInputs _inputs;

    private Rigidbody2D rigidbody2D;
    private Coroutine rewinding;

    private Vector2Int moveDirection;
    
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        rigidbody2D = GetComponent<Rigidbody2D>();
        _inputs = new GameInputs();
        _inputs.Gameplay.Rewind.started += ctx => rewinding = StartCoroutine(nameof(repeatedlyRewind));
        _inputs.Gameplay.Rewind.canceled += ctx =>
        {
            HideRewindScreen();
            StopCoroutine(rewinding);
        };
        _inputs.Gameplay.North.started += ctx => moveDirection += Vector2Int.up;
        _inputs.Gameplay.North.canceled += ctx => moveDirection -= Vector2Int.up;
        _inputs.Gameplay.East.started += ctx => moveDirection += Vector2Int.right;
        _inputs.Gameplay.East.canceled += ctx => moveDirection -= Vector2Int.right;
        _inputs.Gameplay.South.started += ctx => moveDirection += Vector2Int.down;
        _inputs.Gameplay.South.canceled += ctx => moveDirection -= Vector2Int.down;
        _inputs.Gameplay.West.started += ctx => moveDirection += Vector2Int.left;
        _inputs.Gameplay.West.canceled += ctx => moveDirection -= Vector2Int.left;
    }

    private void HideRewindScreen()
    {
        RewindScreen.SetActive(false);
    }

    public override object save()
    {
        return new SerializedPlayer(transform.position.x, transform.position.y, transform.rotation.eulerAngles.z);
    }

    public override void loadFrom(object lowered)
    {
        if (lowered is SerializedPlayer deserialized)
        {
            transform.position = new Vector2(deserialized.x, deserialized.y);
            transform.rotation = Quaternion.Euler(0, 0, deserialized.rotation);
        }
    }

    private float timeToNextMove = 0;
    // Update is called once per frame
    void Update()
    {
        timeToNextMove -= Time.deltaTime;
        if (moveDirection.sqrMagnitude != 0)
        {
            var actualMoveDirection =
                moveDirection.sqrMagnitude > 1 ? new Vector2Int(moveDirection.x, 0) : moveDirection;
            if (timeToNextMove < 0)
            {
                MoveBy(actualMoveDirection);
                timeToNextMove = 0.2f;
            }
        }
        else
        {
            timeToNextMove = 0;
        }
    }

    private void OnEnable()
    {
        _inputs.Gameplay.Enable();
    }

    private void OnDisable()
    {
        _inputs.Gameplay.Disable();
    }

    private void Rewind()
    {
        RewindManager.Rewind();
    }

    private IEnumerator repeatedlyRewind()
    {
        RewindScreen.SetActive(true);

        RewindManager.Rewind();
        float x = 1;
        while (true)
        {
            float waitTime = (float) (0.5 / Math.Sqrt(4 * x));
            yield return new WaitForSeconds(waitTime);
            x += waitTime;
            RewindManager.Rewind();
        }
    }

    private Vector2Int GetPosition()
    {
        return new Vector2Int((int) Math.Round(transform.position.x), (int) Math.Round(transform.position.y));
    }

    private bool CanMoveTo(Vector2Int target, Vector2Int direction)
    {
        var results = Physics2D.OverlapBoxAll(target, new Vector2(0.95f, 0.95f), 0.0f);
        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].gameObject.layer == LayerMask.NameToLayer("Obstacle")) return false;
            if (results[i].gameObject.HasComponent(out Movable movable))
            {
                if (!movable.Push(direction)) return false;
            }
        }
        return true;
    }

    private void MoveTo(Vector2Int target)
    {
        //TODO: Animate this here
        transform.position = new Vector3(target.x, target.y, 0);
        Invoke(nameof(Save), 0.1f);
    }

    private void Save()
    {
        RewindManager.SaveCurrentState();
    }


    private void MoveBy(Vector2Int delta)
    {
        if (CanMoveTo(GetPosition() + delta, delta))
        {
            MoveTo(GetPosition() + delta);
        }

        transform.rotation = delta.AsZRotation(-90);
    }

    public void AddKey()
    {
    }

    public void TeleportTo(Vector2 destinationPosition)
    {
        transform.position = new Vector3(destinationPosition.x, destinationPosition.y, 0);
        Invoke(nameof(Save), 0.1f);
    }
}
