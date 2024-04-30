using System;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour
{
    private float _divider = 2f;

    private float _minChanceSplit = 0f;
    private float _maxChanceSplit = 100f;

    private Renderer _renderer;

    public event Action Clicked;

    public float EffectMyltiply { get; private set; } = 1f;
    public float CurrentChance { get; private set; } = 100f;

    public void SetMyltyply(float effectMyltiply) => EffectMyltiply = effectMyltiply * _divider;
    public void SetChance(float parentChance) => CurrentChance = parentChance / _divider;

    public bool CanSplit()
    {
        float chance = UnityEngine.Random.Range(_minChanceSplit, _maxChanceSplit);

        return CurrentChance >= chance;
    }

    internal void SetColor(Color color) => _renderer.material.color = color;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseUpAsButton() => Clicked?.Invoke();
}
