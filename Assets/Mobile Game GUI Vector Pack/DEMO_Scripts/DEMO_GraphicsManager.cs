using System.Collections.Generic;
using UnityEngine;

public class DEMO_GraphicsManager : MonoBehaviour {

    public GameObject update1View;
    public GameObject list1;
    public GameObject list2;
    public GameObject list3;

    [HideInInspector]
    public GameObject mCurrentEnableObject;
    [HideInInspector]
    public GameObject mPrevEnableObject;
    [HideInInspector]
    public GameObject mNextEnableObject;

    private List<GameObject> screens = new List<GameObject>();
    private int screenIterator = 0;

    // Use this for initialization
    void Start () {
        screens.Add(list1);
        screens.Add(list2);
        screens.Add(list3);

        SetEnableObjects(screenIterator);
    }

    public void EnableUpdate_1_View(bool enable) {
        update1View.SetActive(enable);
    }

    public void GetNextScene() {
        mCurrentEnableObject.SetActive(false);
        mNextEnableObject.SetActive(true);
        ChangeScreenIteratorValue("+");
        SetEnableObjects(screenIterator);
    }

    public void GetPrevScene() {
        mCurrentEnableObject.SetActive(false);
        mPrevEnableObject.SetActive(true);
        ChangeScreenIteratorValue("-");
        SetEnableObjects(screenIterator);
    }

    public void GetCurrentScene() {
        SetEnableObjects(screenIterator);
        mCurrentEnableObject.SetActive(true);
    }

    private void SetEnableObjects(int arrayIndex) {
        mCurrentEnableObject = screens[arrayIndex].GetComponent<DEMO_NavigationInformation>().currentEnableObject;
        mPrevEnableObject = screens[arrayIndex].GetComponent<DEMO_NavigationInformation>().prevEnableObject;
        mNextEnableObject = screens[arrayIndex].GetComponent<DEMO_NavigationInformation>().nextEnableObject;
    }

    private void ChangeScreenIteratorValue(string operatorSymbol) {
        switch (operatorSymbol) {
            case "+":
                if (screenIterator >= (screens.Count - 1)) {
                    screenIterator = screenIterator;
                } else {
                    screenIterator++;
                }
                break;
            case "-":
                if (screenIterator <= 0) {
                    screenIterator = 0;
                    if (screens[screenIterator] == list1) {
                        update1View.SetActive(false);
                    }
                } else {
                    screenIterator--;
                }
                break;
            default:
                if (screenIterator >= (screens.Count - 1)) {
                    screenIterator = screenIterator;
                } else {
                    screenIterator++;
                }
                break;
        }
    }
}
