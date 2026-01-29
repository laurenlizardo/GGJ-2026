using UnityEngine;

[CreateAssetMenu(fileName = "New Vector3 ScriptableObject", menuName = "ScriptableObjects/Vector3 ScriptableObject", order = 1)]
public class Vector3SO : ScriptableObject
{
    [SerializeField] private Vector3 _value;

    public Vector3 Value
    {
        get { return _value; }
        set { _value = value;}
    }
}