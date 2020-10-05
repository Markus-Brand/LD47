using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class LaserDetector : MonoBehaviour
{

    public Rewindable[] Affected;

    [HideInInspector] public Vector2Int DetectionDirection;

    // Start is called before the first frame update
    void Start()
    {
        DetectionDirection = transform.rotation.eulerAngles.z.MainDirection();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Power()
    {
        foreach (var affected in Affected)
        {
            affected.LeverOn();
        }
    }

    public void Depower()
    {
        foreach (var affected in Affected)
        {
            affected.LeverOff();
        }
    }
}
