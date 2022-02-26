using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using System.Linq;

public class StoryScriptManager
{
    private static StoryScriptManager instance;

    protected List<StoryScriptItem> mStoryScriptList = null;

    public static StoryScriptManager GetInstance()
    {
        if (instance == null)
        {
            ////lock (_lock)
            ////{
            //    if (instance == null)
            //    {
            instance = new StoryScriptManager();
            instance.Init();
            //    }
            ////}
        }
        return instance;
    }

    private void Init()
    {
        mStoryScriptList = new List<StoryScriptItem>();
        //mUserAdvancedInformationList = new List<UserAdvancedInformationItem>();

        JsonLoadToStoryScript();
        StoryScriptListShort(true);
    }

    private void JsonLoadToStoryScript()
    {
        if (File.Exists(GlobalConfig.GetFilePath("StoryScripts")))
        {
            mStoryScriptList = JsonOperation.ReadFile<StoryScriptList>("StoryScripts").StoryScripts;
        }
        else
        {
            JsonOperation.FirstLoad("StoryScripts");
            mStoryScriptList = JsonOperation.ReadFile<StoryScriptList>("StoryScripts").StoryScripts;

        }
    }


    private void StoryScriptSaveToJson()
    {
        StoryScriptList currentBasic = new StoryScriptList();

        currentBasic.StoryScripts = mStoryScriptList;

        JsonOperation.WriteFile<StoryScriptList>("StoryScripts", currentBasic);

    }


    public void AddItem(StoryScriptItem item)
    {
        Debug.Log("AddItem " + item.Name);
        mStoryScriptList.Add(item);
        StoryScriptListShort(true);
        StoryScriptSaveToJson();

    }


    public void DelItem(string ID)
    {
        for (int i = 0; i < mStoryScriptList.Count; i++)
        {

            Debug.Log("DelItem");
            if (mStoryScriptList[i].ID == ID)
            {
                Debug.Log("已找到");
                mStoryScriptList.Remove(mStoryScriptList[i]);
                StoryScriptListShort(true);
            }
            else { Debug.Log("没找到"); }
        }
        StoryScriptSaveToJson();
    }


    public void UpdateItem(string ID, StoryScriptItem StoryScript)
    {
        Debug.Log("UpdateItem");
        for (int i = 0; i < mStoryScriptList.Count; i++)
        {
            if (mStoryScriptList[i].ID == ID)
            {
                mStoryScriptList[i] = StoryScript;
            }
        }


        StoryScriptSaveToJson();
    }


    public StoryScriptItem SearchStoryScriptItem(string ID)
    {
        StoryScriptItem currentBasicInformation = new StoryScriptItem();

        for (int i = 0; i < mStoryScriptList.Count; i++)
        {
            if (mStoryScriptList[i].ID == ID)
            {
                currentBasicInformation = mStoryScriptList[i];
            }
        }
        return currentBasicInformation;
    }

    public void StoryScriptListShort(bool isOrderByDescending)
    {
        if (isOrderByDescending)
        {
            mStoryScriptList = mStoryScriptList.OrderByDescending(a => a.ID).ToList();

        }
        else
        {
            mStoryScriptList = mStoryScriptList.OrderBy(a => a.ID).ToList();
        }
    }


    public List<StoryScriptItem> GetmStoryScriptList()
    {
        return mStoryScriptList;
    }

}
