using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Ribbon;

namespace DXSample22
{
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ChildRibbon = new RibbonControl();
            var category = new RibbonPageCategory() { Caption = "Merged" };
            ChildRibbon.Categories.Add(category);
            category.Pages.Add(new RibbonPage() { Caption = "Merged Page" });
        }

        private RibbonControl ChildRibbon { get; }

        private void ButtonBase_OnClick(Object sender, RoutedEventArgs e)
        {
            Output.AppendLine("MainRibbon.Merge(ChildRibbon) ...");
            MainRibbon.Merge(ChildRibbon);
            Output.AppendLine($"MainRibbon.IsMerged: {MainRibbon.IsMerged}");
            Output.AppendLine($"MainRibbon.IsMergedChild(ChildRibbon): {MainRibbon.IsMergedChild(ChildRibbon)}");
            Output.AppendLine($"ChildRibbon.IsMerged: {ChildRibbon.IsMerged}");
        }

        private void MainWindow_OnLoaded(Object sender, RoutedEventArgs e)
        {
            Output.AppendLine($"MainRibbon.IsMerged: {MainRibbon.IsMerged}");
            Output.AppendLine($"MainRibbon.IsMergedChild: {MainRibbon.IsMergedChild(ChildRibbon)}");
            Output.AppendLine($"ChildRibbon.IsMerged(ChildRibbon): {ChildRibbon.IsMerged}");
        }
    }

    public static class TextBoxExtensions
    {
        public static void AppendLine(this TextBox textbox, String line)
        {
            textbox.AppendText(line + Environment.NewLine);
        }
    }
}
