using System.Collections;
using System.Collections.Generic;
using TinySimStore.Character.Player;
using TinySimStore.DB;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private RectTransform content;
    [SerializeField] private GameObject itemSlotPrefab;

    [SerializeField] private List<TextMeshProUGUI> coinsText;
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    private void Start()
    {
        UpdateContent(PlayerManager.Instance.CharacterInventory.Content);
        UpdateCurrency();
    }
    #endregion

    #region PRIVATE METHODS
    private void CleanChildren()
    {
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(content.GetChild(i).gameObject);
        }
    }
    #endregion

    #region PUBLIC METHODS
    public void UpdateCurrency()
    {
        foreach (TextMeshProUGUI text in coinsText)
        {
            text.text = PlayerManager.Instance.CharacterInventory.Coins.Amount.ToString();
        }
    }
    public void UpdateContent(List<SOItemBase> items)
    {
        CleanChildren();
        foreach (SOItemBase item in items)
        {
            if (item != null)
            {
                ItemSlot itemSlot = GameObject.Instantiate(itemSlotPrefab, content).GetComponent<ItemSlot>();
                if (item.Icon != null) itemSlot.ItemIcon.sprite = item.Icon;
                itemSlot.ItemName.text = item.ItemName;

                if (PlayerManager.Instance.CharacterInventory.Content[transform.GetSiblingIndex()] is SOEquippableItem)
                {
                    if (itemSlot.EquipButton != null) itemSlot.AddEquipAction();
                    if (itemSlot.UnequipButton != null) itemSlot.AddUnequipAction();
                }


            }
        }
    }
    #endregion
}
