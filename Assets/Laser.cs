
using UnityEngine;

public class Laser : MonoBehaviour
{
    public LaserEmitter Emitter;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D other)
    {
        Emitter.ShootLaser();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        Emitter.ShootLaser();
    }
}
