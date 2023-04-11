using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalView : MonoBehaviour
{
    [SerializeField]
    private AnimalNames _name;

    [SerializeField]
    private GameObject _selectButtonUI;

    public AnimalNames Name
    {
        get { return _name; }
        set { _name = value; }
    }


    public void SelectedByPlayer()
    {
        _selectButtonUI.SetActive( true);
    }

    public void UnSelectedByPlayer()
    {
        _selectButtonUI.SetActive(false);
    }

}
