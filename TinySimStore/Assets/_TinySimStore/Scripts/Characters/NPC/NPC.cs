using System.Collections;
using System.Collections.Generic;
using TinySimStore.Character.Player;
using TinySimStore.DB;
using TinySimStore.Inventory;
using TinySimStore.Manager;
using TMPro;
using UnityEngine;

namespace TinySimStore.Character
{
    public class NPC : MonoBehaviour
    {
        #region FIELDS
        private CharacterInventory inventory;
        private bool isBusy;
        [SerializeField] private bool isVendor;
        [SerializeField] private SpriteRenderer indicator;
        [SerializeField] private SODialogues dialogue;
        private bool isPlayerInRange;
        #endregion

        #region PROPERTIES
        public CharacterInventory Inventory { get { return inventory; } }
        #endregion

        #region UNITY METHODS
        private void Start()
        {
            if (TryGetComponent<CharacterInventory>(out CharacterInventory inventory)) this.inventory = inventory;
            indicator.enabled = false;
        }
        #endregion

        #region PRIVATE METHODS
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isPlayerInRange = true;
                indicator.enabled = true;
                PlayerManager.Instance.NearNPC = this;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isPlayerInRange = false;
                indicator.enabled = false;
                PlayerManager.Instance.NearNPC = null;
            }
        }
        #endregion

        #region PUBLIC METHODS
        public void Interact()
        {
            if (!isBusy)
            {
                isBusy = true;
                UIManager.Instance.DialoguePanel.StartDialogue(dialogue);
                PlayerManager.Instance.CharacterMovement.enabled = false;
            }
            else
            {
                if (!UIManager.Instance.DialoguePanel.IsLastLine())
                {
                    UIManager.Instance.DialoguePanel.NextLine();
                }
                else
                {
                    UIManager.Instance.DialoguePanel.EndDialogue();
                    isBusy = false;
                    PlayerManager.Instance.CharacterMovement.enabled = true;
                    if (isVendor)
                    {
                        UIManager.Instance.Store.SyncStore();
                        UIManager.Instance.ShowCanvas(UIManager.Instance.StoreCanvas);
                        PlayerManager.Instance.CharacterMovement.enabled = false;
                    }
                }
            }

        }
        #endregion
    }
}