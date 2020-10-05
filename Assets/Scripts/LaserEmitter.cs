using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;

public class LaserEmitter : Rewindable
{

    public Laser LaserPrefab;
    
    private Vector2Int _laserDirection;
    private string laserDirections;

    private List<Laser> _laserChildren;

    private static Vector2Int MainDirection(float eulerAnglesZ)
    {
        while (eulerAnglesZ < 0)
        {
            eulerAnglesZ += 360;
        }

        int direction = (int) (Math.Round(eulerAnglesZ / 90)) % 4;

        switch (direction)
        {
            case 0:
                return Vector2Int.right;
            case 1:
                return Vector2Int.up;
            case 2:
                return Vector2Int.left;
            case 3:
                return Vector2Int.down;
            default:
                return Vector2Int.zero;
        }
    }
    private static char DirectionToCharacter(Vector2Int direction)
    {
        if (direction.x == 1) return 'e';
        if (direction.y == 1) return 'n';
        if (direction.x == -1) return 'w';
        if (direction.y == -1) return 's';
        return ' ';
    }

    protected override void Start()
    {
        base.Start();
        _laserDirection = MainDirection(transform.rotation.eulerAngles.z);
        ShootLaser();
    }

    public void ShootLaser()
    {
        string laserString = "";

        
        var currentPosition = new Vector2Int((int) Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
        var direction = _laserDirection;
        while (isPositionFree(currentPosition))
        {
            currentPosition += direction;
            laserString += DirectionToCharacter(direction);
        }
        
        RebuildWithDirections(laserString);
    }

    private bool isPositionFree(Vector2Int position)
    {
        var results = Physics2D.OverlapBoxAll(position, new Vector2(0.95f, 0.95f), 0.0f);
        return results.Count(r => !r.isTrigger) == 0;
    }

    public override void loadFrom(object laserDirections)
    {
        RebuildWithDirections((string) laserDirections);
    }

    private void RebuildWithDirections(string laserDirections)
    {
        if (this.laserDirections == laserDirections)
        {
            return;
        }
        this.laserDirections = laserDirections;
        if (_laserChildren != null)
        {
            foreach (var laserChild in _laserChildren)
            {
                Destroy(laserChild.gameObject);
            }
        }
        _laserChildren = new List<Laser>();
        if(laserDirections.Length == 0) return;
        var currentPosition = new Vector2Int((int) Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
        var previousCharacter = laserDirections[0];
        var previousDirection = charToDirection(previousCharacter);
        foreach (var character in laserDirections)
        {
            var direction = charToDirection(character);

            if (previousCharacter == character)
            {
                var newLaser = Instantiate(LaserPrefab, new Vector3(currentPosition.x, currentPosition.y), direction.AsZRotation(), transform);
                newLaser.Emitter = this;
                _laserChildren.Add(newLaser);
            }

            currentPosition += direction;
            
            previousDirection = direction;
            previousCharacter = character;
        }
    }

    private static Vector2Int charToDirection(char character)
    {
        switch (character)
        {
            case 'n':
                return Vector2Int.up;
            case 'e':
                return Vector2Int.right;
            case 's':
                return Vector2Int.down;
            case 'w':
                return Vector2Int.left;
        }
        return Vector2Int.zero;;
    }

    public override object save()
    {
        return laserDirections;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
