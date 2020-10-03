using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;


public class SerializedPlayer
{
    public float x;
    public float y;

    public SerializedPlayer(float x, float y)
    {
        this.x = x;
        this.y = y;
    }
}
public class Player : Rewindable
{
    private GameInputs _inputs;

    private Rigidbody2D rigidbody2D;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        rigidbody2D = GetComponent<Rigidbody2D>();
        _inputs = new GameInputs();
        _inputs.Gameplay.Rewind.performed += ctx => Rewind();
        _inputs.Gameplay.North.performed += ctx => MoveBy(Vector2Int.up);
        _inputs.Gameplay.East.performed += ctx => MoveBy(Vector2Int.right);
        _inputs.Gameplay.South.performed += ctx => MoveBy(Vector2Int.down);
        _inputs.Gameplay.West.performed += ctx => MoveBy(Vector2Int.left);
    }

    public override object save()
    {
        return new SerializedPlayer(rigidbody2D.position.x, rigidbody2D.position.y);
    }

    public override void loadFrom(object save)
    {
        if (save is SerializedPlayer deserialized)
        {
            rigidbody2D.position = new Vector2(deserialized.x, deserialized.y);
        }
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

    private void Rewind()
    {
        RewindManager.Rewind();
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
        rigidbody2D.position = new Vector3(target.x, target.y, transform.position.z);
        Invoke(nameof(Save), 0.1f);
    }

    private void Save()
    {
        RewindManager.SaveCurrentState();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Items"))
        {
            Object.Destroy(other.gameObject);
        }
    }

    private void MoveBy(Vector2Int delta)
    {
        if (CanMoveTo(GetPosition() + delta))
        {
            MoveTo(GetPosition() + delta);
        }
    }

    public void AddKey()
    {
    }
}
