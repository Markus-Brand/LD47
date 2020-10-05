using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using Object = UnityEngine.Object;


enum BlockStatus
{
    Blocked, Free, Mirror
}
public class LaserEmitter : Rewindable
{

    public Laser LaserPrefab;
    public Laser EdgeLaserPrefab;
    
    private Vector2Int _laserDirection;
    private string laserDirections;

    private List<Laser> _laserChildren;
    private Mirror _lastMirror;
    private LaserDetector _lastDetector;
    private bool _foundDetector;

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
        _laserDirection = transform.rotation.eulerAngles.z.MainDirection();
        ShootLaser();
    }

    public void ShootLaser()
    {
        string laserString = "";

        
        var currentPosition = new Vector2Int((int) Math.Round(transform.position.x), (int)Math.Round(transform.position.y));
        var direction = _laserDirection;
        var blockStatus = statusAtPosition(currentPosition);
        _foundDetector = false;
        while (blockStatus != BlockStatus.Blocked)
        {
            if (blockStatus == BlockStatus.Free)
            {
                currentPosition += direction;
                laserString += DirectionToCharacter(direction);
            } else if (blockStatus == BlockStatus.Mirror)
            {
                if (direction.Equals(_lastMirror.mainInDirection))
                {
                    direction = direction.Rotate90Clockwise();
                } else if (direction.Equals(_lastMirror.mainInDirection.Rotate90CounterClockwise()))
                {
                    direction = direction.Rotate90CounterClockwise();
                }
                else
                {
                    break;
                }
                currentPosition += direction;
                laserString += DirectionToCharacter(direction);
            }
            blockStatus = statusAtPosition(currentPosition);
        }

        if (!_foundDetector)
        {
            if (_lastDetector != null)
            {
                _lastDetector.Depower();
                _lastDetector = null;
            }
        }
        
        RebuildWithDirections(laserString);
    }

    private BlockStatus statusAtPosition(Vector2Int position)
    {
        var results = Physics2D.OverlapBoxAll(position, new Vector2(0.95f, 0.95f), 0.0f);
        var blocked = false;
        foreach (var result in results)
        {
            if (result.gameObject.HasComponent(out Mirror mirror))
            {
                _lastMirror = mirror;
                return BlockStatus.Mirror;
            }
            if (result.gameObject.HasComponent(out LaserDetector detector))
            {
                _foundDetector = true;
                if (detector != _lastDetector)
                {
                    if (_lastDetector != null)
                    {
                        _lastDetector.Depower();
                    }

                    _lastDetector = detector;
                    detector.Power();
                }
                return BlockStatus.Free;
            }

            if (!result.isTrigger && result.gameObject != gameObject)
            {
                blocked = true;
            }
        }

        return blocked ? BlockStatus.Blocked : BlockStatus.Free;
    }

    public override void loadFrom(object laserDirections)
    {
        //RebuildWithDirections((string) laserDirections);
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
            Laser newLaser;
            if (previousCharacter == character)
            {
                newLaser = Instantiate(LaserPrefab, new Vector3(currentPosition.x, currentPosition.y), direction.AsZRotation(), transform);
                newLaser.Emitter = this;
                _laserChildren.Add(newLaser);
            }
            else
            {
                newLaser = Instantiate(EdgeLaserPrefab, new Vector3(currentPosition.x, currentPosition.y), direction.AsZRotation(), transform);
                newLaser.GetComponent<SpriteRenderer>().flipY =
                    !previousDirection.Rotate90CounterClockwise().Equals(direction);
            }
            newLaser.Emitter = this;
            _laserChildren.Add(newLaser);
            
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
