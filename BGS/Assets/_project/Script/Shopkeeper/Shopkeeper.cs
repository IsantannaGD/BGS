using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Shopkeeper : MonoBehaviour
{
    [SerializeField] private InteractiveArea _serviceDesk;
    [SerializeField] private TextController _textController;

    [SerializeField] private bool _canInteractive = false;

    [SerializeField][CanBeNull] private Player _currentCustomer;

    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        _serviceDesk.OnTriggerStatus += CanInteractiveHandler;
        _textController.SetContextText("Welcome to Clothes Shop, how can i help you ?");
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
        _currentCustomer.OnInteractive += InteractiveHandler;
    }

    private void InteractiveHandler()
    {
        if (!_canInteractive)
        {
            return;
        }

        _textController.OnBoxControl?.Invoke(true);
    }

    private void SellOption()
    {

    }

    private void BuyOption()
    {

    }

    private void LeaveOption()  
    {
        _textController.SetContextText("Thank you and until next time!", true);
    }

    private ChoiceForm[] CreateOptions()
    {
        List<ChoiceForm> choiceList = new List<ChoiceForm>();

        ChoiceForm s = new ChoiceForm("Sell", SellOption);
        ChoiceForm b = new ChoiceForm("Buy", BuyOption);
        ChoiceForm l = new ChoiceForm("Nothing...", LeaveOption);

        choiceList.Add(s);
        choiceList.Add(b);
        choiceList.Add(l);

        return choiceList.ToArray();
    }
}
