﻿using System;
namespace ParqueaderoElDesfalco.Core.Validators
{
    public class EmojiValidator
    {
        public bool VehicleIdHasEmojis(string vehicleId)
        {
            for(int i = 0; i < vehicleId.Length; i++)
            {
                if (char.IsSymbol(vehicleId, i))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
