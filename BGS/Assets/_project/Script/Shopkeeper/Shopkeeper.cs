using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Shopkeeper : MonoBehaviour
{
    private const string Welcome = "Welcome to Clothes Shop, how can i help you ?";
    private const string GoodBye = "Thank you and until next time!";

    [SerializeField] private Button TestButton;

    [SerializeField] private InteractiveArea _serviceDesk;
    [SerializeField] private TextController _textController;

    [SerializeField] private bool _canInteractive = false;

    [SerializeField][CanBeNull] private Player _currentCustomer;
    [SerializeField] private Shop _shop;

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

        _shop.OnReturn += InitialDialogueCallback;

        TestButton.onClick.AddListener(InteractiveHandler);
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
        _currentCustomer.OnInteractive += InteractiveHandler;
    }

    private void InteractiveHandler()
    {
        if (!_canInteractive)
        {
            return;
        }

        InitialDialogueCallback();
    }

    private IEnumerator EnterToTheShop()
    {
        if (!_shop.gameObject.activeInHierarchy)
        {
            _textController.OnBoxControl?.Invoke(true, 0);
        }

        _textController.SetContextText(Welcome);

        yield return new WaitForSeconds(1f);

        _textController.OnBeginChoice?.Invoke();
    }

    private void SellOption()
    {
        _shop.Setup(OperationType.Sell, _currentCustomer, _textController);
    }

    private void BuyOption()
    {
        _shop.Setup(OperationType.Buy, _currentCustomer, _textController);
    }

    private void LeaveOption()  
    {
        _textController.SetContextText(GoodBye);
        _textController.OnBoxControl?.Invoke(false, 1f);
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
