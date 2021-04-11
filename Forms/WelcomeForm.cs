using System;
using System.Windows.Forms;
using System.Drawing;
using DungeonCrawler.Players;

namespace DungeonCrawler.Forms {
    public class WelcomeForm : Panel {
        private Label titel;
        private Label latinText;
        private Label heroName;
        private Label warriorLabel;
        private Label clericLabel;
        private Label mageLabel;

        private Label classRegen;
        private Label classDamage;

        private TextBox heroNameTextBox;
        private RadioButton warriorRadio;
        private RadioButton clericRadio;
        private RadioButton mageRadio;

        public Button StartButton;
        
        public WelcomeForm() {
            this.Width = 500;
            this.Height = 500;
            
            AddControls();
            
        }

        public string GetHeroName() {
            return heroNameTextBox.Text;
        }

        public Hero GetHeroClass() {
            if (warriorRadio.Checked) {
                return new Warrior();     
            } else if (clericRadio.Checked) {
                return new Cleric();    
            } else {
                return new Mage();
            }
        }
        
        private void RadioClicked(object sender, EventArgs e) {
            RadioButton radio = sender as RadioButton;
            if (warriorRadio.Checked) {
                classRegen.Text = "Regeneration: 5";
                classDamage.Text = "Damage magnitude: 3";
            } else if (clericRadio.Checked) {
                classRegen.Text = "Regeneration: 20";
                classDamage.Text = "Damage magnitude: 1";
            } else if (mageRadio.Checked) {
                classRegen.Text = "Regeneration: 10";
                classDamage.Text = "Damage magnitude: 2";
            }
        }
        
        private void AddControls() {
            // Titel Label
            titel = new Label();
            titel.Location = new System.Drawing.Point(50,40);
            titel.Text = "Dungeon Crawler";
            titel.Size = new Size(400, 40);
            titel.Font = new Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            titel.TextAlign = ContentAlignment.MiddleCenter;
            
            // Latin text Label
            latinText = new Label();
            latinText.Location = new System.Drawing.Point(50,100);
            latinText.Text = 
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit.\n" +
                "Nam tristique, quam eget feugiat faucibus, massa sapien\n" +
                "euismod dolor, ac consectetur arcu turpis ac ante. In\n" +
                "ullamcorper massa id orci tristique dapibus. Pellentesque\n" +
                "malesuada sodales lectus vel pellentesque. Fusce suscipit\n" +
                "hendrerit purus ac pharetra\n";
            latinText.Size = new Size(400, 100);
            latinText.Font = new Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            latinText.TextAlign = ContentAlignment.MiddleCenter;
            
            // Hero name Label
            heroName = new Label();
            heroName.Location = new System.Drawing.Point(40,210);
            heroName.Text = "Hero name:";
            heroName.Size = new Size(150, 40);
            heroName.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            heroName.TextAlign = ContentAlignment.MiddleCenter;
            
            // Class Labels
            warriorLabel = new Label();
            warriorLabel.Location = new System.Drawing.Point(40,272);
            warriorLabel.Text = "Warrior";
            warriorLabel.Size = new Size(150, 15);
            warriorLabel.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            warriorLabel.TextAlign = ContentAlignment.MiddleCenter;
            
            clericLabel = new Label();
            clericLabel.Location = new System.Drawing.Point(40,302);
            clericLabel.Text = "Cleric";
            clericLabel.Size = new Size(150, 15);
            clericLabel.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            clericLabel.TextAlign = ContentAlignment.MiddleCenter;
            
            mageLabel = new Label();
            mageLabel.Location = new System.Drawing.Point(40,332);
            mageLabel.Text = "Mage";
            mageLabel.Size = new Size(150, 15);
            mageLabel.Font = new Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            mageLabel.TextAlign = ContentAlignment.MiddleCenter;
            
            // Class regen Label
            classRegen = new Label();
            classRegen.Location = new System.Drawing.Point(230,270);
            classRegen.Text = "Regeneration: 5";
            classRegen.Size = new Size(200, 20);
            classRegen.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            // Class damage Label
            classDamage = new Label();
            classDamage.Location = new System.Drawing.Point(230,290);
            classDamage.Text = "Damage magnitude: 3";
            classDamage.Size = new Size(200, 20);
            classDamage.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            // Hero name TextBox
            heroNameTextBox = new TextBox();
            heroNameTextBox.Location = new System.Drawing.Point(230,220);
            heroNameTextBox.Size = new Size(230, 40);
            heroNameTextBox.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            heroNameTextBox.BorderStyle = BorderStyle.FixedSingle;
            
            // Radio Buttons
            warriorRadio = new RadioButton();
            warriorRadio.Location = new System.Drawing.Point(70,270);
            warriorRadio.Width = 10;
            warriorRadio.Checked = true;
            
            clericRadio = new RadioButton();
            clericRadio.Location = new System.Drawing.Point(70,300);
            clericRadio.Width = 10;
            
            mageRadio = new RadioButton();
            mageRadio.Location = new System.Drawing.Point(70,330);
            mageRadio.Width = 10;
            
            // Start Button
            StartButton = new Button();
            StartButton.Location = new System.Drawing.Point(300,350);
            StartButton.Text = "Start";
            StartButton.Font = new Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            
            this.Controls.Add(titel);
            this.Controls.Add(latinText);
            this.Controls.Add(heroName);
            this.Controls.Add(heroNameTextBox);
            this.Controls.Add(warriorRadio);
            this.Controls.Add(clericRadio);
            this.Controls.Add(mageRadio);
            this.Controls.Add(warriorLabel);
            this.Controls.Add(clericLabel);
            this.Controls.Add(mageLabel);
            this.Controls.Add(classRegen);
            this.Controls.Add(classDamage);
            this.Controls.Add(StartButton);
        }
    }
}