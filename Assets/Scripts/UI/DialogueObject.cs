using UnityEngine;

[CreateAssetMenu(menuName="Data/Dialogue/Dialogue_Object")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;

    public string[] Dialogue => dialogue;
}
