using System;
using System.Drawing;
using System.Windows.Forms;

namespace LoadINF {
    class BetterBox {

        public static DialogResult Show(string title, string promptText) {
            Form form = new Form();
            Label label = new Label();

            Button buttonWOT = new Button();
            Button buttonWOWS = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            label.Font = new Font(label.Font, FontStyle.Bold);

            buttonWOT.Text = "World of Tanks";
            buttonWOWS.Text = "World of Warships";
            buttonCancel.Text = "Cancel";
            buttonWOT.DialogResult = DialogResult.Yes;
            buttonWOWS.DialogResult = DialogResult.No;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);

            buttonWOT.SetBounds(105, 72, 105, 23);
            buttonWOWS.SetBounds(215, 72, 105, 23);
            buttonCancel.SetBounds(325, 72, 55, 23);

            label.AutoSize = true;
            buttonWOT.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonWOWS.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, buttonWOT, buttonWOWS, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonWOT;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            return dialogResult;
        }

    }
}
