using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static class XpManager
{
    public static int CalculateExp(Enemy enemy)
    {
        int baseXp = (Player.MyInstance.Level *5)+45;
        int grayLvl = CalculateGrayLevel();
        int totalXp = 0;

        if(enemy.Level >= Player.MyInstance.Level)
        {
            totalXp = (int)(baseXp * (1 + 0.05f * (enemy.Level - Player.MyInstance.Level)));
        }
        else if(enemy.Level >grayLvl)
        {
            totalXp = (baseXp) * (1 - (Player.MyInstance.Level - enemy.Level) / (ZeroDifference())); 
        }

        return totalXp;
    }

    public static int CalculcateExp(Quest quest)
    {
        if(Player.MyInstance.Level<=quest.Level+5)
        {
            return quest.Xp;
        }
        if (Player.MyInstance.Level <= quest.Level + 6)
        {
            return (int)(quest.Xp*0.8/5)*5;
        }
        if (Player.MyInstance.Level <= quest.Level + 7)
        {
            return (int)(quest.Xp * 0.6 / 5) * 5;
        }
        if (Player.MyInstance.Level <= quest.Level + 8)
        {
            return (int)(quest.Xp * 0.4 / 5) * 5;
        }
        if (Player.MyInstance.Level <= quest.Level + 9)
        {
            return (int)(quest.Xp * 0.2 / 5) * 5;
        }
        if (Player.MyInstance.Level <= quest.Level + 10)
        {
            return (int)(quest.Xp * 0.1 / 5) * 5;
        }

        return 0;
    }
    private static int ZeroDifference()
    {
        if(Player.MyInstance.Level<=7)
        {
            return 5;
        }
        if(Player.MyInstance.Level >= 8 && Player.MyInstance.Level <= 9)
        {
            return 6;
        }
        if (Player.MyInstance.Level >= 10 && Player.MyInstance.Level <= 11)
        {
            return 7;
        }
        if (Player.MyInstance.Level >= 12 && Player.MyInstance.Level <= 15)
        {
            return 8;
        }
        if (Player.MyInstance.Level >= 16 && Player.MyInstance.Level <= 19)
        {
            return 9;
        }
        if (Player.MyInstance.Level >= 20 && Player.MyInstance.Level <= 29)
        {
            return 11;
        }
        if (Player.MyInstance.Level >= 30 && Player.MyInstance.Level <= 39)
        {
            return 12;
        }
        if (Player.MyInstance.Level >= 40 && Player.MyInstance.Level <= 44)
        {
            return 13;
        }
        if (Player.MyInstance.Level >= 45 && Player.MyInstance.Level <= 49)
        {
            return 14;
        }
        if (Player.MyInstance.Level >= 50 && Player.MyInstance.Level <= 54)
        {
            return 15;
        }
        if (Player.MyInstance.Level >= 55 && Player.MyInstance.Level <= 59)
        {
            return 16;
        }
        return 17;
    }

    public static int CalculateGrayLevel()
    {
        if(Player.MyInstance.Level<=5)
        {
            return 0;
        }
        else if(Player.MyInstance.Level>=6 && Player.MyInstance.Level<=49)
        {
            return Player.MyInstance.Level - (Player.MyInstance.Level / 10) - 5;
        }
        else if (Player.MyInstance.Level == 50)
        {
            return Player.MyInstance.Level - 10;    
        }
        else if (Player.MyInstance.Level >= 51 && Player.MyInstance.Level <= 60)
        {
            return Player.MyInstance.Level - (Player.MyInstance.Level / 5) - 1;
        }
        return Player.MyInstance.Level - 9;
    }
}
