namespace AppMAUIGallery.Views;

public partial class Menu : ContentPage
{
	public Menu()
	{
		InitializeComponent();

		var categories = new Repository.CategoryRepository().GetCategories();
        foreach (var category in categories)
		{
			var lblCategory = new Label();
			lblCategory.Text = category.Name;
            lblCategory.FontFamily = "OpenSansSemiBold";
            MenuContainer.Children.Add(lblCategory);

            foreach (var component in category.Components)
			{
                var tap = new TapGestureRecognizer();
                tap.CommandParameter = component.Page;
                tap.Tapped += OnTapComponent;

                var lblComponentTitle = new Label();
                lblComponentTitle.Text = component.Title;
                lblComponentTitle.FontFamily = "OpenSansSemiBold";
                lblComponentTitle.Margin = new Thickness(20, 10, 0, 0);
                lblComponentTitle.GestureRecognizers.Add(tap);

                var lblComponentDescription = new Label();
                lblComponentDescription.Text = component.Description;
                lblComponentDescription.Margin = new Thickness(20, 0, 0, 0);
                lblComponentDescription.GestureRecognizers.Add(tap);

                MenuContainer.Children.Add(lblComponentTitle);
                MenuContainer.Children.Add(lblComponentDescription);
            }
        }
    }
    private void OnTapComponent(object sender, EventArgs e)
    {
        var label = (Label)sender;
        var tap = (TapGestureRecognizer)label.GestureRecognizers[0];
        var pageType = tap.CommandParameter as Type;

        if (pageType == null)
        {
            throw new ArgumentNullException(nameof(pageType), "The page type cannot be null.");
        }

        var pageInstance = Activator.CreateInstance(pageType) as Page;

        if (pageInstance == null)
        {
            throw new InvalidOperationException($"The type {pageType.FullName} could not be instantiated as a Page.");
        }

        var mainPage = Application.Current.Windows[0].Page as FlyoutPage;

        if (mainPage == null)
        {
            throw new InvalidOperationException("The main page is not a FlyoutPage.");
        }

        mainPage.Detail = new NavigationPage( pageInstance);
        mainPage.IsPresented = false;
    }
    private void OnHomeTapped(object sender, EventArgs e)
    {
        var mainPage = Application.Current.Windows[0].Page as FlyoutPage;
        if (mainPage == null)
        {
            throw new InvalidOperationException("The main page is not a FlyoutPage.");
        }
        mainPage.Detail = new NavigationPage(new MainPage());
        mainPage.IsPresented = false;
    }
}