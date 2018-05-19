using System.Drawing;
using System.Windows.Forms;

namespace LoadINF {
    public static class RichTextBoxExtensions {

        /// <summary>
        /// Append a text with the specified color to a RichTextBox. 
        /// </summary>
        public static void AppendText(this RichTextBox box, string text, Color color) {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;
            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
