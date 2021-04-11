using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using DungeonCrawler.Forms;
using DungeonCrawler.Players;

namespace DungeonCrawler.Forms {
    public class MainFrame : Form {
        private bool gamRunning;
        
        private WelcomeForm welcomeForm;
        private DungeonForm dungeonForm;
        
        public MainFrame() {
            this.AutoSize = true;
            
            Panel panel1 = new Panel();
            TextBox textBox1 = new TextBox();
            Label label1 = new Label();

            gamRunning = false;
            
            welcomeForm = new WelcomeForm();
            //dungeonForm = new DungeonForm(new Cleric());
            //dungeonForm.Hide();
                
            welcomeForm.StartButton.Click += StartGame;
            
            //this.Controls.Add(dungeonForm);
            this.Controls.Add(welcomeForm);

            this.KeyPreview = true;
            //this.PreviewKeyDown += new PreviewKeyDownEventHandler(FormPreviewKeyDown);
            this.KeyDown += new KeyEventHandler(FormKeyDown);
            
        }
        
        void FormKeyDown(object sender, KeyEventArgs e)
        {
            if (gamRunning) {
                dungeonForm.OnKeyDown(e.KeyCode);
                dungeonForm.Refresh();
                
            }
        }
        
        private void StartGame(object sender, EventArgs e) {
            string name = welcomeForm.GetHeroName();
            Hero hero = welcomeForm.GetHeroClass();
            
            if (name != "") {
                welcomeForm.Hide();
                gamRunning = true;

                dungeonForm = new DungeonForm(hero);
                this.Controls.Add(dungeonForm);
                
                dungeonForm.Show();
            }
        }
    }
}