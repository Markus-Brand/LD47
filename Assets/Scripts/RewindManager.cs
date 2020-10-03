using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

public class RewindManager : MonoBehaviour
{
    public static Dictionary<string, Rewindable> ActiveObjects = new Dictionary<string, Rewindable>();
    public static List<string> NewlyAdded = new List<string>();
    public static Dictionary<string, GameObject> NewlyRemoved = new Dictionary<string, GameObject>();
    
    private static List<State> _states = new List<State>();
    public Rewindable[] RegisterOnStartup;
    // Start is called before the first frame update
    void Start()
    {
        foreach (var rewindable in RegisterOnStartup)
        {
            Register(rewindable);
        }
        SaveCurrentState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Register(Rewindable rewindable)
    {
        if(ActiveObjects.ContainsKey(rewindable.getId())) return;
        ActiveObjects[rewindable.getId()] = rewindable;
        NewlyAdded.Add(rewindable.getId());
    }


    public static void Remove(string id, GameObject prefab)
    {
        if(!ActiveObjects.ContainsKey(id)) return;
        ActiveObjects.Remove(id);
        NewlyRemoved[id] = prefab;
    }

    public static void SaveCurrentState()
    {
        _states.Add(State.Create(ActiveObjects, NewlyAdded, NewlyRemoved));
        NewlyAdded = new List<string>();
        NewlyRemoved = new Dictionary<string, GameObject>();
    }

    public static void Rewind()
    {
        _states[_states.Count - 1].revert(ActiveObjects);
        _states.RemoveAt(_states.Count - 1);
        _states[_states.Count - 1].apply(ActiveObjects);
    }
}

public class State
{
    private readonly Dictionary<string, object> _saveState;
    private readonly IEnumerable<string> _newObjects;
    private readonly Dictionary<string, GameObject> _removedObjects;

    private State(Dictionary<string, object> state, IEnumerable<string> newObjects,
        Dictionary<string, GameObject> removedObjects)
    {
        _saveState = state;
        _newObjects = newObjects;
        _removedObjects = removedObjects;
    }

    public void apply(Dictionary<string, Rewindable> activeObjects)
    {
        foreach (var pair in _saveState)
        {
            activeObjects[pair.Key].loadFrom(pair.Value);
        }
    }

    public void revert(Dictionary<string, Rewindable> activeObjects)
    {
        foreach (var toBeRemoved in _newObjects)
        {
            var activeObject = activeObjects[toBeRemoved];
            activeObjects.Remove(toBeRemoved);
            Object.Destroy(activeObject.gameObject);
        }
        foreach (var toBeCreated in _removedObjects)
        {
            if (!activeObjects.ContainsKey(toBeCreated.Key))
            {
                var newObject = Object.Instantiate(toBeCreated.Value);
                var rewindable = newObject.GetComponent<Rewindable>();
                rewindable.setId(toBeCreated.Key);
                activeObjects[toBeCreated.Key] = rewindable;
            }
        }
    }

    public static State Create(Dictionary<string, Rewindable> activeObjects, IEnumerable<string> newObjects,
        Dictionary<string, GameObject> removedObjects)
    {
        var state = new Dictionary<string, object>();
        foreach (var activeObject in activeObjects)
        {
            var saved = activeObject.Value.save();
            state.Add(activeObject.Key, saved);
        }

        
        return new State(state, newObjects, removedObjects);
    }
}

public abstract class Rewindable : MonoBehaviour
{
    private string id = "";
    private static long count = 0;
    public string prefabName;
    private GameObject prefab;

    protected virtual void Awake()
    {
        prefab = (GameObject) Resources.Load("Prefabs/" + prefabName);
        if (id.Equals(""))
        {
            id = count.ToString();
            count++;
            RewindManager.Register(this);
        }
    }

    private void OnDestroy()
    {
        RewindManager.Remove(getId(), prefab);
    }

    public void setId(string id)
    {
        this.id = id;
    }

    public string getId()
    {
        return id;
    }

    public abstract void loadFrom(object pairValue);

    public abstract object save();
}
