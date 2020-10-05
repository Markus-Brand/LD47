using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    private SpriteRenderer _renderer;
    private GameInputs _inputs;
    private bool _started;

    private float timeShowing;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<SpriteRenderer>();
        _renderer.enabled = false;
        _inputs = new GameInputs();
    }

    public void StartEscaping()
    {
        if (_started)
        {
            Application.Quit();
        }
        _started = true;
        timeShowing = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _renderer.enabled = _started;
        timeShowing += Time.deltaTime;
        if (timeShowing > 3)
        {
            _started = false;
            timeShowing = 0;
        }
    }
}
