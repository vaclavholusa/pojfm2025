namespace WinFormsAsyncDemo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void syncButton_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);
            MessageBox.Show("DONE - sync");
        }

        private async void asyncButton_Click(object sender, EventArgs e)
        {
            await Task.Delay(5000);
            MessageBox.Show("DONE - async");
        }
    }
}
