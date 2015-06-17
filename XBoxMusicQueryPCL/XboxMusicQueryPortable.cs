using Xamarin.Forms;

namespace XboxMusicQueryPCL
{
    public class XboxMusicQueryPortable : ContentPage
    {
        public XboxMusicQueryPortable()
        {
            var button = new Button
            {
                Text = "Click Me!",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
            };

            int clicked = 0;
            button.Clicked += (s, e) => button.Text = "Clicked: " + clicked++;

            Content = button;
        }
    }
}
