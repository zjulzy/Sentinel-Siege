
using UnityEngine;
using UnityEngine.UI;

public class TurrentItem : MonoBehaviour
{
    public int turrentIndex;
    private BuildManager _buildManager;
    private Color _color;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
        _color = GetComponentInChildren<Image>().color;
    }

    private void Click()
    {
        _buildManager = BuildManager.instance;
        if (_buildManager.currentTurrentId == turrentIndex)
        {
            _buildManager.currentTurrentId = -1;
            Deactivate();
        }
        else
        {
            if (_buildManager.currentTurrentId != -1)
            {
                GetComponentInParent<ShopPanel>().DeactiveAll();
            }

            _buildManager.currentTurrentId = turrentIndex;
            Activate();
        }
    }

    public void Activate()
    {
        GetComponentInChildren<Image>().color = Color.yellow;
    }

    public void Deactivate()
    {
        GetComponentInChildren<Image>().color = _color;
    }
}
