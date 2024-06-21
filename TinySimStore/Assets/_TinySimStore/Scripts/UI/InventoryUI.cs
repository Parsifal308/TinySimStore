using System.Collections;
using System.Collections.Generic;
using TinySimStore.Character.Player;
using TinySimStore.DB;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    #region FIELDS
    [SerializeField] private RectTransform content;
    [SerializeField] private GameObject itemSlotPrefab;
    #endregion

    #region PROPERTIES
    #endregion

    #region UNITY METHODS
    private void Start()
    {
        UpdateContent(PlayerManager.Instance.CharacterInventory.Content);
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
            }
        }
    }
    #endregion
}
