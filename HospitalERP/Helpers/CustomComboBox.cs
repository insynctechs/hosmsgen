using System.Windows.Forms;
namespace HospitalERP.Helpers
{

    public class CustomComboBox : ComboBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            switch ((keyData & (Keys.Alt | Keys.KeyCode)))
            {
                case Keys.Enter:
                case Keys.Escape:
                    if (this.DroppedDown)
                    {
                        this.DroppedDown = false;
                        return false;
                    }
                    break;
            }
            return base.IsInputKey(keyData);
        }
    }
}
