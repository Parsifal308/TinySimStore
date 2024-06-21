using System.Collections;
using System.Collections.Generic;
using TinySimStore.Character.Player;
using TinySimStore.DB;
using TinySimStore.Manager;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StoreUI : MonoBehaviour
{
    #region FIELDS
    private GameObject lastPanelFocused;
    [SerializeField] private RectTransform playerInventory;
    [SerializeField] private RectTransform playerCart;
    [SerializeField] private RectTransform vendorInventory;
    [SerializeField] private RectTransform vendorCart;

    [SerializeField] private Button resetButton;
    [SerializeField] private Button tradeButton;
    [SerializeField] private TextMeshProUGUI costText;

    [SerializeField] private GameObject itemPrefab;

    public List<int> playerItemIndexes;
    public List<int> vendorItemIndexes;
    #endregion

    #region PROPERTIES
    public RectTransform PlayerCart { get { return playerCart; } }
    public RectTransform VendorCart { get { return vendorCart; } }
    public GameObject LastPanelFocused { get { return lastPanelFocused; } set { lastPanelFocused = value; } }
    #endregion

    #region UNITY METHODS
    private void Start()
    {
        AddResetAction();
        AddBuyAction();
    }
    #endregion

    #region PRIVATE METHODS
    public void AddResetAction()
    {
        UnityAction ResetAction = () =>
        {
            SyncStore();
        };
        resetButton?.onClick.AddListener(ResetAction);
    }
    public void AddBuyAction()
    {
        UnityAction BuyAction = () =>
        {
            if (PlayerManager.Instance.CharacterInventory.Coins.Amount >= int.Parse(costText.text))
            {
                Debug.Log("Can Trade!!");
                PlayerManager.Instance.CharacterInventory.Coins.ModifyMoney(int.Parse(costText.text));
                UIManager.Instance.Inventory.UpdateCurrency();
                foreach (int index in playerItemIndexes)
                {
                    PlayerManager.Instance.NearNPC.Inventory.AddToEmpty(PlayerManager.Instance.CharacterInventory.Content[index]);
                    PlayerManager.Instance.CharacterInventory.Content[index]=null;
                }
                foreach (int index in vendorItemIndexes)
                {
                    PlayerManager.Instance.CharacterInventory.AddToEmpty(PlayerManager.Instance.NearNPC.Inventory.Content[index]);
                    PlayerManager.Instance.NearNPC.Inventory.Content[index] = null;
                }
                SyncStore();
                UIManager.Instance.Inventory.UpdateContent(PlayerManager.Instance.CharacterInventory.Content);
                UIManager.Instance.Inventory.UpdateCurrency();
            }
            else
            {
                Debug.Log("Can't Trade!!");
            }
        };
        tradeButton?.onClick.AddListener(BuyAction);
    }
    private void CleanChildren(RectTransform content)
    {
        for (int i = content.childCount - 1; i >= 0; i--)
        {
            GameObject.Destroy(content.GetChild(i).gameObject);
        }
    }
    #endregion

    #region PUBLIC METHODS
    public void AddToBuyCart(SOItemBase data)
    {
        int cost = int.Parse(costText.text);
        cost -= data.Price.Amount;
        costText.text = cost.ToString();
    }
    public void AddToSellCart(SOItemBase data)
    {
        int cost = int.Parse(costText.text);
        cost += data.Price.Amount;
        costText.text = cost.ToString();
    }
    public void SyncStore()
    {
        UpdateContent(PlayerManager.Instance.CharacterInventory.Content, playerInventory);
        if (PlayerManager.Instance.NearNPC != null) UpdateContent(PlayerManager.Instance.NearNPC.Inventory.Content, vendorInventory);
        CleanChildren(playerCart);
        CleanChildren(vendorCart);
        playerItemIndexes.Clear();
        vendorItemIndexes.Clear();
        costText.text = "0";
    }
    public void UpdateContent(List<SOItemBase> items, RectTransform content)
    {
        CleanChildren(content);
        foreach (SOItemBase item in items)
        {
            if (item != null)
            {
                ItemSlot itemSlot = GameObject.Instantiate(itemPrefab, content).GetComponent<ItemSlot>();
                itemSlot.ItemIndex = itemSlot.transform.GetSiblingIndex();
                if (item.Icon != null) itemSlot.ItemIcon.sprite = item.Icon;
                itemSlot.ItemName.text = item.ItemName;
                if (items.Equals(PlayerManager.Instance.CharacterInventory.Content))
                {
                    UnityAction SellAction = () =>
                    {
                        playerItemIndexes.Add(itemSlot.ItemIndex);
                        AddToSellCart(item);
                    };
                    itemSlot.SellButton?.onClick.AddListener(SellAction);
                    itemSlot.AddSellAction();
                }
                if (items.Equals(PlayerManager.Instance.NearNPC.Inventory.Content))
                {
                    UnityAction BuyAction = () =>
                    {
                        vendorItemIndexes.Add(itemSlot.ItemIndex);
                        AddToBuyCart(item);
                    };
                    itemSlot.BuyButton?.onClick.AddListener(BuyAction);
                    itemSlot.AddBuyAction();
                }
            }
        }
    }
    #endregion
}
