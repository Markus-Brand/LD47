using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Lever : Rewindable
{
    private bool on;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.HasComponent(out Player player))
        {
            
        };
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
