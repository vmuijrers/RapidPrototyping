using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackBoard : MonoBehaviour
{
    [SerializeReference][SerializeField] private List<BaseDataClass> data = new List<BaseDataClass>();
    private Dictionary<string, ScriptableObject> blackBoard = new Dictionary<string, ScriptableObject>();

    private void Awake()
    {
        blackBoard = new Dictionary<string, ScriptableObject>();
        foreach (BaseDataClass d in data)
        {
            var result = d.ConvertDummyToVariable();
            blackBoard.Add(d.variableName, result);
        }
    }

    public T GetValueByName<T>(string name) where T : ScriptableObject
    {
        if (blackBoard.ContainsKey(name))
        {
            return blackBoard[name] as T;
        }
        Debug.LogWarning($"Variable {name} was not found in the blackboard dictionary!");
        return null;
    }

    [ContextMenu("AddFloatVariable")]
    public void AddFloatValue()
    {
        data.Add(new FloatDataDummy());
    }

    [ContextMenu("AddGameObjectVariable")]
    public void AddGameObjectValue()
    {
        data.Add(new GameObjectDataDummy());
    }

}

[System.Serializable]
public abstract class BaseDataClass
{
    public string variableName;

    public abstract ScriptableObject ConvertDummyToVariable();
}

[System.Serializable]
public class FloatDataDummy : BaseDataClass
{
    public float value;
    public UnityEngine.Events.UnityEvent<float> OnValueChanged;

    public override ScriptableObject ConvertDummyToVariable()
    {
        FloatVariable fVariable = ScriptableObject.CreateInstance<FloatVariable>();
        fVariable.Value = value;
        fVariable.OnValueChanged = OnValueChanged;
        fVariable.OnValueChanged.AddListener((x) => value = x);
        return fVariable;
    }
}

[System.Serializable]
public class GameObjectDataDummy : BaseDataClass
{
    public GameObject value;
    public UnityEngine.Events.UnityEvent<GameObject> OnValueChanged;

    public override ScriptableObject ConvertDummyToVariable()
    {
        GameObjectVariable fVariable = ScriptableObject.CreateInstance<GameObjectVariable>();
        fVariable.Value = value;
        fVariable.OnValueChanged = OnValueChanged;
        fVariable.OnValueChanged.AddListener((x) => value = x);
        return fVariable;
    }
}
