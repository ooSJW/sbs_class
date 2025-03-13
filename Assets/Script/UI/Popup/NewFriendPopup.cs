using UnityEngine;

public class NewFriendPopup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void AddNewFriend()
    {
        int story;
        StoryProgress progress;
        GameManager.Instance.prefsManager.LoadChapterInfo(out story, out progress);

        story++;

        GameManager.Instance.prefsManager.SaveChapterInfo(story, StoryProgress.Completed);

        GameManager.Instance.storyManager.DoNextStory();
        

        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
