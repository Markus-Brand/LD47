﻿using DefaultNamespace;
using UnityEngine;

public class Button : Rewindable
{
    public bool pressed;
    public AudioSource sound;

    public SpriteRenderer NumberRenderer;
    public int Number;
    public Sprite[] NumberSprites;
    public Sprite ButtonPressedSprite;
    private Sprite ButtonOpenSprite;

    private SpriteRenderer buttonTop;

    public Rewindable[] Affected;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        NumberRenderer.sprite = NumberSprites[Number - 1];
        buttonTop = GetComponent<SpriteRenderer>();
        ButtonOpenSprite = buttonTop.sprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_rewinding || pressed) return;
        if(other.gameObject.HasComponent(out Player player))
        {
            pressed = true;
            foreach (var t in Affected)
            {
                t.LeverOn();
            }

            buttonTop.sprite = ButtonPressedSprite;
            sound.Play();
        };
    }


    public override void loadFrom(object lowered)
    {
        var newState = (bool) lowered;
        pressed = newState;
        buttonTop.sprite = pressed ? ButtonPressedSprite : ButtonOpenSprite;
    }

    public override object save()
    {
        return pressed;
    }
}
