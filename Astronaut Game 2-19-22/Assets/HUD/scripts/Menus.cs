using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Menus : MonoBehaviour
{
    public bool menusIsOpen;// = false;
    public MenusType currentMenusType;// = MenusType.Inventory;
    public GameObject menusObject;

    public GameObject invObject;
    public GameObject questObject;
    public GameObject skillsObject;

    public Button arrowLeft;
    public Button arrowRight;

    private GameObject[] menus;
    private int currentPage;
    private Dictionary<int, MenusType> dict;

    // Start is called before the first frame update
    void Start()
    {
        menusIsOpen = false;
        currentMenusType = MenusType.Inventory;
        currentPage = 0;
        menus = new GameObject[3];
        menus[0] = invObject;
        menus[1] = questObject;
        menus[2] = skillsObject;

        dict = new Dictionary<int, MenusType>();
        dict.Add(0, MenusType.Inventory);
        dict.Add(1, MenusType.Quests);
        dict.Add(2, MenusType.Skills);

        arrowLeft.onClick.AddListener(MenuPreviousPage);
        arrowRight.onClick.AddListener(MenuNextPage);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
     * Opens the menu of the menu page type. 
     * Calling this while the menu type is already open results 
     * in the menu closing
     */
    public void OpenMenus(MenusType menusType = MenusType.Inventory)
    {
        
        if (menusIsOpen && currentMenusType == menusType)
        {
            menusIsOpen = false;
            menusObject.SetActive(menusIsOpen);
            invObject.SetActive(menusIsOpen);
            questObject.SetActive(menusIsOpen);
            skillsObject.SetActive(menusIsOpen);
        }
        else
        {
            currentMenusType = menusType;
            menusIsOpen = true;
            menusObject.SetActive(menusIsOpen);

            if (menusType == MenusType.Inventory)
            {
                EnableMenus(invObject);
                currentPage = 0;
            }
            else if (menusType == MenusType.Quests)
            {
                EnableMenus(questObject);
                currentPage = 1;
            }
            else if (menusType == MenusType.Skills)
            {
                EnableMenus(skillsObject);
                currentPage = 2;
            }
            else if (menusType == MenusType.Character)
            {
                currentPage = 3;
            }
            else if (menusType == MenusType.Stats)
            {
                currentPage = 4;
            }
        }
        
    }

    private void EnableMenus(GameObject obj)
    {
        int length = menus.Length;
        for(int i = 0; i < length; i++)
        {
            menus[i].SetActive(false);
        }

        obj.SetActive(true);
        
    }

    private void MenuPreviousPage()
    {
        menus[currentPage].SetActive(false);

        if (currentPage == 0)
        {
            currentPage = menus.Length - 1;
        }
        else
        {
            currentPage -= 1;
        }

        OpenMenus(dict[currentPage]);
    }

    private void MenuNextPage()
    {
        menus[currentPage].SetActive(false);

        if (currentPage == menus.Length - 1)
        {
            currentPage = 0;
        }
        else
        {
            currentPage += 1;
        }

        OpenMenus(dict[currentPage]);
    }
}
