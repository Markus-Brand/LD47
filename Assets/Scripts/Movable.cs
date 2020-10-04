using System;
using UnityEngine;

public class SerializedMoveable
{
    public Vector2Int position;

    public SerializedMoveable(Vector2Int position)
    {
        this.position = position;
    }
}

public class Movable : Rewindable
{
    public override void loadFrom(object lowered)
    {
        if (lowered is SerializedMoveable deserialized)
        {
            transform.position = new Vector3(deserialized.position.x, deserialized.position.y);
        }
    }

    private Vector2Int GetPosition()
    {
        return new Vector2Int((int) Math.Round(transform.position.x), (int) Math.Round(transform.position.y));
    }
    
    public override object save()
    {
        return new SerializedMoveable(GetPosition());
    }
    
    private bool CanMoveTo(Vector2Int target)
    {
        var results = Physics2D.OverlapBoxAll(target, new Vector2(0.95f, 0.95f), 0.0f);
        return results.Length == 0;
    }
    
    private void MoveTo(Vector2Int target)
    {
        //TODO: Animate this here
        transform.position = new Vector3(target.x, target.y);
    }

    public bool Push(Vector2Int direction)
    {
        if (!CanMoveTo(GetPosition() + direction)) return false;
        MoveTo(GetPosition() + direction);
        return true;
    }
}