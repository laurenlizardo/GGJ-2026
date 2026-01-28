using UnityEngine;

[CreateAssetMenu(fileName = "New Character Profile", menuName = "Character Profile")]
public class CharacterProfile : ScriptableObject
{
    [SerializeField] private string _name;
    public string Name => _name;

    [SerializeField] private Sprite _sprite;
    public Sprite Sprite => _sprite;
}