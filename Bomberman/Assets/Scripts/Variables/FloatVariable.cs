using UnityEngine;

[CreateAssetMenu(fileName = "FloatVariable", menuName = "Variables/FloatVariable")]
public class FloatVariable : BaseVariable<float>
{
    public void AddValue(float addValue)
    {
        Value = Value + addValue;
    }
}
