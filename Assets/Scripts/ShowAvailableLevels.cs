using Michsky.UI.ModernUIPack;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowAvailableLevels : MonoBehaviour
{

    [SerializeField] private GameLevels levels;
    [SerializeField] private HorizontalSelector _selector;
    [SerializeField] private Image _chosen;

    // Start is called before the first frame update
    void Start()
    {

        foreach(ScriptableLevel level in levels._levels)
        {

          
            _selector.CreateNewItem(level.name);
            _selector.defaultIndex = 0;
        }

        ChosenLevel(_selector.index);
    }

    public void ChosenLevel(int value)
    {
        string name = _selector.itemList[value].itemTitle;
        foreach(ScriptableLevel level in levels._levels)
        {
            if (level.name == name)
                _chosen.sprite = level._levelBanner;
            else
                continue;
        }
    }


}
