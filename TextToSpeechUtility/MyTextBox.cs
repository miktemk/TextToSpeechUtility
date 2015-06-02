namespace SpeechTest
{
	public class MyTextBox : System.Windows.Forms.TextBox
	{
		protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Control && (e.KeyCode == System.Windows.Forms.Keys.A))
			{
				this.SelectAll();
				e.SuppressKeyPress = true;
				e.Handled = true;
			}
			else
				base.OnKeyDown(e);
		}
	}
}