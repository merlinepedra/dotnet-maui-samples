using CommunityToolkit.Maui.Markup;
using MauiBlazorApp.Controls;
using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Controls;
using static CommunityToolkit.Maui.Markup.GridRowsColumns;

namespace MauiBlazorApp
{
    public partial class BlazorPage : ContentPage
    {
        enum BodyRow { Top, Bottom }

        public void InitializeComponent()
        {
            SetDynamicResource(ContentPage.BackgroundColorProperty, "SecondaryColor");
            Content = new Grid()
            {
                RowDefinitions = Rows.Define(Auto, Star),
                Children =
                {
                    new StackLayout()
                    {
                        Children =
                        {
                            new TextLabel("The current count is: 0").StartExpand()
                                                                    .CenterVertical()
                                                                    .Assign(out lblCounter),
                            new TextButton("Increment").End()
                                                       .CenterVertical()
                                                       .Invoke(btn => btn.Clicked += Counter_Clicked),
                        },
                    }.Padding(20)
                     .Row(BodyRow.Top),
                    new BlazorWebView()
                    {
                        HostPage = "wwwroot/index.html",
                        RootComponents =
                        {
                            new()
                            {
                                ComponentType = typeof(Gateway),
                                Selector = "#app"
                            },
                        },
                    }.Row(BodyRow.Bottom),
                }
            }.FillExpand();
        }

        #region Variables
        private Label lblCounter;
        #endregion
    }
}