using UnityEngine;

public class FloatVariableChanger : MonoBehaviour
{
    public string variableName;
    public float amount;

    public void ChangeVariableForTarget(GameObject target)
    {
        target
            .GetComponent<BlackBoard>()?
            .GetValueByName<FloatVariable>(variableName)?
            .AddValue(amount);
    }

    public void ChangeVariableSelf()
    {
        GetComponent<BlackBoard>()?
        .GetValueByName<FloatVariable>(variableName)?
        .AddValue(amount);
    }
}
