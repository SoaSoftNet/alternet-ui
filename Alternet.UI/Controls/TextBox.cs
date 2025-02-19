using System;
using System.ComponentModel;

namespace Alternet.UI
{
    /// <summary>
    /// Represents a control that can be used to display or edit unformatted text.
    /// </summary>
    /// <remarks>
    /// With the <see cref="TextBox"/> control, the user can enter text in an application.
    /// </remarks>
    public class TextBox : Control
    {
        private bool editControlOnly = false;

        /// <summary>
        /// todo: use BorderStyle for this purpose later.
        /// </summary>
        public event EventHandler? EditControlOnlyChanged;

        /// <summary>
        /// Gets or sets the text contents of the text box.
        /// </summary>
        /// <value>A string containing the text contents of the text box. The default is an empty string ("").</value>
        /// <remarks>
        /// Getting this property returns a string copy of the contents of the text box. Setting this property replaces the contents of the text box with the specified string.
        /// </remarks>
        [DefaultValue("")]
        [Localizability(LocalizationCategory.Text)]
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        /// <summary>
        /// Event for "Text has changed"
        /// </summary>
        public static readonly RoutedEvent TextChangedEvent = EventManager.RegisterRoutedEvent(
            "TextChanged", // Event name
            RoutingStrategy.Bubble, //
            typeof(TextChangedEventHandler), //
            typeof(TextBox)); //

        /// <summary>
        /// Occurs when the value of the <see cref="Text"/> property changes.
        /// </summary>
        public event TextChangedEventHandler TextChanged
        {
            add
            {
                AddHandler(TextChangedEvent, value);
            }

            remove
            {
                RemoveHandler(TextChangedEvent, value);
            }
        }

        /// <summary>
        /// Identifies the <see cref="Text"/> dependency property.
        /// </summary>
        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(
                "Text", // Property name
                typeof(string), // Property type
                typeof(TextBox), // Property owner
                new FrameworkPropertyMetadata( // Property metadata
                        string.Empty, // default value
                        FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | // Flags
                            FrameworkPropertyMetadataOptions.AffectsPaint,
                        new PropertyChangedCallback(OnTextPropertyChanged),    // property changed callback
                        new CoerceValueCallback(CoerceText),
                        true, // IsAnimationProhibited
                        UpdateSourceTrigger.PropertyChanged
                        //UpdateSourceTrigger.LostFocus   // DefaultUpdateSourceTrigger
                        ));

        /// <summary>
        /// Callback for changes to the Text property
        /// </summary>
        private static void OnTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TextBox textBox = (TextBox)d;
            textBox.OnTextPropertyChanged((string)e.OldValue, (string)e.NewValue);
        }

        private void OnTextPropertyChanged(string oldText, string newText)
        {
            OnTextChanged(new TextChangedEventArgs(TextChangedEvent));
        }

        /// <summary>
        /// Called when content in this Control changes.
        /// Raises the TextChanged event.
        /// </summary>
        /// <param name="e"></param>
        protected virtual void OnTextChanged(TextChangedEventArgs e)
        {
            RaiseEvent(e);
        }

        /// <summary>
        /// Raises the <see cref="TextChanged"/> event and calls <see cref="OnTextChanged(EventArgs)"/>.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        public void RaiseTextChanged(TextChangedEventArgs e)
        {
            if (e == null)
                throw new ArgumentNullException(nameof(e));

            OnTextChanged(e);
        }

        private static object CoerceText(DependencyObject d, object value) => value == null ? string.Empty : value;

        /// <summary>
        /// todo: use BorderStyle for this purpose later.
        /// </summary>
        public bool EditControlOnly
        {
            get
            {
                CheckDisposed();
                return editControlOnly;
            }

            set
            {
                CheckDisposed();
                if (editControlOnly == value)
                    return;

                editControlOnly = value;
                EditControlOnlyChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private bool readOnly = false;

        /// <summary>
        /// Gets or sets a value indicating whether text in the text box is read-only.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the text box is read-only; otherwise, <see langword="false"/>. The default is <see
        /// langword="false"/>.
        /// </value>
        /// <remarks>
        /// When this property is set to <see langword="true"/>, the contents of the control cannot be changed by the user at runtime.
        /// With this property set to <see langword="true"/>, you can still set the value of the <see cref="Text"/> property in code.
        /// </remarks>
        public bool ReadOnly
        {
            get
            {
                CheckDisposed();
                return readOnly;
            }

            set
            {
                CheckDisposed();
                if (readOnly == value)
                    return;

                readOnly = value;
                ReadOnlyChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Occurs when <see cref="ReadOnly"/> property value changes.
        /// </summary>
        public event EventHandler? ReadOnlyChanged;


        private bool multiline = false;

        /// <summary>
        /// Gets or sets a value indicating whether this is a multiline text box control.
        /// </summary>
        /// <value>
        /// <see langword="true"/> if the control is a multiline text box control; otherwise, <see langword="false"/>. The default is <see langword="false"/>.
        /// </value>
        public bool Multiline
        {
            get
            {
                CheckDisposed();
                return multiline;
            }

            set
            {
                CheckDisposed();
                if (multiline == value)
                    return;

                multiline = value;
                MultilineChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Occurs when <see cref="Multiline"/> property value changes.
        /// </summary>
        public event EventHandler? MultilineChanged;

        /// <summary>
        /// Called when the value of the <see cref="Text"/> property changes.
        /// </summary>
        /// <param name="e">An <see cref="EventArgs"/> that contains the event data.</param>
        protected virtual void OnTextChanged(EventArgs e)
        {
        }

        /// <inheritdoc/>
        protected override ControlHandler CreateHandler()
        {
            if (EditControlOnly)
                return new NativeTextBoxHandler();

            return base.CreateHandler();
        }
    }
}