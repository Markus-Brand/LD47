using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class Mirror : MonoBehaviour
{
    public Vector2Int mainInDirection;

    // Start is called before the first frame update
    void Start()
    {
        mainInDirection = transform.rotation.eulerAngles.z.MainDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
