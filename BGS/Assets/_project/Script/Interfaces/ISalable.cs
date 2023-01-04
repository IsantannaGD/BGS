using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISalable
{
    public bool SellItem(Player p, float value, Shop buyer)
    {
        if (buyer.ShopKeeperWallet < value)
        {
            return false;
        }

        p.Inventory.PlayerSellItemHandler(this, value);
        return true;
    }
}
