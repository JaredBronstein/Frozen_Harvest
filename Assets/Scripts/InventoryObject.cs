﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractiveObject
{
    [Tooltip ("The name of the object, as it will appear in the inventory menu UI")]
    [SerializeField]
    private string objectName = nameof(InventoryObject);

    [Tooltip ("The text that will display when the player selects this object in the inventory menu")]
    [TextArea(3,8)]
    [SerializeField]
    private string description;

    [Tooltip ("Icon to display for this item in the inventory menu")]
    [SerializeField]
    private Sprite icon;

    public Sprite Icon => icon;
    public string Description => description;
    public string ObjectName => objectName;

    private new Renderer renderer;
    private new Collider collider;
    private new BoxCollider boxCollider;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        collider = GetComponent<Collider>();
        boxCollider = GetComponent<BoxCollider>();
    }

    public InventoryObject()
    {
        displayText = $"Take {objectName}";
    }

    /// <summary>
    /// When the player interacts with an inventory object we need to do 2 things.
    /// 1. Add the inventory object to the PlayerInventory list
    /// 2. Remove the object from the game world / scene
    ///     Can't use Destroy, because I need to keep the gameobject in the inventory list.
    ///     So we just disable the collider and renderer
    /// </summary>
    public override void InteractWith()
    {
        base.InteractWith();
        PlayerInventory.InventoryObjects.Add(this);
        InventoryMenu.Instance.AddItemToMenu(this);
        renderer.enabled = false;
        collider.enabled = false;
        boxCollider.enabled = false;
    }
}
