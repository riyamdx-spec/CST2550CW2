using BettingSystem.Services;

namespace BettingSystem.Forms.CustomControls
{
    public partial class leagueButton : UserControl
    {
        private ImageLoader _imageLoader = new ImageLoader();

        public leagueButton()
        {
            InitializeComponent();

            //propagate click events
            leagueImg.Click += leagueButton_Click;
            LeagueBtnRoundedPanelBG.Click += leagueButton_Click;
        }

        private void leagueButton_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        public async Task setImage(string url)
        {
            if (leagueImg.Image != null)
            {
                leagueImg.Image.Dispose();
                leagueImg.Image = null; // Clear existing image while loading new one
            }
            leagueImg.Image = await _imageLoader.GetImageAsync(url);
        }
    }
}
