using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] TMP_Text scoreLable;
    [SerializeField] SettingsPopup settingsPopup;

    private int _score;

    private void OnEnable()
    {
        Messenger.AddListener(GameEvents.ENEMY_HIT, OnEnemyHit);
    }

    private void OnDisable()
    {
        Messenger.RemoveListener(GameEvents.ENEMY_HIT, OnEnemyHit);
    }
    private void OnEnemyHit()
    {
        _score += 1;
        scoreLable.text = _score.ToString();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        _score = 0;
        scoreLable.text = _score.ToString();
        scoreLable.text = _score.ToString();
        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update()
    {
        //scoreLable.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings(){
        Debug.Log("Opening Settings...");
        settingsPopup.Open();
    }

}
