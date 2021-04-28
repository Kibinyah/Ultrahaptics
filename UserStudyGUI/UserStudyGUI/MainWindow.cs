using System;
using Gtk;
using System.Diagnostics;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
//using System.Threading;
using System.Timers;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;


public partial class MainWindow : Gtk.Window
{
    int count = 0;
    int userid = 0;
    ComboBox cb;
    ComboBox cb2;
    HScale hs1;
    HScale hs2;
    String activeTest = "Pattern 1";
    String chosenPattern = "Pattern 1";
    String activePattern;
        //"Pattern 1";
    int timeLeft;
    Timer myTimer = new Timer();
    bool clickOnce = true;
    bool clickOnceSubmit = true;
    bool firstTime = true;

    double indexRange = 50;
    double middleRange = 50;

    //When on different machine, change filepaths to the new filepath on machine
    String pattern1 = "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards";
    String pattern2 = "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards";
    String pattern3 = "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1";
    String pattern4 = "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2";

    //Likewise change filepaths when on new machine
    ArrayList patterns = new ArrayList() {
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2",

                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2",

                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2",

                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2",

                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2",

                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2",

                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2",

                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2",

                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2",

                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesForwards",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesBackwards",
                           "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB1",
                            "/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/AmplitudeModulation_TwoLinesFB2"
    };

    public MainWindow() : base(Gtk.WindowType.Toplevel)
    {
        Build();
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        Application.Quit();
        a.RetVal = true;
    }


    protected void testButtonClicked(object sender, EventArgs e)
    {
        Process p = new Process();
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.CreateNoWindow = true;
        if (activeTest == "Pattern 1")
        {
            p.StartInfo.FileName = pattern1;
        }
        else if (activeTest == "Pattern 2")
        {     
            p.StartInfo.FileName = pattern2;
        }
        else if (activeTest == "Pattern 3")
        {
            p.StartInfo.FileName = pattern3;
        }
        else if (activeTest == "Pattern 4")
        {
            p.StartInfo.FileName = pattern4;
        }
        p.Start();
    }

    protected void SubmitButtonClicked(object sender, EventArgs e)
    {
        if (clickOnceSubmit == true)
        {
            clickOnceSubmit = false;
            clickOnce = true;
            string userId = userID.Text;
            //Change filepath when on new machine
            string textFile = @"/Users/kevinpan/Projects/UserStudyGUI/UserStudyGUI/ParticipantData/" + userId + ".txt";
            try
            {
                if (!File.Exists(textFile))
                {
                    StreamWriter sw = File.CreateText(textFile);
                    //sw.WriteLine("Hiiii");
                    sw.WriteLine("{0}.", count);
                    sw.WriteLine("True Pattern: {0}", activePattern);
                    sw.WriteLine("Chosen Pattern: {0}", chosenPattern);
                    sw.WriteLine(" ");
                    sw.Close();
                }
                else
                {
                    StreamWriter sw = File.AppendText(textFile);
                    sw.WriteLine("{0}.", count);
                    sw.WriteLine("True Pattern: {0}", activePattern);
                    sw.WriteLine("Chosen Pattern: {0}", chosenPattern);
                    if (count == 20 || count == 40)
                    {
                        sw.WriteLine(" ");
                        sw.WriteLine("_______________________");
                        sw.WriteLine("Index Finger Range: {0}", indexRange);
                        sw.WriteLine("Middle Finger Range: {0}", middleRange);
                    }
                    sw.WriteLine(" ");
                    sw.Close();
                }
            }
            catch (IOException i)
            {
                Console.WriteLine(i.Source);
            }
        }
    }

    protected void ChangePatternTest(object sender, EventArgs e)
    {
        cb = (ComboBox) sender;
        activeTest = cb.ActiveText;
    }

    protected void ChangePatternFelt(object sender, EventArgs e)
    {
        cb = (ComboBox)sender;
        chosenPattern = cb.ActiveText;
    }

    protected void startButtonClicked(object sender, EventArgs e)
    {
        if (clickOnce == true)
        {
            clickOnce = false;
            clickOnceSubmit = true;
            if (patterns.Count > 0)
            {
                count += 1;
                counter.Text = count.ToString();
                counter.ModifyFont(Pango.FontDescription.FromString("Purisa 40"));
                timer.ModifyFont(Pango.FontDescription.FromString("Purisa 50"));
                myTimer_Start();
            }
            else
            {
                MessageDialog md = new MessageDialog(this,
                    DialogFlags.DestroyWithParent, MessageType.Info,
                    ButtonsType.Close, "All Patterns have been tried.");
                md.Run();
                md.Destroy();
            }
        }
    }
    protected void myTimer_Start()
    {
        timeLeft = 3;
        //timer.Text = timeLeft.ToString();

        if (firstTime == true) {
            myTimer.Interval = 1000;
            myTimer.Enabled = true;
            myTimer.Elapsed += new ElapsedEventHandler(myTimer_Tick);
            firstTime = false;
        }

        myTimer.Start();
        //timer.Text = timeLeft.ToString();
    }
    protected void myTimer_Tick(object sender, ElapsedEventArgs e)
    {
        timer.Text = timeLeft.ToString();
        timeLeft -= 1;

        if (timeLeft < 0)
        { 
            myTimer.Stop();
            myTimer.Close();
           // myTimer.Dispose();
           // myTimer.
            runPattern();
        }
    }

    protected void runPattern()
    {
        int index;
        Random rand = new Random();
  
        if(patterns.Count > 1)
        {
            index = rand.Next(patterns.Count - 1);
        }
        else
        {
            index = 0;
        }
        Process p = new Process();
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.CreateNoWindow = true;
        string filename = (string)patterns[index];
        p.StartInfo.FileName = filename;
        p.Start();
        if (patterns[index].ToString() == pattern1)
        {
            activePattern = "Pattern 1";
        }
        else if (patterns[index].ToString() == pattern2)
        {
            activePattern = "Pattern 2";
        }
        else if (patterns[index].ToString() == pattern3)
        { 
            activePattern = "Pattern 3";
        }
        else if (patterns[index].ToString() == pattern4)
        {
            activePattern = "Pattern 4";
        }
        else
        {
            activePattern = patterns[index].ToString();
        }
        //activePattern = patterns[index].ToString();
        patterns.RemoveAt(index);
        //clickOnce = true;
    }

    protected void ChangeIndexRange(object sender, EventArgs e)
    {
        hs1 = (HScale)sender;
        indexRange = hs1.Value;
    }

    protected void ChangeMiddleRange(object sender, EventArgs e)
    {
        hs2 = (HScale)sender;
        middleRange = hs2.Value;
    }
}
