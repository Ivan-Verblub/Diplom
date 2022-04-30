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
            if(UpdateTable != null)
                UpdateTable.Invoke(this, EventArgs.Empty);
        }
        public bool IsNullUT
        {
            get
            {
                return (UpdateTable == null);
            }
        }
        public event EventHandler<EventArgs> UpdateFilterTable;
        public void InvokeUpdateFilterTable(object filter)
        {
            if(UpdateFilterTable != null)
                UpdateFilterTable.Invoke(filter, EventArgs.Empty);
        }
        public bool IsNullUFT
        {
            get
            {
                return (UpdateFilterTable == null);
            }
        }
        public event EventHandler<EventArgs> EditFilterTable;
        public void InvokeEditFilterTable()
        {
            if(EditFilterTable != null)
                EditFilterTable.Invoke(this, EventArgs.Empty);
        }
        public bool IsNullEFT
        {
            get
            {
                return (EditFilterTable == null);
            }
        }
        public event EventHandler<EventArgs> FieldTable;
        public void InvokeFieldTable(object field)
        {
            if(FieldTable != null)
                FieldTable.Invoke(field, EventArgs.Empty);
        }
        public bool IsNullFT
        {
            get
            {
                return (FieldTable == null);
            }
        }
    }
}
