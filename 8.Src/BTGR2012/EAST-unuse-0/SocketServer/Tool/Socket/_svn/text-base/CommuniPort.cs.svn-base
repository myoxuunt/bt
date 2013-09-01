using System;

namespace Tool
{
    /// <summary>
    /// 通讯口基类
    /// </summary>
    public abstract class CommuniPort
    {
        abstract public bool Write(byte[] bytes);

        abstract public byte[] Read();

        public virtual void Remove()
        {
            if (this.CommuniPorts != null)
            {
                this.CommuniPorts.Remove(this);
            }
        }

        public System.Collections.ObjectModel.Collection<CommuniPort> CommuniPorts
        {
            get { return _communiPorts; }
            set
            {
                if (this._communiPorts != value)
                {
                    _communiPorts = value;
                }
            }
        } private System.Collections.ObjectModel.Collection<CommuniPort> _communiPorts;
    }
}