using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MatrixEditor.Dictionaries
{
    public partial class ControlTemplates : ResourceDictionary
    {
        private void OnTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            var bindingExpression = textBox.GetBindingExpression(TextBox.TextProperty);
            if(bindingExpression == null ) return;

            if(e.Key == Key.Enter)
            {
                if(textBox.Tag is ICommand command && command.CanExecute(textBox.Text))
                {
                    command.Execute(textBox.Text);
                }
                else
                {
                    bindingExpression.UpdateSource();
                }
                Keyboard.ClearFocus();
                e.Handled = true;
            }
            else if(e.Key == Key.Escape)
            {
                bindingExpression.UpdateTarget();
                Keyboard.ClearFocus();
            }
        }
    }
}
