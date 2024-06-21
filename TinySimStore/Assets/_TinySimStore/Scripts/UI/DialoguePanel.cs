using System.Collections;
using System.Collections.Generic;
using TinySimStore.DB;
using TinySimStore.Manager;
using TMPro;
using UnityEngine;

public class DialoguePanel : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private SODialogues dialogue;
    private int dialogueLineIndex = 0;
    #endregion

    #region PROPERTIES
    public TextMeshProUGUI Text { get { return text; } }
    public SODialogues SODialogues { get { return dialogue; } set { dialogue = value; } }
    #endregion

    #region UNITY METHODS
    #endregion

    #region PRIVATE METHODS
    #endregion

    #region PUBLIC METHODS
    public bool IsLastLine()
    {
        return dialogue.Lines.Count == dialogueLineIndex ? true : false;
    }
    public void StartDialogue(SODialogues dialogue)
    {
        UIManager.Instance.ShowCanvas(UIManager.Instance.DialogueCanvas);
        this.dialogue = dialogue;
        dialogueLineIndex = 0;
        text.text = dialogue.Lines[dialogueLineIndex];
        dialogueLineIndex++;
    }
    public void NextLine()
    {
        text.text = dialogue.Lines[dialogueLineIndex];
        dialogueLineIndex++;
    }
    public void EndDialogue()
    {
        this.dialogue = null;
        text.text = "";
        UIManager.Instance.HideCanvas(UIManager.Instance.DialogueCanvas);
    }
    #endregion
}
