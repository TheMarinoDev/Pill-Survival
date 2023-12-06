using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance { get; private set; }
    public int EXP = 0;
    public int NextLevelUp = 5;
    public Entity PlayerEntity;
    public EntityStats DefaultStats;
     // List to hold all possible upgrades
    public List<Upgrade> availableUpgrades = new List<Upgrade>();
    // Number of upgrades to offer on level up
    public int upgradesToOffer = 3;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.
        PlayerEntity = GetComponent<Entity>();

        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this);
        InitializeUpgrades();
    }

    private void InitializeUpgrades()
    {
        //availableUpgrades.Add(UpgradeObject);

    }
    public void ResetPlayer()
    {
        PlayerEntity.stats.CopyStats(DefaultStats);
    }
    public void ApplyEXP(int amount)
    {
        EXP += amount;
        if(EXP >= NextLevelUp)
        {
            EXP = 0;
            NextLevelUp += 8;
            PlayerEntity.stats.Level++;
            OfferUpgrades();

            //Prompt the player pick from one of three randomly selected upgrades
            //GrantUpgrade();
            UIManager.instance.menuState = UIManager.MenuState.UPGRADESELECT;//placeholder
        }
    }
    private void OfferUpgrades()
    {
        List<Upgrade> upgradesToOfferList = new List<Upgrade>();

        for (int i = 0; i < upgradesToOffer; i++)
        {
            if (availableUpgrades.Count > 0)
            {
                int randomIndex = Random.Range(0, availableUpgrades.Count);
                upgradesToOfferList.Add(availableUpgrades[randomIndex]);
            }
        }
    }
}
