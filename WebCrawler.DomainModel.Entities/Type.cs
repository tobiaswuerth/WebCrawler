using System;

namespace WebCrawler.DomainModel.Entities
{
    public class Type
    {
        private UInt32? _typeId;
        private String _extension;
        private String _description;
        private String _mime;

        public UInt32 TypeId
        {
            get
            {
                if(_typeId.HasValue)
                {
                    return _typeId.Value;
                }

                throw new MemberAccessException("TypeId is not set");
            }
            set
            {
                _typeId = value;
            }
        }

        public String Extension
        {
            get
            {
                if(!String.IsNullOrEmpty(_extension))
                {
                    return _extension;
                }

                throw new MemberAccessException("Extension is not set");
            }
            set
            {
                if(null == value)
                {
                    throw new ArgumentNullException("value", "Extension cannot be null");
                }
                if(String.Empty.Equals(value.Trim()))
                {
                    throw new ArgumentException("Extension cannot be empty", "value");
                }
                if(!value.Trim().StartsWith("."))
                {
                    throw new ArgumentException("Extension does not match requested format", "value");
                }
                if(2 > value.Trim().Length)
                {
                    throw new ArgumentException("Extension does not match requested format", "value");
                }

                _extension = value.Trim();
            }
        }

        public String Description
        {
            get
            {
                if(!String.IsNullOrEmpty(_description))
                {
                    return _description;
                }

                throw new MemberAccessException("Description is not set");
            }
            set
            {
                if(null == value)
                {
                    throw new ArgumentNullException("value", "Description cannot be null");
                }
                if(String.Empty.Equals(value.Trim()))
                {
                    throw new ArgumentException("Description cannot be empty", "value");
                }

                _description = value.Trim();
            }
        }

        public String MIME
        {
            get
            {
                if(!String.IsNullOrEmpty(_mime))
                {
                    return _mime;
                }

                throw new MemberAccessException("MIME is not set");
            }
            set
            {
                if(null == value)
                {
                    throw new ArgumentNullException("value", "MIME cannot be null");
                }
                if(String.Empty.Equals(value.Trim()))
                {
                    throw new ArgumentException("MIME cannot be empty", "value");
                }

                _mime = value.Trim();
            }
        }

        public Type()
        {
        }

        public Type(UInt32 typeId, String extension, String description, String mime)
        {
            TypeId = typeId;
            Extension = extension;
            Description = description;
            MIME = mime;
        }

        public Boolean Validate()
        {
            if(null == _typeId)
            {
                return false;
            }
            if(null == _extension)
            {
                return false;
            }
            if(null == _description)
            {
                return false;
            }
            if(null == _mime)
            {
                return false;
            }

            return true;
        }
    }
}