using Android.App;
using Android.Widget;
using Android.OS;

namespace GradeTracker
{
    [Activity(Label = "GradeTracker", MainLauncher = true)]
    public class MainActivity : Activity
    {
        Button createBtn;
        LinearLayout vertLayout;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            vertLayout = FindViewById<LinearLayout>(Resource.Id.subjectLayout);
            createBtn = FindViewById<Button>(Resource.Id.btnCreateSubject);
            createBtn.Click += CreateNewSubject;
        }

        private void PopUpCreationMenu(object sender, System.EventArgs e)
        {
            var btnConfirm = new Button(ApplicationContext);

            btnConfirm.Click += CreateNewSubject;
        }
        
        private void CreateNewSubject(object sender, System.EventArgs e)
        {
            var button = new Button(ApplicationContext)
            {
                Text = "New Subject\tAverage: 100%",
                TextAlignment = Android.Views.TextAlignment.Center,
            };
            vertLayout.AddView(button);
        }
    }
}

