using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gos.Forms
{
    internal class EventController
    {
        public static EventController Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new EventController();
                return _instance;
            }
        }
        private static EventController _instance;
        private EventController()
        {

        }

        public event EventHandler<EventArgs> UpdateTable;
        public void InvokeUpdateTable()
        {
            UpdateTable.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler<EventArgs> UpdateFilterTable;
        public void InvokeUpdateFilterTable(object filter)
        {
            UpdateFilterTable.Invoke(filter, EventArgs.Empty);
        }
        public event EventHandler<EventArgs> EditFilterTable;
        public void InvokeEditFilterTable()
        {
            EditFilterTable.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler<EventArgs> FieldTable;
        public void InvokeFieldTable(object field)
        {
            EditFilterTable.Invoke(field, EventArgs.Empty);
        }
    }
}
