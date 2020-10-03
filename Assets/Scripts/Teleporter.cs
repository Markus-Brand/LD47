using System;
using DefaultNamespace;
using UnityEngine;

public class Teleporter : Rewindable
{
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.HasComponent(out Player player))
        {
            Teleport();
        };
    }

    private void Teleport()
    {
        throw new NotImplementedException();
    }

    public override void loadFrom(object pairValue)
    {
        throw new System.NotImplementedException();
    }

    public override object save()
    {
        throw new System.NotImplementedException();
    }
}
