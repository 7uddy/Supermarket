public partial class UserUpdateView : Window
{
    public UserUpdateView()
    {
        InitializeComponent();
        DataContext = new UserVM();
    }
}
