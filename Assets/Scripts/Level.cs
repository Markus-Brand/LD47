using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Level : MonoBehaviour
{
    private GameObject _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.HasComponent(out Player player))
        {
            _camera.transform.position = GetComponent<Collider2D>().bounds.center + Vector3.back * 10;
        };
    }
}
