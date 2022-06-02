using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuMovement : MonoBehaviour
{
    public float delay = 0f;
    public float xEnd= 12.5f;
    public float xStart= -12.5f;
    public float xEndstred = 12.5f;
    public float xStartstred = -12.5f;
    public float time = 5f;
    public Transform pacman;
    public Transform pacmanstred;
    public Transform cerveny;
    public Transform oranzovy;
    public Transform ruzovy;
    public Transform modry;
    public Transform modrydruhy;
    public Transform modrystred;
    public Transform god;
    public Transform oci;
    
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(StartAnim());
    }
    IEnumerator StartAnim()
    {
        while (true) {
            //PRVE
            //Cesta Tam
            pacman.DOMove(new Vector2(xEnd, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = false;
            yield return new WaitForSeconds(delay);
            cerveny.DOMove(new Vector2(xEnd, cerveny.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);

            //Cesta s5
            cerveny.DOMove(new Vector2(xStart, cerveny.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            pacman.GetComponent<SpriteRenderer>().flipX = true;
            pacman.DOMove(new Vector2(xStart, pacman.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);

            //DRUHE
            ruzovy.DOMove(new Vector2(xEnd, ruzovy.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            pacman.DOMove(new Vector2(xEnd, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = false;
            yield return new WaitForSeconds(delay);
            cerveny.DOMove(new Vector2(xEnd, cerveny.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);

            //Cesta s5
            ruzovy.DOMove(new Vector2(xStart, ruzovy.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            pacman.GetComponent<SpriteRenderer>().flipX = true;
            pacman.DOMove(new Vector2(xStart, pacman.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            cerveny.DOMove(new Vector2(xStart, cerveny.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);


            modrystred.DOMove(new Vector2(xEndstred, modrystred.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            pacman.DOMove(new Vector2(xEnd, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = false;
            yield return new WaitForSeconds(time);

            modrystred.DOMove(new Vector2(xStart, modrystred.position.y), time).SetEase(Ease.Linear);
            modrystred.GetComponent<SpriteRenderer>().flipX = true;
            yield return new WaitForSeconds(delay);
            pacman.DOMove(new Vector2(xStart, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = true;
            yield return new WaitForSeconds(time);


            pacman.DOMove(new Vector2(xEnd, pacmanstred.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = false;
            yield return new WaitForSeconds(delay);
            modrystred.DOMove(new Vector2(xEndstred, modrystred.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            modrydruhy.DOMove(new Vector2(xEndstred, modrydruhy.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);

            pacman.DOMove(new Vector2(xStart, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = true;
            yield return new WaitForSeconds(delay);
            modrystred.DOMove(new Vector2(xStart, modrystred.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            modrydruhy.DOMove(new Vector2(xStart, modrydruhy.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);

            pacman.DOMove(new Vector2(xEnd, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = false; ;
            yield return new WaitForSeconds(delay);
            oci.DOMove(new Vector2(xEndstred, oci.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);


            pacman.DOMove(new Vector2(xStart, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = true;
            yield return new WaitForSeconds(delay);
            oci.DOMove(new Vector2(xStart, oci.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);


            pacman.DOMove(new Vector2(xEnd, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = false;
            yield return new WaitForSeconds(delay);
            cerveny.DOMove(new Vector2(xEnd, cerveny.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            modry.DOMove(new Vector2(xEnd, modry.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            ruzovy.DOMove(new Vector2(xEnd, ruzovy.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            oranzovy.DOMove(new Vector2(xEnd, oranzovy.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);

            pacman.DOMove(new Vector2(xStart, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = true;
            yield return new WaitForSeconds(delay);
            cerveny.DOMove(new Vector2(xStart, cerveny.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            modry.DOMove(new Vector2(xStart, modry.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            ruzovy.DOMove(new Vector2(xStartstred, ruzovy.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            oranzovy.DOMove(new Vector2(xStart, oranzovy.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(time);













            //tam
            god.DOMove(new Vector2(xEnd, god.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            pacman.DOMove(new Vector2(xEnd, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = false;
            yield return new WaitForSeconds(time);
            //s5
            god.DOMove(new Vector2(xStart, god.position.y), time).SetEase(Ease.Linear);
            yield return new WaitForSeconds(delay);
            god.GetComponent<SpriteRenderer>().flipX = true;
            pacman.DOMove(new Vector2(xStart, pacman.position.y), time).SetEase(Ease.Linear);
            pacman.GetComponent<SpriteRenderer>().flipX = true;
            yield return new WaitForSeconds(time);

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
