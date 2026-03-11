using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "VibeProject/CharacterData")]
public class CharacterData : ScriptableObject
{

    public string characterName;
    public float maxHealth;
    public float maxMana;
    public float speed;
}
