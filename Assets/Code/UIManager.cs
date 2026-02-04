using System.Collections.Generic;
using TMPro;
using UnityEngine;
using LaurenLizardo.ToTheMasquerade.DialogueSystem;

namespace LaurenLizardo.ToTheMasquerade
{
    public class UIManager : MonoBehaviour
    {
        private Conversation _conversationToLoad;
        private Queue<Dialogue> _conversationToPlay = new Queue<Dialogue>();
        
        public GameObject DialogueBox;
        
        public TMP_Text DirectionsTmp;
        public TMP_Text NameTmp;
        public TMP_Text LineTmp;
        
        public GameObject NextButton;
        public GameObject LeftChoiceButton;
        public GameObject RightChoiceButton;
        public GameObject CloseButton;
    
        private void Start()
        {
            ShowDialogueBox(false);
            ShowNextButton(false);
            ShowChoiceButtons(false);
            ShowCloseButton(false);
        }
        
        public void InitializeCurrentConversation(Conversation conversation)
        {
            for (int i = 0; i < conversation.Dialogues.Count; i++)
            {
                _conversationToPlay.Enqueue(conversation.Dialogues[i]);
            }
        }
        
        public void LoadNextDialogue()  // Link to NextButton
        {
            Dialogue currentDialogue = _conversationToPlay.Peek();
    
            NameTmp.text = currentDialogue.Name;
            LineTmp.text = currentDialogue.Line;
    
            if (currentDialogue.VoidEventChannels != null)
            {
                for (int i = 0; i < currentDialogue.VoidEventChannels.Count; i++)
                {
                    currentDialogue.VoidEventChannels[i].Raise();
                }
            }
    
            _conversationToPlay.Dequeue();
            
            if (_conversationToPlay.Count != 0)
                ShowNextButton(true);
        }
    
        public void EndConversation()
        {
            _conversationToPlay.Clear();
            ShowDialogueBox(false);
            ShowNextButton(false);
            ShowChoiceButtons(false);
            ShowCloseButton(false);
        }
    
        public void ShowDirections(bool show)
        {
            DirectionsTmp.gameObject.SetActive(show);
        }
    
        public void ShowDialogueBox(bool show)
        {
            DialogueBox.SetActive(show);
        }
    
        public void ShowNextButton(bool show)
        {
            NextButton.SetActive(show);
        }
    
        public void ShowChoiceButtons(bool show)
        {
            LeftChoiceButton.SetActive(show);
            RightChoiceButton.SetActive(show);
        }
    
        public void ShowCloseButton(bool show)
        {
            CloseButton.SetActive(show);
        }
    }
}
