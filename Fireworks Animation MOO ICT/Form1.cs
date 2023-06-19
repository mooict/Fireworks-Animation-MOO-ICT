namespace Fireworks_Animation_MOO_ICT
{
    // Made by MOO ICT
    // For educational purpose only
    public partial class Form1 : Form
    {

        List<string> image_location = new List<string>();
        List<Firework> fireworks_list = new List<Firework>();
        int backgroundNumber;


        public Form1()
        {
            InitializeComponent();
            SetUp();
        }

        private void SetUp()
        {
            image_location = Directory.GetFiles("background", "*.jpg").ToList();
            this.BackgroundImage = Image.FromFile(image_location[0]);
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }


        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (backgroundNumber < image_location.Count -1)
            {
                backgroundNumber++;
            }
            else
            {
                backgroundNumber = 0;
            }

            this.BackgroundImage = Image.FromFile(image_location[backgroundNumber]);

        }

        private void FormMouseDown(object sender, MouseEventArgs e)
        {
            Point mousePosition = new Point();
            mousePosition.X = e.X;
            mousePosition.Y = e.Y;

            Firework newFirework = new Firework();
            newFirework.position.X = mousePosition.X - (newFirework.width/2);
            newFirework.position.Y = mousePosition.Y - (newFirework.height/2);
            fireworks_list.Add(newFirework);
        }

        private void FormPaintEvent(object sender, PaintEventArgs e)
        {
            foreach (Firework newFirework  in fireworks_list.ToList())
            {
                if (newFirework.animationComplete == false)
                {
                    e.Graphics.DrawImage(newFirework.firework, newFirework.position.X, newFirework.position.Y, newFirework.width, newFirework.height);
                }
            }
        }

        private void AnimationTimerEvent(object sender, EventArgs e)
        {
            if (fireworks_list != null)
            {
                foreach (Firework firework in fireworks_list.ToList())
                {

                    if (firework.animationComplete == false)
                    {
                        firework.AnimateFireWork();
                    }
                    else
                    {
                        fireworks_list.Remove(firework);
                    }
                }
            }


            this.Invalidate();

        }
    }
}