using System.Collections;
using System.Collections.Generic;
using TinySimStore.Character.Player;
using TinySimStore.DB;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private TextMeshProUGUI itemName;
    [SerializeField] private Image itemIcon;
    [SerializeField] private Image equippedIcon;
    [SerializeField] private Button equipButton;
    [SerializeField] private Button unequipButton;
    #endregion

    #region PROPERTIES
    public TextMeshProUGUI ItemName { get { return itemName; } }
    public Image ItemIcon { get { return itemIcon; } }
    public Button EquipButton { get { return equipButton; } }
    #endregion

    #region UNITY METHODS
    private void Start()
    {
        if (PlayerManager.Instance.CharacterInventory.Content[transform.GetSiblingIndex()] is SOEquippableItem)
        {
            AddEquipAction();
            AddUnequipAction();
        }
    }
    #endregion

    #region PRIVATE METHODS
    private void AddEquipAction()
    {
        UnityAction equipAction = () =>
        {
            if (PlayerManager.Instance.CharacterEquipment.TryEquip(PlayerManager.Instance.CharacterInventory.Content[transform.GetSiblingIndex()] as SOEquippableItem))
            {
                equippedIcon.enabled = true;
                equipButton.gameObject.SetActive(false);
                unequipButton.gameObject.SetActive(true);
            }
            else
            {
                equippedIcon.enabled = false;
                equipButton.gameObject.SetActive(true);
                unequipButton.gameObject.SetActive(false);
            }
            //PlayerManager.Instance.CharacterEquipment.TryEquip(PlayerManager.Instance.CharacterInventory.Content[transform.GetSiblingIndex()] as SOEquippableItem);
        };
        equipButton.onClick.AddListener(equipAction);
    }
    private void AddUnequipAction()
    {
        UnityAction unequipAction = () =>
        {
            if (PlayerManager.Instance.CharacterEquipment.TryUnequip((PlayerManager.Instance.CharacterInventory.Content[transform.GetSiblingIndex()] as SOEquippableItem).EquipableType))
            {
                equippedIcon.enabled = false;
                equipButton.gameObject.SetActive(true);
                unequipButton.gameObject.SetActive(false);
            }
            else
            {
                equippedIcon.enabled = true;
                equipButton.gameObject.SetActive(false);
                unequipButton.gameObject.SetActive(true);
            }
        };
        unequipButton.onClick.AddListener(unequipAction);
        #endregion

        #region PUBLIC METHODS
        #endregion
    }
}
