using Unity.VisualScripting;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private Brick Brick;
    [SerializeField] private int hitTothisObject = 0;
    [SerializeField] private ParticleSystem breakParticle, breakBoxParticle;
    [SerializeField] private AudioClip sfxGlassBoxDestroy, sfxBrickBoxDestroy;
    [SerializeField] private GameObject LevelController;
    private LevelController levelcont;

    private void Start()
    {
        hitTothisObject = 0;
        levelcont = LevelController.GetComponent<LevelController>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        hitTothisObject += 1;
        if (Brick != null)
        {
            if (hitTothisObject == Brick.hitToDestroy)
            {
                //this.gameObject.SetActive(false);//colocar retraso
                if (Brick.sfxDestroy != null)
                {
                    AudioManager.Instance.PlaySFX(Brick.sfxDestroy);
                }
                Destroy(this.gameObject, 0.2f);
                //Brick.SumPoints(levelcont.score);
                levelcont.BrickWasDestroyed(Brick.pointsToAdd);
                breakParticle.Play();
            }
            else 
            {
                if ((Brick.brickType == Brick.BrickType.glassBrick) && hitTothisObject == 1)
                {
                    Debug.Log(this.transform.GetChild(0).gameObject.name);
                    if (this.transform.GetChild(0).gameObject != null) 
                    {
                        this.transform.GetChild(0).gameObject.SetActive(false);
                        if (breakBoxParticle != null)
                        {
                            breakBoxParticle.Play();
                        }
                        if (sfxGlassBoxDestroy != null)
                        {
                            AudioManager.Instance.PlaySFX(sfxGlassBoxDestroy);
                        }
                    }
                }
                if ((Brick.brickType == Brick.BrickType.brickBrick) && hitTothisObject == 2)
                {
                    Debug.Log(this.transform.GetChild(0).gameObject.name);
                    if (this.transform.GetChild(0).gameObject != null)
                    {
                        this.transform.GetChild(0).gameObject.SetActive(false);
                        if (breakBoxParticle != null)
                        {
                            breakBoxParticle.Play();
                        }
                        if (sfxBrickBoxDestroy != null)
                        {
                            AudioManager.Instance.PlaySFX(sfxBrickBoxDestroy);
                        }
                    }
                }
            }
        }
    }
}
