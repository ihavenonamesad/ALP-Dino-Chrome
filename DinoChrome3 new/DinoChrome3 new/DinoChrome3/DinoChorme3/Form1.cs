namespace DinoChorme3
{
    public partial class Form1 : Form
    {
        int highScore= 0;
        bool jumping = false;
        bool crouch = false;
        int crouchSpeed;
        int jumpSpeed;
        int force = 12;
        double score = 0;
        int obstacleSpeed = 10;
        Random rand = new Random();
        int position;
        bool isGameOver = true;
        int counter = 0;
        public Form1()
        {
            InitializeComponent();
            GameReset();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void MainGameTimerEvent(object sender, EventArgs e)
        {
            dino1.Top += jumpSpeed;
            txtScore.Text = "Score: " + Convert.ToInt32(score);
            gametimer.Start();

            if (jumping == true && force < 0)
            {
                jumping = false;
            }

            if (jumping == true)
            {
                jumpSpeed = -12;
                force -= 1;

            }
            else
            {
                jumpSpeed = 12;
            }

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;
                    if (x.Left + x.Width < -100)
                    {
                        // x.Left = 640 + (x.Left + position + x.Width * 3);
                        x.Left = this.ClientSize.Width + rand.Next(4, 10) * 80;
                        //x.Left = this.ClientSize.Width + rand.Next(200, 800);
                        //counter++;
                        //if (counter > 0)
                        //{
                        //    x.Left += 300;
                        //}
                        //counter++;
                        //counter = rand.Next(0, 6);
                        //switch (counter)
                        //{
                        //    case 1:
                        //        x.Left = this.ClientSize.Width + 300 + rand.Next(0, 300);
                        //        break;
                        //    case 2:
                        //        x.Left = this.ClientSize.Width + 450 + rand.Next(0, 300);
                        //        break;
                        //    case 3:
                        //        x.Left = this.ClientSize.Width + 600 + rand.Next(0, 300);
                        //        break;
                        //    case 4:
                        //        x.Left = this.ClientSize.Width + 750 + rand.Next(0, 300);
                        //        break;
                        //    case 5:
                        //        x.Left = this.ClientSize.Width + 900 + rand.Next(0, 300);
                        //        break;

                        //}

                    }
                    if (dino1.Bounds.IntersectsWith(x.Bounds) && dino1.Visible == true)
                    {
                        isGameOver = false;
                        gametimer.Stop();
                        gameOverr.Visible = true;
                        pictureBox1.Visible = false;
                        pictureBox9.Visible = true;
                        if (score > highScore)
                        {
                            highScore = Convert.ToInt32(score);
                        }
                    }
                    if (dinocrouch.Bounds.IntersectsWith(x.Bounds) && dinocrouch.Visible == true)
                    {
                        isGameOver = false;
                        gametimer.Stop();
                        gameOverr.Visible = true;
                        pictureBox1.Visible = false;
                        pictureBox9.Visible = true;
                        if (score > highScore)
                        {
                            highScore = Convert.ToInt32(score);
                        }
                    }
                    score = score + 0.05;
                }
            }
            if (dino1.Top > 361 && jumping == false)
            {
                force = 12;
                dino1.Top = 362;
                jumpSpeed = 0;
            }

            if (crouch == true)
            {
                dinocrouch.Visible = true;
                dino1.Visible = false;
            }
            else
            {
                crouch = false;
                dinocrouch.Visible = false;
                dino1.Visible = true;
            }
            if (score > 100)
            {
                obstacleSpeed = 12;
            }

            if (score > 200)
            {
                obstacleSpeed = 15;
            }
        }

        private void MainGameTimer2(object sender, EventArgs e)
        {
            dino1.Top += crouchSpeed;
            txtScore.Text = "Score: " + Convert.ToInt32(score);
            //txtScore.Text = "Score: " + score;

            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && x.Tag == "obstacle")
                {
                    x.Left -= obstacleSpeed;
                    if (x.Left + x.Width < -120)
                    {
                        //x.Left = this.ClientSize.Width + rand.Next(200, 800);
                        x.Left = this.ClientSize.Width + rand.Next(4, 10) * 80;
                        counter++;
                        if (counter == 1)
                        {
                            x.Left += 300;
                        }
                    }
                    if (!dinocrouch.Bounds.IntersectsWith(x.Bounds))
                    {

                    }
                    else if (crouch = false)
                    {

                        gametimer.Stop();
                    }
                    score = score + 0.05;
                }
            }
            if (score > 100)
            {
                obstacleSpeed = 15;
            }

            if (score > 300)
            {
                obstacleSpeed = 21;
            }
        }
        private void keyisdown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && e.KeyCode == Keys.C)
            {
                jumping = false;
                crouch = false;
            }

            else if (e.KeyCode == Keys.Space)
            {
                jumping = true;
            }
            else if (e.KeyCode == Keys.C)
            {
                crouch = true;
            }

        }

        private void keyisup(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && e.KeyCode == Keys.C)
            {
                jumping = false;
                crouch = false;
            }
            //else if (jumping == true)
            //{
            //    jumping = false;
            // }
            else if (e.KeyCode == Keys.Space)
            {
                jumping = false;
            }
            else if (e.KeyCode == Keys.C)
            {
                crouch = false;
            }

            // else if (crouch == true)
            //{
            //    crouch = false;
            // }

            else if (e.KeyCode == Keys.R && isGameOver == false)
            {
                gameOverr.Visible = false;
                pictureBox1.Visible = true;
                pictureBox9.Visible = false;
                GameReset();
                hScore.Text = "High Score: " + highScore;
                score = 0;
            }

        }

        public void GameReset()
        {
            isGameOver = true;
            force = 12;
            jumpSpeed = 0;
            jumping = false;
            score = 0;
            obstacleSpeed = 10;
            txtScore.Text = "Score: " + score;
            dino1.Image = Properties.Resources.running_1_;
            dino1.Top = 362;
            foreach (Control x in this.Controls)
            {
                if (x is PictureBox && (string)x.Tag == "obstacle")
                {

                    position = rand.Next(4, 10)*80;
                   x.Left = 640 + (x.Left + position + x.Width * 3);

                }


            }
            gametimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void dino1_Click(object sender, EventArgs e)
        {

        }

        private void dinocrouch_Click(object sender, EventArgs e)
        {
            dinocrouch.Visible = false;
        }

        private void txtScore_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_2(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_3(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void hScore_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)//Gambar Berhenti
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)//Gambar Gerak
        {

        }
    }
}