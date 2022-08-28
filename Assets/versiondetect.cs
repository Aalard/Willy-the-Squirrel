using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class versiondetect : MonoBehaviour
{
    public Text versionText;
    string version;
    private void Awake()
    {
        versionText.text = "v. " + Application.version;
    }
}
