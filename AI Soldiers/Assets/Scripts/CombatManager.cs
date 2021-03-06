﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour {

    static Dictionary<string, List<Entity>> EntityTypes = new Dictionary<string, List<Entity>>();

    public static int RedDeathCount = 0;
    public static int GreenDeathCount = 0;

    public static void RegisterEntity(Entity entity, string tag)
    {
        if(EntityTypes.ContainsKey(tag) == false)
        {
            EntityTypes.Add(tag, new List<Entity>());
        }

        EntityTypes[tag].Add(entity); // Adds entity to correct list
    }

    public static Entity GetRandomTarget(string flag)
    {
        if (!EntityTypes.ContainsKey(flag))
            return null;

        List<Entity> members = EntityTypes[flag];
        var index = Random.Range(0, members.Count);

        if (members.Count == 0)
            return null;
        
        return members[index];
    }

    public static Entity GetFirstTarget(string flag)
    {
        if (EntityTypes.ContainsKey(flag) == false)
            return null;
        if (EntityTypes[flag].Count == 0)
            return null;

        return EntityTypes[flag][0];
    }

    public static void RemoveEntity(string flag, Entity entity)
    {
        EntityTypes[flag].Remove(entity);
    }

    public static void Clear()
    {
        EntityTypes.Clear();
        RedDeathCount = 0;
        GreenDeathCount = 0;
    }
}
