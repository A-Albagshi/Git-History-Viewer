using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibGit2Sharp;

namespace GitHistoryViewer
{
    public partial class Form1 : Form
    {
        private Graphics g;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            this.Invalidate();

            
            /*string dir = @"https://github.com/AbdulazizAlmohammadi/Painter";
            Repository.Clone(dir, localDir);*/

            /*Pen p = new Pen(Brushes.Black, 2);
            string localDir = @"C:\Users\a-22_\RiderProjects\GitHistoryViewer\GitHistoryViewer\git";

            using (var repo = new Repository(localDir))
            {
                int x = 50;
                string commitsStr = "";
                foreach (var commit in repo.Commits)
                {
                    g.DrawEllipse(p,x+=150,50,50,50);    
                    /*
                    commitsStr += $"{commit.Id.ToString().Substring(0, 7)}  {commit.Tree.Id.ToString().Substring(0, 7)}" + Environment.NewLine;
                #1#
                }

                string branchesStr = "";
                foreach (var b in repo.Branches)
                {
                     branchesStr+= $"{b.FriendlyName}" + Environment.NewLine;
                }
                */

                
                /*
                label1.Text = commitsStr;
                label2.Text = branchesStr;
                */
                
                /*var commit = repo.Head.Tip;
                Console.WriteLine($"Commit Full ID: {commit.Id}");
                Console.WriteLine($"Message: {commit.MessageShort}");
                Console.WriteLine($"Author: {commit.Author.Name}");
                Console.WriteLine($"Time: {commit.Author.When.ToLocalTime()}");
                */

            }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

            g = e.Graphics;
            Pen p = new Pen(Brushes.Black, 5);
            Font font1 = new Font("Times New Roman", 24, FontStyle.Bold, GraphicsUnit.Pixel);
            string localDir = @"C:\Users\a-22_\RiderProjects\GitHistoryViewer\GitHistoryViewer\git";

            DrawObjects drw = new DrawObjects();

            bool once = false;
            
            using (var repo = new Repository(localDir))
            {
                foreach (var commit in repo.Commits)
                {
                    foreach (var b in repo.Branches)
                    {
                        if (commit.Id.ToString().Substring(0, 7) == repo.Branches[b.FriendlyName].Tip.Id.ToString().Substring(0, 7))
                        {
                            drw.drawBranch(g,b.FriendlyName);
                            /*
                            MessageBox.Show(commit.Id.ToString().Substring(0, 7) + " " + repo.Branches[b.FriendlyName].Tip.Id.ToString().Substring(0, 7) );
                        */
                        }
                        
                        
                    }

                    if (!once && repo.Head.Tip.ToString().Substring(0, 7) == commit.Id.ToString().Substring(0, 7))
                    {
                        drw.drawHead(g);
                        once = true;
                    }
                    
                    drw.drawCommit(g);
                    drw.drawString(g,commit.Id.ToString().Substring(0, 7));
                    drw.drawLine(g);
                    drw.updateX();
    
                }

            }

            
            
            
            
            this.panel1.AutoScrollMinSize = new Size( drw.x, this.panel1.AutoScrollMinSize.Height);

        }

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            this.panel1.Invalidate();
        }
    }

    }
