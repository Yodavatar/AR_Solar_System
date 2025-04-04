using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QCM : MonoBehaviour
{
    public TMP_Text timerText; // Texte du timer
    public TMP_Text questionText; // Texte de la question
    public Button[] answerButtons; // Boutons des r�ponses
    public TMP_Text[] answerTexts; // Textes des r�ponses (TMP)
    public TMP_Text scoreText; // Texte du score



    private float timeLeft = 60f; // 1min (60 secondes)
    private bool isTimerRunning = true;
    private int score = 0; // Score du joueur
    private int currentQuestionIndex = 0; //index de la question actuel



    private Question[] questions = new Question[]
    {
        new Question("Que représente la vitesse de rotation d'une planète sur elle-même ?", new string[] { "La vitesse à laquelle la planète tourne autour du Soleil.", "La vitesse à laquelle la planète se déplace dans l'espace.", "La vitesse à laquelle la planète tourne autour de son axe.", "La vitesse à laquelle les satellites de la planéte orbitent autour d'elle." }, 2),
        new Question("C'est quoi une planète gazeuse ?", new string[] { "Une planète composée principalement de roches et de métaux.", "Une planète qui n'a pas de noyau solide.", "Une planète dont la surface est recouverte d'eau.", "Une planète composée principalement d'hydrogène et d'hélium, avec une épaisse atmosphère." }, 3),
        new Question("Quelle est le meilleur moyen mémnotechnique pour se rappeler de l'ordre des planètes du systême solaire ?", new string[] { "Utiliser les premières lettres des planètes pour former un mot.", "Se rappeler des couleurs associées à chaque planète.", "Utiliser une chanson ou une comptine.", "Se rappeler des distances relatives entre les planètes." }, 0),
        new Question("De quelle couleur est Neptune ?", new string[] { "Rouge", "Bleu", "Vert", "Jaune" }, 1),
        new Question("Pourquoi Mercure n'a-t-elle pas de satellites naturels ?", new string[] { "Parce que Mercure est trop proche du Soleil pour que des satellites puissent se former.", "Parce que Mercure est trop petite pour attirer des satellites.", "Parce que les forces de marée du Soleil empéchent la formation de satellites.", "Parce que Mercure a une atmosphère trop dense pour permettre la formation de satellites." }, 2),
        new Question("Quelle est la particularité de la rotation de Vénus sur elle-même ?", new string[] { "Elle tourne dans le même sens que la plupart des autres planètes.", "Elle tourne très rapidement sur elle-même.", "Elle a une rotation rétrograde, c'est-à-dire dans le sens opposé à la plupart des autres planétes.","Elle ne tourne pas sur elle-même."}, 2),
        new Question("Pourquoi Mars est-elle appelée la planète rouge ?", new string[] { " Parce qu'elle est recouverte de lave en fusion.", "Parce qu'elle est composée principalement de fer.", "Parce que la présence d'oxyde de fer (rouille) sur sa surface lui donne une couleur rougeatre.", "Parce qu'elle reflète la lumière rouge du Soleil."}, 2),
        new Question("Quelle est la caractéristique principale de la Grande Tache Rouge sur Jupiter ?", new string[] { "C'est une zone de végétation dense.", "C'est une tempète anticyclonique qui persiste depuis des siècles.", "C'est une région riche en minéraux.", "C'est une zone de glace."}, 1),
        new Question("Pourquoi Saturne est-elle célébre ?", new string[]{"Pour ses volcans actifs.", "Pour ses anneaux composés de glace et de poussière.", "Pour sa couleur bleue distinctive.", "Pour sa proximité avec la Terre."}, 1),
        new Question("Quelle est la principale différence entre Uranus et Neptune ?", new string[] {"Uranus a une atmosphère plus épaisse que Neptune.", "Neptune est plus éloignée du Soleil qu'Uranus.", "Uranus a une rotation rétrograde, tandis que Neptune a une rotation normale.", "Uranus est plus grande que Neptune."}, 1),
        new Question("Quel est le nom de la première personne à avoir marché sur la Lune ?", new string[] { "Buzz Aldrin", "Neil Armstrong", "Yuri Gagarin", "Alan Shepard" }, 1),
        new Question("Combien de planètes naines sont officiellement reconnues dans notre système solaire ?", new string[] { "3", "5", "7", "9" }, 1),
        new Question("Quel est le plus grand satellite naturel de Saturne ?", new string[] { "Titan", "Encelade", "Mimas", "Japet" }, 0)
    };


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Score : 0"; // Affichage du score au d�but
        ShowQuestion();
        StartCoroutine(TimerCoroutine());
    }
    
    void ShowQuestion()
    {
        if (currentQuestionIndex < questions.Length)
        {
            questionText.text = questions[currentQuestionIndex].text;
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerTexts[i].text = questions[currentQuestionIndex].answers[i];
                int index = i;
                answerButtons[i].onClick.RemoveAllListeners(); //  Nettoie les anciens �v�nements
                answerButtons[i].onClick.AddListener(() => OnAnswerSelected(index)); //  Ajoute le bon �v�nement

                // Ajuster la taille du texte de la r�ponse en fonction du nombre de caract�res
                AjusterTailleTexte(answerTexts[i]);
            }


        }
        else
        {
            EndGame(2);//plus de question
        }
    }



    void OnAnswerSelected(int index)
    {

        if (index == questions[currentQuestionIndex].correctAnswer)
        {

            score++; // +1 au score
            timeLeft += 15f; // +15 sec si bonne r�ponse
        }
        else
        {
            timeLeft -= 10f; // -15 secondes si mauvaise r�ponse
        }


        scoreText.text = "Score : " + score; // Mise � jour du score
        currentQuestionIndex++;

        if (currentQuestionIndex < questions.Length)
        {
            ShowQuestion();
        }
        else
        {
            EndGame(2);//plus de question
        }
    }



    IEnumerator TimerCoroutine()
    {
        while (isTimerRunning)
        {
            if (timeLeft > 0)
            {
                timeLeft -= Time.deltaTime;
                timerText.text = "Temps : " + Mathf.Ceil(timeLeft).ToString();
            }
            else
            {
                EndGame(1); //plus de temps
            }
            yield return null;
        }
    }

    void EndGame(int endcondition)
    {

        isTimerRunning = false;
        if (endcondition == 1)
        {
            timerText.text = "Temps écoulé !";
        }
        if (endcondition == 2)
        {
            timerText.text = "fin des questions";
        }
        questionText.text = "Fin du jeu ! Score final : " + score;
        scoreText.text = "";


        foreach (Button bouton in answerButtons)
        {
            bouton.gameObject.SetActive(false); // D�sactiver les boutons
        }
    }


    private void AjusterTailleTexte(TMP_Text texte)
    {
        string texteReponse = texte.text;
        texte.fontSize =40;

        // Ajuste la Taille du Texte enf onction de sa longueur
        if (texteReponse.Length >= 70 && texteReponse.Length <= 85)
        {
            texte.fontSize -= 3; // R�duire la taille de 3 points
        }
        else if (texteReponse.Length > 85 && texteReponse.Length <= 100)
        {
            texte.fontSize -= 6; // R�duire la taille de 6 points 
        }
    }

    private class Question
    {
        public string text;
        public string[] answers;
        public int correctAnswer;

        public Question(string text, string[] answers, int correctAnswer)
        {
            this.text = text;
            this.answers = answers;
            this.correctAnswer = correctAnswer;
        }
    }
}
