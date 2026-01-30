using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private CharacterProfile _characterProfile;
    public CharacterProfile CharacterProfile => _characterProfile;
    
    [SerializeField] private Conversation _conversation;
    public Conversation Conversation => _conversation;
}