using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockadeComposite : Rewindable
{
    public bool Lowered;
    public Color color;

    private Blockade[] _blockades;
    
    

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _blockades = GetComponentsInChildren<Blockade>();
        SetSprites();
        SetColors();
    }

    private void SetColors()
    {
        foreach (var blockade in _blockades)
        {
            blockade.SetColor(color);
        }
    }

    private void SetSprites()
    {
        foreach (var blockade in _blockades)
        {
            blockade.SetSprite(Lowered);
        }
    }

    public override void loadFrom(object lowered)
    {
        Lowered = (bool) lowered;
        SetSprites();
        SetColors();
    }

    public override object save()
    {
        return Lowered;
    }

    public override void LeverOn()
    {
        Lowered = true;
        SetSprites();
    }

    public override void LeverOff()
    {
        Lowered = false;
        SetSprites();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
