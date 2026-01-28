using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class ConversationManager : MonoBehaviour
{
    [SerializeField] private Conversation _conversation;
    public Queue<Dialogue> DialogueQueue;

    private void Start()
    {
        DialogueQueue = new Queue<Dialogue>();
        
        for (int i = 0; i < _conversation.Dialogues.Count; i++)
        {
            DialogueQueue.Enqueue(_conversation.Dialogues[i]);
            
            Debug.Log("Added [" + _conversation.Dialogues[i].SpeakerName + "] and [" + _conversation.Dialogues[i].Line + "] to queue");
        }
        
        Debug.Log("============COMPLETED POPULATING DIALOGUE QUEUE============");
    }
    
    public void NextDialogue(InputAction.CallbackContext context)
    {
        if (DialogueQueue.Count == 0)
        {
            return;
        }
        
        if (context.performed)
        {
            // Display dialogue in queue
            Debug.Log(string.Format("NAME: {0}", DialogueQueue.Peek().SpeakerName));
            Debug.Log(string.Format("LINE: {0}", DialogueQueue.Peek().Line));
            
            // Remove dialogue from queue
            DialogueQueue.Dequeue();
        }
    }
}