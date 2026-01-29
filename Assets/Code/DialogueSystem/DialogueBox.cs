using UnityEngine;

public class DialogueBox : MonoBehaviour
{
    [SerializeField] private ConversationManager _conversationManager;
    
    [SerializeField] private Sprite _characterSprite;
    public Sprite CharacterSprite => _characterSprite;
    
    [SerializeField] private string _characterName;
    public string CharacterName => _characterName;
    
    [SerializeField] private string _dialogueLine;
    public string DialogueLine => _dialogueLine;

    public void UpdateUI(ConversationManager conversationManager)
    {
        _characterSprite = _conversationManager.CurrentDialogue.CharacterProfile.Sprite;
        _characterName = _conversationManager.CurrentDialogue.CharacterProfile.Name;
        _dialogueLine = _conversationManager.CurrentDialogue.Line;
    }
}