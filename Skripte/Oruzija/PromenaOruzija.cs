using UnityEngine;

public class PromenaOruzija : MonoBehaviour
{
    public int IzabranoOruzije = 0;

    // Start is called before the first frame update
    void Start()
    {
        IzaberiOruzije();
    }

    // Update is called once per frame
    void Update()
    {
        int ProsloOruzije = IzabranoOruzije;

        // Check for mouse scroll input
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            ChangeWeapon(1);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            ChangeWeapon(-1);
        }

        // Check for Q key input
        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeWeapon(1);
        }

        if (ProsloOruzije != IzabranoOruzije)
        {
            IzaberiOruzije();
        }
    }

    void ChangeWeapon(int direction)
    {
        // Change the selected weapon index based on the direction
        IzabranoOruzije += direction;

        // Ensure the index stays within valid bounds
        if (IzabranoOruzije >= transform.childCount)
        {
            IzabranoOruzije = 0;
        }
        else if (IzabranoOruzije < 0)
        {
            IzabranoOruzije = transform.childCount - 1;
        }
    }

    void IzaberiOruzije()
    {
        int i = 0;
        foreach (Transform oruzije in transform)
        {
            if (i == IzabranoOruzije)
                oruzije.gameObject.SetActive(true);
            else
                oruzije.gameObject.SetActive(false);
            i++;
        }
    }
}
