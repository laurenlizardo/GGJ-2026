using System;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using TMPro;
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
    public TMP_Text CharacterNameText;
    public TMP_Text DialogueLine;
    public Button NextButton;
    public Button ExitButton;

    public static Conversation Current;

    private void Awake()
    {
        DialogueBox.SetActive(false);
    }

    public static void SetCurrentConversation(Conversation conversation)
    {
        Current = conversation;
    }
    
    // Connect this to NextButton
    public void NextDialogue()   
    {
        
        
        // Display dialogue in queue
        _currentDialogue = DialogueQueue.Peek();
        
        Debug.Log(string.Format("NAME: {0}", _currentDialogue.CharacterProfile.Name));
        Debug.Log(string.Format("LINE: {0}", _currentDialogue.Line));
        
        CharacterNameText.text = _currentDialogue.CharacterProfile.Name;
        DialogueLine.text = _currentDialogue.Line;
            
        // Remove dialogue from queue
        DialogueQueue.Dequeue();
        
        if (DialogueQueue.Count == 0)
        {
            NextButton.gameObject.SetActive(false);
            ExitButton.gameObject.SetActive(true);
        }
    }

    // Invoke this when the NPC is clicked on
    public void Begin()
    {
        InitializeConversation();
        
        DialogueBox.SetActive(true);
        NextButton.gameObject.SetActive(true);
        ExitButton.gameObject.SetActive(false);
        
        CharacterNameText.text = "";
        DialogueLine.text = "";
        
        NextDialogue();
    }

    // Connect this to ExitButton
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
}