using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StoryScriptItem
{
    public string Name;
    public string ID;
    public int Level;
    public List<string> body;
}

[Serializable]
public class StoryScriptList
{
    public List<StoryScriptItem> StoryScripts;
}