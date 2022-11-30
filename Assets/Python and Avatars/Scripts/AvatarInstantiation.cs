using System.Collections;
using System.Collections.Generic;
using Sunbox.Avatars;
using UnityEngine;

public class AvatarInstantiation : MonoBehaviour
{
    public Animator animator;
    public AvatarCustomization avatar;
    public Avatar femaleAvatar;
    public Avatar maleAvatar;

    private void Start()
    {
        animator.gameObject.SetActive(false);
        if(avatar.CurrentGender == 0)
        {
            animator.avatar = maleAvatar;
        }
        else
        {
            animator.avatar = femaleAvatar;
        }
        animator.gameObject.SetActive(true);
    }

}
