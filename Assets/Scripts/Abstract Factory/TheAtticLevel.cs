using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheAtticLevel : ILevelFactory
{
    public ISceneProperties GetSceneProperties()
    {
        return new TheAtticSceneProperties();
    }
    public ISpawnProperties GetSpawnProperties()
    {
        return new TheAtticSpawnProperties();
    }
}
