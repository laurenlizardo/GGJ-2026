using UnityEngine;
using System.Collections.Generic;

namespace LaurenLizardo.ToTheMasquerade.DialogueSystem
{
    [CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogue System/Conversation")]
    public class Conversation : ScriptableObject
    {
        [SerializeField] private List<Dialogue> _dialogues = new List<Dialogue>();
        public List<Dialogue> Dialogues => _dialogues;
    }
}