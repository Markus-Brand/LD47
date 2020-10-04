using System;
using DefaultNamespace;
using UnityEngine;

public class Teleporter : Rewindable
{
    public bool active;
    public Vector2 loopingDestinationPosition;
    public Vector2 activeDestinationPosition;
    private Animator _animator;
    private static readonly int Active = Animator.StringToHash("Active");

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        _animator.SetBool(Active, active);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_rewinding) return;
        if(other.gameObject.HasComponent(out Player player))
        {
            Debug.Log("Teleport");
            player.TeleportTo(active ? activeDestinationPosition : loopingDestinationPosition);
        };
    }

    public void Activate()
    {
        active = true;
        _animator.SetBool(Active, active);
    }

    public void Deactivate()
    {
        active = false;
        _animator.SetBool(Active, active);
    }
    
    public override void loadFrom(object active)
    {
        this.active = (bool) active;
        _animator.SetBool(Active, this.active);
    }

    public override object save()
    {
        return active;
    }

    public override void LeverOn()
    {
        Activate();
    }

    public override void LeverOff()
    {
        Deactivate();
    }
}
