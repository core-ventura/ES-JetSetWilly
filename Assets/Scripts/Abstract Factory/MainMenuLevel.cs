using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuLevel : ILevelFactory
{
    public ISceneProperties GetSceneProperties()
    {
        return new MainMenuSceneProperties();
    }
    public ISpawnProperties GetSpawnProperties()
    {
        return new MainMenuSpawnProperties();
    }
}
