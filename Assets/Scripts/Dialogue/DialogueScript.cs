using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue Script", menuName = "Dialogue/Dialogue Script", order = 1)]
public class DialogueScript : ScriptableObject
{
    [SerializeField] private string[] lines;
    [SerializeField] private string questRewardLine;

    public string[] getLines { get { return lines; } }
    public string getQuestRewardLine { get { return questRewardLine; } }
}