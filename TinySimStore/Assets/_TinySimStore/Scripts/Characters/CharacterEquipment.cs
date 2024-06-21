using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TinySimStore.DB;
using Unity.VisualScripting;
using UnityEngine;

namespace TinySimStore.Character
{
    public class CharacterEquipment : MonoBehaviour
    {
        #region FIELDS
        [Header("CHARACTER SETTINGS:"), Space(10)]
        [SerializeField] private EquipmentSlot headSlot;
        [SerializeField] private EquipmentSlot chestSlot;
        [SerializeField] private EquipmentSlot pelvisSlot;
        [SerializeField] private EquipmentSlot shoulderSlot;
        [SerializeField] private EquipmentSlot elbowSlot;
        [SerializeField] private EquipmentSlot handSlot;
        [SerializeField] private EquipmentSlot legSlot;
        [SerializeField] private EquipmentSlot bootSlot;
        #endregion

        #region PROPERTIES
        #endregion

        #region UNITY METHODS
        private void Start()
        {
            TryUpdateEquipment();
        }
        #endregion

        #region PRIVATE METHODS
        private void TryUpdateEquipment()
        {
            headSlot.UpdateSprite();
            chestSlot.UpdateSprite();
            pelvisSlot.UpdateSprite();
            shoulderSlot.UpdateSprite();
            elbowSlot.UpdateSprite();
            handSlot.UpdateSprite();
            legSlot.UpdateSprite();
            bootSlot.UpdateSprite();
        }
        #endregion

        #region PUBLIC METHODS

        public bool TryUnequip(EquipableType equipableType)
        {
            switch (equipableType)
            {
                case EquipableType.Head:
                    headSlot.Data = null;
                    headSlot.UpdateSprite();
                    break;
                case EquipableType.Torso:
                    chestSlot.Data = null;
                    chestSlot.UpdateSprite();
                    break;
                case EquipableType.Pelvis:
                    pelvisSlot.Data = null;
                    pelvisSlot.UpdateSprite();
                    break;
                case EquipableType.Legs:
                    legSlot.Data = null;
                    legSlot.UpdateSprite();
                    break;
                case EquipableType.Boots:
                    bootSlot.Data = null;
                    bootSlot.UpdateSprite();
                    break;
                case EquipableType.Shoulders:
                    shoulderSlot.Data = null;
                    shoulderSlot.UpdateSprite();
                    break;
                case EquipableType.Arms:
                    elbowSlot.Data = null;
                    elbowSlot.UpdateSprite();
                    break;
                case EquipableType.Hands:
                    handSlot.Data = null;
                    handSlot.UpdateSprite();
                    break;
            }
            return true;
        }
        public bool TryEquip(SOEquippableItem equippable)
        {
            switch (equippable.EquipableType)
            {
                case EquipableType.Head:
                    try
                    {
                        headSlot.Data = equippable;
                        headSlot.UpdateSprite();
                        break;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                case EquipableType.Torso:
                    try
                    {
                        chestSlot.Data = equippable;
                        chestSlot.UpdateSprite();
                        break;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                case EquipableType.Pelvis:
                    try
                    {
                        pelvisSlot.Data = equippable;
                        pelvisSlot.UpdateSprite();
                        break;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                case EquipableType.Legs:
                    try
                    {
                        legSlot.Data = equippable;
                        legSlot.UpdateSprite();
                        break;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                case EquipableType.Boots:
                    try
                    {
                        bootSlot.Data = equippable;
                        bootSlot.UpdateSprite();
                        break;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                case EquipableType.Shoulders:
                    try
                    {
                        shoulderSlot.Data = equippable;
                        shoulderSlot.UpdateSprite();
                        break;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                case EquipableType.Arms:
                    try
                    {
                        elbowSlot.Data = equippable;
                        elbowSlot.UpdateSprite();
                        break;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                case EquipableType.Hands:
                    try
                    {
                        handSlot.Data = equippable;
                        handSlot.UpdateSprite();
                        break;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
            }
            return true;
        }
        #endregion
    }
    [Serializable]
    public class EquipmentSlot
    {
        #region FIELDS
        [SerializeField] private List<SpriteRenderer> renderers;
        [SerializeField] private SOEquippableItem data;
        #endregion

        #region PROPERTIES
        public SOEquippableItem Data { get { return data; } set { data = value; } }
        #endregion

        #region METHODS
        public void UpdateSprite()
        {
            for (int i = 0; i < renderers.Count; i++)
            {
                if (data != null)
                {
                    try
                    {
                        renderers[i].sprite = data.EquipmentSprite[i];
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
                else
                {
                    renderers[i].sprite = null;
                }

            }
        }
        #endregion
    }
}