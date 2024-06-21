using System.Collections;
using System.Collections.Generic;
using TinySimStore.Manager;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Mawe.Utils
{
    public class DragAndDrop : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler, IDropHandler
    {
        #region FIELDS
        [SerializeField] private float dampingSpeed = 0.025f;
        private RectTransform dragginObjectTransform;
        private Vector3 velocity = Vector3.zero;
        private CanvasGroup canvasGroup;
        #endregion

        #region UNITY METHODS
        void Awake()
        {
            dragginObjectTransform = transform as RectTransform;
            canvasGroup = GetComponent<CanvasGroup>();
        }
        #endregion
        public void OnDrag(PointerEventData eventData)
        {
            if (RectTransformUtility.ScreenPointToWorldPointInRectangle(dragginObjectTransform, eventData.position, eventData.pressEventCamera, out var globalMousePos))
            {
                dragginObjectTransform.position = Vector3.SmoothDamp(dragginObjectTransform.position, globalMousePos, ref velocity, dampingSpeed);
            }
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            canvasGroup.blocksRaycasts = false;
            canvasGroup.alpha = 0.75f;
            dragginObjectTransform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
            Transform parent = dragginObjectTransform.parent;
            transform.SetParent(GetComponentInParent<Canvas>().transform);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log("OnEndDrag");
            canvasGroup.blocksRaycasts = true;
            canvasGroup.alpha = 1f;
            dragginObjectTransform.localScale = new Vector3(1f, 1f, 1f);

            UIManager.Instance.Store.LastPanelFocused = eventData.pointerCurrentRaycast.gameObject;
            if (UIManager.Instance.Store.LastPanelFocused != null)
            {
                Debug.Log("Soltado sobre: " + UIManager.Instance.Store.LastPanelFocused.name);
            }
            else
            {

            }
        }
        public void OnDrop(PointerEventData eventData)
        {
            // Lógica para manejar el final del arrastre en este panel
            Debug.Log("Objeto soltado en el panel: " + gameObject.name);
        }
    }
}