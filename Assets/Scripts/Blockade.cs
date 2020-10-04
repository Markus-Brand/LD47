using UnityEngine;

public class Blockade : Rewindable
{
    public Sprite LowSprite;
    public Sprite HighSprite;
    public bool InvertedFromComposite;
    
    private SpriteRenderer _renderer;
    private Collider2D _collider;

    public void SetSprite(bool lowered)
    {
        bool state = lowered ^ InvertedFromComposite;
        if (!_renderer)
        {
            _renderer = GetComponent<SpriteRenderer>();
            _collider = GetComponent<Collider2D>();
        }
        _renderer.sprite = state ? LowSprite : HighSprite;
        _collider.enabled = !state;
    }

    public void SetColor(Color color)
    {
        _renderer.color = color;
    }

    public override void loadFrom(object lowered)
    {
    }

    public override object save()
    {
        return null;
    }
}
