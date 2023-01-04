using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWearable
{
    public bool WearItem(Player p, ClothType c, Item i)
    {
        switch (c)
        {
            case ClothType.Hat:
                if (p.CheckEquippedHatID() == i.ID)
                {
                    p.OnEquipHat?.Invoke(i as Hat, false);
                    return false;
                }

                Hat hatToSend = i as Hat;
                p.OnEquipHat?.Invoke(hatToSend, true);

                break;

            case ClothType.Shirt:
                if (p.CheckEquippedShirtID() == i.ID)
                {
                    p.OnEquipShirt?.Invoke(i as Shirt, false);
                    return false;
                }

                Shirt shirtToSend = i as Shirt;
                p.OnEquipShirt?.Invoke(shirtToSend, true);

                break;
            case ClothType.Trousers:
                if (p.CheckEquippedTrousersID() == i.ID)
                {
                    p.OnEquipTrousers?.Invoke(i as Trousers, false);
                    return false;
                }

                Trousers trousersToSend = i as Trousers;
                p.OnEquipTrousers?.Invoke(trousersToSend, true);

                break;
        }

        return true;
    }
}
