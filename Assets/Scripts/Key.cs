using DefaultNamespace;
using UnityEngine;

public class Key : Rewindable
{
    public override void loadFrom(object lowered)
    {
        transform.position = (Vector3) lowered;
    }

    public override object save()
    {
        return transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(_rewinding) return;
        if(other.gameObject.HasComponent(out Player player))
        {
            player.AddKey();
            Instantiate(prefab);
            Destroy(gameObject);
        }
    }
}
