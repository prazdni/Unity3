using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace MyLabyrinth
{
    public sealed class BonusCreator
    {
        public BonusCreator(AllExecutableObjects listExecutableObjects, BonusesContainer container)
        {
            IExecute bonus = null;
            
            for (int i = 0; i < container.BonusCount; i++)
            {
                switch (container[i].BonusType)
                {
                    case BonusType.BadBonus:
                        bonus = new BadBonus(Object.Instantiate(Reference.Bonus, container[i].SpawnPoint,
                            Quaternion.identity));
                        ((Bonus)bonus).SetBonusType(BonusType.BadBonus);
                        break;
                    case BonusType.GoodBonus:
                        bonus = new GoodBonus(Object.Instantiate(Reference.Bonus, container[i].SpawnPoint,
                            Quaternion.identity));
                        ((Bonus)bonus).SetBonusType(BonusType.GoodBonus);
                        break;
                    case BonusType.KeyBonus:
                        bonus = new KeyBonus(Object.Instantiate(Reference.Bonus, container[i].SpawnPoint,
                            Quaternion.identity));
                        ((Bonus)bonus).SetBonusType(BonusType.KeyBonus);
                        break;
                    case BonusType.SpeedBonus:
                        bonus = new SpeedBonus(Object.Instantiate(Reference.Bonus, container[i].SpawnPoint,
                            Quaternion.identity));
                        ((Bonus)bonus).SetBonusType(BonusType.SpeedBonus);
                        break;
                    case BonusType.None:
                        throw new Exception("Missing Bonus Type");
                }
                
                listExecutableObjects.AddExecutableObject(bonus);
            }
        }
    }
}