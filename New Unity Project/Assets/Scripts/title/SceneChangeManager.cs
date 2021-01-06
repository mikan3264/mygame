using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public sealed class SceneChangeManager : SingletonMonoBehaviour<SceneChangeManager>
{
    string next_scene_name = null;
    public Image fadeImage;
    Sequence seq, seq1;
    public CanvasGroup end;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(this);
	}
	
    public void ChangeSceneGame(string name)
    {
        if (seq == null && seq1 == null)
        {
            next_scene_name = name;
            //SceneManager.LoadScene(name);

            seq = DOTween.Sequence()
                .InsertCallback(0, () => {
                    DOTween.ToAlpha(
                    () => fadeImage.color,
                    color =>
                    {
                        fadeImage.color = color;
                    },
                    1.0f,
                    1.0f
                    );
                })
                .InsertCallback(0, () => {
                    end.DOFade(0.0f, 1.0f);
                })
                .InsertCallback(1.0f, () =>
                {
                    seq1 = DOTween.Sequence()
                    .AppendCallback(() =>
                    {
                        SceneManager.LoadScene(next_scene_name);
                    })
                    .AppendCallback(() =>
                    {
                        DOTween.ToAlpha(
                        () => fadeImage.color,
                        color =>
                        {
                            fadeImage.color = color;
                        },
                        0.0f,
                        1.0f
                        );
                    }).OnComplete(() => { seq1.Kill(); }).OnKill(() => { seq1 = null; });
                }).OnComplete(()=> { seq.Kill(); }).OnKill(() => { seq = null; });
        }

    }
}
