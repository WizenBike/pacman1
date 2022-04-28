using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    public MovemantControler mc;
    public Vector2 objectyve;
    public GameObject player;
    bool haveNode = false;
    public float scatterCooldown;
    public float scatterDuration = 1000;
    public float time;
    public float timeScatter;
    public bool flipped;
    public GameObject homePod;
    public GameObject eyes;
    public GameObject body;
    public GameObject startNode;
    public GameObject redNode;
    public float gainSpeedOnDeath;
    public int scoreOnCatch;
    public float scaredDuration;
    public float scaredTime;
    private Animator _anim; 
    public GameObject pinkNode;
    public GameObject blueNode;
    public GameObject orangeNode;



    public GameObject finder;
    

    public enum GhostTipes
    {
        red,
        pink,
        blue,
        orange,
    }
    public GhostTipes gostTipe;
    public enum GhostStates
    {
        scatter,
        chase,
        scared,
        goHome,
        inHome,
        goOutOfHome,
    }
    public GhostStates ghostState; 

    public enum Directions
    {
        Up,
        Down,
        Right,
        Left
    }

    private void Awake()
    {
        mc = gameObject.GetComponent<MovemantControler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
        print("Dopièíííííííí");
        PayerControler.Instance.CollideWithPower += () => {
            if (ghostState != GhostStates.goHome && ghostState != GhostStates.goOutOfHome)
            {
                print("Poooomeeee kokot");
                _anim.SetBool("isScared", true);
                ghostState = GhostStates.scared;
                scaredTime = scaredDuration;
            }
           
            
        };
        
    }


    protected virtual void goHome()
    {

    }

    protected virtual void goOutOfHome()
    {

    }

    protected virtual void SwitchToScatter()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        print(time);
        SwitchToScatter();
            
           if(ghostState != GhostStates.scared )
           {
            flipped = false;

           }
           if (ghostState == GhostStates.scared)
           {
            time = 0;
            timeScatter = 0;
           }
        
        if (ghostState == GhostStates.goOutOfHome)
        {
            goOutOfHome(); 

        }
        if (ghostState == GhostStates.goHome)
        {
           
            goHome();         

        }
        if(ghostState == GhostStates.scared)
        {
            print(scaredTime);
            scaredTime -= Time.deltaTime;
            if (scaredTime <= 0) 
            {
                _anim.SetBool("isScared", false);
                ghostState = GhostStates.chase;
            }
        }
       



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (startNode == null && collision.gameObject.CompareTag("Gulicka"))
        {
            print("CURENT NODEEEEEEE");

            startNode = collision.gameObject;
            mc.currentNode = startNode;

        }


        if (ghostState == GhostStates.scared && collision.gameObject.CompareTag("Player"))
        {
            _anim.SetBool("isScared", false);
            mc.speed *= gainSpeedOnDeath;
            ghostState = GhostStates.goHome;
            Spawn.score += scoreOnCatch;
            body.SetActive(false);
            
        }
    }
    public Directions GetDirections(GameObject leftNode, GameObject rightNode, GameObject upNode, GameObject downNode)
    {
        Dictionary<Directions, float> dirs = new Dictionary<Directions, float>();

        //GameObject[] sides = new GameObject[] { leftNode, rightNode, upNode, downNode };

        if (leftNode != null && mc.direction != "right")
        {
            dirs.Add(Directions.Left, Vector2.Distance(leftNode.transform.position, objectyve));
        }
        if (rightNode != null && mc.direction != "left")
        {
            dirs.Add(Directions.Right, Vector2.Distance(rightNode.transform.position, objectyve));
        }
        if (upNode != null && mc.direction != "down")
        {
            dirs.Add(Directions.Up, Vector2.Distance(upNode.transform.position, objectyve));
        }
        if (downNode != null && mc.direction != "up")
        {
            dirs.Add(Directions.Down, Vector2.Distance(downNode.transform.position, objectyve));
        }

        float closestDir = float.MaxValue;

        foreach (KeyValuePair<Directions, float> dictionaryItem in dirs) {

            closestDir = Mathf.Min(closestDir, dictionaryItem.Value);

        }

        foreach (KeyValuePair<Directions, float> dictionaryItem in dirs)
        {
            if (dictionaryItem.Value == closestDir)
            {
                return dictionaryItem.Key;
            }
               

        }

        return Directions.Down;



    }

    private string Convertor(Directions dirsEnums)
    {
        if (dirsEnums == Directions.Down)
        {
            return "down";
        }
        else if (dirsEnums == Directions.Left)
        {
            return "left";
        }
        else if (dirsEnums == Directions.Right)
        {
            return "right";
        }
        else if (dirsEnums == Directions.Up)
        {
            return "up";
        }
        else
        {
            return null;
        }
    }
    
    public string FlippedDir(string currentDir)
    {
        if (currentDir== "up")
        {
            return "down";
        }
        if (currentDir == "right")
        {
            return "left";
        }
        if (currentDir == "left")
        {
            return "right";
        }
        if (currentDir == "down")
        {
            return "up";
        }
        else
        {
            return null;
        }
    }

    public string RandScaredDir(GameObject leftNode, GameObject rightNode, GameObject upNode, GameObject downNode)
    {
        List<Directions> dirsToChose = new List<Directions>();
        if (leftNode != null && mc.direction != "right" )
        {
            dirsToChose.Add(Directions.Left);
        }
        if (rightNode != null && mc.direction != "left")
        {
            dirsToChose.Add(Directions.Right);
        }
        if (upNode != null && mc.direction != "down")
        {
            dirsToChose.Add(Directions.Up);
        }
        if (downNode != null && mc.direction != "up" )
        {
            dirsToChose.Add(Directions.Down);
        }
        Directions randEnum = dirsToChose[Random.Range(0,dirsToChose.Count)];
        string dir = Convertor(randEnum);
        return dir;

    }

    
    public string getBestTrajectory(GameObject leftNode, GameObject rightNode , GameObject upNode, GameObject downNode)
    {
        Directions closestDir = GetDirections(leftNode, rightNode, upNode, downNode);
        if (ghostState == GhostStates.chase)
        {
            objectyve = PlayerPos(player);
            return Convertor(closestDir);
        }
        else if (ghostState ==  GhostStates.scatter)
        {
            
            
            objectyve = finder.transform.position;
            return Convertor(closestDir);
        }
        else if( ghostState == GhostStates.scared )
        {   
            if(!flipped)
            {
                flipped = true;
                string flip = FlippedDir(mc.direction);
                return flip;
            }
            return RandScaredDir(leftNode, rightNode, upNode, downNode);
        }
        else if (ghostState == GhostStates.goHome)
        {


          
            
                objectyve = startNode.transform.position;
                return Convertor(closestDir);
             
           
            
            
            
        }else if (ghostState == GhostStates.goOutOfHome)
        {
            
        }
        else
        {
            objectyve = PlayerPos(player);
            return Convertor(closestDir);
        }

        objectyve = PlayerPos(player);
        return Convertor(closestDir);





    }

    protected virtual Vector3 PlayerPos(GameObject Player)
    {
        return player.transform.position;
    }

}
