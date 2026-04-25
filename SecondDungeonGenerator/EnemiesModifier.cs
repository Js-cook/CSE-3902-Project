using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

public class EnemiesModifier {


    public void ModifyEnemyTypes(List<RoomNode> rooms)
    {
        bool dodongoAdded = false;
        var random = new Random();
        int randomCountMax = random.Next(rooms.Count);
        int randomCount = 0;

        foreach (var room in rooms)
        {
            randomCount++;
           if (room.EnemiesData != null)
            {
                foreach (XElement enemy in room.EnemiesData.Elements("Enemy"))
                {
                    XAttribute typeAttribute = enemy.Attribute("type");

                    if (typeAttribute != null)
                    {
                        string enemyToAdd = GetRandomEnemyType();
                        if (randomCount >= randomCountMax && !dodongoAdded)
                        {
                            dodongoAdded |= true;
                            enemyToAdd = "Dodongo";
                            Debug.WriteLine($"Dodongo added to room ({room.Row}, {room.Col})");
                        }
                           
                        typeAttribute.Value = enemyToAdd;
                    }
                }
            }
        }
    }


    private string GetRandomEnemyType()
    {
        var random = new Random();
        List<string> enemies = [
            "Gel", "Bat", "Skeleton", "Goriya"
            ];

        int randomIndex = random.Next(enemies.Count);

        return enemies[randomIndex];

    }


}


