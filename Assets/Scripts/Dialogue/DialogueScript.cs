using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Script", menuName = "Dialogue/Dialogue Script", order = 1)]
public class DialogueScript : ScriptableObject
{
    [SerializeField] private string[] lines;
    public string[] getLines { get { return lines; } }
}