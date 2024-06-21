using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TinySimStore.DB
{
    [CreateAssetMenu(fileName = "New Equippable Item", menuName = "Tiny Sim Store/Equippable Item")]
    public class SOEquippableItem : SOItemBase
    {
        #region FIELDS
        [SerializeField] protected List<Sprite> equipmentSprite;
        [SerializeField] protected EquipableType equipableType;
        #endregion

        #region PROPERTIES
        public EquipableType EquipableType { get { return equipableType; } }
        public List<Sprite> EquipmentSprite { get { return equipmentSprite; } }
        #endregion
    }
    public enum EquipableType
    {
        Head,
        Torso,
        Pelvis,
        Legs,
        Boots,
        Shoulders,
        Arms,
        Hands
    }
}