using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.IO;
using HuggingFace.API;

public class SpeechRecognition : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    private AudioClip clip;
    private byte[] bytes;
    public bool isRecording = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isRecording && Input.GetKeyDown(KeyCode.Space) == true)
        {
            StartRecording();
        }
        else if (isRecording &&
            (Input.GetKeyDown(KeyCode.Space) == false || Microphone.GetPosition(null) >= clip.samples)) //??
        {
            StopRecording();
        }
    }

    private void StartRecording()
    {
        clip = Microphone.Start(null, false, 30, 44100); // with the default device, non-looping, up to 30 seconds, at 44 khz
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
                writer.Write("fmt".ToCharArray());
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
        HuggingFaceAPI.AutomaticSpeechRecognition(bytes, response =>
        {
            text.text = response;
        }, error => {
            text.text = error;
        });
    }

    private void StopRecording()
    {
        var position = Microphone.GetPosition(null);
        Microphone.End(null);
        var samples = new float[position * clip.channels];
        clip.GetData(samples, 0);
        bytes = EncodeAsWAV(samples, clip.frequency, clip.channels);
        isRecording = false;
        SendRecording();
    }
}
