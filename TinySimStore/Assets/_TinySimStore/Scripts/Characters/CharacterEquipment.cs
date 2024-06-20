using System;
using System.Collections;
using System.Collections.Generic;
using TinySimStore.DB;
using UnityEngine;

namespace TinySimStore.Character
{
    public class CharacterEquipment : MonoBehaviour
    {
        #region FIELDS
        [Header("CHARACTER SETTINGS:"), Space(10)]
        [SerializeField] private EquipmentSlot headSlot;
        [SerializeField] private EquipmentSlot chestSlot;
        [SerializeField, Space(10)] private EquipmentSlot pelvisSlot;

        [SerializeField] private EquipmentSlot leftShoulderSlot;
        [SerializeField, Space(10)] private EquipmentSlot rightShoulderSlot;

        [SerializeField] private EquipmentSlot leftElbowSlot;
        [SerializeField, Space(10)] private EquipmentSlot rightElbowSlot;

        [SerializeField] private EquipmentSlot leftHandSlot;
        [SerializeField, Space(10)] private EquipmentSlot rightHandSlot;

        [SerializeField] private EquipmentSlot leftLegSlot;
        [SerializeField, Space(10)] private EquipmentSlot rightLegSlot;

        [SerializeField] private EquipmentSlot leftBootSlot;
        [SerializeField] private EquipmentSlot rightBootSlot;
        #endregion

        #region PROPERTIES
        #endregion

        #region UNITY METHODS
        #endregion

        #region PRIVATE METHODS
        #endregion

        #region PUBLIC METHODS
        #endregion
    }
    [Serializable]
    public class EquipmentSlot
    {
        [SerializeField] private GameObject location;
        [SerializeField] private SOEquippableItem data;
    }
}