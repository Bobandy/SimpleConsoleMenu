using System;

namespace SimpleCMenu.Menu
{
    public class MenuItem
    {
        #region Properties

        public int ID { get; set; }
        public string Text { get; set; }
        public Action Action { get; set; }

        #endregion

        #region Constructors

        public MenuItem()
        {

        }

        public MenuItem(int id, string text, Action action)
        {
            this.ID = id;
            this.Text = text;
            this.Action = action;
        }

        #endregion
    }
}
