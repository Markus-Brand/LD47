using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
	public GameObject followed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var destinationPosition = followed.transform.position + Vector3.back * 20;
        transform.position += (destinationPosition - transform.position) * Time.deltaTime * 5;
    }
}
