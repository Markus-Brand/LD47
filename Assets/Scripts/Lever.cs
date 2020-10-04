using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Lever : Rewindable
{
    public bool on;
    public AudioSource sound;

    public SpriteRenderer Knob;
    public SpriteRenderer ColorDisplay;
    public Color color;
    
    private Animator _animator;
    private static readonly int On = Animator.StringToHash("On");

    public Rewindable[] Toggled;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        _animator.SetBool(On, on);
        Knob.color = color;
        ColorDisplay.color = color;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_rewinding) return;
        if(other.gameObject.HasComponent(out Player player))
        {
            on = !on;
            foreach (var t in Toggled)
            {
                if (on)
                {
                    t.LeverOn();
                }
                else
                {
                    t.LeverOff();
                }
            }
            sound.Play();
            _animator.SetBool(On, on);
        };
    }


    public override void loadFrom(object lowered)
    {
        var newState = (bool) lowered;
        if (newState != on) sound.Play();
        on = newState;
        _animator.SetBool(On, on);
    }

    public override object save()
    {
        return on;
    }
}
