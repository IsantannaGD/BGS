using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPurchasable
{
    public bool BuyItem(Player p, float value)
    {
        if (p.Wallet < value)
        { return false; }
        
        p.PlayerBuyItemHandler(this, value);
        return true;
    }
}
