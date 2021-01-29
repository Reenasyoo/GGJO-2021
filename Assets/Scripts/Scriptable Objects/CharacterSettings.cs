using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName = "CharacterSettings", menuName = "Character/CharacterSettings")]
public class CharacterSettings : ScriptableObject
{
    public float MovementSpeed = 10f;
    public float JumpHeight = 10f;
}
