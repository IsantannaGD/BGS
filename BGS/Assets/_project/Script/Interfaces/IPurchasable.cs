using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPurchasable
{
    public bool BuyItem(Player p, float value)
    {
        if (p.Inventory.Wallet < value)
        { return false; }
        
        p.Inventory.PlayerBuyItemHandler(this, value);
        return true;
    }
}
