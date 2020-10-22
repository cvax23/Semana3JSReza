using Xamarin.Forms;

namespace Semana3JSReza
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
                        
            MainPage = new NavigationPage(new MainPage());
            //MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
