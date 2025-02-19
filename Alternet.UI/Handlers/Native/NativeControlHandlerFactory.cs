namespace Alternet.UI
{
    /// <summary>
    /// Implements an <see cref="IControlHandlerFactory"/> for the Native visual theme.
    /// </summary>
    public class NativeControlHandlerFactory : IControlHandlerFactory
    {
        /// <inheritdoc/>
        public ControlHandler CreateControlHandler(Control control) => control switch
        {
            Button => new NativeButtonHandler(),
            StackPanel => new StackPanelHandler(),
            Border => new GenericBorderHandler(),
            PictureBox => new PictureBoxHandler(),
            Label => new NativeLabelHandler(),
            TextBox => new NativeTextBoxHandler(),
            CheckBox => new NativeCheckBoxHandler(),
            RadioButton => new NativeRadioButtonHandler(),
            TabControl => new NativeTabControlHandler(),
            GroupBox => new NativeGroupBoxHandler(),
            ProgressBar => new NativeProgressBarHandler(),
            Slider => new NativeSliderHandler(),
            NumericUpDown => new NativeNumericUpDownHandler(),
            ListBox => new NativeListBoxHandler(),
            ComboBox => new NativeComboBoxHandler(),
            ListView => new NativeListViewHandler(),
            TreeView => new NativeTreeViewHandler(),
            MainMenu => new NativeMainMenuHandler(),
            MenuItem => new NativeMenuItemHandler(),
            ContextMenu => new NativeContextMenuHandler(),
            _ => new GenericControlHandler()
        };
    }
}