using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    public Action<OperationType, Player, TextController> OnSetupShopView;

    private const string Welcome = "Welcome to Clothes Shop, how can i help you ?";
    private const string GoodBye = "Thank you and until next time!";

    public Shop Shop => _shop;

    [SerializeField] private Shop _shop;
    [SerializeField] private InteractiveArea _serviceDesk;
    [SerializeField] private TextController _textController;

    [SerializeField] private bool _canInteractive = false;
    [SerializeField] private bool _shopInUse = false;

    [SerializeField][CanBeNull] private Player _currentCustomer;
    

    public void InitialDialogueCallback()
    {
        StartCoroutine(EnterToTheShop());
    }

    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        _serviceDesk.OnTriggerStatus += CanInteractiveHandler;
        _textController.SetChoices(CreateOptions());
    }

    private void CanInteractiveHandler(bool status, Player player)
    {
        _canInteractive = status;

        if (!status)
        {
            _currentCustomer.OnInteractive -= InteractiveHandler;
            _currentCustomer = null;
            return;
        }

        _currentCustomer = player;
        _shop.Setup(_currentCustomer);
        _currentCustomer.OnInteractive += InteractiveHandler;
    }

    private void InteractiveHandler()
    {
        if (!_canInteractive || _shopInUse)
        {
            return;
        }

        InitialDialogueCallback();
    }

    private IEnumerator EnterToTheShop()
    {
        if (!_shopInUse)
        {
            _textController.OnBoxControl?.Invoke(true, 0);
        }

        _textController.SetContextText(Welcome);
        _shopInUse = true;
        GameController.Instance.OnPlayerInInteraction?.Invoke(!_shopInUse);

        yield return new WaitForSeconds(1f);

        _textController.OnBeginChoice?.Invoke();
    }

    private void SellOption()
    {
        OnSetupShopView?.Invoke(OperationType.Sell, _currentCustomer, _textController);
    }

    private void BuyOption()
    {
        OnSetupShopView?.Invoke(OperationType.Buy, _currentCustomer, _textController);
    }

    private void LeaveOption()  
    {
        _textController.SetContextText(GoodBye);
        _textController.OnBoxControl?.Invoke(false, 1f);
        _shopInUse = false;

        GameController.Instance.OnPlayerInInteraction?.Invoke(!_shopInUse);
    }

    private ChoiceForm[] CreateOptions()
    {
        List<ChoiceForm> choiceList = new List<ChoiceForm>();

        ChoiceForm b = new ChoiceForm("Buy", BuyOption);
        ChoiceForm s = new ChoiceForm("Sell", SellOption);
        ChoiceForm l = new ChoiceForm("Nothing...", LeaveOption);

        choiceList.Add(b);
        choiceList.Add(s);
        choiceList.Add(l);

        return choiceList.ToArray();
    }
}
