using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SanityBarHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameManagerObject;
    [SerializeField]
    private Color _sanityBarColour;

    [SerializeField]
    private Slider _sanitySlider;

    private DataHandler dataHandler;

    private GameManager _gameManager;
    
    private void Awake()
    {
        _gameManager = _gameManagerObject.GetComponent<GameManager>();
        dataHandler = _gameManagerObject.GetComponent<DataHandler>();
    }

    public void UpdateSanity()
    {
        _sanitySlider.value = dataHandler.GetCurrentSanity();
    }

}
