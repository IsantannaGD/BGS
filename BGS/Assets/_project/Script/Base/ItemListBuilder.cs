using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ItemListBuilder : MonoBehaviour
{
    public Action<Item> OnSelectItemInList;

    [SerializeField] protected GameObject listPanel;
    [SerializeField] protected GameObject spawnPoint;
    [SerializeField] protected ItemLabel labelPrefab;

    [SerializeField] protected TextController textController;
    [SerializeField] protected TextMeshProUGUI selectedItemName;
    [SerializeField] protected TextMeshProUGUI selectedItemDescription;
    [SerializeField] protected TextMeshProUGUI selectedItemType;
    [SerializeField] protected TextMeshProUGUI selectedItemValue;
    [SerializeField] protected TextMeshProUGUI ownerWallet;
    [SerializeField] protected Image selectedItemImage;
    [SerializeField] protected Button interactionButton;
    [SerializeField] protected Button cancelInteractionButton;

    [SerializeField] protected Item currentItem;
    [SerializeField] protected float currentValue;
    [SerializeField] protected float animTime = 0.5f;
    
    [SerializeField] protected List<ItemLabel> createdItems;

    private void Awake()
    {
        Initializations();
    }

    private void Initializations()
    {
        interactionButton.onClick.AddListener(InteractiveButtonHandler);
        cancelInteractionButton.onClick.AddListener(CancelHandler);

        Subscriptions();

        listPanel.SetActive(false);
    }

    protected void CreateList(List<Item> items)
    {
        foreach (Item item in items)
        {
            ItemLabel n = Instantiate(labelPrefab, spawnPoint.transform);
            n.Setup(item);

            OnSelectItemInList += n.SelectItemInListCallback;
            n.OnSelectItem += SelectItemHandler;

            createdItems.Add(n);
        }
    }

    protected abstract void SelectItemHandler(Item i);
    protected abstract void InteractiveButtonHandler();
    protected abstract void CancelHandler();
    protected virtual void UpdateWalletDisplay(float value)
    {
        ownerWallet.text = value.ToString("000");
    }

    protected virtual void ShowSelectedItemHandler()
    {
        selectedItemName.text = currentItem.Name;
        selectedItemDescription.text = currentItem.Description;
        selectedItemImage.gameObject.SetActive(true);
        selectedItemImage.sprite = currentItem.ItemSprite;
        selectedItemImage.DOFade(1f, 0.5f);
        selectedItemType.text = currentItem.ItemType.ToString();
        selectedItemValue.text = $"{currentValue}";
        interactionButton.interactable = true;

    }

    protected void ClearSelection()
    {
        selectedItemName.text = " ";
        selectedItemDescription.text = " ";
        selectedItemImage.DOFade(0f, 0.5f).OnComplete(() => {selectedItemImage.gameObject.SetActive(false);});
        selectedItemType.text = " ";
        selectedItemValue.text = " ";
        currentValue = 0f;
        currentItem = null;
        interactionButton.interactable = false;
        ExtraListComponents();
    }

    protected void ClearList()
    {
        foreach (ItemLabel label in createdItems)
        {
            OnSelectItemInList -= label.SelectItemInListCallback;
            label.OnSelectItem -= SelectItemHandler;
            Destroy(label.gameObject);
        }

        createdItems.Clear();
        ClearSelection();
    }
    protected void PanelAnim(bool status)
    {
        if (status)
        {
            listPanel.SetActive(true);
            listPanel.transform.DOScale(1f, animTime);
            return;
        }

        listPanel.transform.DOScale(0f, animTime).OnComplete(() =>
        {
            listPanel.SetActive(false);
        });
    }

    protected virtual void ExtraListComponents()
    { }

    protected virtual void Subscriptions()
    { }
    protected virtual void UnSubscriptions()
    { }

    private void OnDestroy()
    {
        UnSubscriptions();
    }
}
