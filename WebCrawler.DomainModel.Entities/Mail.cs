using System;
using System.Net.Mail;

namespace WebCrawler.DomainModel.Entities
{
    public class Mail
    {
        private UInt32? _mailId;
        private MailAddress _mailAddress;
        private Hash _mailAddressHash;

        public UInt32 MailId
        {
            get
            {
                if(_mailId.HasValue)
                {
                    return _mailId.Value;
                }

                throw new MemberAccessException("MailId is not set");
            }
            set
            {
                _mailId = value;
            }
        }

        public MailAddress MailAddress
        {
            get
            {
                if(null != _mailAddress)
                {
                    return _mailAddress;
                }

                throw new MemberAccessException("MailAddress is not set");
            }
            set
            {
                if(null == value)
                {
                    throw new ArgumentNullException("value", "MailAddress cannot be null");
                }
                _mailAddress = value;
                _mailAddressHash = Hash.Factory.Create(_mailAddress.Address);
            }
        }

        public Hash MailAddressHash
        {
            get
            {
                if(null != _mailAddressHash)
                {
                    return _mailAddressHash;
                }

                throw new MemberAccessException("MailAddress is not set");
            }
        }
    }
}