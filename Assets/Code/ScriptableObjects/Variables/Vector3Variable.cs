using UnityEngine;

[CreateAssetMenu(fileName = "New Vector3 ScriptableObject", menuName = "ScriptableObjects/Vector3 ScriptableObject", order = 1)]
public class Vector3Variable : ScriptableObject
{
    public Vector3 Value
    {
        get;
        private set;
    }

    public void SetValue(Vector3 value)
    {
        Value = value;
    }
}