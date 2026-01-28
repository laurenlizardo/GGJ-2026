using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Dialogue")]
public class Dialogue : ScriptableObject
{
    [SerializeField] private string _speakerName;
    [SerializeField] private string _line;

    public string SpeakerName => _speakerName;
    public string Line => _line;
}