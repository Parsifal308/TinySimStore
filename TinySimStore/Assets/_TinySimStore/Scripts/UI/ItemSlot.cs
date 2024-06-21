using System.Collections;
using System.Collections.Generic;
using TinySimStore.Character.Player;
using TinySimStore.DB;
using TinySimStore.Manager;
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
    [SerializeField] private Button buyButton;
    [SerializeField] private Button sellButton;
    private int itemIndex;
    #endregion

    #region PROPERTIES
    public int ItemIndex { get { return itemIndex; } set { itemIndex = value; } }
    public TextMeshProUGUI ItemName { get { return itemName; } }
    public Image ItemIcon { get { return itemIcon; } }
    public Button EquipButton { get { return equipButton; } }
    public Button UnequipButton { get { return unequipButton; } }
    public Button BuyButton { get { return buyButton; } }
    public Button SellButton { get { return sellButton; } }
    #endregion

    #region UNITY METHODS
    private void Start()
    {

    }
    #endregion

    #region PRIVATE METHODS
    public void AddBuyAction()
    {
        sellButton.gameObject.SetActive(false);
        UnityAction BuyAction = () =>
        {
            transform.SetParent(UIManager.Instance.Store.PlayerCart.transform);
            buyButton.gameObject.SetActive(false);
        };
        buyButton?.onClick.AddListener(BuyAction);
    }
    public void AddSellAction()
    {
        buyButton.gameObject.SetActive(false);
        UnityAction SellAction = () =>
        {
            transform.SetParent(UIManager.Instance.Store.VendorCart.transform);
            sellButton.gameObject.SetActive(false);
        };
        sellButton?.onClick.AddListener(SellAction);
    }
    public void AddEquipAction()
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
        };
        equipButton?.onClick.AddListener(equipAction);
    }
    public void AddUnequipAction()
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
        unequipButton?.onClick.AddListener(unequipAction);
        #endregion

        #region PUBLIC METHODS
        #endregion
    }
}
