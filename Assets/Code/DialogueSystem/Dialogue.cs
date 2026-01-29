using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private CharacterProfile _characterProfile;
    public CharacterProfile CharacterProfile => _characterProfile;
    
    [SerializeField] private string _line;
    public string Line => _line;
}