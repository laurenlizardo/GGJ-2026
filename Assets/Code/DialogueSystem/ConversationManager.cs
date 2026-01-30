using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private Conversation _conversation;
    public Queue<Dialogue> DialogueQueue;
    
    private Conversation _currentConversation;
    public Conversation CurrentConversation => _currentConversation;

    private Dialogue _currentDialogue;
    public Dialogue CurrentDialogue => _currentDialogue;
    
    public GameObject DialogueBox;
    public Button NextButton;
    public Button ExitButton;
    
    public void NextDialogue(InputAction.CallbackContext context)   // Connect to NextButton
    {
        if (DialogueQueue.Count == 0)
        {
            NextButton.gameObject.SetActive(false);
            ExitButton.gameObject.SetActive(true);
            return;
        }
        
        if (context.performed)
        {
            // Display dialogue in queue
            _currentDialogue = DialogueQueue.Peek();
            Debug.Log(string.Format("NAME: {0}", _currentDialogue.CharacterProfile.Name));
            Debug.Log(string.Format("LINE: {0}", _currentDialogue.Line));
            
            // Remove dialogue from queue
            DialogueQueue.Dequeue();
        }
    }

    public void Begin()
    {
        InitializeConversation();
        
        DialogueBox.SetActive(true);
        NextButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(false);
    }

    public void End()
    {
        DialogueBox.SetActive(false);
    }

    private void InitializeConversation()
    {
        DialogueQueue = new Queue<Dialogue>();
        
        for (int i = 0; i < _conversation.Dialogues.Count; i++)
        {
            DialogueQueue.Enqueue(_conversation.Dialogues[i]);
            
            Debug.Log("Added [" + _conversation.Dialogues[i].CharacterProfile.Name + "] and [" + _conversation.Dialogues[i].Line + "] to queue");
        }
        
        Debug.Log("============COMPLETED POPULATING DIALOGUE QUEUE============");
    }

    // Use this to get the Conversation attached to the NPC
    public void SetCurrentConversation(Conversation conversation)
    {
        _currentConversation = conversation;
    }
}