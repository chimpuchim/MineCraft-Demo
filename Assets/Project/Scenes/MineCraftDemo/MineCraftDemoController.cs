using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SS.View;

public class MineCraftDemoController : Controller
{
    public const string MINECRAFTDEMO_SCENE_NAME = "MineCraftDemo";

    public override string SceneName()
    {
        return MINECRAFTDEMO_SCENE_NAME;
    }
}