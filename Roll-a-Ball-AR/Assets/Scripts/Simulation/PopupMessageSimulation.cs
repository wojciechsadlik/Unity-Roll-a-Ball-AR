using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupMessageSimulation : MonoBehaviour
{

    public GameObject ui;

    public void Open(string inventoryStuffName, string message)
    {
        ui.SetActive(!ui.activeSelf);

        if (ui.activeSelf)
        {
            Text textObject = ui.gameObject.GetComponentInChildren<Text>();
            textObject.text = message;

            Time.timeScale = 0f;
        }
    }
    public void Close()
    {
        ui.SetActive(!ui.activeSelf);
        if (!ui.activeSelf)
        {
            Time.timeScale = 1f;
        }
    }
    //You need to have Folder Resources/InvenotryItems
    public Texture TakeInvenotryCollecition(string LoadCollectionsToInventory)
    {
        Texture loadedGO = Resources.Load("InvenotryItems/" + LoadCollectionsToInventory, typeof(Texture)) as Texture;
        return loadedGO;
    }
}