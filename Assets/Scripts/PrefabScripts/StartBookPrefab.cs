using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class StartBookPrefab : MonoBehaviour
{
    [SerializeField]
    private Button btn;
    public void UpdateUI(UnityAction action)
    {
        btn.onClick.AddListener(action);
    }
}