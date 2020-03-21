using System.Collections.Generic;
using dev7.EMS.BT.Utilities;
using dev7.EMS.Domain.ResultMessages;

namespace dev7.EMS.Model
{
    public abstract class ModelBase
    {
        #region ctor

        protected ModelBase()
        {
            ResultMessages = new List<ResultMessage>();
        }

        #endregion ctor

        #region properties

        public bool HasErrors { get; set; } = false;
        public IList<ResultMessage> ResultMessages { get; set; }
        public int Id { get; set; }
        public string Msg { get; set; }
        public virtual long CreatedById { get; set; } // CreatedById
        public virtual System.DateTime CreatedDate { get; set; } // CreatedDate
        //public virtual long? ModifiedById { get; set; } // ModifiedById
        //public virtual System.DateTime? ModifiedDate { get; set; } // ModifiedDate
        public virtual bool IsActive { get; set; }
        public virtual bool IsValid { get; set; }


        //public long StatusCode { get; set; }

        #endregion properties

        #region methods

        public void AddSuccessMessage(string message)
        {
            AddResultMessage(message, false, ResultCode.Success);
        }

        public T AddSuccessMessage<T>(T model, string message) where T : ModelBase
        {
            return AddResultMessage(model, message, false, ResultCode.Success);
        }

        public void AddWarningMessage(string message)
        {
            AddResultMessage(message, true, ResultCode.Warning);
        }

        public T AddWarningMessage<T>(T model, string message) where T : ModelBase
        {
            return AddResultMessage(model, message, true, ResultCode.Warning);
        }

        public T ClearAllUserMessages<T>(T model) where T : ModelBase
        {
            model.HasErrors = false;
            model.ResultMessages.Clear();
            return model;
        }

        public void AddErrorMessage(string message)
        {
            AddResultMessage(message, true, ResultCode.Danger);
        }

        public T AddErrorMessage<T>(T model, string message) where T : ModelBase
        {
            return AddResultMessage(model, message, true, ResultCode.Danger);
        }

        public void AddUserMessage(string message, bool hasErrors, ResultCode resultCode)
        {
            AddResultMessage(message, hasErrors, resultCode);
        }

        public T AddUserMessage<T>(T model, string message, bool hasErrors, ResultCode resultCode) where T : ModelBase
        {
            return AddResultMessage(model, message, hasErrors, resultCode);
        }

        private static T AddResultMessage<T>(T model, string message, bool hasErrors, ResultCode resultCode) where T : ModelBase
        {
            model.HasErrors = hasErrors;
            model.ResultMessages.Add(new ResultMessage { Message = message, MessageType = resultCode.ToString().ToLowerInvariant() });
            return model;
        }

        private void AddResultMessage(string message, bool hasErrors, ResultCode resultCode)
        {
            HasErrors = hasErrors;
            ResultMessages.Add(new ResultMessage { Message = message, MessageType = resultCode.ToString().ToLowerInvariant() });
        }

        #endregion methods
    }
}
