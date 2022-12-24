using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.PlayerLoop;


public class TextController : MonoBehaviour
{
    public Action OnChoiceSelected;
    public Action OnBeginChoice;
    public Action<bool> OnBoxControl;

    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] private TextMeshProUGUI _context;
    [SerializeField] private ChoiceContainer[] _choices;

    [SerializeField] private float _fadeTime = 0.5f;
    [SerializeField] private float _scaleTime = 0.5f;
    [SerializeField] private bool _initialized = false;
    
    public void SetContextText(string text, bool isUpdating = false)
    {
        _context.text = text;
        _canvasGroup.alpha = 0f;

        if (isUpdating)
        {
            Fade(true);
        }
    }

    public void SetChoices(params ChoiceForm[] c)
    {
        for (int i = 0; i < c.Length; i++)
        {
            _choices[i].Setup(c[i].EventCallback, c[i].Message);
        }
    }

    private void Start()
    {
        Initialization();
    }

    private void Initialization()
    {
        foreach (ChoiceContainer choice in _choices)
        {
            OnChoiceSelected += choice.FadeOut;
            OnBeginChoice += choice.Initialize;
        }

        OnBoxControl += BoxAnimControl;
    }
    private void OnChoiceSelectedHandler()
    {
        OnChoiceSelected?.Invoke();
    }

    private void BoxAnimControl(bool status)
    {
        if (status)
        {
            gameObject.transform.DOScale(1f, _scaleTime).OnComplete(() => Fade(true));
            return;
        }

        gameObject.transform.DOScale(0f, _scaleTime);
    }

    private void Fade(bool status)
    {
        if (status)
        {
            _canvasGroup.DOFade(1f, _fadeTime);
            return;
        }

        _canvasGroup.DOFade(0f, _fadeTime);
    }
}
