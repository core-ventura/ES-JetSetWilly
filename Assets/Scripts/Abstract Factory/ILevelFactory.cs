using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILevelFactory
{
    ISceneProperties GetSceneProperties();
    ISpawnProperties GetSpawnProperties();
}
