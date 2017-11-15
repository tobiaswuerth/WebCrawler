using System;

namespace WebCrawler.DomainModel.Entities
{
    public class Status
    {
        private UInt32? _statusId;
        private String _name;

        public UInt32 StatusId
        {
            get
            {
                if(_statusId.HasValue)
                {
                    return _statusId.Value;
                }

                throw new MemberAccessException("StatusId is not set");
            }
            set
            {
                _statusId = value;
            }
        }

        public String Name
        {
            get
            {
                if(!String.IsNullOrEmpty(_name))
                {
                    return _name;
                }

                throw new MemberAccessException("Name is not set");
            }
            set
            {
                if(null == value)
                {
                    throw new ArgumentNullException("value", "Name cannot be null");
                }
                if(String.Empty.Equals(value.Trim()))
                {
                    throw new ArgumentException("Name cannot be empty", "value");
                }

                _name = value.Trim();
            }
        }

        public Status()
        {
        }

        public Status(UInt32 statusId, String name)
        {
            StatusId = statusId;
            Name = name;
        }

        public Boolean Validate()
        {
            if(null == _statusId)
            {
                return false;
            }
            if(null == _name)
            {
                return false;
            }

            return true;
        }
    }
}