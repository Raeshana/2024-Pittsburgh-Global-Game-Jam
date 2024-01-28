using System.IO;
using HuggingFace.API;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpeechRecognition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    public GameObject player;
    private PlayerController pc;

    private AudioClip clip;
    private byte[] bytes;
    public bool isRecording = false;
    public string recordedText;

    // Start is called before the first frame update
    void Start()
    {
        recordedText = "";
        //player = GameObject.FindGameObjectWithTag("Player");
        pc = player.GetComponent<PlayerController>();
    }

    // Update is called once per frame


    void Update()
    {
        if (!isRecording && Input.GetKey(KeyCode.Space) == true)
        {
            StartRecording();
        }
        else if (isRecording && Input.GetKey(KeyCode.Space) == false)
        //(Input.GetKeyDown(KeyCode.Space) == false || Microphone.GetPosition(null) >= clip.samples)) //??
        {
            StopRecording();
        }
    }

    private void StartRecording()
    {
        text.color = Color.yellow;
        text.text = "Recording...";
        clip = Microphone.Start(null, false, 10, 44100); // with the default device, non-looping, up to 30 seconds, at 44 khz
        isRecording = true;
    }

    private byte[] EncodeAsWAV(float[] samples, int frequency, int channels)
    {
        using (var memoryStream = new MemoryStream(44 + samples.Length * 2))
        {
            using (var writer = new BinaryWriter(memoryStream)) //preparing the audio
            {
                writer.Write("RIFF".ToCharArray());
                writer.Write(36 + samples.Length * 2);
                writer.Write("WAVE".ToCharArray());
                writer.Write("fmt ".ToCharArray());
                writer.Write(16);
                writer.Write((ushort)1);
                writer.Write((ushort)channels);
                writer.Write(frequency);
                writer.Write(frequency * channels * 2);
                writer.Write((ushort)(channels * 2));
                writer.Write((ushort)16);
                writer.Write("data".ToCharArray());
                writer.Write(samples.Length * 2);

                foreach (var sample in samples)
                {
                    writer.Write((short)(sample * short.MaxValue));
                }
            }
            return memoryStream.ToArray();
        }
    }

    private void SendRecording()
    {
        text.color = Color.yellow;
        text.text = "Sending...";
        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response =>
        {
            text.color = Color.white;
            text.text = response;
            recordedText = response;
            pc.IsPlayerLaughing(response);
        }, error =>
        {
            text.color = Color.black;
            text.text = error;
        });
    }

    private void StopRecording()
    {
        var position = Microphone.GetPosition(null);
        Microphone.End(null);
        var samples = new float[position * clip.channels];
        //Debug.Log(position);
        //Debug.Log(clip.channels);
        //Debug.Log(samples);
        clip.GetData(samples, 0);
        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        isRecording = false;
        SendRecording();
    }
}
