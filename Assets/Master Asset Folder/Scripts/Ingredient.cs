﻿using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class Ingredient : ScriptableObject
{
    [Header("Ingredient Details")]
    public string ingredientName;
    public int ingredientNumber;
    public float ingredientCost;
    public Sprite ingredientSprite;
}