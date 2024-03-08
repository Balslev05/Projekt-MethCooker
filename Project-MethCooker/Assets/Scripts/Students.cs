using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class Students : MonoBehaviour
{
    public DummeSpørgesmål[] muligeSpørgsmål;
    public GameObject morten;
    [Header("Assignebels")] 
    public DummeSpørgesmål ElevensSpørgesmål;
    public GameObject udråbstegn;
    [FormerlySerializedAs("tavel")] [Header("TavelDialog")] 
    public GameObject Target;
    public GameObject spørgesmålTitel;
    public GameObject[] SvarUI;
    private Repetation trust;
    private GameObject Tavel;
    private GameObject spørgsmål;
   
    [Header("stats")]
    public float Studentsraisehands;
    public float Studentlifetime;
    public bool handisraised;

    // Start is called before the first frame update

    private void Awake()
    {
        udråbstegn.SetActive(false);
    }

    void Start()
    {
         int r = Random.Range(0, muligeSpørgsmål.Length);
         Debug.Log(r);
         ElevensSpørgesmål = muligeSpørgsmål[r];
    }

    // Update is called once per frame
    void Update()
    {
        morten = GameObject.FindWithTag("Player");
        spørgesmålTitel = GameObject.FindWithTag("Titel");
        SvarUI = GameObject.FindGameObjectsWithTag("Svar");
        Target = GameObject.FindWithTag("tavel");
        spørgsmål = GameObject.FindWithTag("spørgsmål");
        
        Studentlifetime += Time.deltaTime;

        if (Studentlifetime > 30 && morten.GetComponent<PlayerMovement>().isTeaching == false)
        {
            trust.currentTrust -= 1;
            Destroy(gameObject);
        }
        if (Studentlifetime > Studentsraisehands)
        {
            Vector3 walkdirection =Target.transform.position - transform.position;
            walkdirection = walkdirection.normalized;
            transform.position += walkdirection * Time.deltaTime;
        }
        
        if( Vector2.Distance(transform.position,Target.transform.position) < 1.5f)
        {
            handisraised = true;    
            udråbstegn.SetActive(true);
        }
    }

    public void Spøgsmål()
    {
        print("Yeay");
        spørgesmålTitel.transform.localScale = new Vector3(1,1,1);
        
        spørgsmål.GetComponent<TMP_Text>().text = ElevensSpørgesmål.Spørgesmål;
        
        for (int i = 0; i < ElevensSpørgesmål.Svarmuligheder.Length; i++)
        {
            if (ElevensSpørgesmål.Rigtignummer == i)
            {
                SvarUI[i].GetComponent<TMP_Text>().text = ElevensSpørgesmål.Svarmuligheder[i];
                SvarUI[i].gameObject.GetComponent<Button>().correcanware = true;
            }
            else
            {                
                SvarUI[i].gameObject.GetComponent<Button>().correcanware = false;
                SvarUI[i].GetComponent<TMP_Text>().text = ElevensSpørgesmål.Svarmuligheder[i];
            }
        }
    }


    public void setSetting(Transform Target, Repetation morten)
    {
        print("woaw");
        this.Target = Target.gameObject;
        trust = morten;
    }



}
