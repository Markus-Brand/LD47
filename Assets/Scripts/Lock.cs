using System;
using UnityEngine;

public class SerializedLock
{
    public Vector2Int position;
    public string keyId;

    public SerializedLock(Vector2Int position, string keyId)
    {
        this.position = position;
        this.keyId = keyId;
    }
}
public class Lock : Rewindable
{

    public Key key;

    private string keyId = null;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(AcquireID), Time.fixedDeltaTime);
    }

    private void AcquireID()
    {
        if (keyId == null) keyId = key.getId();
    }

    public override void loadFrom(object lowered)
    {
        if (lowered is SerializedLock deserialized)
        {
            transform.position = new Vector3(deserialized.position.x, deserialized.position.y);
            keyId = deserialized.keyId;
        }
    }

    public override object save()
    {
        return new SerializedLock(GetPosition(), keyId);
    }
    
    private Vector2Int GetPosition()
    {
        var position = transform.position;
        return new Vector2Int((int) Math.Round(position.x), (int) Math.Round(position.y));
    }

    public string GetKeyId()
    {
        return keyId;
    }

    public void OpenSesame()
    {
        Destroy(gameObject);
    }
}