using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PageSystem : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject [] pages;
    private int _currentPage;
    void Start()
    {
        pages[0].SetActive(true);
        _currentPage = 0;
    }

    // Update is called once per frame
    public void OnNext(){
        
        pages[_currentPage].SetActive(false);
        _currentPage = Mathf.Min(pages.Length-1, _currentPage+1);
        if(_currentPage == pages.Length-1) SoundEffectSystem.Instance.playEndSong();
        pages[_currentPage].SetActive(true);
    }
    public void OnPrevious(){
        
        pages[_currentPage].SetActive(false);
        _currentPage = Mathf.Max(0, _currentPage-1);
        pages[_currentPage].SetActive(true);
    }
}
