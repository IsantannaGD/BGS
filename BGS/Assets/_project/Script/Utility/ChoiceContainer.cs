using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public struct ChoiceForm
{
    public readonly string Message;
    public readonly UnityAction EventCallback;

    public ChoiceForm(string message, UnityAction eventCallback)
    {
        Message = message;
        EventCallback = eventCallback;
    }
}

public class ChoiceContainer : MonoBehaviour
{
    public Action OnChoiceSelect;

    [SerializeField] private Button _button;
    [SerializeField] private TextMeshProUGUI _display;
    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField] private float _fadeTime;

    [SerializeField] private bool _active = false;

    public void Setup(UnityAction e, string message)
    {
        _display.text = message;
        _button.onClick.AddListener(e);
        _button.onClick.AddListener(OnSelectHandler);

        _canvasGroup.alpha = 0f;
        _canvasGroup.interactable = false;
        _active = true;
    }

    public void Initialize()
    {
        if (_active)
        {
            FadeIn();
        }
    }

    public void FadeOut()
    {
        if (_active)
        {
            _canvasGroup.DOFade(0f, _fadeTime).OnComplete(() =>
            {
                _canvasGroup.interactable = false;
                _canvasGroup.blocksRaycasts = false;
            });
        }
    }

    private void FadeIn()
    {
        gameObject.SetActive(true);
        _canvasGroup.DOFade(1f, _fadeTime).OnComplete(() =>
        {
            _canvasGroup.interactable = true;
            _canvasGroup.blocksRaycasts = true;
        });
    }

    private void OnSelectHandler()
    {
        OnChoiceSelect?.Invoke();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveAllListeners();
        _display.text = " ";
        _active = false;
    }
}
