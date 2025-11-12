using Unity.VisualScripting;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    [SerializeField] private Brick Brick;
    [SerializeField] private int hitTothisObject = 0;
    [SerializeField] private ParticleSystem breakParticle, breakBoxParticle;
    
    private void OnCollisionEnter(Collision collision)
    {
        hitTothisObject += 1;
        if (Brick != null)
        {
            if (hitTothisObject == Brick.hitToDestroy)
            {
                this.gameObject.SetActive(false);//colocar retraso
                breakParticle.Play();
            }
            /*else 
            {
                if (Brick.brickType.Equals("glassBrick") && hitTothisObject == 1)
                {
                    if (this.transform.GetChild(0).gameObject != null) 
                    {
                        this.transform.GetChild(0).gameObject.SetActive(false);
                        if (breakBoxParticle != null)
                        {
                            breakBoxParticle.Play();
                        }
                    }
                }
                else if (Brick.brickType.Equals("brickBrick") && hitTothisObject == 2)
                {
                    if (this.transform.GetChild(0).gameObject != null)
                    {
                        this.transform.GetChild(0).gameObject.SetActive(false);
                        if (breakBoxParticle != null)
                        {
                            breakBoxParticle.Play();
                        }
                    }
                }
            }*/
        }
    }
}
